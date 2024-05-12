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

        private void MinRechargeUD_ValueChanged(object sender, EventArgs e)
        {
            MaxRechargeUD.Value = Math.Max(MaxRechargeUD.Value, MinRechargeUD.Value);
        }

        private void MaxRechargeUD_ValueChanged(object sender, EventArgs e)
        {
            MinRechargeUD.Value = Math.Min(MinRechargeUD.Value, MaxRechargeUD.Value);
        }

        private void RunTestsButton_Click(object sender, EventArgs e)
        {
            bool error = true;
            if (EnginePpmUD.Value == 0)
            {
                errorProvider1.SetError(EnginePpmUD, "Engine PPM must be > 0");
            }
            else if (EnginePpvUD.Value == 0)
            {
                errorProvider1.SetError(EnginePpvUD, "Engine PPV must be > 0");
            }
            else if (EnginePpcUD.Value == 0)
            {
                errorProvider1.SetError(EnginePpcUD, "Engine PPC must be > 0");
            }
            else
            {
                error = false;
            }

            if (!error)
            {
                // Disable button
                RunTestsButton.Enabled = false;

                float storagePerCost = GenericStorageRB.Checked
                    ? 250f
                    : CargoContainerRB.Checked
                        ? 469.5652f
                        : 218.75f;

                float storagePerVolume = GenericStorageRB.Checked
                    ? 500f
                    : CargoContainerRB.Checked
                        ? 1000f
                        : 583.3333f;

                TestType toCompare = DpsPerCostRB.Checked
                    ? TestType.DpsPerCost
                    : TestType.DpsPerVolume;

                int planarSmokeStrength = (int)PlanarSmokeUD.Value;

                char columnDelimiter = CommaDecimalCB.Checked ? ';' : ',';

                LaserComparer comparer = new(
                    (int)StackLengthUD.Value,
                    (int)StackCountUD.Value,
                    InlineDoublersCB.Checked,
                    (int)CombinerCountUD.Value,
                    (int)MinRechargeUD.Value,
                    (int)MaxRechargeUD.Value,
                    (float)TargetResistanceUD.Value,
                    (int)SmokeStrengthUD.Value,
                    planarSmokeStrength,
                    (float)EnginePpmUD.Value,
                    (float)EnginePpvUD.Value,
                    (float)EnginePpcUD.Value,
                    RequiresFuelCB.Checked,
                    storagePerCost,
                    storagePerVolume,
                    toCompare,
                    (int)TestIntervalUD.Value,
                    columnDelimiter
                    );


                comparer.LaserTest();

                RunTestsButton.Enabled = true;
            }
        }
    }
}
