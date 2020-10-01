using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCD350TeamHardModeTriviaMaze;
using System.Data.SQLite;

namespace TestingQuestionClass {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestSlytherinQuestionReturnsString() {
            //Arrange
            string hogwartsHouse = "Slytherin";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string question = connectDb.GetQuestion(hogwartsHouse, questionNumber);

            //Assert
            Assert.AreNotEqual(question, "");
        }

        [TestMethod]
        public void TestHufflepuffQuestionReturnsString() {
            //Arrange
            string hogwartsHouse = "Hufflepuff";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string question = connectDb.GetQuestion(hogwartsHouse, questionNumber);

            //Assert
            Assert.AreNotEqual(question, "");
        }

        [TestMethod]
        public void TestRavenclawQuestionReturnsString() {
            //Arrange
            string hogwartsHouse = "Ravenclaw";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string question = connectDb.GetQuestion(hogwartsHouse, questionNumber);

            //Assert
            Assert.AreNotEqual(question, "");
        }

        [TestMethod]
        public void TestGryffindorQuestionReturnsString() {
            //Arrange
            string hogwartsHouse = "Gryffindor";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string question = connectDb.GetQuestion(hogwartsHouse, questionNumber);

            //Assert
            Assert.AreNotEqual(question, "");
        }

        [TestMethod]
        public void TestSlytherinAnswerReturnsString() {
            //Arrange
            string hogwartsHouse = "Slytherin";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string answer = connectDb.GetAnswer(hogwartsHouse, questionNumber).ToLower();

            //Assert
            Assert.AreNotEqual(answer, "");
        }

        [TestMethod]
        public void TestHufflepuffAnswerReturnsString() {
            //Arrange
            string hogwartsHouse = "Hufflepuff";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string answer = connectDb.GetAnswer(hogwartsHouse, questionNumber).ToLower();

            //Assert
            Assert.AreNotEqual(answer, "");
        }

        [TestMethod]
        public void TestRavenclawAnswerReturnsString() {
            //Arrange
            string hogwartsHouse = "Ravenclaw";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string answer = connectDb.GetAnswer(hogwartsHouse, questionNumber).ToLower();

            //Assert
            Assert.AreNotEqual(answer, "");
        }

        [TestMethod]
        public void TestGryffindorAnswerReturnsString() {
            //Arrange
            string hogwartsHouse = "Gryffindor";
            SqliteHandler connectDb = new SqliteHandler();
            int questionNumber = 1;

            //Act
            string answer = connectDb.GetAnswer(hogwartsHouse, questionNumber).ToLower();

            //Assert
            Assert.AreNotEqual(answer, "");
        }
    }
}
