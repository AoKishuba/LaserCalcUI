
namespace LaserCalcUI
{
    partial class Input
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            StackLengthUD = new NumericUpDown();
            StackLengthLabel = new Label();
            StackCountLabel = new Label();
            StackCountUD = new NumericUpDown();
            TargetResistanceLabel = new Label();
            TargetResistanceUD = new NumericUpDown();
            toolTip1 = new ToolTip(components);
            SmokeStrengthUD = new NumericUpDown();
            PlanarSmokeUD = new NumericUpDown();
            EnginePpmUD = new NumericUpDown();
            EnginePpvUD = new NumericUpDown();
            EnginePpcUD = new NumericUpDown();
            RequiresFuelCB = new CheckBox();
            GenericStorageRB = new RadioButton();
            CargoContainerRB = new RadioButton();
            CoalRB = new RadioButton();
            DpsPerCostRB = new RadioButton();
            DpsPerVolumeRB = new RadioButton();
            TestIntervalUD = new NumericUpDown();
            RunTestsButton = new Button();
            InlineDoublersCB = new CheckBox();
            CombinerCountUD = new NumericUpDown();
            MinRechargeUD = new NumericUpDown();
            MaxRechargeUD = new NumericUpDown();
            SmokeStrengthLabel = new Label();
            EnginePpmLabel = new Label();
            EnginePpvLabel = new Label();
            EnginePpcLabel = new Label();
            StorageTypePanel = new Panel();
            StorageTypeLabel = new Label();
            LaserParametersPanel = new Panel();
            MaxRechargeLabel = new Label();
            MinRechargeLabel = new Label();
            CombinerCountLabel = new Label();
            LaserParametersLabel = new Label();
            TargetDefensesPanel = new Panel();
            label1 = new Label();
            TargetDefensesLabel = new Label();
            EngineStatsPanel = new Panel();
            EngineStatsLabel = new Label();
            TestParametersPanel = new Panel();
            TestPerLabel3 = new Label();
            TestPerLabel2 = new Label();
            TestPerLabel = new Label();
            TestParametersLabel = new Label();
            errorProvider1 = new ErrorProvider(components);
            CommaDecimalCB = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)StackLengthUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StackCountUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TargetResistanceUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SmokeStrengthUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlanarSmokeUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EnginePpmUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EnginePpvUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EnginePpcUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TestIntervalUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CombinerCountUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinRechargeUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxRechargeUD).BeginInit();
            StorageTypePanel.SuspendLayout();
            LaserParametersPanel.SuspendLayout();
            TargetDefensesPanel.SuspendLayout();
            EngineStatsPanel.SuspendLayout();
            TestParametersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // StackLengthUD
            // 
            StackLengthUD.Location = new Point(160, 20);
            StackLengthUD.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            StackLengthUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            StackLengthUD.Name = "StackLengthUD";
            StackLengthUD.Size = new Size(60, 23);
            StackLengthUD.TabIndex = 0;
            StackLengthUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(StackLengthUD, "Max number of laser components in series");
            StackLengthUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // StackLengthLabel
            // 
            StackLengthLabel.AutoSize = true;
            StackLengthLabel.Location = new Point(0, 24);
            StackLengthLabel.Name = "StackLengthLabel";
            StackLengthLabel.Size = new Size(75, 15);
            StackLengthLabel.TabIndex = 1;
            StackLengthLabel.Text = "Stack Length";
            // 
            // StackCountLabel
            // 
            StackCountLabel.AutoSize = true;
            StackCountLabel.Location = new Point(0, 49);
            StackCountLabel.Name = "StackCountLabel";
            StackCountLabel.Size = new Size(71, 15);
            StackCountLabel.TabIndex = 3;
            StackCountLabel.Text = "Stack Count";
            // 
            // StackCountUD
            // 
            StackCountUD.Location = new Point(160, 45);
            StackCountUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            StackCountUD.Name = "StackCountUD";
            StackCountUD.Size = new Size(60, 23);
            StackCountUD.TabIndex = 2;
            StackCountUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(StackCountUD, "Number of parallel stacks of laser components");
            StackCountUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TargetResistanceLabel
            // 
            TargetResistanceLabel.AutoSize = true;
            TargetResistanceLabel.Location = new Point(0, 24);
            TargetResistanceLabel.Name = "TargetResistanceLabel";
            TargetResistanceLabel.Size = new Size(119, 15);
            TargetResistanceLabel.TabIndex = 5;
            TargetResistanceLabel.Text = "Target Fire Resistance";
            // 
            // TargetResistanceUD
            // 
            TargetResistanceUD.DecimalPlaces = 1;
            TargetResistanceUD.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            TargetResistanceUD.Location = new Point(155, 20);
            TargetResistanceUD.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            TargetResistanceUD.Name = "TargetResistanceUD";
            TargetResistanceUD.Size = new Size(60, 23);
            TargetResistanceUD.TabIndex = 4;
            TargetResistanceUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(TargetResistanceUD, "Target Fire Resistance.");
            TargetResistanceUD.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // SmokeStrengthUD
            // 
            SmokeStrengthUD.Location = new Point(155, 45);
            SmokeStrengthUD.Maximum = new decimal(new int[] { 250000, 0, 0, 0 });
            SmokeStrengthUD.Name = "SmokeStrengthUD";
            SmokeStrengthUD.Size = new Size(60, 23);
            SmokeStrengthUD.TabIndex = 6;
            SmokeStrengthUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(SmokeStrengthUD, "Target smoke strength.\r\n1 full-strength smoke dispenser = 25,000 strength\r\nMax 250,000 (10 full-strength dispensers)");
            // 
            // PlanarSmokeUD
            // 
            PlanarSmokeUD.Location = new Point(155, 70);
            PlanarSmokeUD.Maximum = new decimal(new int[] { 1500, 0, 0, 0 });
            PlanarSmokeUD.Name = "PlanarSmokeUD";
            PlanarSmokeUD.Size = new Size(60, 23);
            PlanarSmokeUD.TabIndex = 8;
            PlanarSmokeUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(PlanarSmokeUD, "Target planar shield smoke strength equivalent.\r\nMax 1500");
            // 
            // EnginePpmUD
            // 
            EnginePpmUD.Location = new Point(155, 20);
            EnginePpmUD.Maximum = new decimal(new int[] { 1500, 0, 0, 0 });
            EnginePpmUD.Name = "EnginePpmUD";
            EnginePpmUD.Size = new Size(60, 23);
            EnginePpmUD.TabIndex = 17;
            EnginePpmUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(EnginePpmUD, "Engine Power Per Material");
            EnginePpmUD.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // EnginePpvUD
            // 
            EnginePpvUD.DecimalPlaces = 1;
            EnginePpvUD.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            EnginePpvUD.Location = new Point(155, 45);
            EnginePpvUD.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            EnginePpvUD.Name = "EnginePpvUD";
            EnginePpvUD.Size = new Size(60, 23);
            EnginePpvUD.TabIndex = 20;
            EnginePpvUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(EnginePpvUD, "Engine Power Per Volume");
            EnginePpvUD.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // EnginePpcUD
            // 
            EnginePpcUD.DecimalPlaces = 1;
            EnginePpcUD.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            EnginePpcUD.Location = new Point(155, 70);
            EnginePpcUD.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            EnginePpcUD.Name = "EnginePpcUD";
            EnginePpcUD.Size = new Size(60, 23);
            EnginePpcUD.TabIndex = 22;
            EnginePpcUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(EnginePpcUD, "Engine Power Per Cost");
            EnginePpcUD.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // RequiresFuelCB
            // 
            RequiresFuelCB.AutoSize = true;
            RequiresFuelCB.Location = new Point(0, 99);
            RequiresFuelCB.Name = "RequiresFuelCB";
            RequiresFuelCB.Size = new Size(135, 19);
            RequiresFuelCB.TabIndex = 23;
            RequiresFuelCB.Text = "Requires Fuel Access";
            toolTip1.SetToolTip(RequiresFuelCB, "Check if using a Fuel Engine or Custom Jet Engine.");
            RequiresFuelCB.UseVisualStyleBackColor = true;
            // 
            // GenericStorageRB
            // 
            GenericStorageRB.AutoSize = true;
            GenericStorageRB.Location = new Point(0, 20);
            GenericStorageRB.Name = "GenericStorageRB";
            GenericStorageRB.Size = new Size(65, 19);
            GenericStorageRB.TabIndex = 0;
            GenericStorageRB.TabStop = true;
            GenericStorageRB.Text = "Generic";
            toolTip1.SetToolTip(GenericStorageRB, "Everything in the Material Storage Tab besides Coal and Cargo container.");
            GenericStorageRB.UseVisualStyleBackColor = true;
            // 
            // CargoContainerRB
            // 
            CargoContainerRB.AutoSize = true;
            CargoContainerRB.Location = new Point(0, 45);
            CargoContainerRB.Name = "CargoContainerRB";
            CargoContainerRB.Size = new Size(112, 19);
            CargoContainerRB.TabIndex = 2;
            CargoContainerRB.TabStop = true;
            CargoContainerRB.Text = "Cargo Container";
            toolTip1.SetToolTip(CargoContainerRB, "Cargo container");
            CargoContainerRB.UseVisualStyleBackColor = true;
            // 
            // CoalRB
            // 
            CoalRB.AutoSize = true;
            CoalRB.Location = new Point(0, 70);
            CoalRB.Name = "CoalRB";
            CoalRB.Size = new Size(49, 19);
            CoalRB.TabIndex = 3;
            CoalRB.TabStop = true;
            CoalRB.Text = "Coal";
            toolTip1.SetToolTip(CoalRB, "Coal pile or Coal pile large");
            CoalRB.UseVisualStyleBackColor = true;
            // 
            // DpsPerCostRB
            // 
            DpsPerCostRB.AutoSize = true;
            DpsPerCostRB.Checked = true;
            DpsPerCostRB.Location = new Point(184, 32);
            DpsPerCostRB.Name = "DpsPerCostRB";
            DpsPerCostRB.Size = new Size(47, 19);
            DpsPerCostRB.TabIndex = 13;
            DpsPerCostRB.TabStop = true;
            DpsPerCostRB.Text = "cost";
            toolTip1.SetToolTip(DpsPerCostRB, "Select to optimize for DPS per total system cost");
            DpsPerCostRB.UseVisualStyleBackColor = true;
            // 
            // DpsPerVolumeRB
            // 
            DpsPerVolumeRB.AutoSize = true;
            DpsPerVolumeRB.Location = new Point(184, 57);
            DpsPerVolumeRB.Name = "DpsPerVolumeRB";
            DpsPerVolumeRB.Size = new Size(65, 19);
            DpsPerVolumeRB.TabIndex = 15;
            DpsPerVolumeRB.Text = "volume";
            toolTip1.SetToolTip(DpsPerVolumeRB, "Select to optimize for DPS per total system volume");
            DpsPerVolumeRB.UseVisualStyleBackColor = true;
            // 
            // TestIntervalUD
            // 
            TestIntervalUD.Location = new Point(348, 43);
            TestIntervalUD.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            TestIntervalUD.Name = "TestIntervalUD";
            TestIntervalUD.Size = new Size(35, 23);
            TestIntervalUD.TabIndex = 17;
            TestIntervalUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(TestIntervalUD, "Test interval in minutes. Used for fuel calculations.\r\n");
            TestIntervalUD.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // RunTestsButton
            // 
            RunTestsButton.BackColor = SystemColors.ButtonHighlight;
            RunTestsButton.Location = new Point(0, 82);
            RunTestsButton.Name = "RunTestsButton";
            RunTestsButton.Size = new Size(456, 50);
            RunTestsButton.TabIndex = 11;
            RunTestsButton.Text = "Run Tests";
            toolTip1.SetToolTip(RunTestsButton, "Run test. Results will appear in the LaserCalcUI directory.");
            RunTestsButton.UseVisualStyleBackColor = false;
            RunTestsButton.Click += RunTestsButton_Click;
            // 
            // InlineDoublersCB
            // 
            InlineDoublersCB.AutoSize = true;
            InlineDoublersCB.Location = new Point(0, 74);
            InlineDoublersCB.Name = "InlineDoublersCB";
            InlineDoublersCB.Size = new Size(105, 19);
            InlineDoublersCB.TabIndex = 15;
            InlineDoublersCB.Text = "Inline Doublers";
            toolTip1.SetToolTip(InlineDoublersCB, "Check if frequency doublers will be inline with cavities.\r\nI recommend fitting them between stacks instead.");
            InlineDoublersCB.UseVisualStyleBackColor = true;
            // 
            // CombinerCountUD
            // 
            CombinerCountUD.Location = new Point(160, 95);
            CombinerCountUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CombinerCountUD.Name = "CombinerCountUD";
            CombinerCountUD.Size = new Size(60, 23);
            CombinerCountUD.TabIndex = 17;
            CombinerCountUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(CombinerCountUD, "Number of Laser combiners and LAMS nodes.");
            CombinerCountUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MinRechargeUD
            // 
            MinRechargeUD.Location = new Point(160, 120);
            MinRechargeUD.Name = "MinRechargeUD";
            MinRechargeUD.Size = new Size(60, 23);
            MinRechargeUD.TabIndex = 19;
            MinRechargeUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(MinRechargeUD, "Minimum acceptable recharge time in seconds.\r\nInclusive.");
            MinRechargeUD.Value = new decimal(new int[] { 5, 0, 0, 0 });
            MinRechargeUD.ValueChanged += MinRechargeUD_ValueChanged;
            // 
            // MaxRechargeUD
            // 
            MaxRechargeUD.Location = new Point(160, 145);
            MaxRechargeUD.Name = "MaxRechargeUD";
            MaxRechargeUD.Size = new Size(60, 23);
            MaxRechargeUD.TabIndex = 21;
            MaxRechargeUD.TextAlign = HorizontalAlignment.Right;
            toolTip1.SetToolTip(MaxRechargeUD, "Maximum acceptable recharge time in seconds.\r\nInclusive.");
            MaxRechargeUD.Value = new decimal(new int[] { 15, 0, 0, 0 });
            MaxRechargeUD.ValueChanged += MaxRechargeUD_ValueChanged;
            // 
            // SmokeStrengthLabel
            // 
            SmokeStrengthLabel.AutoSize = true;
            SmokeStrengthLabel.Location = new Point(0, 49);
            SmokeStrengthLabel.Name = "SmokeStrengthLabel";
            SmokeStrengthLabel.Size = new Size(91, 15);
            SmokeStrengthLabel.TabIndex = 7;
            SmokeStrengthLabel.Text = "Smoke Strength";
            // 
            // EnginePpmLabel
            // 
            EnginePpmLabel.AutoSize = true;
            EnginePpmLabel.Location = new Point(0, 24);
            EnginePpmLabel.Name = "EnginePpmLabel";
            EnginePpmLabel.Size = new Size(71, 15);
            EnginePpmLabel.TabIndex = 18;
            EnginePpmLabel.Text = "Engine PPM";
            // 
            // EnginePpvLabel
            // 
            EnginePpvLabel.AutoSize = true;
            EnginePpvLabel.Location = new Point(0, 49);
            EnginePpvLabel.Name = "EnginePpvLabel";
            EnginePpvLabel.Size = new Size(67, 15);
            EnginePpvLabel.TabIndex = 19;
            EnginePpvLabel.Text = "Engine PPV";
            // 
            // EnginePpcLabel
            // 
            EnginePpcLabel.AutoSize = true;
            EnginePpcLabel.Location = new Point(0, 74);
            EnginePpcLabel.Name = "EnginePpcLabel";
            EnginePpcLabel.Size = new Size(68, 15);
            EnginePpcLabel.TabIndex = 21;
            EnginePpcLabel.Text = "Engine PPC";
            // 
            // StorageTypePanel
            // 
            StorageTypePanel.Controls.Add(CoalRB);
            StorageTypePanel.Controls.Add(CargoContainerRB);
            StorageTypePanel.Controls.Add(StorageTypeLabel);
            StorageTypePanel.Controls.Add(GenericStorageRB);
            StorageTypePanel.Location = new Point(10, 195);
            StorageTypePanel.Name = "StorageTypePanel";
            StorageTypePanel.Size = new Size(220, 95);
            StorageTypePanel.TabIndex = 25;
            // 
            // StorageTypeLabel
            // 
            StorageTypeLabel.AutoSize = true;
            StorageTypeLabel.Location = new Point(73, 0);
            StorageTypeLabel.Name = "StorageTypeLabel";
            StorageTypeLabel.Size = new Size(74, 15);
            StorageTypeLabel.TabIndex = 1;
            StorageTypeLabel.Text = "Storage Type";
            // 
            // LaserParametersPanel
            // 
            LaserParametersPanel.Controls.Add(MaxRechargeUD);
            LaserParametersPanel.Controls.Add(MaxRechargeLabel);
            LaserParametersPanel.Controls.Add(MinRechargeUD);
            LaserParametersPanel.Controls.Add(MinRechargeLabel);
            LaserParametersPanel.Controls.Add(CombinerCountUD);
            LaserParametersPanel.Controls.Add(CombinerCountLabel);
            LaserParametersPanel.Controls.Add(LaserParametersLabel);
            LaserParametersPanel.Controls.Add(StackLengthLabel);
            LaserParametersPanel.Controls.Add(InlineDoublersCB);
            LaserParametersPanel.Controls.Add(StackLengthUD);
            LaserParametersPanel.Controls.Add(StackCountUD);
            LaserParametersPanel.Controls.Add(StackCountLabel);
            LaserParametersPanel.Location = new Point(10, 10);
            LaserParametersPanel.Name = "LaserParametersPanel";
            LaserParametersPanel.Size = new Size(220, 170);
            LaserParametersPanel.TabIndex = 26;
            // 
            // MaxRechargeLabel
            // 
            MaxRechargeLabel.AutoSize = true;
            MaxRechargeLabel.Location = new Point(0, 149);
            MaxRechargeLabel.Name = "MaxRechargeLabel";
            MaxRechargeLabel.Size = new Size(139, 15);
            MaxRechargeLabel.TabIndex = 22;
            MaxRechargeLabel.Text = "Max Recharge Time (sec)";
            // 
            // MinRechargeLabel
            // 
            MinRechargeLabel.AutoSize = true;
            MinRechargeLabel.Location = new Point(0, 124);
            MinRechargeLabel.Name = "MinRechargeLabel";
            MinRechargeLabel.Size = new Size(137, 15);
            MinRechargeLabel.TabIndex = 20;
            MinRechargeLabel.Text = "Min Recharge Time (sec)";
            // 
            // CombinerCountLabel
            // 
            CombinerCountLabel.AutoSize = true;
            CombinerCountLabel.Location = new Point(0, 99);
            CombinerCountLabel.Name = "CombinerCountLabel";
            CombinerCountLabel.Size = new Size(96, 15);
            CombinerCountLabel.TabIndex = 18;
            CombinerCountLabel.Text = "Combiner Count";
            // 
            // LaserParametersLabel
            // 
            LaserParametersLabel.AutoSize = true;
            LaserParametersLabel.Location = new Point(60, 0);
            LaserParametersLabel.Name = "LaserParametersLabel";
            LaserParametersLabel.Size = new Size(96, 15);
            LaserParametersLabel.TabIndex = 16;
            LaserParametersLabel.Text = "Laser Parameters";
            // 
            // TargetDefensesPanel
            // 
            TargetDefensesPanel.Controls.Add(label1);
            TargetDefensesPanel.Controls.Add(TargetDefensesLabel);
            TargetDefensesPanel.Controls.Add(PlanarSmokeUD);
            TargetDefensesPanel.Controls.Add(TargetResistanceLabel);
            TargetDefensesPanel.Controls.Add(TargetResistanceUD);
            TargetDefensesPanel.Controls.Add(SmokeStrengthUD);
            TargetDefensesPanel.Controls.Add(SmokeStrengthLabel);
            TargetDefensesPanel.Location = new Point(246, 145);
            TargetDefensesPanel.Name = "TargetDefensesPanel";
            TargetDefensesPanel.Size = new Size(220, 102);
            TargetDefensesPanel.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 74);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 9;
            label1.Text = "Planar Smoke Equivalent";
            // 
            // TargetDefensesLabel
            // 
            TargetDefensesLabel.AutoSize = true;
            TargetDefensesLabel.Location = new Point(65, 0);
            TargetDefensesLabel.Name = "TargetDefensesLabel";
            TargetDefensesLabel.Size = new Size(89, 15);
            TargetDefensesLabel.TabIndex = 0;
            TargetDefensesLabel.Text = "Target Defenses";
            // 
            // EngineStatsPanel
            // 
            EngineStatsPanel.Controls.Add(EngineStatsLabel);
            EngineStatsPanel.Controls.Add(EnginePpmLabel);
            EngineStatsPanel.Controls.Add(EnginePpmUD);
            EngineStatsPanel.Controls.Add(EnginePpvLabel);
            EngineStatsPanel.Controls.Add(RequiresFuelCB);
            EngineStatsPanel.Controls.Add(EnginePpvUD);
            EngineStatsPanel.Controls.Add(EnginePpcUD);
            EngineStatsPanel.Controls.Add(EnginePpcLabel);
            EngineStatsPanel.Location = new Point(246, 10);
            EngineStatsPanel.Name = "EngineStatsPanel";
            EngineStatsPanel.Size = new Size(220, 120);
            EngineStatsPanel.TabIndex = 28;
            // 
            // EngineStatsLabel
            // 
            EngineStatsLabel.AutoSize = true;
            EngineStatsLabel.Location = new Point(74, 0);
            EngineStatsLabel.Name = "EngineStatsLabel";
            EngineStatsLabel.Size = new Size(71, 15);
            EngineStatsLabel.TabIndex = 0;
            EngineStatsLabel.Text = "Engine Stats";
            // 
            // TestParametersPanel
            // 
            TestParametersPanel.Controls.Add(TestPerLabel3);
            TestParametersPanel.Controls.Add(TestIntervalUD);
            TestParametersPanel.Controls.Add(TestPerLabel2);
            TestParametersPanel.Controls.Add(DpsPerVolumeRB);
            TestParametersPanel.Controls.Add(TestPerLabel);
            TestParametersPanel.Controls.Add(DpsPerCostRB);
            TestParametersPanel.Controls.Add(TestParametersLabel);
            TestParametersPanel.Controls.Add(RunTestsButton);
            TestParametersPanel.Location = new Point(10, 303);
            TestParametersPanel.Name = "TestParametersPanel";
            TestParametersPanel.Size = new Size(456, 134);
            TestParametersPanel.TabIndex = 29;
            // 
            // TestPerLabel3
            // 
            TestPerLabel3.AutoSize = true;
            TestPerLabel3.Location = new Point(386, 45);
            TestPerLabel3.Name = "TestPerLabel3";
            TestPerLabel3.Size = new Size(53, 15);
            TestPerLabel3.TabIndex = 18;
            TestPerLabel3.Text = "minutes.";
            // 
            // TestPerLabel2
            // 
            TestPerLabel2.AutoSize = true;
            TestPerLabel2.Location = new Point(245, 45);
            TestPerLabel2.Name = "TestPerLabel2";
            TestPerLabel2.Size = new Size(102, 15);
            TestPerLabel2.TabIndex = 16;
            TestPerLabel2.Text = "over the course of";
            // 
            // TestPerLabel
            // 
            TestPerLabel.AutoSize = true;
            TestPerLabel.Location = new Point(0, 45);
            TestPerLabel.Name = "TestPerLabel";
            TestPerLabel.Size = new Size(184, 15);
            TestPerLabel.TabIndex = 14;
            TestPerLabel.Text = "Optimize for DPS per total system";
            // 
            // TestParametersLabel
            // 
            TestParametersLabel.AutoSize = true;
            TestParametersLabel.Location = new Point(183, 0);
            TestParametersLabel.Name = "TestParametersLabel";
            TestParametersLabel.Size = new Size(89, 15);
            TestParametersLabel.TabIndex = 12;
            TestParametersLabel.Text = "Test Parameters";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CommaDecimalCB
            // 
            CommaDecimalCB.AutoSize = true;
            CommaDecimalCB.Location = new Point(246, 266);
            CommaDecimalCB.Name = "CommaDecimalCB";
            CommaDecimalCB.Size = new Size(168, 19);
            CommaDecimalCB.TabIndex = 30;
            CommaDecimalCB.Text = "Comma Decimal Separator";
            toolTip1.SetToolTip(CommaDecimalCB, "Check if your computer displays \"five and three tenths\" as 5,3 (with a comma)");
            CommaDecimalCB.UseVisualStyleBackColor = true;
            // 
            // Input
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 444);
            Controls.Add(CommaDecimalCB);
            Controls.Add(EngineStatsPanel);
            Controls.Add(TargetDefensesPanel);
            Controls.Add(LaserParametersPanel);
            Controls.Add(StorageTypePanel);
            Controls.Add(TestParametersPanel);
            Name = "Input";
            Text = "Laser Calc";
            ((System.ComponentModel.ISupportInitialize)StackLengthUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)StackCountUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)TargetResistanceUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)SmokeStrengthUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlanarSmokeUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)EnginePpmUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)EnginePpvUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)EnginePpcUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)TestIntervalUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)CombinerCountUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinRechargeUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxRechargeUD).EndInit();
            StorageTypePanel.ResumeLayout(false);
            StorageTypePanel.PerformLayout();
            LaserParametersPanel.ResumeLayout(false);
            LaserParametersPanel.PerformLayout();
            TargetDefensesPanel.ResumeLayout(false);
            TargetDefensesPanel.PerformLayout();
            EngineStatsPanel.ResumeLayout(false);
            EngineStatsPanel.PerformLayout();
            TestParametersPanel.ResumeLayout(false);
            TestParametersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NumericUpDown StackLengthUD;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label StackLengthLabel;
        private System.Windows.Forms.Label StackCountLabel;
        private System.Windows.Forms.NumericUpDown StackCountUD;
        private System.Windows.Forms.Label TargetResistanceLabel;
        private System.Windows.Forms.NumericUpDown TargetResistanceUD;
        private System.Windows.Forms.Label SmokeStrengthLabel;
        private System.Windows.Forms.NumericUpDown SmokeStrengthUD;
        private System.Windows.Forms.NumericUpDown PlanarSmokeUD;
        private System.Windows.Forms.Button RunTestsButton;
        private System.Windows.Forms.CheckBox InlineDoublersCB;
        private System.Windows.Forms.NumericUpDown EnginePpmUD;
        private System.Windows.Forms.Label EnginePpmLabel;
        private System.Windows.Forms.Label EnginePpvLabel;
        private System.Windows.Forms.NumericUpDown EnginePpvUD;
        private System.Windows.Forms.NumericUpDown EnginePpcUD;
        private System.Windows.Forms.Label EnginePpcLabel;
        private System.Windows.Forms.CheckBox RequiresFuelCB;
        private System.Windows.Forms.Panel StorageTypePanel;
        private System.Windows.Forms.Label StorageTypeLabel;
        private System.Windows.Forms.RadioButton GenericStorageRB;
        private System.Windows.Forms.Panel LaserParametersPanel;
        private System.Windows.Forms.Label LaserParametersLabel;
        private System.Windows.Forms.Panel TargetDefensesPanel;
        private System.Windows.Forms.Label TargetDefensesLabel;
        private System.Windows.Forms.Panel EngineStatsPanel;
        private System.Windows.Forms.Label EngineStatsLabel;
        private System.Windows.Forms.RadioButton CoalRB;
        private System.Windows.Forms.RadioButton CargoContainerRB;
        private System.Windows.Forms.Panel TestParametersPanel;
        private System.Windows.Forms.Label TestPerLabel3;
        private System.Windows.Forms.NumericUpDown TestIntervalUD;
        private System.Windows.Forms.Label TestPerLabel2;
        private System.Windows.Forms.RadioButton DpsPerVolumeRB;
        private System.Windows.Forms.Label TestPerLabel;
        private System.Windows.Forms.RadioButton DpsPerCostRB;
        private System.Windows.Forms.Label TestParametersLabel;
        private System.Windows.Forms.NumericUpDown CombinerCountUD;
        private System.Windows.Forms.Label CombinerCountLabel;
        private System.Windows.Forms.NumericUpDown MaxRechargeUD;
        private System.Windows.Forms.Label MaxRechargeLabel;
        private System.Windows.Forms.NumericUpDown MinRechargeUD;
        private System.Windows.Forms.Label MinRechargeLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Label label1;
        private CheckBox CommaDecimalCB;
    }
}

