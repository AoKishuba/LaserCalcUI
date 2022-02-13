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

            float ringACBonus = RingACRB.Checked
                ? (float)RingACUD.Value
                : 0;

            int planarSmokeStrength = PlanarSmokeRB.Checked
                ? (int)PlanarSmokeUD.Value
                : 0;

            LaserComparer comparer = new(
                (int)StackLengthUD.Value,
                (int)StackCountUD.Value,
                InlineDoublersCB.Checked,
                (int)CombinerCountUD.Value,
                (int)MinRechargeUD.Value,
                (int)MaxRechargeUD.Value,
                (float)TargetACUD.Value,
                ringACBonus,
                (int)SmokeStrengthUD.Value,
                planarSmokeStrength,
                (float)EnginePpmUD.Value,
                (float)EnginePpvUD.Value,
                (float)EnginePpcUD.Value,
                RequiresFuelCB.Checked,
                storagePerCost,
                storagePerVolume,
                toCompare,
                (int)TestIntervalUD.Value
                );

            comparer.LaserTestCascade();

            RunTestsButton.Enabled = true;
        }
    }
}
