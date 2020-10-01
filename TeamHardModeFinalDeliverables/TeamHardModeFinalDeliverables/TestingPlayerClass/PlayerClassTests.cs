using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCD350TeamHardModeTriviaMaze;

namespace TestingPlayerClass {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void DoesPlayerBecomeRavenclaw() {

            //Arrange
            Player ravenPlayer;
            string expectedHouse = "Ravenclaw";

            //Act     
            ravenPlayer = new Player("Ravenclaw");

            //Assert
            Assert.AreEqual(expectedHouse, ravenPlayer.GetHouse().GetHouseName());
        }

        [TestMethod]
        public void DoesPlayerBecomeGryffindor() {

            //Arrange
            Player griffPlayer;
            string expectedHouse = "Gryffindor";

            //Act     
            griffPlayer = new Player("Gryffindor");

            //Assert
            Assert.AreEqual(expectedHouse, griffPlayer.GetHouse().GetHouseName());
        }

        [TestMethod]
        public void DoesPlayerBecomeSlytherin() {

            //Arrange
            Player SlytherinPlayer;
            string expectedHouse = "Slytherin";

            //Act     
            SlytherinPlayer = new Player("Slytherin");

            //Assert
            Assert.AreEqual(expectedHouse, SlytherinPlayer.GetHouse().GetHouseName());
        }

        [TestMethod]
        public void DoesPlayerBecomeHufflepuff() {

            //Arrange
            Player hufflepuffPlayer;
            string expectedHouse = "Hufflepuff";

            //Act     
            hufflepuffPlayer = new Player("Hufflepuff");

            //Assert
            Assert.AreEqual(expectedHouse, hufflepuffPlayer.GetHouse().GetHouseName());
        }
    }
}
