using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCD350TeamHardModeTriviaMaze;
using System.Windows;

namespace TestingStringTo2DArray {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void String1ShouldBeEqual() {

            //Arrange
            string singleString = "1001220002001111";
            string[,] stringsIn2d = {
                { "1", "0", "0", "1" },
                { "2", "2", "0", "0" },
                { "0", "2", "0", "0" },
                { "1", "1", "1", "1" }
            };
            string[,] convertedString;
            bool areEqual = true;

            //Act
            convertedString = MainWindow.ConvertSingleStringTo2DString(singleString);
            for (int r = 0; r < 4; r++) {
                for (int c = 0; c < 4; c++) {
                    if (!(convertedString[r, c].Equals(stringsIn2d[r, c]))) {
                        areEqual = false;
                    }
                }
            }

            //Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void String2ShouldNotBeEqual() {

            //Arrange
            string singleString = "1101220102001121";
            string[,] stringsIn2d = {
                { "1", "0", "0", "1" },
                { "2", "2", "0", "0" },
                { "0", "2", "0", "0" },
                { "1", "1", "1", "1" }
            };
            string[,] convertedString;
            bool areEqual = true;

            //Act
            convertedString = MainWindow.ConvertSingleStringTo2DString(singleString);
            for (int r = 0; r < 4; r++) {
                for (int c = 0; c < 4; c++) {
                    if (!(convertedString[r, c].Equals(stringsIn2d[r, c]))) {
                        areEqual = false;
                    }
                }
            }

            //Assert
            Assert.IsFalse(areEqual);
        }
    }
}
