using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCD350TeamHardModeTriviaMaze;

namespace TestingBoardClass {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestIfLoadBoardStateParsesStringCorrectly() {

            //Arrange
            int[,] boardOfInts = {
                { 1, 0, 1, 1 },
                { 2, 0, 1, 1 },
                { 2, 2, 0, 1 },
                { 1, 1, 1, 1 }
            };
            string [,] boardOfStrings = {
                { "1", "0", "1", "1" },
                { "2", "0", "1", "1" },
                { "2", "2", "0", "1" },
                { "1", "1", "1", "1" }
            };

            Board board4x4 = new Board(4,4);

            bool areEquals = true;

            //Act     
            board4x4.LoadBoardState(boardOfStrings, 4, 4);

            for (int r = 0; r < 4; r++) {
                for (int c = 0; c < 4; c++) {
                    if(board4x4.GetNumberGrid()[r,c] != boardOfInts[r, c]) {
                        areEquals = false;
                        return;
                    }

                }
            }



            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void TestMakeADefautlBoard() {

            //Arrange
            int[,] boardOfInts = {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 }
            };
  
            Board board4x4 = new Board(4, 4);

            bool areEquals = true;

            //Act
            for (int r = 0; r < 4; r++) {
                for (int c = 0; c < 4; c++) {
                    if (board4x4.GetNumberGrid()[r, c] != boardOfInts[r, c]) {
                        areEquals = false;
                        return;
                    }

                }
            }


            //Assert
            Assert.IsTrue(areEquals);
        }
    }
}
