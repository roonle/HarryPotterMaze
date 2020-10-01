using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD350TeamHardModeTriviaMaze {
    public class HouseHufflepuff : HogwartsHouses {

        public HouseHufflepuff() : base("Hufflepuff", new SolidColorBrush(Colors.Goldenrod), new SolidColorBrush(Colors.SlateGray),
            new SolidColorBrush(Colors.DarkSlateGray), new SolidColorBrush(Colors.LightGray)) {
        }           
    }  
}
