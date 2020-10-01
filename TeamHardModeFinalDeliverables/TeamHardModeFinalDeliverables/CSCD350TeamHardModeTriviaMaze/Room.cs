using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD350TeamHardModeTriviaMaze { 

    public class Room {
        
        private Question question;
        private Boolean locked;
        private Boolean attempted;
        private int questionNumber;
        private int theroomNumber;
        
        
        public Room(int roomNumber, string house) {
            theroomNumber = roomNumber;
            if (roomNumber != 0) {
                question = new Question(roomNumber + 1, house);
                locked = true;
                attempted = false;
            } else {
                question = new Question();
                locked = false;
                attempted = true;
            }  
        }

        public Boolean IsLocked() {
            return locked;
        }

        public void WasAttempted() {
            attempted = true;
        }

        public Boolean IsAttempted() {
            return attempted;
        }

        public void Unlock() {
            this.locked = false;
        }

        public Question GetQuestion() {
            return this.question;
        }

        public int GetRoomNumber() {
            return theroomNumber;
        }
    }
}
