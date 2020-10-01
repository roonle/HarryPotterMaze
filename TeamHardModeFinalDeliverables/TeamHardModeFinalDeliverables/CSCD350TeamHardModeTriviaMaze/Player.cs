using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD350TeamHardModeTriviaMaze { 

    public class Player {

        private HogwartsHouses hogwartshouse;

        public Player(HogwartsHouses hh) {
            this.hogwartshouse = hh;
        }

        public Player() { 
            //Defaults to Gryffindor
            this.hogwartshouse = new HouseGryffindor();
        }

        public Player(string house) {
            this.hogwartshouse = ChooseAHouse(house);
        }

        public HogwartsHouses GetHouse() {
            return this.hogwartshouse;
        }

        public HogwartsHouses ChooseAHouse(string house) {
            if (house.Equals("Gryffindor")) {
                return new HouseGryffindor();
            }
            else if (house.Equals("Ravenclaw")) {
                return new HouseRavenclaw();
            }
            else if (house.Equals("Hufflepuff")) {
                return new HouseHufflepuff();
            }
            else if (house.Equals("Slytherin")) {
                return new HouseSlytherin();
            }
            //defaults to house Gryffindor
            else {
                return new HouseGryffindor();
            }
        }
    }
}
