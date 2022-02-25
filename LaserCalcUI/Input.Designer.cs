
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
            this.components = new System.ComponentModel.Container();
            this.StackLengthUD = new System.Windows.Forms.NumericUpDown();
            this.StackLengthLabel = new System.Windows.Forms.Label();
            this.StackCountLabel = new System.Windows.Forms.Label();
            this.StackCountUD = new System.Windows.Forms.NumericUpDown();
            this.TargetACLabel = new System.Windows.Forms.Label();
            this.TargetACUD = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SmokeStrengthUD = new System.Windows.Forms.NumericUpDown();
            this.PlanarSmokeUD = new System.Windows.Forms.NumericUpDown();
            this.RingACUD = new System.Windows.Forms.NumericUpDown();
            this.EnginePpmUD = new System.Windows.Forms.NumericUpDown();
            this.EnginePpvUD = new System.Windows.Forms.NumericUpDown();
            this.EnginePpcUD = new System.Windows.Forms.NumericUpDown();
            this.RequiresFuelCB = new System.Windows.Forms.CheckBox();
            this.GenericStorageRB = new System.Windows.Forms.RadioButton();
            this.CargoContainerRB = new System.Windows.Forms.RadioButton();
            this.CoalRB = new System.Windows.Forms.RadioButton();
            this.DpsPerCostRB = new System.Windows.Forms.RadioButton();
            this.DpsPerVolumeRB = new System.Windows.Forms.RadioButton();
            this.TestIntervalUD = new System.Windows.Forms.NumericUpDown();
            this.RunTestsButton = new System.Windows.Forms.Button();
            this.InlineDoublersCB = new System.Windows.Forms.CheckBox();
            this.CombinerCountUD = new System.Windows.Forms.NumericUpDown();
            this.MinRechargeUD = new System.Windows.Forms.NumericUpDown();
            this.MaxRechargeUD = new System.Windows.Forms.NumericUpDown();
            this.SmokeStrengthLabel = new System.Windows.Forms.Label();
            this.PlanarSmokeRB = new System.Windows.Forms.RadioButton();
            this.RingACRB = new System.Windows.Forms.RadioButton();
            this.EnginePpmLabel = new System.Windows.Forms.Label();
            this.EnginePpvLabel = new System.Windows.Forms.Label();
            this.EnginePpcLabel = new System.Windows.Forms.Label();
            this.StorageTypePanel = new System.Windows.Forms.Panel();
            this.StorageTypeLabel = new System.Windows.Forms.Label();
            this.LaserParametersPanel = new System.Windows.Forms.Panel();
            this.MaxRechargeLabel = new System.Windows.Forms.Label();
            this.MinRechargeLabel = new System.Windows.Forms.Label();
            this.CombinerCountLabel = new System.Windows.Forms.Label();
            this.LaserParametersLabel = new System.Windows.Forms.Label();
            this.TargetDefensesPanel = new System.Windows.Forms.Panel();
            this.TargetDefensesLabel = new System.Windows.Forms.Label();
            this.EngineStatsPanel = new System.Windows.Forms.Panel();
            this.EngineStatsLabel = new System.Windows.Forms.Label();
            this.TestParametersPanel = new System.Windows.Forms.Panel();
            this.TestPerLabel3 = new System.Windows.Forms.Label();
            this.TestPerLabel2 = new System.Windows.Forms.Label();
            this.TestPerLabel = new System.Windows.Forms.Label();
            this.TestParametersLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StackLengthUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StackCountUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetACUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmokeStrengthUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanarSmokeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RingACUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnginePpmUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnginePpvUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnginePpcUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestIntervalUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CombinerCountUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRechargeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRechargeUD)).BeginInit();
            this.StorageTypePanel.SuspendLayout();
            this.LaserParametersPanel.SuspendLayout();
            this.TargetDefensesPanel.SuspendLayout();
            this.EngineStatsPanel.SuspendLayout();
            this.TestParametersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // StackLengthUD
            // 
            this.StackLengthUD.Location = new System.Drawing.Point(160, 20);
            this.StackLengthUD.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.StackLengthUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StackLengthUD.Name = "StackLengthUD";
            this.StackLengthUD.Size = new System.Drawing.Size(60, 23);
            this.StackLengthUD.TabIndex = 0;
            this.StackLengthUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.StackLengthUD, "Max number of laser components in series");
            this.StackLengthUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StackLengthLabel
            // 
            this.StackLengthLabel.AutoSize = true;
            this.StackLengthLabel.Location = new System.Drawing.Point(0, 24);
            this.StackLengthLabel.Name = "StackLengthLabel";
            this.StackLengthLabel.Size = new System.Drawing.Size(75, 15);
            this.StackLengthLabel.TabIndex = 1;
            this.StackLengthLabel.Text = "Stack Length";
            // 
            // StackCountLabel
            // 
            this.StackCountLabel.AutoSize = true;
            this.StackCountLabel.Location = new System.Drawing.Point(0, 49);
            this.StackCountLabel.Name = "StackCountLabel";
            this.StackCountLabel.Size = new System.Drawing.Size(71, 15);
            this.StackCountLabel.TabIndex = 3;
            this.StackCountLabel.Text = "Stack Count";
            // 
            // StackCountUD
            // 
            this.StackCountUD.Location = new System.Drawing.Point(160, 45);
            this.StackCountUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StackCountUD.Name = "StackCountUD";
            this.StackCountUD.Size = new System.Drawing.Size(60, 23);
            this.StackCountUD.TabIndex = 2;
            this.StackCountUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.StackCountUD, "Number of parallel stacks of laser components");
            this.StackCountUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TargetACLabel
            // 
            this.TargetACLabel.AutoSize = true;
            this.TargetACLabel.Location = new System.Drawing.Point(0, 24);
            this.TargetACLabel.Name = "TargetACLabel";
            this.TargetACLabel.Size = new System.Drawing.Size(58, 15);
            this.TargetACLabel.TabIndex = 5;
            this.TargetACLabel.Text = "Target AC";
            // 
            // TargetACUD
            // 
            this.TargetACUD.DecimalPlaces = 1;
            this.TargetACUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TargetACUD.Location = new System.Drawing.Point(155, 20);
            this.TargetACUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TargetACUD.Name = "TargetACUD";
            this.TargetACUD.Size = new System.Drawing.Size(60, 23);
            this.TargetACUD.TabIndex = 4;
            this.TargetACUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.TargetACUD, "Target Armour Class.\r\nNote that lasers ignore armour stacking.");
            this.TargetACUD.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // SmokeStrengthUD
            // 
            this.SmokeStrengthUD.Location = new System.Drawing.Point(155, 45);
            this.SmokeStrengthUD.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.SmokeStrengthUD.Name = "SmokeStrengthUD";
            this.SmokeStrengthUD.Size = new System.Drawing.Size(60, 23);
            this.SmokeStrengthUD.TabIndex = 6;
            this.SmokeStrengthUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.SmokeStrengthUD, "Target smoke strength.\r\n1 full-strength smoke dispenser = 25,000 strength\r\nMax 25" +
        "0,000 (10 full-strength dispensers)");
            // 
            // PlanarSmokeUD
            // 
            this.PlanarSmokeUD.Location = new System.Drawing.Point(155, 70);
            this.PlanarSmokeUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PlanarSmokeUD.Name = "PlanarSmokeUD";
            this.PlanarSmokeUD.Size = new System.Drawing.Size(60, 23);
            this.PlanarSmokeUD.TabIndex = 8;
            this.PlanarSmokeUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.PlanarSmokeUD, "Target planar shield smoke strength equivalent.\r\nMax 1000");
            // 
            // RingACUD
            // 
            this.RingACUD.DecimalPlaces = 1;
            this.RingACUD.Enabled = false;
            this.RingACUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RingACUD.Location = new System.Drawing.Point(155, 95);
            this.RingACUD.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RingACUD.Name = "RingACUD";
            this.RingACUD.Size = new System.Drawing.Size(60, 23);
            this.RingACUD.TabIndex = 14;
            this.RingACUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.RingACUD, "Target planar shield strength.\r\nMax 20");
            // 
            // EnginePpmUD
            // 
            this.EnginePpmUD.Location = new System.Drawing.Point(155, 20);
            this.EnginePpmUD.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.EnginePpmUD.Name = "EnginePpmUD";
            this.EnginePpmUD.Size = new System.Drawing.Size(60, 23);
            this.EnginePpmUD.TabIndex = 17;
            this.EnginePpmUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.EnginePpmUD, "Engine Power Per Material");
            // 
            // EnginePpvUD
            // 
            this.EnginePpvUD.DecimalPlaces = 1;
            this.EnginePpvUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.EnginePpvUD.Location = new System.Drawing.Point(155, 45);
            this.EnginePpvUD.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.EnginePpvUD.Name = "EnginePpvUD";
            this.EnginePpvUD.Size = new System.Drawing.Size(60, 23);
            this.EnginePpvUD.TabIndex = 20;
            this.EnginePpvUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.EnginePpvUD, "Engine Power Per Volume");
            // 
            // EnginePpcUD
            // 
            this.EnginePpcUD.DecimalPlaces = 1;
            this.EnginePpcUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.EnginePpcUD.Location = new System.Drawing.Point(155, 70);
            this.EnginePpcUD.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.EnginePpcUD.Name = "EnginePpcUD";
            this.EnginePpcUD.Size = new System.Drawing.Size(60, 23);
            this.EnginePpcUD.TabIndex = 22;
            this.EnginePpcUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.EnginePpcUD, "Engine Power Per Cost");
            // 
            // RequiresFuelCB
            // 
            this.RequiresFuelCB.AutoSize = true;
            this.RequiresFuelCB.Location = new System.Drawing.Point(0, 99);
            this.RequiresFuelCB.Name = "RequiresFuelCB";
            this.RequiresFuelCB.Size = new System.Drawing.Size(135, 19);
            this.RequiresFuelCB.TabIndex = 23;
            this.RequiresFuelCB.Text = "Requires Fuel Access";
            this.toolTip1.SetToolTip(this.RequiresFuelCB, "Check if using a Fuel Engine or Custom Jet Engine.");
            this.RequiresFuelCB.UseVisualStyleBackColor = true;
            // 
            // GenericStorageRB
            // 
            this.GenericStorageRB.AutoSize = true;
            this.GenericStorageRB.Location = new System.Drawing.Point(0, 20);
            this.GenericStorageRB.Name = "GenericStorageRB";
            this.GenericStorageRB.Size = new System.Drawing.Size(65, 19);
            this.GenericStorageRB.TabIndex = 0;
            this.GenericStorageRB.TabStop = true;
            this.GenericStorageRB.Text = "Generic";
            this.toolTip1.SetToolTip(this.GenericStorageRB, "Everything in the Material Storage Tab besides Coal and Cargo container.");
            this.GenericStorageRB.UseVisualStyleBackColor = true;
            // 
            // CargoContainerRB
            // 
            this.CargoContainerRB.AutoSize = true;
            this.CargoContainerRB.Location = new System.Drawing.Point(0, 45);
            this.CargoContainerRB.Name = "CargoContainerRB";
            this.CargoContainerRB.Size = new System.Drawing.Size(112, 19);
            this.CargoContainerRB.TabIndex = 2;
            this.CargoContainerRB.TabStop = true;
            this.CargoContainerRB.Text = "Cargo Container";
            this.toolTip1.SetToolTip(this.CargoContainerRB, "Cargo container");
            this.CargoContainerRB.UseVisualStyleBackColor = true;
            // 
            // CoalRB
            // 
            this.CoalRB.AutoSize = true;
            this.CoalRB.Location = new System.Drawing.Point(0, 70);
            this.CoalRB.Name = "CoalRB";
            this.CoalRB.Size = new System.Drawing.Size(49, 19);
            this.CoalRB.TabIndex = 3;
            this.CoalRB.TabStop = true;
            this.CoalRB.Text = "Coal";
            this.toolTip1.SetToolTip(this.CoalRB, "Coal pile or Coal pile large");
            this.CoalRB.UseVisualStyleBackColor = true;
            // 
            // DpsPerCostRB
            // 
            this.DpsPerCostRB.AutoSize = true;
            this.DpsPerCostRB.Checked = true;
            this.DpsPerCostRB.Location = new System.Drawing.Point(184, 32);
            this.DpsPerCostRB.Name = "DpsPerCostRB";
            this.DpsPerCostRB.Size = new System.Drawing.Size(47, 19);
            this.DpsPerCostRB.TabIndex = 13;
            this.DpsPerCostRB.TabStop = true;
            this.DpsPerCostRB.Text = "cost";
            this.toolTip1.SetToolTip(this.DpsPerCostRB, "Select to optimize for DPS per total system cost");
            this.DpsPerCostRB.UseVisualStyleBackColor = true;
            // 
            // DpsPerVolumeRB
            // 
            this.DpsPerVolumeRB.AutoSize = true;
            this.DpsPerVolumeRB.Location = new System.Drawing.Point(184, 57);
            this.DpsPerVolumeRB.Name = "DpsPerVolumeRB";
            this.DpsPerVolumeRB.Size = new System.Drawing.Size(65, 19);
            this.DpsPerVolumeRB.TabIndex = 15;
            this.DpsPerVolumeRB.Text = "volume";
            this.toolTip1.SetToolTip(this.DpsPerVolumeRB, "Select to optimize for DPS per total system volume");
            this.DpsPerVolumeRB.UseVisualStyleBackColor = true;
            // 
            // TestIntervalUD
            // 
            this.TestIntervalUD.Location = new System.Drawing.Point(348, 43);
            this.TestIntervalUD.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.TestIntervalUD.Name = "TestIntervalUD";
            this.TestIntervalUD.Size = new System.Drawing.Size(35, 23);
            this.TestIntervalUD.TabIndex = 17;
            this.TestIntervalUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.TestIntervalUD, "Test interval in minutes. Used for fuel calculations.\r\n");
            this.TestIntervalUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // RunTestsButton
            // 
            this.RunTestsButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RunTestsButton.Location = new System.Drawing.Point(0, 82);
            this.RunTestsButton.Name = "RunTestsButton";
            this.RunTestsButton.Size = new System.Drawing.Size(456, 50);
            this.RunTestsButton.TabIndex = 11;
            this.RunTestsButton.Text = "Run Tests";
            this.toolTip1.SetToolTip(this.RunTestsButton, "Run test. Results will appear in the LaserCalcUI directory.");
            this.RunTestsButton.UseVisualStyleBackColor = false;
            this.RunTestsButton.Click += new System.EventHandler(this.RunTestsButton_Click);
            // 
            // InlineDoublersCB
            // 
            this.InlineDoublersCB.AutoSize = true;
            this.InlineDoublersCB.Location = new System.Drawing.Point(0, 74);
            this.InlineDoublersCB.Name = "InlineDoublersCB";
            this.InlineDoublersCB.Size = new System.Drawing.Size(105, 19);
            this.InlineDoublersCB.TabIndex = 15;
            this.InlineDoublersCB.Text = "Inline Doublers";
            this.toolTip1.SetToolTip(this.InlineDoublersCB, "Check if frequency doublers will be inline with cavities.\r\nI recommend fitting th" +
        "em between stacks instead.");
            this.InlineDoublersCB.UseVisualStyleBackColor = true;
            // 
            // CombinerCountUD
            // 
            this.CombinerCountUD.Location = new System.Drawing.Point(160, 95);
            this.CombinerCountUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CombinerCountUD.Name = "CombinerCountUD";
            this.CombinerCountUD.Size = new System.Drawing.Size(60, 23);
            this.CombinerCountUD.TabIndex = 17;
            this.CombinerCountUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.CombinerCountUD, "Number of Laser combiners and LAMS nodes.");
            this.CombinerCountUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MinRechargeUD
            // 
            this.MinRechargeUD.Location = new System.Drawing.Point(160, 120);
            this.MinRechargeUD.Name = "MinRechargeUD";
            this.MinRechargeUD.Size = new System.Drawing.Size(60, 23);
            this.MinRechargeUD.TabIndex = 19;
            this.MinRechargeUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.MinRechargeUD, "Minimum acceptable recharge time in seconds.\r\nInclusive.");
            this.MinRechargeUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MinRechargeUD.ValueChanged += new System.EventHandler(this.MinRechargeUD_ValueChanged);
            // 
            // MaxRechargeUD
            // 
            this.MaxRechargeUD.Location = new System.Drawing.Point(160, 145);
            this.MaxRechargeUD.Name = "MaxRechargeUD";
            this.MaxRechargeUD.Size = new System.Drawing.Size(60, 23);
            this.MaxRechargeUD.TabIndex = 21;
            this.MaxRechargeUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.MaxRechargeUD, "Maximum acceptable recharge time in seconds.\r\nInclusive.");
            this.MaxRechargeUD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.MaxRechargeUD.ValueChanged += new System.EventHandler(this.MaxRechargeUD_ValueChanged);
            // 
            // SmokeStrengthLabel
            // 
            this.SmokeStrengthLabel.AutoSize = true;
            this.SmokeStrengthLabel.Location = new System.Drawing.Point(0, 49);
            this.SmokeStrengthLabel.Name = "SmokeStrengthLabel";
            this.SmokeStrengthLabel.Size = new System.Drawing.Size(91, 15);
            this.SmokeStrengthLabel.TabIndex = 7;
            this.SmokeStrengthLabel.Text = "Smoke Strength";
            // 
            // PlanarSmokeRB
            // 
            this.PlanarSmokeRB.AutoSize = true;
            this.PlanarSmokeRB.Checked = true;
            this.PlanarSmokeRB.Location = new System.Drawing.Point(0, 74);
            this.PlanarSmokeRB.Name = "PlanarSmokeRB";
            this.PlanarSmokeRB.Size = new System.Drawing.Size(155, 19);
            this.PlanarSmokeRB.TabIndex = 12;
            this.PlanarSmokeRB.TabStop = true;
            this.PlanarSmokeRB.Text = "Planar Smoke Equivalent";
            this.PlanarSmokeRB.UseVisualStyleBackColor = true;
            this.PlanarSmokeRB.CheckedChanged += new System.EventHandler(this.PlanarSmokeRB_CheckedChanged);
            // 
            // RingACRB
            // 
            this.RingACRB.AutoSize = true;
            this.RingACRB.Location = new System.Drawing.Point(0, 99);
            this.RingACRB.Name = "RingACRB";
            this.RingACRB.Size = new System.Drawing.Size(139, 19);
            this.RingACRB.TabIndex = 13;
            this.RingACRB.Text = "Ring Shield AC Bonus";
            this.RingACRB.UseVisualStyleBackColor = true;
            this.RingACRB.CheckedChanged += new System.EventHandler(this.RingACRB_CheckedChanged);
            // 
            // EnginePpmLabel
            // 
            this.EnginePpmLabel.AutoSize = true;
            this.EnginePpmLabel.Location = new System.Drawing.Point(0, 24);
            this.EnginePpmLabel.Name = "EnginePpmLabel";
            this.EnginePpmLabel.Size = new System.Drawing.Size(71, 15);
            this.EnginePpmLabel.TabIndex = 18;
            this.EnginePpmLabel.Text = "Engine PPM";
            // 
            // EnginePpvLabel
            // 
            this.EnginePpvLabel.AutoSize = true;
            this.EnginePpvLabel.Location = new System.Drawing.Point(0, 49);
            this.EnginePpvLabel.Name = "EnginePpvLabel";
            this.EnginePpvLabel.Size = new System.Drawing.Size(67, 15);
            this.EnginePpvLabel.TabIndex = 19;
            this.EnginePpvLabel.Text = "Engine PPV";
            // 
            // EnginePpcLabel
            // 
            this.EnginePpcLabel.AutoSize = true;
            this.EnginePpcLabel.Location = new System.Drawing.Point(0, 74);
            this.EnginePpcLabel.Name = "EnginePpcLabel";
            this.EnginePpcLabel.Size = new System.Drawing.Size(68, 15);
            this.EnginePpcLabel.TabIndex = 21;
            this.EnginePpcLabel.Text = "Engine PPC";
            // 
            // StorageTypePanel
            // 
            this.StorageTypePanel.Controls.Add(this.CoalRB);
            this.StorageTypePanel.Controls.Add(this.CargoContainerRB);
            this.StorageTypePanel.Controls.Add(this.StorageTypeLabel);
            this.StorageTypePanel.Controls.Add(this.GenericStorageRB);
            this.StorageTypePanel.Location = new System.Drawing.Point(10, 195);
            this.StorageTypePanel.Name = "StorageTypePanel";
            this.StorageTypePanel.Size = new System.Drawing.Size(220, 95);
            this.StorageTypePanel.TabIndex = 25;
            // 
            // StorageTypeLabel
            // 
            this.StorageTypeLabel.AutoSize = true;
            this.StorageTypeLabel.Location = new System.Drawing.Point(73, 0);
            this.StorageTypeLabel.Name = "StorageTypeLabel";
            this.StorageTypeLabel.Size = new System.Drawing.Size(74, 15);
            this.StorageTypeLabel.TabIndex = 1;
            this.StorageTypeLabel.Text = "Storage Type";
            // 
            // LaserParametersPanel
            // 
            this.LaserParametersPanel.Controls.Add(this.MaxRechargeUD);
            this.LaserParametersPanel.Controls.Add(this.MaxRechargeLabel);
            this.LaserParametersPanel.Controls.Add(this.MinRechargeUD);
            this.LaserParametersPanel.Controls.Add(this.MinRechargeLabel);
            this.LaserParametersPanel.Controls.Add(this.CombinerCountUD);
            this.LaserParametersPanel.Controls.Add(this.CombinerCountLabel);
            this.LaserParametersPanel.Controls.Add(this.LaserParametersLabel);
            this.LaserParametersPanel.Controls.Add(this.StackLengthLabel);
            this.LaserParametersPanel.Controls.Add(this.InlineDoublersCB);
            this.LaserParametersPanel.Controls.Add(this.StackLengthUD);
            this.LaserParametersPanel.Controls.Add(this.StackCountUD);
            this.LaserParametersPanel.Controls.Add(this.StackCountLabel);
            this.LaserParametersPanel.Location = new System.Drawing.Point(10, 10);
            this.LaserParametersPanel.Name = "LaserParametersPanel";
            this.LaserParametersPanel.Size = new System.Drawing.Size(220, 170);
            this.LaserParametersPanel.TabIndex = 26;
            // 
            // MaxRechargeLabel
            // 
            this.MaxRechargeLabel.AutoSize = true;
            this.MaxRechargeLabel.Location = new System.Drawing.Point(0, 149);
            this.MaxRechargeLabel.Name = "MaxRechargeLabel";
            this.MaxRechargeLabel.Size = new System.Drawing.Size(139, 15);
            this.MaxRechargeLabel.TabIndex = 22;
            this.MaxRechargeLabel.Text = "Max Recharge Time (sec)";
            // 
            // MinRechargeLabel
            // 
            this.MinRechargeLabel.AutoSize = true;
            this.MinRechargeLabel.Location = new System.Drawing.Point(0, 124);
            this.MinRechargeLabel.Name = "MinRechargeLabel";
            this.MinRechargeLabel.Size = new System.Drawing.Size(137, 15);
            this.MinRechargeLabel.TabIndex = 20;
            this.MinRechargeLabel.Text = "Min Recharge Time (sec)";
            // 
            // CombinerCountLabel
            // 
            this.CombinerCountLabel.AutoSize = true;
            this.CombinerCountLabel.Location = new System.Drawing.Point(0, 99);
            this.CombinerCountLabel.Name = "CombinerCountLabel";
            this.CombinerCountLabel.Size = new System.Drawing.Size(96, 15);
            this.CombinerCountLabel.TabIndex = 18;
            this.CombinerCountLabel.Text = "Combiner Count";
            // 
            // LaserParametersLabel
            // 
            this.LaserParametersLabel.AutoSize = true;
            this.LaserParametersLabel.Location = new System.Drawing.Point(60, 0);
            this.LaserParametersLabel.Name = "LaserParametersLabel";
            this.LaserParametersLabel.Size = new System.Drawing.Size(96, 15);
            this.LaserParametersLabel.TabIndex = 16;
            this.LaserParametersLabel.Text = "Laser Parameters";
            // 
            // TargetDefensesPanel
            // 
            this.TargetDefensesPanel.Controls.Add(this.PlanarSmokeRB);
            this.TargetDefensesPanel.Controls.Add(this.RingACRB);
            this.TargetDefensesPanel.Controls.Add(this.TargetDefensesLabel);
            this.TargetDefensesPanel.Controls.Add(this.PlanarSmokeUD);
            this.TargetDefensesPanel.Controls.Add(this.TargetACLabel);
            this.TargetDefensesPanel.Controls.Add(this.RingACUD);
            this.TargetDefensesPanel.Controls.Add(this.TargetACUD);
            this.TargetDefensesPanel.Controls.Add(this.SmokeStrengthUD);
            this.TargetDefensesPanel.Controls.Add(this.SmokeStrengthLabel);
            this.TargetDefensesPanel.Location = new System.Drawing.Point(246, 145);
            this.TargetDefensesPanel.Name = "TargetDefensesPanel";
            this.TargetDefensesPanel.Size = new System.Drawing.Size(220, 120);
            this.TargetDefensesPanel.TabIndex = 27;
            // 
            // TargetDefensesLabel
            // 
            this.TargetDefensesLabel.AutoSize = true;
            this.TargetDefensesLabel.Location = new System.Drawing.Point(65, 0);
            this.TargetDefensesLabel.Name = "TargetDefensesLabel";
            this.TargetDefensesLabel.Size = new System.Drawing.Size(89, 15);
            this.TargetDefensesLabel.TabIndex = 0;
            this.TargetDefensesLabel.Text = "Target Defenses";
            // 
            // EngineStatsPanel
            // 
            this.EngineStatsPanel.Controls.Add(this.EngineStatsLabel);
            this.EngineStatsPanel.Controls.Add(this.EnginePpmLabel);
            this.EngineStatsPanel.Controls.Add(this.EnginePpmUD);
            this.EngineStatsPanel.Controls.Add(this.EnginePpvLabel);
            this.EngineStatsPanel.Controls.Add(this.RequiresFuelCB);
            this.EngineStatsPanel.Controls.Add(this.EnginePpvUD);
            this.EngineStatsPanel.Controls.Add(this.EnginePpcUD);
            this.EngineStatsPanel.Controls.Add(this.EnginePpcLabel);
            this.EngineStatsPanel.Location = new System.Drawing.Point(246, 10);
            this.EngineStatsPanel.Name = "EngineStatsPanel";
            this.EngineStatsPanel.Size = new System.Drawing.Size(220, 120);
            this.EngineStatsPanel.TabIndex = 28;
            // 
            // EngineStatsLabel
            // 
            this.EngineStatsLabel.AutoSize = true;
            this.EngineStatsLabel.Location = new System.Drawing.Point(74, 0);
            this.EngineStatsLabel.Name = "EngineStatsLabel";
            this.EngineStatsLabel.Size = new System.Drawing.Size(71, 15);
            this.EngineStatsLabel.TabIndex = 0;
            this.EngineStatsLabel.Text = "Engine Stats";
            // 
            // TestParametersPanel
            // 
            this.TestParametersPanel.Controls.Add(this.TestPerLabel3);
            this.TestParametersPanel.Controls.Add(this.TestIntervalUD);
            this.TestParametersPanel.Controls.Add(this.TestPerLabel2);
            this.TestParametersPanel.Controls.Add(this.DpsPerVolumeRB);
            this.TestParametersPanel.Controls.Add(this.TestPerLabel);
            this.TestParametersPanel.Controls.Add(this.DpsPerCostRB);
            this.TestParametersPanel.Controls.Add(this.TestParametersLabel);
            this.TestParametersPanel.Controls.Add(this.RunTestsButton);
            this.TestParametersPanel.Location = new System.Drawing.Point(10, 303);
            this.TestParametersPanel.Name = "TestParametersPanel";
            this.TestParametersPanel.Size = new System.Drawing.Size(456, 134);
            this.TestParametersPanel.TabIndex = 29;
            // 
            // TestPerLabel3
            // 
            this.TestPerLabel3.AutoSize = true;
            this.TestPerLabel3.Location = new System.Drawing.Point(386, 45);
            this.TestPerLabel3.Name = "TestPerLabel3";
            this.TestPerLabel3.Size = new System.Drawing.Size(53, 15);
            this.TestPerLabel3.TabIndex = 18;
            this.TestPerLabel3.Text = "minutes.";
            // 
            // TestPerLabel2
            // 
            this.TestPerLabel2.AutoSize = true;
            this.TestPerLabel2.Location = new System.Drawing.Point(245, 45);
            this.TestPerLabel2.Name = "TestPerLabel2";
            this.TestPerLabel2.Size = new System.Drawing.Size(102, 15);
            this.TestPerLabel2.TabIndex = 16;
            this.TestPerLabel2.Text = "over the course of";
            // 
            // TestPerLabel
            // 
            this.TestPerLabel.AutoSize = true;
            this.TestPerLabel.Location = new System.Drawing.Point(0, 45);
            this.TestPerLabel.Name = "TestPerLabel";
            this.TestPerLabel.Size = new System.Drawing.Size(184, 15);
            this.TestPerLabel.TabIndex = 14;
            this.TestPerLabel.Text = "Optimize for DPS per total system";
            // 
            // TestParametersLabel
            // 
            this.TestParametersLabel.AutoSize = true;
            this.TestParametersLabel.Location = new System.Drawing.Point(183, 0);
            this.TestParametersLabel.Name = "TestParametersLabel";
            this.TestParametersLabel.Size = new System.Drawing.Size(89, 15);
            this.TestParametersLabel.TabIndex = 12;
            this.TestParametersLabel.Text = "Test Parameters";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 444);
            this.Controls.Add(this.EngineStatsPanel);
            this.Controls.Add(this.TargetDefensesPanel);
            this.Controls.Add(this.LaserParametersPanel);
            this.Controls.Add(this.StorageTypePanel);
            this.Controls.Add(this.TestParametersPanel);
            this.Name = "Input";
            this.Text = "Laser Calc";
            ((System.ComponentModel.ISupportInitialize)(this.StackLengthUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StackCountUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetACUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmokeStrengthUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanarSmokeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RingACUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnginePpmUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnginePpvUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnginePpcUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestIntervalUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CombinerCountUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRechargeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRechargeUD)).EndInit();
            this.StorageTypePanel.ResumeLayout(false);
            this.StorageTypePanel.PerformLayout();
            this.LaserParametersPanel.ResumeLayout(false);
            this.LaserParametersPanel.PerformLayout();
            this.TargetDefensesPanel.ResumeLayout(false);
            this.TargetDefensesPanel.PerformLayout();
            this.EngineStatsPanel.ResumeLayout(false);
            this.EngineStatsPanel.PerformLayout();
            this.TestParametersPanel.ResumeLayout(false);
            this.TestParametersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown StackLengthUD;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label StackLengthLabel;
        private System.Windows.Forms.Label StackCountLabel;
        private System.Windows.Forms.NumericUpDown StackCountUD;
        private System.Windows.Forms.Label TargetACLabel;
        private System.Windows.Forms.NumericUpDown TargetACUD;
        private System.Windows.Forms.Label SmokeStrengthLabel;
        private System.Windows.Forms.NumericUpDown SmokeStrengthUD;
        private System.Windows.Forms.NumericUpDown PlanarSmokeUD;
        private System.Windows.Forms.Button RunTestsButton;
        private System.Windows.Forms.RadioButton PlanarSmokeRB;
        private System.Windows.Forms.RadioButton RingACRB;
        private System.Windows.Forms.NumericUpDown RingACUD;
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
    }
}

