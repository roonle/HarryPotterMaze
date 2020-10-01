using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD350TeamHardModeTriviaMaze { 
    public class Question {

        private SqliteHandler connectDb = new SqliteHandler();
        private String hogwartsHouse; 
        private string question;
        private string answer;
        private int questionNumber;

        public Question() {
            question = "WELCOME TO THE HARRY POTTER MAZE. Click down or right to move to through the maze. Get to the bottom right corner of the maze to become a wizard!";
        }

        public Question(int questionNumber, string hogwartsHouse) {

            if (hogwartsHouse == "Gryffindor") {
                //pull question and answer from database
                question = connectDb.GetQuestion("Gryffindor", questionNumber);
                answer = connectDb.GetAnswer("Gryffindor", questionNumber).ToLower();
                

            } else if (hogwartsHouse == "Hufflepuff") {
                //pull question and answer from database
                question = connectDb.GetQuestion("Hufflepuff", questionNumber);
                answer = connectDb.GetAnswer("Hufflepuff", questionNumber).ToLower();

            } else if (hogwartsHouse == "Slytherin") {
                //pull question and answer from database
                question = connectDb.GetQuestion("Slytherin", questionNumber);
                answer = connectDb.GetAnswer("Slytherin", questionNumber).ToLower();

            } else if (hogwartsHouse == "Ravenclaw") {
                //pull question and answer from database
                question = connectDb.GetQuestion("Ravenclaw", questionNumber);
                answer = connectDb.GetAnswer("Ravenclaw", questionNumber).ToLower();
            } 
        }
        
        public string GetQuestion() {
            return this.question;
        }

        public string GetAnswer() {
            return this.answer;
        } 

        public Boolean CheckAnswer(String attempt) {
            return attempt.Equals(this.answer); 
        }
    }
}
