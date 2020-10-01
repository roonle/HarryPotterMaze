using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CSCD350TeamHardModeTriviaMaze {

    public class SqliteHandler {

        private SQLiteCommand sqlite_cmd;
        private SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Maze.db;Version=3;New=True;Compress=True;");
        private SQLiteDataReader sqlite_datareader;
        private string question;
        private string answer;
        private int id;

        private string boardSave;
        private string boardPosition;
        private string boardHouse;

        public void SetupDatabase() {
            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Gryffindor (ID int(5), GryffindorQ varchar(250), GyffindorA varchar(100));";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Slytherin (ID int(5), SlytherinQ varchar(250), SlytherinA varchar(100));";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Hufflepuff (ID int(5), HufflepuffQ varchar(250), HufflepuffA varchar(100));";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Ravenclaw (ID int(5), RavenclawQ varchar(250), RavenclawA varchar(100));";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS BoardData (ID int(5), BoardSave varchar(50), BoardPosition varchar(25), BoardHouse varchar(100));";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void InsertData(string house, int id, string question, string answer) {
            sqlite_conn.Open();

            if (house == "Gryffindor") {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO  Gryffindor (id,GryffindorQ,GyffindorA) VALUES ('{id}','{question}','{answer}');";
                sqlite_cmd.ExecuteNonQuery();

            } else if (house == "Slytherin") {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO Slytherin (id,SlytherinQ,SlytherinA) VALUES ('{id}','{question}','{answer}');";
                sqlite_cmd.ExecuteNonQuery();

            } else if (house == "Hufflepuff") {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO Hufflepuff (id,HufflepuffQ,HufflepuffA) VALUES ('{id}','{question}','{answer}');";
                sqlite_cmd.ExecuteNonQuery();

            } else if (house == "Ravenclaw") {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO Ravenclaw (id,RavenclawQ,RavenclawA) VALUES ('{id}','{question}','{answer}');";
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_conn.Close();
        }
 
        public string GetQuestion(string type, int inputId) {
            sqlite_conn.Open();

            if (type == "Gryffindor") {
                return TryToGetQuestion("Gryffindor", inputId);

            } else if (type == "Slytherin") {
                return TryToGetQuestion("Slytherin", inputId);

            } else if (type == "Hufflepuff") {
                return TryToGetQuestion("Hufflepuff", inputId);

            } else if (type == "Ravenclaw") {
                return TryToGetQuestion("Ravenclaw", inputId);
            }
            sqlite_conn.Close();
            return question;
        }

        public string TryToGetQuestion(string house, int inputId) {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT " + house + "Q FROM " + house + " WHERE id = '" + inputId +"' ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            try {
                // Always call Read before accessing data.
                while (sqlite_datareader.Read()) {
                    this.question = sqlite_datareader.GetString(0);
                }
            } catch (Exception e) {
                throw new Exception("Data read error in sqlite Class", e);
            }
            sqlite_conn.Close();
            return question;
        }

        public string GetAnswer(string type, int id) {
            
            
            if (type == "Gryffindor") {
                return TryToGetAnswer("Gryffindor", id);

            } else if (type == "Slytherin") {
                return TryToGetAnswer("Slytherin", id);

            } else if (type == "Hufflepuff") {
                return TryToGetAnswer("Hufflepuff", id);

            } else if (type == "Ravenclaw") {
                return TryToGetAnswer("Ravenclaw", id);
            }

            sqlite_datareader.Close();
            sqlite_conn.Close();
            return answer;
        }

        public string TryToGetAnswer(string house, int inputId) {
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            if (house == "Gryffindor") {
                string houseMispelled = "Gyffindor";
                sqlite_cmd.CommandText = $"SELECT " + houseMispelled + "A FROM " + house + " WHERE id = '" + inputId + "' ";
            } else {
                sqlite_cmd.CommandText = $"SELECT " + house + "A FROM " + house + " WHERE id = '" + inputId + "' ";
            }
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            try {
                // Always call Read before accessing data.
                while (sqlite_datareader.Read()) {
                    this.answer = sqlite_datareader.GetString(0);
                }
            } catch (Exception e) {
                throw new Exception("Data read error in sqlite Class", e);
            }
            sqlite_datareader.Close();
            sqlite_conn.Close();
            return answer;
        }

        public string GetBoardSave(int id) {
            string boardSave = "";
            return boardSave;
        }

        public string GetBoardPosition(int id) {
            string boardPosition = "";
            return boardPosition;
        }

        public void SetQuestion(string inputQuestion) {
            this.question = inputQuestion;
        }

        public void SetId(int inputId) {
            this.id = inputId;
        }

        public void SetAnswer(string inputAnswer) {
            this.answer = inputAnswer;
        }

        public void InsertSaveData(int id, string boardSave, string boardPosition, string house) {
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"UPDATE BoardData SET BoardSave = '{boardSave}' , BoardPosition = '{boardPosition}', BoardHouse =  '{house}' WHERE id = '{id}';";
            // sqlite_cmd.CommandText = $"INSERT INTO BoardData (id,BoardSave,BoardPosition,BoardHouse) VALUES ('{id}','{boardSave}','{boardPosition}', '{house}');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void LoadSaveData() {
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT BoardSave FROM BoardData WHERE id = '1' ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            try {
                // Always call Read before accessing data.
                while (sqlite_datareader.Read())
                {
                    this.boardSave = sqlite_datareader.GetString(0);

                }
            } catch (Exception e) {
                throw new Exception("Data read error in sqlite loadSaveData method", e);
            }

            if (boardSave != " ") {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"SELECT BoardSave FROM BoardData WHERE id = '1' ";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                try {
                    // Always call Read before accessing data.
                    while (sqlite_datareader.Read()) {
                        this.boardSave = sqlite_datareader.GetString(0);

                    }
                } catch (Exception e) {
                    throw new Exception("Data read error in sqlite loadSaveData method", e);
                }

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"SELECT BoardPosition FROM BoardData WHERE id = '1' ";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                try {
                    // Always call Read before accessing data.
                    while (sqlite_datareader.Read()) {
                        this.boardPosition = sqlite_datareader.GetString(0);

                    }
                } catch (Exception e) {
                    throw new Exception("Data read error in sqlite loadSaveData method", e);
                }

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"SELECT BoardHouse FROM BoardData WHERE id = '1' ";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                try {
                    // Always call Read before accessing data.
                    while (sqlite_datareader.Read()) {
                        this.boardHouse = sqlite_datareader.GetString(0);
                    }
                }

                catch (Exception e) {
                    throw new Exception("Data read error in sqlite loadSaveData method", e);
                }
            }
            sqlite_datareader.Close();
            sqlite_conn.Close();
        }

        public string GetBoardSave() {
            return this.boardSave;
        }

        public string GetBoardPosition() {
            return this.boardPosition;
        }

        public string GetBoardHouse() {
            return this.boardHouse;
        }


    }
}