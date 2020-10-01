using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Coordinates;

namespace RecursionMaze
{
    
        public class RecursiveMaze
        {
        /**
 * 
 */

        /**
         * @author Calum
         *
         */
        //public class MazeTester
        //{

        /**
         * 
         */
        /* public MazeTester()
         {

         }*/

        /*public static void Main(String[] args)
        {
            //small maze, and no path to exit test
            *//*
            int[][] grid1 =
                { 
                {1,1,1,0,1},
                {1,0,1,1,0},
                {0,0,0,0,1}
                };
            *//*

            //test move left and up
            *//*
             int[][] grid2 =
                { 
                {1,1,1,0,1,1,1},
                {1,0,1,1,1,0,1},
                {0,0,0,0,0,1,1},
                {1,1,1,0,1,1,1},
                {1,0,1,1,1,1,1},
                {1,0,0,0,0,0,0},
                {1,1,1,1,1,1,1}
                };
             *//*
            //int[][] grid =
            *//*int[,] grid =
                   {
                    {1,1,1,0,1,1,0,0,0,1,1,1,1},
                    {1,0,1,1,1,0,1,1,1,1,0,0,1},
                    {0,0,0,0,1,0,1,0,1,0,1,0,0},
                    {1,1,1,0,1,1,1,0,1,0,1,1,1},
                    {1,0,1,0,0,0,0,1,1,1,0,0,1},
                    {1,0,1,1,1,1,1,1,0,1,1,1,1},
                    {1,0,0,0,0,0,0,0,0,0,0,0,0},
                    {1,1,1,1,1,1,1,1,1,1,1,1,1}
                    };*//*

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Environment.NewLine + $"Attempting Maze number: {i}");
                int[,] grid = MakeAMaze(rowsToUse, colsToUse);
                RunTheMaze(grid);
            }
            //int[,] grid = MakeAMaze(rowsToUse, colsToUse);
            *//*
                        //method call, passes in origin and the grid
                        Boolean answer = RecMaze(0, 0, grid);
                        //System.out.println(answer);
                        //if statement for if the program reaches end and doesen't find a path to exit
                        //if (answer == false && (grid[grid.Length - 1][grid[0].Length - 1] == 1))
                        if(answer == false && (grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1] == 1))
                        {
                            Console.WriteLine("There was no path to exit the maze.");
                        }
                        else if (answer == true)
                        {
                            Console.WriteLine("Rejoice!, there is an escape.");
                        }
                        //for loop that prints out the maze
                        for (int y = 0; y < grid.GetLength(0); y++)
                        {
                            Console.Write("{");
                            //for (int x = 0; x < (grid[0].Length); x++)
                            for (int x = 0; x < (grid.GetLength(1)); x++)
                            {
                                //if (x < (grid[0].Length - 1))
                                if (x < (grid.GetLength(1) - 1))
                                {
                                    //Console.WriteLine(grid[y][x] + ", ");
                                    Console.Write(grid[y,x] + ", ");
                                }
                                else
                                {
                                    //Console.WriteLine(grid[y][x]);
                                    Console.Write(grid[y,x]);
                                }
                            }
                            Console.WriteLine("} \n");
                        }*//*

        }//end main*/
                           /*public RecursiveMaze()
                           {
                           int[,] grid = MakeAMaze(rowsToUse, colsToUse);
                           }*/
                           //private int[,] theMainGrid;
        private int[,] grid;
        private int colsToUse;
        private int rowsToUse;
        public RecursiveMaze(int r, int c)
        {
            //theMainGrid = new int[rowsToUse, colsToUse];
            colsToUse = c;
            rowsToUse = r;
            grid = new int[rowsToUse, colsToUse];
                
        }

