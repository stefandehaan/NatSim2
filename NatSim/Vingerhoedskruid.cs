using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace NatSim
{
    public class Vingerhoedskruid: Plant
    {
        public Vingerhoedskruid() : base(4, "Digitalis Purpurea", 4, Bloeiwijze.tros)
        {
            initClass(new Point(0, 0));
        }

        public Vingerhoedskruid(Point locatie) : base(4, "Digitalis Purpurea", 4, Bloeiwijze.tros)
        {
            initClass(locatie);
        }

        private void initClass(Point locatie)
        {
            Locatie = locatie;
            Tekengebied.Afmetingen = new Size(4, 10);
            Kleur = Color.Blue;
        }

        
    }
}
