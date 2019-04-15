using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace NatSim
{
    public class Venijnboom: Plant
    {
        public Venijnboom() : base(1, "Taxus bacatta", 2000, Bloeiwijze.kegel)
        {
            initClass(new Point(0, 0));
        }

        public Venijnboom(Point locatie) : base(1, "Taxus bacatta", 2000, Bloeiwijze.kegel)
        {
            initClass(locatie);
        }

        private void initClass(Point locatie)
        {
            Locatie = locatie;
            Tekengebied.Afmetingen = new Size(10, 400);
            Kleur = Color.ForestGreen;
        }

        private List<string> _geneesmiddelVoor = new List<string> { "Longkanker", "Borstkanker" };
        private int _maximaleGrootte = 20000;

        public List<string> GeneesmiddelVoor { get { return _geneesmiddelVoor; } }
        public int MaximaleGrootte { get { return _maximaleGrootte; } }

        public double AantalKubiekeMetersHout { get; set; }
    }
}
