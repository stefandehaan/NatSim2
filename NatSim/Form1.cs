using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatSim
{
    public partial class FrmNatSim : Form
    {
        Graphics papier;
        SoortLeven soortPlant = SoortLeven.Gras;
        SoortLeven soortDier = SoortLeven.Konijn;
        Natuur natuur = new Natuur();

        public FrmNatSim()
        {
            InitializeComponent();
            papier = pbWereld.CreateGraphics();
            natuur.NieuwLeven += natuur_NieuwLeven;
            natuur.Getroffen += natuur_Getroffen;
            
        }

        void natuur_Getroffen(object sender, GetroffenEventArgs e)
        {
                lblInformatie.Text = e.GeraaktOp.ToString("hh:mm:ss tt") +
                Environment.NewLine + Environment.NewLine + e.Getroffen.ToString();
        }

        void natuur_NieuwLeven(object sender, NieuwLevenEventArgs e)
        {
            e.NieuwLeven.Teken(papier);
        }

        private void ResizePictureBox()
        {
            int margeBreedte = 40;
            int margeHoogte = 64;
            pbWereld.Width = this.Width - grbDieren.Width - grbPlanten.Width - margeBreedte;
            pbWereld.Height = this.Height - margeHoogte;
            papier = pbWereld.CreateGraphics();
        }

        private void ResizeLblInformatie()
        {
            int margeHoogte = 88;
            lblInformatie.Height = this.Height - margeHoogte - pnlKnoppen.Height;
        }

        private void frmNatSim_Resize(Object sender, EventArgs e)
        {
            ResizePictureBox();
            ResizeLblInformatie();
        }

        private void pbWereld_MouseClick(object sender, MouseEventArgs e)
        {
            SoortLeven soortleven = SoortLeven.Gras;
            if (e.Button == MouseButtons.Left)
            {
                soortleven = soortDier;
            }
            else if (e.Button == MouseButtons.Right)
            {
                soortleven = soortPlant;
            }

            switch(soortleven)
            {
                case SoortLeven.Gras:
                    natuur.Add(new Gras(e.Location));
                    break;

                case SoortLeven.Vingerhoedskruid:
                    natuur.Add(new Vingerhoedskruid(e.Location));
                    break;

                case SoortLeven.Venijnboom:
                    natuur.Add(new Venijnboom(e.Location));
                    break;

                case SoortLeven.Koe:
                    natuur.Add(new Koe(e.Location));
                    break;

                case SoortLeven.Konijn:
                    natuur.Add(new Konijn(e.Location));
                    break;

                case SoortLeven.Jaguar:
                    natuur.Add(new Jaguar(e.Location));
                    break;

                case SoortLeven.Beer:
                    natuur.Add(new Beer(e.Location));
                    break;

                case SoortLeven.Lynx:
                    natuur.Add(new Lynx(e.Location));
                    break;
            }
        }

        private void TekenDier(Point positie)
        {
            if (rdbKonijn.Checked == true)
            {
                Konijn Konijn01 = new Konijn(positie, "Flappie", Color.Brown);
                Konijn01.Teken(pbWereld.CreateGraphics());
            }
            else if (rdbKoe.Checked == true)
            {
                Koe Koe01 = new Koe(positie, "Bertha", Color.Black);
                Koe01.Teken(pbWereld.CreateGraphics());
            }
            else if (rdbJaguar.Checked == true)
            {
                Jaguar jaguar01 = new Jaguar(positie, "Bart", Color.Yellow);
                jaguar01.Teken(pbWereld.CreateGraphics());
            }
            else if (rdbLynx.Checked == true)
            {
                Lynx Lynx01 = new Lynx(positie, "Bob", Color.Gray);
                Lynx01.Teken(pbWereld.CreateGraphics());
            }
            else if (rdbBeer.Checked == true)
            {
                Beer Beer01 = new Beer(positie, "lmao", Color.Gray);
                Beer01.Teken(pbWereld.CreateGraphics());
            }
        }

        private void TekenPlant(Point positie)
        {
            if(rdbGras.Checked == true)
            {
                Gras Gras01 = new Gras(positie);
                Gras01.Teken(pbWereld.CreateGraphics());
            }
            else if (rdbVenijnboom.Checked == true)
            {
                Venijnboom venijnboom01 = new Venijnboom(positie);
                venijnboom01.Teken(pbWereld.CreateGraphics());
            }
        }

        private void rdbKonijn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKonijn.Checked) soortDier = SoortLeven.Konijn;
        }

        private void rdbGras_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGras.Checked) soortPlant = SoortLeven.Gras;
        }

        private void rdbKoe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKoe.Checked) soortDier = SoortLeven.Koe;
        }

        private void rdbVenijnboom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVenijnboom.Checked) soortPlant = SoortLeven.Venijnboom;
        }

        private void rdbVingerhoedskruid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVingerhoedskruid.Checked) soortPlant = SoortLeven.Vingerhoedskruid;
        }

        private void rdbLynx_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLynx.Checked) soortDier = SoortLeven.Lynx;
        }

        private void rdbBeer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBeer.Checked) soortDier = SoortLeven.Beer;
        }

        private void FrmNatSim_Load(object sender, EventArgs e)
        {
        }

        private void FrmNatSim_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pbWereld_MouseMove(object sender, MouseEventArgs e)
        {
            if (chbZaai.Checked && rdbGras.Checked)
            {
                //Gras.Zaaien(e.Location, pbWereld.CreateGraphics(), 2 , 2, 4);
            }
            else
            {
                //lblInformatie.Text = "";
                natuur.LevenGeraakt(e.Location);
            }
        }

        private void rdbJaguar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbJaguar.Checked) soortDier = SoortLeven.Jaguar;
        }
    }
}
