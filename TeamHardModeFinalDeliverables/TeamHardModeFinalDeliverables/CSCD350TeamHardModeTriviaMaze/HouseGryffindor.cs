using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD350TeamHardModeTriviaMaze {
    public class HouseGryffindor : HogwartsHouses {

        public HouseGryffindor() : base("Gryffindor", new SolidColorBrush(Colors.Crimson), new SolidColorBrush(Colors.Goldenrod),
        new SolidColorBrush(Colors.DarkSlateGray), new SolidColorBrush(Colors.LightGray)) {
        }
    }
}
