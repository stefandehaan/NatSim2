using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NatSim
{
    public interface IBewegendObject
    {
        Snelheid SnelheidObject { get; set; }
        Timer klok { get; set; }

        Point Stap();
        Point Stap(Snelheid snelheidObject);
    }
}