        //public List<Coordinate> GetTheUsablePath(List<Coordinate> usablePath)
        public List<Coordinate> GetTheUsablePath()
        {
            /*for(int r = 0; r < theMainGrid.GetLength(0); r++)
            {
                for(int c = 0; c < theMainGrid.GetLength(1); c++)
                {
                    if(theMainGrid[r,c] == 7)
                    {
                        Coordinate nc = new Coordinate(r, c);
                        usablePath.Add(nc);
                    }
                }
            }*/
            List<Coordinate> usablePath = new List<Coordinate>();
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r, c] == 3 || grid[r,c] == 7)
                    {
                        Coordinate nc = new Coordinate(r, c);
                        usablePath.Add(nc);
                    }
                }
            }
            return usablePath;
        }
        //public static int[,] RunTheMaze(int[,] grid)
        public int[,] RunTheMaze()
        {
        //bool isWinnable = false;
        /*for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Environment.NewLine + $"Attempting Maze number: {i}");
            int[,] grid = MakeAMaze(rowsToUse, colsToUse);
            RunTheMaze(grid);
        }*/
        int[,] numberGrid = new int[rowsToUse, colsToUse];
        bool answer = false;
            do
            {
            grid = MakeAMaze(rowsToUse, colsToUse);
            //numberGrid = MakeAMaze(rowsToUse, colsToUse);
            numberGrid = CopyTheGrid(grid);

            
                //method call, passes in origin and the grid
                //Boolean answer = RecMaze(0, 0, grid);
                answer = RecMaze(0, 0, grid);
            //System.out.println(answer);
            //if statement for if the program reaches end and doesen't find a path to exit
            //if (answer == false && (grid[grid.Length - 1][grid[0].Length - 1] == 1))
            /*if (answer == false && (grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1] == 1))
            {
                //Console.WriteLine("There was no path to exit the maze.");
            }*/
            //else if (answer == true)
                if (answer == true)
                {
                //Console.WriteLine("Rejoice!, there is an escape.");
                return numberGrid;
                        
                }
                /*//for loop that prints out the maze
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    Console.Write("{");
                    //for (int x = 0; x < (grid[0].Length); x++)
                    for (int x = 0; x < (grid.GetLength(1)); x++)
                    {
                        //if (x < (grid[0].Length - 1))
                        if (x < (grid.GetLength(1) - 1))
                        {
                            //Console.WriteLine(grid[y][x] + ", ");
                            Console.Write(grid[y, x] + ", ");
                        }
                        else
                        {
                            //Console.WriteLine(grid[y][x]);
                            Console.Write(grid[y, x]);
                        }
                    }
                    Console.WriteLine("} \n");
                }*/
                //grid = null;


            } while(answer == false);

        return numberGrid;
        }

        private static int[,] CopyTheGrid(int[,] grid)
        {
            int[,] theCopy = new int[grid.GetLength(0),grid.GetLength(1)];
            for(int r = 0; r < grid.GetLength(0); r++)
            {
                for(int c = 0; c < grid.GetLength(1); c++)
                {
                    theCopy[r, c] = grid[r, c];
                }
            }
            return theCopy;
        }

        //recursive method, accept a y and x value, along with the grid
        public static bool RecMaze(int y, int x, int[,] grid)
            {
                //simply checks if the end of the maze is a room or a wall and returns false if it is a wall
                //if (grid[grid.Length - 1][grid[0].Length - 1] == 0)
                if (grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1] == 0)
                {
                    //Console.WriteLine("There is no end to this maze.");
                    return false;
                }
                //base case that triggers if at the final room of the maze and the room is a 1
                //if (y == (grid.Length - 1) && x == (grid[0].Length - 1) && grid[y][x] == 1)
                if (y == (grid.GetLength(0) - 1) && x == (grid.GetLength(1) - 1) && grid[y, x] == 1)
                {
                    //grid[y][x] = 7;
                    grid[y, x] = 7;
                    return true;
                }

                //checks if currently passed in coordinates are a room, are within the boundaries of the maze, that the room is not a wall, and has not previously been visited.
                //if (grid[y][x] == 1 && y >= 0 && y < grid.Length && x >= 0 && x < grid[0].Length && grid[y][x] != 0 && grid[y][x] != 3)
                if (grid[y, x] == 1 && y >= 0 && y < grid.GetLength(0) && x >= 0 && x < grid.GetLength(1) && grid[y, x] != 0 && grid[y, x] != 3)
                {
                    //marks the room as visited
                    //grid[y][x] = 3;
                    grid[y, x] = 3;
                    //go right
                    //checks if not at the right most boundary, and if the room to the right isn't a wall or visited. Then moves in.
                    //if ((x < grid[0].Length - 1) && grid[y][x + 1] != 0 && grid[y][x + 1] != 3)
                    if ((x < grid.GetLength(1) - 1) && grid[y, x + 1] != 0 && grid[y, x + 1] != 3)
                    {
                        if (RecMaze(y, x + 1, grid))
                        {
                            //grid[y][x] = 7;
                            grid[y, x] = 7;
                            return true;
                        }
                        //if the previous method call returns false, then try finding a new path with this method call
                        else
                        {
                            RecMaze(y, x, grid);
                        }
                    }
                    //go down
                    //checks if not at the bottom most boundary, and if the room to the bottom isn't a wall or visited. Then moves in.
                    //if ((y < grid.Length - 1) && grid[y + 1][x] != 0 && grid[y + 1][x] != 3)
                    if ((y < grid.GetLength(0) - 1) && grid[y + 1, x] != 0 && grid[y + 1, x] != 3)
                    {
                        if (RecMaze(y + 1, x, grid))
                        {
                            //grid[y][x] = 7;
                            grid[y, x] = 7;
                            return true;
                        }
                        //if the previous method call returns false, then try finding a new path with this method call
                        else
                        {
                            RecMaze(y, x, grid);
                        }
                    }
                    //go left
                    //checks if not at the left most boundary, and if the room to the left isn't a wall or visited. Then moves in.
                    //if ((x < grid[0].Length) && x > 0 && grid[y][x - 1] != 0 && grid[y][x - 1] != 3)
                    if ((x < grid.GetLength(1)) && x > 0 && grid[y, x - 1] != 0 && grid[y, x - 1] != 3)
                    {
                        if (RecMaze(y, x - 1, grid))
                        {
                            //grid[y][x] = 7;
                            grid[y, x] = 7;
                            return true;
                        }

                        //if the previous method call returns false, then try finding a new path with this method call
                        else
                        {
                            RecMaze(y, x, grid);
                        }
                    }
                    //go up
                    //checks if not at the upper most boundary, and if the room above isn't a wall or visited. Then moves in.
                    //if ((y < grid.Length) && y > 0 && grid[y - 1][x] != 0 && grid[y - 1][x] != 3)
                    if ((y < grid.GetLength(0)) && y > 0 && grid[y - 1, x] != 0 && grid[y - 1, x] != 3)
                    {
                        if (RecMaze(y - 1, x, grid))
                        {
                            //grid[y][x] = 7;
                            grid[y, x] = 7;
                            return true;
                        }
                        //if the previous method call returns false, then try finding a new path with this method call
                        else
                        {
                            RecMaze(y, x, grid);
                        }
                    }

                }

                else
                {
                    return false;
                }

                return false;
                //}//end recMaze method

                //}//end class

            }//end recMaze method
            public static int[,] MakeAMaze(int rows, int cols)
            {
                int[,] theGrid = new int[rows, cols];
                int pathVal = 0;
                Random rand = new Random();
                for (int r = 0; r < rows; r++)
                {

                    for (int c = 0; c < cols; c++)
                    {
                        if ((r == 0 && c == 0) || (r >= (theGrid.GetLength(0) - 3) && c >= (theGrid.GetLength(1) - 3)))
                        {
                            theGrid[r, c] = 1;
                        }
                        else
                        {
                            pathVal = MetAPathValue(rand);
                            theGrid[r, c] = pathVal;
                        }
                    }
                }
                return theGrid;

            }

            public static int MetAPathValue(Random rand)
            {
                int val = 0;
                val = rand.Next(101);
                if (val <= 45)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
                //return val;
            }
        }//end class
    //}//end namespace

}
