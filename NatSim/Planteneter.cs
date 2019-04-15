using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSim
{
    public abstract class Planteneter: Dier
    {
        public Planteneter(int verhoudingTickJaren, string latijnseNaam, int levensduur, double gewichtMaximaal): base(verhoudingTickJaren, latijnseNaam, levensduur, gewichtMaximaal) { }

        public override void Eet(Leven leven)
        {
            if (leven.IsPlant)
            {
                if(WordVergiftigdDoor.Contains(leven.NederlandseNaam))
                {
                    if(Honger())
                    {
                        this.Sterf();
                    }
                    else
                    {
                        SnelheidObject = SnelheidObject.Keerom();
                    }
                }
                else if(MaagGevuld < 100)
                {
                    MaagGevuld = MaagGevuld + leven.Voedinswaarde;
                    leven.Sterf();
                }
            }
            else
            {
                SnelheidObject = SnelheidObject.Keerom();
            }
        }

        
    }
}
