using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD350TeamHardModeTriviaMaze {
    public class HouseRavenclaw : HogwartsHouses {

        public HouseRavenclaw() : base("Ravenclaw", new SolidColorBrush(Colors.Navy), new SolidColorBrush(Colors.Lavender),
            new SolidColorBrush(Colors.DarkSlateGray), new SolidColorBrush(Colors.Goldenrod)) {
        }    
    }
}
