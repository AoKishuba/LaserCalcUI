using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserCalcUI
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        private void PlanarSmokeRB_CheckedChanged(object sender, EventArgs e)
        {
            PlanarSmokeUD.Enabled = PlanarSmokeRB.Checked;
            RingACUD.Enabled = !PlanarSmokeRB.Checked;
        }

        private void RingACRB_CheckedChanged(object sender, EventArgs e)
        {
            RingACUD.Enabled = RingACRB.Checked;
            PlanarSmokeUD.Enabled = !RingACRB.Checked;
        }
    }
}
