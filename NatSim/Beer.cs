using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace NatSim
{
    public class Beer : Alleseter
    {
        public Beer() : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(new Point(0, 0), "", Color.White);
        }

        public Beer(Point locatie) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, "", Color.White);
        }

        public Beer(Point locatie, string naam, Color kleur) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, naam, kleur);
        }

        private void initClass(Point locatie, string naam, Color kleur)
        {
            Locatie = locatie;
            Naam = naam;
            Kleur = kleur;
            Tekengebied.Afmetingen = new Size(20, 12);
            WordVergiftigdDoor.Add("Vingerhoedskruid");
            WordVergiftigdDoor.Add("Venijnboom");
            Gewicht = 5;
            Voedinswaarde = 1;
        }

        private const string _latijnseNaam = "Ursidae";
        private const int _leeftijd = 20;
        private const int _verhoudingTicksJaren = 1;
        private const double _gewichtMaximaal = 600;

        public string Naam { get; set; }
        public double Gewicht { get; set; }
        public DateTime Geboortedatum { get; set; }
        public DateTime Sterfdatum { get; set; }
    }
}
