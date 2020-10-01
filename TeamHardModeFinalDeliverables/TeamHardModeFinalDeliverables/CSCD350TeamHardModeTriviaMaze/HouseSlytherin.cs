using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD350TeamHardModeTriviaMaze {
    public class HouseSlytherin : HogwartsHouses {

        public HouseSlytherin() : base("Slytherin", new SolidColorBrush(Colors.DarkGreen), new SolidColorBrush(Colors.Silver),
            new SolidColorBrush(Colors.DarkSlateGray), new SolidColorBrush(Colors.Goldenrod)) {
        }
    }
}
