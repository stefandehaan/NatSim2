using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NatSim
{
    public enum SoortLeven
    {
        Gras,
        Vingerhoedskruid,
        Venijnboom,
        Koe,
        Konijn,
        Beer,
        Lynx,
        Jaguar
    }
    public class Natuur : List<Leven>
    {
        public event EventHandler<NieuwLevenEventArgs> NieuwLeven;
        public event EventHandler<GetroffenEventArgs> Getroffen;

        public Natuur(): base()
        {
            Timer _LevensKlok = new Timer();
            _LevensKlok.Interval = 10;
            _LevensKlok.Start();

            _LevensKlok.Tick += _LevensKlok_Tick;
        }

        public void LevenGeraakt(Point locatie)
        {
            foreach(Leven leven in this)
            {
                leven.IsOpObject(locatie);
            }
        }

        private void _LevensKlok_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Dier dier = this[i].ToDier();
                if(dier != null)
                {
                    dier.Beweeg();
                    CollisionDetection(dier);
                }
            }
        }

        public void CollisionDetection(Dier dier)
        {
            for(int i=0; i < this.Count; i++)
            {
                if (dier.ID != this[i].ID)
                {
                    dier.IsBotsing(this[i]);
                }
            }
        }

        public new void Add(Leven leven)
        {
            leven.Einde += leven_Einde;
            leven.OpObject += Leven_OpObject;

            if(leven.IsDier == true)
            {
                Random random = new Random();
                Snelheid snelheid = new Snelheid(random.Next(-4, 4), random.Next(-4, 4));
                ((Dier)leven).SnelheidObject = snelheid;
            }
            base.Add(leven);

            if(NieuwLeven != null)
            {
                NieuwLeven(this, new NieuwLevenEventArgs(leven));
            }
        }

        private void Leven_OpObject(object sender, EventArgs e)
        {
            if (Getroffen != null)
            {
                Getroffen(this, new GetroffenEventArgs((Leven)sender));
            }
        }

        private void leven_Einde(object sender, EventArgs e)
        {
            this.Remove((Leven)sender); ;
        }
    }
    public class NieuwLevenEventArgs : EventArgs
    {
        public NieuwLevenEventArgs(Leven leven)
        {
            NieuwLeven = leven;
        }

        public Leven NieuwLeven { get; set; }
    }

    public class GetroffenEventArgs : EventArgs
    {
        public GetroffenEventArgs(Leven leven)
        {
            Getroffen = leven;
            GeraaktOp = DateTime.Now;
        }

        public Leven Getroffen { get; set; }
        public DateTime GeraaktOp { get; set; } 
    }
}
