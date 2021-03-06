﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSim
{
    public abstract class Alleseter : Dier
    {
        public Alleseter(int verhoudingTickJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingTickJaren, latijnseNaam, levensduur, gewichtMaximaal) { }

        public override void Eet(Leven leven)
        {
            if (leven.IsPlant)
            {
                if (WordVergiftigdDoor.Contains(leven.NederlandseNaam))
                {
                    if (Honger())
                    {
                        this.Sterf();
                       
                    }
                    else
                    {
                        SnelheidObject = SnelheidObject.Keerom();
                    }
                }
                else if (MaagGevuld < 100)
                {
                    MaagGevuld = MaagGevuld + leven.Voedinswaarde;
                    leven.Sterf();
                }
            }
            else if (leven.IsDier)
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
                    if (leven.NederlandseNaam == "Beer")
                    {
                        SnelheidObject = SnelheidObject.Keerom();
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
            else
            {
                SnelheidObject = SnelheidObject.Keerom();
            }
        }
    }
}
