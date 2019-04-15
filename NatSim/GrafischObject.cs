using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace NatSim
{
    public abstract class GrafischObject
    {
        public GrafischObject()
        {
            initClass();
        }

        public Color Kleur { get; set; }
        public Color KaderKleur { get; set; }
        public Point Locatie
        {
            get { return Tekengebied.Locatie; }
            set { Tekengebied.Locatie = value; }
        }

        public Graphics Papier
        {
            get { return _papier; }
            set
            {
                _papier = value;
                if (value != null)
                {
                    int breedteVenster = (int)Papier.VisibleClipBounds.Width;
                    int hoogteVenster = (int)Papier.VisibleClipBounds.Height;
                    _graphicsVenster = new Rechthoek(new Point(0, 0), new Size(breedteVenster, hoogteVenster));
                }
            }
        }

        public Rechthoek Tekengebied { get; set; }
        public Color Wiskleur { get; set; }
        public Rechthoek GraphicsVenster { get { return _graphicsVenster; } }
        public Guid ID { get { return _id; } }

        private Guid _id;
        private bool _verwijderd = false;
        private Graphics _papier;
        private Rechthoek _graphicsVenster;

        private void initClass()
        {
            KaderKleur = Color.Black;
            Kleur = Color.WhiteSmoke;
            Wiskleur = Color.PaleGoldenrod;

            Tekengebied = new Rechthoek();

            _id = Guid.NewGuid();
        }

        public void Verwijder()
        {
            _verwijderd = true;
            Wis();
        }

        public void Wis()
        {
            Color oudeKleur = Kleur;
            Color oudeKaderKleur = KaderKleur;
            Kleur = Wiskleur;
            KaderKleur = Wiskleur;
            Teken();
            KaderKleur = oudeKaderKleur;
            Kleur = oudeKleur;
        }

        public void Teken(Graphics papier)
        {
            Papier = papier;
            Pen pen = new Pen(KaderKleur, 2);

            if (Papier != null)
            {
                Papier.DrawRectangle(pen, Tekengebied.ToRectangle());
                pen.Dispose();

                SolidBrush kwast = new SolidBrush(Kleur);
                Papier.FillRectangle(kwast, Tekengebied.ToRectangle());
                kwast.Dispose();
            }
        }

        public void Teken()
        {
            Teken(Papier)
;       }

        public event EventHandler<EventArgs> OpObject;

        protected virtual void OnOpObject (object sender)
        {
            if (OpObject != null)
            {
                OpObject(this, EventArgs.Empty);
            }
        }

        public void IsOpObject(Point punt)
        {
            if (punt.X >= Tekengebied.A.X && punt.X <= Tekengebied.B.X &&
                punt.Y >= Tekengebied.A.Y && punt.Y <= Tekengebied.D.Y)
            {
                OnOpObject(this);
            }
        }
    }
}
