using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSim
{
    public abstract class Vleeseter: Dier
    {
        public Vleeseter(int verhoudingTickJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingTickJaren, latijnseNaam, levensduur, gewichtMaximaal) { }

        public override void Eet(Leven leven)
        {
            if (leven.IsDier)
            {
                if (leven.NederlandseNaam == "Lynx")
                {
                    SnelheidObject = SnelheidObject.Keerom();
                    leven.ToDier().SnelheidObject.Keerom();
                }
                else
                {
                    int dier1 = 100;
                    int dier2 = 60;

                    if (dier2 > dier1)
                    {
                        SnelheidObject = SnelheidObject.Keerom();
                        MaagGevuld = MaagGevuld - 10;
                    }
                    else
                    {
                        leven.Sterf();
                    }
                }
            }
            else if (MaagGevuld < 100)
            {
                MaagGevuld = MaagGevuld + leven.Voedinswaarde;
                leven.Sterf();
            }
            else if (leven.IsPlant)
            {
                SnelheidObject = SnelheidObject.Keerom();
            }
            else
            {
                SnelheidObject = SnelheidObject.Keerom();
            }
        }
    }
}
