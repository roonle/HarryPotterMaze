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
using System.Windows.Shapes;
using System.Text.RegularExpressions;



namespace CSCD350TeamHardModeTriviaMaze
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DBWindow : Window
    {
        public DBWindow()
        {
            InitializeComponent();
        }

        private void SubButt_Click(object sender, RoutedEventArgs e)
        {
            SqliteHandler data = new SqliteHandler();



            if (RegexInput(houseText.Text, idText.Text, questionText.Text, answerText.Text))
            {
                data.InsertData(houseText.Text, int.Parse(idText.Text), questionText.Text, answerText.Text);
                idText.Text = "";
                questionText.Text = "";
                answerText.Text = "";
                houseText.Text = "";
            }
        }


        private Boolean RegexInput(string house, string id, string question, string answer)
        {
            string pattern = "^\\d{2,3}$";

            Regex input = new Regex(pattern);

            if (Int32.Parse(id) > 16)
            {
                Console.WriteLine("did it hit id");
                if (input.IsMatch(id))
                {
                    Console.WriteLine("did it hit matchid");
                    if (house == "Gryffindor" || house == "Ravenclaw" || house == "Hufflepuff" || house == "Slytherin")
                    {
                        Console.WriteLine("did it hit the string house");
                        pattern = "^[^/\\()~!@#$%^&*]*$";
                        Regex inputQA = new Regex(pattern);

                        if (inputQA.IsMatch(question) && inputQA.IsMatch(answer))
                        {
                            Console.WriteLine("did it hit here qA");
                            MessageBox.Show("Successfully placed in Database!");
                            return true;
                        }
                    }

                }
            }

            MessageBox.Show("Something went wrong with your inputs, for ID please type in a number greater then 16 that is not more then" +
                "3 decimal long, for houses type uppercase and the name of the house, for the question and answer no special characters are allowed");
            return false;
        }


    }
}