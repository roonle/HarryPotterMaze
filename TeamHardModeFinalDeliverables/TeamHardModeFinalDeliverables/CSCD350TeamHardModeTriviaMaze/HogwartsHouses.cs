using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media; //Needed for SolidColorBrush

namespace CSCD350TeamHardModeTriviaMaze {
    public abstract class HogwartsHouses {

        private string hogwartsHouse;
        //Colours
        private SolidColorBrush playerColor;
        private SolidColorBrush playersPathColor;
        private SolidColorBrush gridBackColor;
        private SolidColorBrush gridLinesColor;

        public HogwartsHouses() {
        }

        public HogwartsHouses(String hn, SolidColorBrush pc, SolidColorBrush pp, SolidColorBrush gbc, SolidColorBrush lc) {
            this.hogwartsHouse = hn;
            playerColor = pc;
            playersPathColor = pp;
            gridBackColor = gbc;
            gridLinesColor = lc;
        }

        public SolidColorBrush GetPlayerColor() {
            return this.playerColor;
        }

        public SolidColorBrush GetPathColor() {
            return this.playersPathColor;
        }

        public SolidColorBrush GetGridBackColor() {
            return this.gridBackColor;
        }

        public SolidColorBrush GetLineColor() {
            return this.gridLinesColor;
        }

        public String GetHouseName() {
            return this.hogwartsHouse;
        }
    }
}
