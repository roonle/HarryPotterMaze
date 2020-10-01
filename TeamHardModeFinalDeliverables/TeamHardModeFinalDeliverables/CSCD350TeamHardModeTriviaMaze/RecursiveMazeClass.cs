using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Coordinates;

namespace RecursionMaze {

    public class RecursiveMaze {

        private int[,] grid;
        private int colsToUse;
        private int rowsToUse;

        public RecursiveMaze(int r, int c) {
            colsToUse = c;
            rowsToUse = r;
            grid = new int[rowsToUse, colsToUse];

        }

        public bool FindAnEnd(int [,] theMaze) {
            bool exit = false;
            exit = RecMaze(0, 0, theMaze);
            return exit;
        }

        //recursive method, accept a y and x value, along with the grid
        public static bool RecMaze(int y, int x, int[,] grid) {
            //simply checks if the end of the maze is a room or a wall and returns false if it is a wall
            if (grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1] == 0) {
                //Console.WriteLine("There is no end to this maze.");
                return false;
            }
            //base case that triggers if at the final room of the maze and the room is a 1
            //if (y == (grid.GetLength(0) - 1) && x == (grid.GetLength(1) - 1) && grid[y, x] == 1)
            if (y == (grid.GetLength(0) - 1) && x == (grid.GetLength(1) - 1) && (grid[y, x] == 1 || grid[y, x] == 2)) {
                grid[y, x] = 7;
                return true;
            }

            //checks if currently passed in coordinates are a room, are within the boundaries of the maze, that the room is not a wall, and has not previously been visited.
            //if (grid[y, x] == 1 && y >= 0 && y < grid.GetLength(0) && x >= 0 && x < grid.GetLength(1) && grid[y, x] != 0 && grid[y, x] != 3)
            if ((grid[y, x] == 1 || grid[y, x] == 2) && y >= 0 && y < grid.GetLength(0) && x >= 0 && x < grid.GetLength(1) && grid[y, x] != 0 && grid[y, x] != 3) {
                //marks the room as visited
                grid[y, x] = 3;
                //go right
                //checks if not at the right most boundary, and if the room to the right isn't a wall or visited. Then moves in.
                if ((x < grid.GetLength(1) - 1) && grid[y, x + 1] != 0 && grid[y, x + 1] != 3) {
                    if (RecMaze(y, x + 1, grid)) {
                        grid[y, x] = 7;
                        return true;
                    }
                    //if the previous method call returns false, then try finding a new path with this method call
                    else {
                        RecMaze(y, x, grid);
                    }
                }
                //go down
                //checks if not at the bottom most boundary, and if the room to the bottom isn't a wall or visited. Then moves in.
                if ((y < grid.GetLength(0) - 1) && grid[y + 1, x] != 0 && grid[y + 1, x] != 3) {
                    if (RecMaze(y + 1, x, grid)) {
                        grid[y, x] = 7;
                        return true;
                    }
                    //if the previous method call returns false, then try finding a new path with this method call
                    else {
                        RecMaze(y, x, grid);
                    }
                }
                //go left
                //checks if not at the left most boundary, and if the room to the left isn't a wall or visited. Then moves in.
                if ((x < grid.GetLength(1)) && x > 0 && grid[y, x - 1] != 0 && grid[y, x - 1] != 3) {
                    if (RecMaze(y, x - 1, grid)) {
                        //grid[y][x] = 7;
                        grid[y, x] = 7;
                        return true;
                    }

                    //if the previous method call returns false, then try finding a new path with this method call
                    else {
                        RecMaze(y, x, grid);
                    }
                }
                //go up
                //checks if not at the upper most boundary, and if the room above isn't a wall or visited. Then moves in.
                if ((y < grid.GetLength(0)) && y > 0 && grid[y - 1, x] != 0 && grid[y - 1, x] != 3) {
                    if (RecMaze(y - 1, x, grid)) {
                        grid[y, x] = 7;
                        return true;
                    }
                    //if the previous method call returns false, then try finding a new path with this method call
                    else {
                        RecMaze(y, x, grid);
                    }
                }

            }

            else {
                return false;
            }

            return false;
        }//end recMaze method

        //added 12/6
        public void PrintTheMaze(int[,] theMaze) {
            for (int r = 0; r < theMaze.GetLength(0); r++) {
                for (int c = 0; c < theMaze.GetLength(1); c++) {
                    Console.Write(theMaze[r, c] + ",");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine();

        }

    }//end class
}
