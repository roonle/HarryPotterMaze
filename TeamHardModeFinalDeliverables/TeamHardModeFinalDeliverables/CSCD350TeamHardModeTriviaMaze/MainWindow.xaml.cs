using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Coordinates;
using RecursionMaze;

namespace CSCD350TeamHardModeTriviaMaze {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private DBWindow dbWindow;

        //Rectangles
        private Rectangle[,] boardRectangles;
        private Rectangle[,] boardLinesHorizontal;
        private Rectangle[,] boardLinesVertical;

        //Constants
        #region Constants
        private const int howManyRows = 4;
        private const int howManyColumns = 4;
        private const int heightOfRectangles = 40;
        private const int widthOfRectangles = 40;
        private const int gapBetweenRectangles = 20;
        private const int lineThickness = 5;
        #endregion

        private Coordinate currentPos;
        private Coordinate previousPos;
        private Board gameBoard;
        private MediaPlayer mp = new MediaPlayer();
        private Player thePlayer;
        private SqliteHandler database = new SqliteHandler();

        public MainWindow() {
            InitializeComponent();
            mnuSave.IsEnabled = false;
            database.SetupDatabase();
            PlayHPThemeSong();
        }
        
        public void StartSettingThingsUp() {
            LoadABackgroundImage();
            InitializeGameBoard();
            MakeRectangleBoard();
            InitializeCoordinates();
            InitializePlayer();
            ChangeColorsToMatchPlayer();
            UpdateInstructions();
            InitializeFirstRoom();
        }
        
        //Places goals of game into the first rooms question box
        private void InitializeFirstRoom() {
            Room currRoom = gameBoard.GetRoom(currentPos.Row, currentPos.Column);
            if (currRoom.GetRoomNumber() == 0) {
                ChangeQuestionBox();
            }
        }

