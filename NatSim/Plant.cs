using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSim
{
    public abstract class Plant: Leven
    {
        public Plant() { }
        public Plant(int verhoudingTickJaren, string latijnseNaam, int levensduur, Bloeiwijze bloeiwijzePlant):
            base(verhoudingTickJaren, latijnseNaam, levensduur)
        {
            BloeiwijzePlant = bloeiwijzePlant;
        }

        public Bloeiwijze BloeiwijzePlant { get; set; }

        public override string ToString()
        {
            return "Latijnse naam: " + LatijnseNaam + Environment.NewLine +
                Environment.NewLine + "Nederlandse naam : " + NederlandseNaam
                + Environment.NewLine + Environment.NewLine + "Levensduur: " + Levensduur
                + Environment.NewLine + Environment.NewLine + "Bloeiwijze: " + BloeiwijzePlant
                + Environment.NewLine + "Locatie: "
                + Locatie.ToString();
        }
    }
}
