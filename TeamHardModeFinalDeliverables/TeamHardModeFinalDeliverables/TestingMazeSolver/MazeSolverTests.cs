using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecursionMaze;

namespace TestingMazeSolver {
    [TestClass]
    public class MazeSolverTests {
        [TestMethod]
        public void Solvable_Maze1() {
            //Arrange
            int[,] defaultBoard = new int[4, 4];
            RecursiveMaze rcm = new RecursiveMaze(4, 4);

            //Act
            for (int r = 0; r < 4; r++) {
                for (int c = 0; c < 4; c++) {
                    defaultBoard[r, c] = 1;

                }
            }
            //Assert
            Assert.IsTrue(rcm.FindAnEnd(defaultBoard));
        }

        [TestMethod]
        public void Unsolvable_Maze1() {
            //Arrange
            int[,] defaultBoard = new int[4, 4];
            RecursiveMaze rcm = new RecursiveMaze(4, 4);

            //Act
            for (int r = 0; r < 4; r++) {
                for (int c = 0; c < 4; c++) {
                    defaultBoard[r, c] = 0;

                }
            }
            //Assert
            Assert.IsFalse(rcm.FindAnEnd(defaultBoard));
        }
        [TestMethod]
        public void Solvable_Maze2() {
            //Arrange
            int[,] defaultBoard = new int[4, 4] { { 1, 1, 1, 0 }, { 1, 1, 1, 0 }, { 1, 0, 0, 0 }, { 1, 1, 1, 1 } };
            RecursiveMaze rcm = new RecursiveMaze(4, 4);

            //Assert
            Assert.IsTrue(rcm.FindAnEnd(defaultBoard));
        }

        [TestMethod]
        public void Unsolvable_Maze2() {
            //Arrange
            int[,] defaultBoard = new int[4, 4] { { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 1, 0, 1, 0 }, { 1, 1, 1, 0 } };
            RecursiveMaze rcm = new RecursiveMaze(4, 4);

            //Assert
            Assert.IsFalse(rcm.FindAnEnd(defaultBoard));
        }

        [TestMethod]
        public void SolvableMazeWith2sIn() {
            //Arrange
            int[,] defaultBoard = new int[4, 4] { { 2, 2, 2, 2 }, { 0, 2, 2, 0 }, { 2, 0, 2, 2 }, { 2, 0, 0, 2 } };
            RecursiveMaze rcm = new RecursiveMaze(4, 4);

            //Assert
            Assert.IsTrue(rcm.FindAnEnd(defaultBoard));
        }
    }
}
