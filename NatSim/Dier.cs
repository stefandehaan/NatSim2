using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NatSim
{
    public abstract class Dier: Leven, IBewegendObject
    {
        public Dier(int verhoudingTickJaren, string latijnseNaam, int levensduur, double gewichtMaximaal): base(verhoudingTickJaren, latijnseNaam, levensduur)
        {
            initDier(gewichtMaximaal);
        }

        public bool IsBotsing(Leven leven)
        {
            if(this.Tekengebied.Overlap(leven.Tekengebied))
            {
                Dier dier = leven.ToDier();
                if (dier != null)
                {
                    this.SnelheidObject = this.SnelheidObject.Keerom();
                    dier.SnelheidObject = dier.SnelheidObject.Keerom();
                }
                Eet(leven);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Latijnse naam: " + LatijnseNaam + Environment.NewLine +
                Environment.NewLine + "Nederlandse naam : " + NederlandseNaam
                + Environment.NewLine + Environment.NewLine + "Levensduur: " + Levensduur
                + Environment.NewLine + Environment.NewLine + "Is: " + this.GetType().BaseType.Name.ToString()  + Environment.NewLine + "Locatie: "
                + Locatie.ToString();
        }

        private void initDier(double gewichtMaximaal)
        {
            _gewichtMaximaal = gewichtMaximaal;
            WordVergiftigdDoor = new List<string>();
        }

        private double _gewichtMaximaal = 0;
        public int MaagGevuld { get; set; }
        public int SpijsverteringsDuur { get; set; }
        public double GewichtMaximaal { get { return _gewichtMaximaal; } }
        public List<string> WordVergiftigdDoor { get; set; }
        public Snelheid SnelheidObject { get; set; }
        public Timer klok { get; set; }

        public abstract void Eet(Leven leven);
        public bool Honger()
        {
            return (MaagGevuld < 25);
        }

        public Point Stap()
        {
            return Stap(this.SnelheidObject);
        }

        public Point Stap(Snelheid snelheidObject)
        {
            this.SnelheidObject = snelheidObject;

            int berekendeX = Locatie.X + (snelheidObject.X);
            int berekendeY = Locatie.Y + (snelheidObject.Y);

            Rechthoek nieuwTekengebied = new Rechthoek(new Point(berekendeX, berekendeY), Tekengebied.Afmetingen);
            Vlak vlak = Rechthoek.GrensBereikt(nieuwTekengebied, GraphicsVenster);

            SnelheidObject = SnelheidObject.Stuiter(vlak);

            berekendeX = Locatie.X + (snelheidObject.X);
            berekendeY = Locatie.Y + (snelheidObject.Y);

            return new Point(berekendeX, berekendeY);
        }

        public void Beweeg()
        {
            Verwijder();
            Locatie = Stap();
            Teken();
        }
    }
}