        private void PlayHPThemeSong() {
            mp.Open(new Uri("../../HPThemeSong.mp3", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlayGryffindorYell() {
            mp.Open(new Uri("../../gryffindor.wav", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlayHufflepuffYell() {
            mp.Open(new Uri("../../hufflepuff.wav", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlaySlytherinYell() {
            mp.Open(new Uri("../../slytherin.wav", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlayRavenclawYell() {
            mp.Open(new Uri("../../ravenclaw.wav", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlayCorrect() {
            mp.Open(new Uri("../../correct.mp3", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlayIncorrect() {
            mp.Open(new Uri("../../wrong.mp3", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlayWin() {
            mp.Open(new Uri("../../winner.mp3", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void PlayLose() {
            mp.Open(new Uri("../../loser.mp3", UriKind.RelativeOrAbsolute));
            mp.Play();
        }

        private void StopMusic() {
            mp.Stop();
        }

        private void MakeRectangleBoard() {
            //amountOfLines is how many lines there should be. Only works atm with an [n * n] grid. Wont work with e.g [n * r]
            int amountOfLines = howManyColumns - 1;

            //Instiate the 2d arrays
            boardRectangles = new Rectangle[howManyRows, howManyColumns];
            boardLinesHorizontal = new Rectangle[howManyRows, howManyColumns];
            boardLinesVertical = new Rectangle[howManyRows, howManyColumns];

            //For loop to walk through and create Rectangles for the game board. The "lines" are just thin rectangles.
            for (int r = 0; r < howManyRows; r++) {
                for (int c = 0; c < howManyColumns; c++) {

                    //Affects the rectangles
                    boardRectangles[r, c] = new Rectangle();
                    boardRectangles[r, c].SetValue(Canvas.LeftProperty, (double)c * (widthOfRectangles + gapBetweenRectangles));
                    boardRectangles[r, c].SetValue(Canvas.TopProperty, (double)r * (heightOfRectangles + gapBetweenRectangles));
                    boardRectangles[r, c].Width = widthOfRectangles;
                    boardRectangles[r, c].Height = heightOfRectangles;
                    boardRectangles[r, c].Fill = thePlayer.GetHouse().GetGridBackColor();
                    cnvBoardCanvas.Children.Add(boardRectangles[r, c]);

                    //Affects the Lines
                    if (c < amountOfLines) {
                        //Horizontal lines
                        boardLinesHorizontal[r, c] = new Rectangle();
                        boardLinesHorizontal[r, c].SetValue(Canvas.LeftProperty, ((double)c * (widthOfRectangles + gapBetweenRectangles)) + widthOfRectangles);
                        boardLinesHorizontal[r, c].SetValue(Canvas.TopProperty, ((double)r * (heightOfRectangles + gapBetweenRectangles)) + (heightOfRectangles / 2) - (lineThickness / 2));
                        boardLinesHorizontal[r, c].Width = widthOfRectangles;
                        boardLinesHorizontal[r, c].Height = lineThickness;
                        boardLinesHorizontal[r, c].Fill = thePlayer.GetHouse().GetLineColor();
                        cnvBoardCanvas.Children.Add(boardLinesHorizontal[r, c]);
                    }
                    if (r < amountOfLines) {
                        //Vertical lines
                        boardLinesVertical[r, c] = new Rectangle();
                        boardLinesVertical[r, c].SetValue(Canvas.LeftProperty, ((double)c * (widthOfRectangles + gapBetweenRectangles)) + (widthOfRectangles / 2) - (lineThickness / 2));
                        boardLinesVertical[r, c].SetValue(Canvas.TopProperty, ((double)r * (heightOfRectangles + gapBetweenRectangles)) + heightOfRectangles);
                        boardLinesVertical[r, c].Width = lineThickness;
                        boardLinesVertical[r, c].Height = gapBetweenRectangles;
                        boardLinesVertical[r, c].Fill = thePlayer.GetHouse().GetLineColor();
                        cnvBoardCanvas.Children.Add(boardLinesVertical[r, c]);
                    }
                }
            }
            FillTheEnd();
          
        }

        private void InitializeGameBoard() {
            gameBoard = new Board(howManyRows, howManyColumns, thePlayer.GetHouse().GetHouseName());
            mnuSave.IsEnabled = true;
        }

        public void InitializePlayer() {        
            boardRectangles[currentPos.Row, currentPos.Column].Fill = thePlayer.GetHouse().GetPlayerColor();
        }

        public void InitializeCoordinates() {
            currentPos = new Coordinate();
            previousPos = new Coordinate();
        }

        //creates new program
        private void MnuFileNew_Click(object sender, RoutedEventArgs e) {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }

        private void MnuExit_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Goodbye");
            Environment.Exit(0);
        }

        private void MnuFileDBWindow_Click(object sender, RoutedEventArgs e) {
            this.dbWindow = new DBWindow();
            this.dbWindow.ShowDialog();
        }

        //This method is when a user clicks the submit button for their answer
        private void BtnSubmit_Click(object sender, RoutedEventArgs e) {
            //Recieve answer from click, converts to lowercase
            String answer = (txtbxAnswerBox.Text).ToLower();
            
            //compare answer to check with question class
            Room currRoom = gameBoard.GetRoom(currentPos.Row, currentPos.Column);
            Question q = currRoom.GetQuestion();
            if (q.CheckAnswer(answer)) {
                PlayCorrect();
                currRoom.Unlock();
                currRoom.WasAttempted();
                MessageBox.Show("Correct!");
                gameBoard.GetNumberGrid()[currentPos.Row, currentPos.Column] = 2;

                if(currentPos.Row == 3 && currentPos.Column == 3) {
                    PlayWin();
                    MessageBox.Show("YOU'RE A WIZARD! WINNER!");
                }

            } else {
                PlayIncorrect();
                MessageBox.Show("Incorrect!");
                gameBoard.GetNumberGrid()[currentPos.Row, currentPos.Column] = 0;
                currRoom.WasAttempted();

                //bounce user back into previous room
                Coordinate temp = new Coordinate(currentPos.Row, currentPos.Column);
                currentPos.Row = previousPos.Row;
                currentPos.Column = previousPos.Column;
                ColorTheGrid();
                //boardRectangles[temp.Row, temp.Column].Fill = thePlayer.GetHouse().GetPathColor();
                boardRectangles[temp.Row, temp.Column].Fill = new SolidColorBrush(Colors.Black);
            }
            if (IsMazeSolvable() == false) {
                PlayLose();
                MessageBox.Show("Maze is unsolvable! You lose!");
            }
            EnableMoveButtons();
        }

        //This method is the basic example of how to change the text in the question box
        private void ChangeQuestionBox() {
            //Question q = new Question();
            Room currRoom = gameBoard.GetRoom(currentPos.Row, currentPos.Column);
            String question = currRoom.GetQuestion().GetQuestion();
            txtbxQuestionBox.Text = question;

            //This will probably call the same method from far above
            if (currRoom.GetRoomNumber() != 0) {
                DisableMoveButtons();
            } 
        }

        #region House Selection Buttons
        private void BtnHouseGryffindor_Click(object sender, RoutedEventArgs e) {
            StopMusic();
            PlayGryffindorYell();
            thePlayer = new Player(new HouseGryffindor());
            DisableHouseSelectionGrid();
            StartSettingThingsUp();
        }

        private void BtnHouseRavenclaw_Click(object sender, RoutedEventArgs e) {
            StopMusic();
            PlayRavenclawYell();
            thePlayer = new Player(new HouseRavenclaw());
            DisableHouseSelectionGrid();
            StartSettingThingsUp();
        }

        private void BtnHouseSlytherin_Click(object sender, RoutedEventArgs e) {
            StopMusic();
            PlaySlytherinYell();
            thePlayer = new Player(new HouseSlytherin());
            DisableHouseSelectionGrid();
            StartSettingThingsUp();
        }

        private void BtnHouseHufflepuff_Click(object sender, RoutedEventArgs e) {
            StopMusic();
            PlayHufflepuffYell();
            thePlayer = new Player(new HouseHufflepuff());
            DisableHouseSelectionGrid();
            StartSettingThingsUp();
        }

        private void DisableHouseSelectionGrid() {
            grdChooseHousesGrid.Children.Clear();
            //grdChooseHousesGrid.IsEnabled = false;
            grdMainGrid.Children.Remove(grdChooseHousesGrid);
            
        }
        #endregion

        private void LoadABackgroundImage() {
            string imgSource = (thePlayer.GetHouse().GetHouseName() +"TopLeft" + @".jpg");
            Image character = new Image();
            character.Width = 1080;
            character.Height = 720;
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri(imgSource, UriKind.Relative);
            bmi.CacheOption = BitmapCacheOption.OnLoad;
            bmi.EndInit();
            character.Source = bmi;
            cnvBackgroundImage.Children.Add(character);
        }

        private void TryMoving(string direction) {
            previousPos.Row = currentPos.Row;
            previousPos.Column = currentPos.Column;
            bool moved = false;

            if (direction.Equals("down")) {
                if (currentPos.Row < boardRectangles.GetLength(0) - 1) {
                    currentPos.Row += 1;
                    if (ValidMove()) {
                        moved = true;
                    } else {
                        currentPos.Row -= 1;
                    }
                }
            } else if (direction.Equals("up")) {
                if (currentPos.Row > 0) {
                    currentPos.Row -= 1;
                    if (ValidMove()) {
                        moved = true;
                    } else {
                        currentPos.Row += 1;
                    }                 
                }
            } else if (direction.Equals("right")) {
                if (currentPos.Column < boardRectangles.GetLength(1) - 1) {
                    currentPos.Column += 1;
                    if (ValidMove()) {
                        moved = true;
                    } else {
                        currentPos.Column -= 1;
                    } 
                }
            } else if (direction.Equals("left")) {
                if (currentPos.Column > 0) {
                    currentPos.Column -= 1;
                    if (ValidMove()) {
                        moved = true;
                    } else {
                        currentPos.Column += 1;
                    }
                }
            }

            if (moved == true) {
                Room currRoom = gameBoard.GetRoom(currentPos.Row, currentPos.Column);
                
                //Question prompted
                if (currRoom.IsLocked() && !currRoom.IsAttempted()) {
                    ChangeQuestionBox();
                } 

                //Room is unlocked. Colors of maze updates.
                ColorTheGrid();
            }
        }

        private Boolean IsMazeSolvable() {
            RecursiveMaze rcm = new RecursiveMaze(howManyRows, howManyColumns);
            bool solvable = rcm.FindAnEnd(gameBoard.GetNumberGridCopy());
            return solvable;
        }

        private void ColorTheGrid() {
            boardRectangles[previousPos.Row, previousPos.Column].Fill = thePlayer.GetHouse().GetPathColor();
            boardRectangles[currentPos.Row, currentPos.Column].Fill = thePlayer.GetHouse().GetPlayerColor();
        }

        private void BtnMoveUp_Click(object sender, RoutedEventArgs e) {
            string direction = "up";
            TryMoving(direction);
        }

        private void BtnMoveDown_Click(object sender, RoutedEventArgs e) {
            string direction = "down";
            TryMoving(direction);
        }

        private void BtnMoveRight_Click(object sender, RoutedEventArgs e) {
            string direction = "right";
            TryMoving(direction);
        }

        private void BtnMoveLeft_Click(object sender, RoutedEventArgs e) {
            string direction = "left";
            TryMoving(direction);
        }

        private void DisableMoveButtons() {
            btnMoveDown.IsEnabled = false;
            btnMoveLeft.IsEnabled = false;
            btnMoveRight.IsEnabled = false;
            btnMoveUp.IsEnabled = false;
        }

        private void EnableMoveButtons() {
            btnMoveDown.IsEnabled = true;
            btnMoveLeft.IsEnabled = true;
            btnMoveRight.IsEnabled = true;
            btnMoveUp.IsEnabled = true; ;
        }

        private Boolean ValidMove() {
            Room currRoom = gameBoard.GetRoom(currentPos.Row, currentPos.Column);
            if (currRoom.IsLocked() && !currRoom.IsAttempted() || !currRoom.IsLocked() && currRoom.IsAttempted() || currRoom.GetRoomNumber() == 0) {
                return true;
            }
            return false;
        }

        //Added UI stuff
        private void ChangeColorsToMatchPlayer() {
            ChangeQuestionGradient();
            ChangeQuestionTextColor();
            ChangeGridChoicesColor();
        }

        private void ChangeQuestionGradient() {
            LinearGradientBrush lbrush = new LinearGradientBrush(thePlayer.GetHouse().GetPlayerColor().Color, Colors.Black, 90.0);
            txtbxQuestionBox.Background = lbrush;
        }

        private void ChangeQuestionTextColor() {
            txtbxQuestionBox.Foreground = new SolidColorBrush(Colors.White);
        }

        private void ChangeGridChoicesColor() {
            LinearGradientBrush bGrad = new LinearGradientBrush(Colors.Gray, Colors.Black, 90.0);
            grdChoices.Background = bGrad;
        }

        private void UpdateInstructions() {
            ChangeQuestionInstructionsText();
            ChangeTipsText();
        }

        private void ChangeQuestionInstructionsText() {
            string nuText = "Instruction for Answers:*"
                + "*For True or False enter 'True' or 'False'.* "
                + "*For Multiple Choice enter 'A', 'B', 'C', or 'D'.* "
                + "*For Short Answers Enter the full word(s).*"
                + "*You can use 'Delete' key to clear answers.*";

            txtblkQuestionInstructions.Text = nuText.Replace("*", System.Environment.NewLine);
            txtblkQuestionInstructions.Foreground = new SolidColorBrush(Colors.Goldenrod);
        }

        private void ChangeTipsText() {
            string nuText = "Tips:*"
                + "*''Clear' removes text quickly* ";

            txtblkTips.Text = nuText.Replace("*", System.Environment.NewLine);
            txtblkTips.Foreground = new SolidColorBrush(Colors.Goldenrod);
        }

        private void RemoveTextInAnswerBox() {
            txtbxAnswerBox.Text = "";
        }

        private void BtnClearAnswer_Click(object sender, RoutedEventArgs e) {
            RemoveTextInAnswerBox();
        }

        //This method should be called if there is a save on the database not sure if theres a way to check, otherwise only let the user load after theyve clicked save.
        private void LoadAGame(string boardStateFullString, string playersPosition, string houseName) {
                      
            string[,] boardState = ConvertSingleStringTo2DString(boardStateFullString);

            //Starting from here will continue like normal based on what values were received from database above

            //updates player
            thePlayer = new Player(houseName);

            LoadABackgroundImage();

            //Updates player position
            InitializeCoordinates();
            playersPosition = playersPosition.Replace("(", "");
            playersPosition = playersPosition.Replace(")", "");
            string[] parsePlayerPos = playersPosition.Split(',');
            currentPos = new Coordinate(int.Parse(parsePlayerPos[0]), int.Parse(parsePlayerPos[1]));

            //Updates board state
            InitializeGameBoard();
            gameBoard.LoadBoardState(boardState, howManyRows, howManyColumns);
            MakeRectangleBoard();
            LoadRoomStates();

            if(database.GetBoardHouse() == "Gryffindor") {
                StopMusic();
                PlayGryffindorYell();
                thePlayer = new Player(new HouseGryffindor());
            } else if (database.GetBoardHouse() == "Slytherin") {
                StopMusic();
                PlayGryffindorYell();
                thePlayer = new Player(new HouseSlytherin());
            } else if (database.GetBoardHouse() == "Ravenclaw") {
                StopMusic();
                PlayRavenclawYell();
                thePlayer = new Player(new HouseRavenclaw());
            } else if (database.GetBoardHouse() == "Hufflepuff") {
                StopMusic();
                PlayHufflepuffYell();
                thePlayer = new Player(new HouseHufflepuff());
            }

            DisableHouseSelectionGrid();
            ChangeColorsToMatchPlayer();
            UpdateInstructions();
            //Fills players saved position
            InitializePlayer();
            //Triggers to fill in the beginning if the player is somewhere not at at the start
            if(currentPos.Row != 0 || currentPos.Column != 0) {
                FillTheBeginning();
            }
        }

        public static string[,] ConvertSingleStringTo2DString(string boardStateFullString) {
            string[,] fullBoard = new string[howManyRows, howManyColumns];
            int fullStringIndex = 0;
            for (int r = 0; r < howManyRows; r++) {
                for (int c = 0; c < howManyColumns; c++) {
                    fullBoard[r, c] = boardStateFullString[fullStringIndex] + "";
                    fullStringIndex++;
                }
            }
            return fullBoard;
        }
        private void LoadRoomStates() {
            ColorAtCoordinate(0, 0, thePlayer.GetHouse().GetPathColor());
            for (int r = 0; r < howManyRows; r++) {
                for (int c = 0; c < howManyColumns; c++) {
                    //2 means the user previously solved the room
                    if (gameBoard.GetNumberGrid()[r, c] == 2) {
                        gameBoard.GetRoom(r, c).WasAttempted();
                        gameBoard.GetRoom(r, c).Unlock();
                        ColorAtCoordinate(r, c, thePlayer.GetHouse().GetPathColor());
                    }
                    //0 means the room is gone/disabled
                    else if (gameBoard.GetNumberGrid()[r, c] == 0) {
                        gameBoard.GetRoom(r, c).WasAttempted();
                        ColorAtCoordinate(r, c, new SolidColorBrush(Colors.Black));
                    }
                    
                }
            }
        }

        private void ColorAtCoordinate(int row, int col, SolidColorBrush br) {
            boardRectangles[row, col].Fill = br;
        }

        private void MnuLoad_Click(object sender, RoutedEventArgs e) {
            database.LoadSaveData();
            if (database.GetBoardSave() == " ") {
                MessageBox.Show("You must save a game first");
            } else {
                LoadAGame(database.GetBoardSave(), database.GetBoardPosition(), database.GetBoardHouse());
            }
        }

        private void MnuSave_Click(object sender, RoutedEventArgs e) {
            string row = currentPos.Row.ToString();
            string col = currentPos.Column.ToString();
            string boardPosition = "(" + row + "," + col + ")";
            string boardSaveData = "";
            for (int r = 0; r < howManyRows; r++) {
                for (int c = 0; c < howManyColumns; c++) {
                    boardSaveData += gameBoard.GetNumberGrid()[r, c].ToString();
                }
            }
            database.InsertSaveData(1, boardSaveData, boardPosition, thePlayer.GetHouse().GetHouseName());
        }

        private void FillTheBeginning() {
            ColorAtCoordinate(0, 0, thePlayer.GetHouse().GetPathColor());
        }

        private void FillTheEnd() {
            ColorAtCoordinate(howManyRows - 1, howManyColumns - 1, new SolidColorBrush(Colors.Purple));
        }
    }//End MainWindow
}
