using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD350TeamHardModeTriviaMaze {

    public class Board {
        
        private Room[,] rooms;
        private Player player;
        private string house;
        private int[,] numberGrid;

        public Board(int rows, int cols, string h) {
            MakeADefaultBoard(rows, cols);
            house = h;
            FillRooms(rows, cols);
        }

        //This one was made for testing purposes
        public Board(int rows, int cols) {
            MakeADefaultBoard(rows, cols);
        }

        public void MakeADefaultBoard(int rows, int cols) {
            numberGrid = new int[rows, cols];
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    numberGrid[r, c] = 1;
                }
            }
        }

        public int[,] GetNumberGrid() {
            return numberGrid;
        }

        public int[,] GetNumberGridCopy() {
            int[,] copy = new int[numberGrid.GetLength(0), numberGrid.GetLength(1)];
            for (int r = 0; r < copy.GetLength(0); r++) {
                for (int c = 0; c < copy.GetLength(1); c++) {
                    copy[r, c] = numberGrid[r, c];
                }
            }
            return copy;
        }

        public void FillRooms(int rows, int cols) {
            rooms = new Room[rows,cols];
            int count = 0;
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    rooms[r, c] = new Room(count, house);
                    count += 1;
                }
            }
        }

        public Room GetRoom(int r, int c) {
            return rooms[r, c];
        }

        public void LoadBoardState(string[,] savedBoard, int rows, int cols) {

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    numberGrid[r, c] = int.Parse(savedBoard[r, c]);
                }
            }
        }
    }
}
