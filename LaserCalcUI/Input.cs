namespace LaserCalcUI
{
    readonly record struct FireResistanceItem(float ID, string Text);

    readonly record struct LayerItem(Layer ID, string Text);

    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();

            FireResistanceItem[] fireResistances =
            [
                new FireResistanceItem(Layer.WoodFR, $"{Layer.WoodFR}, wood"),
                new FireResistanceItem(Layer.MetalFR, $"{Layer.MetalFR}, metal"),
                new FireResistanceItem(Layer.StoneFR, $"{Layer.StoneFR}, stone"),
                new FireResistanceItem(Layer.AlloyFR, $"{Layer.AlloyFR}, alloy"),
                new FireResistanceItem(Layer.HeavyFR, $"{Layer.HeavyFR}, heavy"),
            ];
            ResistanceDD.DisplayMember = "Text";
            ResistanceDD.DataSource = fireResistances;
            ResistanceDD.SelectedIndex = 0;

            ArmorLayerDD.DisplayMember = "Text";
            foreach (Layer layer in Layer.AllLayers)
            {
                ArmorLayerDD.Items.Add(new LayerItem(layer, layer.Name));
            }
            ArmorLayerDD.SelectedIndex = 0;

            LayerLB.DisplayMember = "Text";

            TargetSchemePanel.Enabled = PendepthCB.Checked;
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

            int[] qSwitchCounts;
            if (TestZeroQCB.Checked && TestQSwitchedCB.Checked)
            {
                qSwitchCounts = [0, (int)QSwitchCountUD.Value];
            }
            else if (!TestZeroQCB.Checked)
            {
                qSwitchCounts = [(int)QSwitchCountUD.Value];
            }
            else
            {
                qSwitchCounts = [0];
            }

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

            List<Layer> layerList;
            if (LayerLB.Items.Count == 0 || !PendepthCB.Checked)
            {
                layerList = [Layer.Air];
            }
            else
            {
                layerList = [];
                for (int layerIndex = 0; layerIndex < LayerLB.Items.Count; layerIndex++)
                {
                    layerList.Add(((LayerItem)LayerLB.Items[layerIndex]).ID);
                }
            }
            Scheme targetArmorScheme = new(layerList);

            TestType testType = DpsPerCostRB.Checked
                ? TestType.DpsPerCost
                : TestType.DpsPerVolume;

            int planarSmokeStrength = (int)PlanarSmokeUD.Value;

            char columnDelimiter = CommaDecimalCB.Checked ? ';' : ',';

            LaserComparer comparer = new(
                (int)StackLengthUD.Value,
                (int)StackCountUD.Value,
                InlineDoublersCB.Checked,
                (int)CombinerCountUD.Value,
                qSwitchCounts,
                (int)MinRechargeUD.Value,
                (int)MaxRechargeUD.Value,
                ((FireResistanceItem)ResistanceDD.SelectedItem).ID,
                (int)SmokeStrengthUD.Value,
                planarSmokeStrength,
                (float)EnginePpmUD.Value,
                (float)EnginePpvUD.Value,
                (float)EnginePpcUD.Value,
                RequiresFuelCB.Checked,
                storagePerCost,
                storagePerVolume,
                targetArmorScheme,
                testType,
                (int)TestIntervalUD.Value,
                columnDelimiter
                );


            comparer.BigTest();

            RunTestsButton.Enabled = true;
        }

        // At least one CB must be checked
        private void TestZeroQCB_CheckedChanged(object sender, EventArgs e)
        {
            TestQSwitchedCB.Enabled = TestZeroQCB.Checked;
            if (TestZeroQCB.Checked)
            {
                PendepthCB.Enabled = false;
                PendepthCB.Checked = false;
            }
            else
            {
                PendepthCB.Enabled = true;
                TestQSwitchedCB.Checked = true;
            }
        }

        private void TestQSwitchedCB_CheckedChanged(object sender, EventArgs e)
        {
            TestZeroQCB.Enabled = TestQSwitchedCB.Checked;
            if (!TestQSwitchedCB.Checked)
            {
                TestZeroQCB.Checked = true;
            }
        }

        private void PendepthCB_CheckedChanged(object sender, EventArgs e)
        {
            TargetSchemePanel.Enabled = PendepthCB.Checked;
            LayerLB.Enabled = PendepthCB.Checked;
            ArmorLayerDD.Enabled = PendepthCB.Checked;
        }

        private void AddLayerButton_Click(object sender, EventArgs e)
        {
            if (ArmorLayerDD.SelectedItem != null)
            {
                LayerLB.BeginUpdate();
                LayerLB.Items.Add((LayerItem)ArmorLayerDD.SelectedItem);
                LayerLB.EndUpdate();
            }
        }

        private void DeleteLayerButton_Click(object sender, EventArgs e)
        {
            if (LayerLB.Items.Count > 0)
            {
                LayerLB.BeginUpdate();
                LayerLB.Items.Remove(LayerLB.Items[^1]);
                LayerLB.EndUpdate();
            }
        }
    }
}
