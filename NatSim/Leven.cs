using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatSim
{
    public abstract class Leven: GrafischObject
    {
        public Leven()
        {
            initClass(1, "", int.MaxValue);
        }

        public event EventHandler<EventArgs> Einde;

        protected virtual void OnEinde()
        {
            if(Einde != null)
            {
                Einde(this, EventArgs.Empty);
            }
        }

        public Leven(int verhoudingTicksJaren, string latijnsenaam, int levensduur)
        {
            initClass(verhoudingTicksJaren, latijnsenaam, levensduur);
        }

        private void initClass(int verhoudingTicksJaren, string latijnsenaam, int levensduur)
        {
            VerhoudingTicksJaren = verhoudingTicksJaren;
            _latijnseNaam = latijnsenaam;
            _levensduur = levensduur;
            _verouder = new Timer();
            _verouder.Interval = _aantalTicksPerSeconde * VerhoudingTicksJaren;
            _verouder.Start();
            _verouder.Tick += _verouder_Tick;
        }

        private void _verouder_Tick(object sender, EventArgs e)
        {
            if (Leeftijd < Levensduur)
            {
                Leeftijd++;
            }
            else
            {
                _verouder.Stop();
                Sterf();
            }
        }

        public const int _aantalTicksPerSeconde = 1000;
        public string _latijnseNaam;
        public double _levensduur;
        public Timer _verouder;

        public int Leeftijd { get; set; }
        public int VerhoudingTicksJaren { get; set; }
        public int Voedinswaarde { get; set; }

        public string LatijnseNaam { get { return _latijnseNaam; } }
        public double Levensduur { get { return _levensduur; } }
        public string NederlandseNaam { get { return base.ToString().Split('.').Last(); } }

        public Timer Verouder { get { return _verouder; } }

        public void Sterf()
        {
            Verwijder();
            OnEinde();
        }

        public bool IsPlant
        {
            get { return this.GetType().IsSubclassOf(typeof(Plant)); }
        }

        public bool IsDier
        {
            get { return this.GetType().IsSubclassOf(typeof(Dier)); }
        }

        public Dier ToDier()
        {
            if (IsDier) return (Dier)this;
            else return null; 
        }

        public Plant ToPlant()
        {
            if (IsPlant) return (Plant)this;
            else return null;
        }

        public SoortLeven ToSoort()
        {
            switch(NederlandseNaam.ToLower())
            {
                case "beer": return SoortLeven.Beer;
                case "Gras": return SoortLeven.Gras;
                case "Koe": return SoortLeven.Koe;
                case "Konijn": return SoortLeven.Konijn;
                case "Lynx": return SoortLeven.Lynx;
                case "Venijnboom": return SoortLeven.Venijnboom;
                case "Vingerhoedskruid": return SoortLeven.Vingerhoedskruid;
                default: return SoortLeven.Gras;
            }
        }

        public Gras ToGras()
        {
            if(this.GetType() == typeof(Gras))
            {
                return (Gras)this;
            }
            else
            {
                return null;
            }
        }

        public Venijnboom ToVenijnboom()
        {
            if (this.GetType() == typeof(Venijnboom))
            {
                return (Venijnboom)this;
            }
            else
            {
                return null;
            }
        }

        public Vingerhoedskruid ToVingerhoedskruid()
        {
            if (this.GetType() == typeof(Vingerhoedskruid))
            {
                return (Vingerhoedskruid)this;
            }
            else
            {
                return null;
            }
        }
    }
}
