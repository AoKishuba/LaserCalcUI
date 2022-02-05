
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
            this.SmokeStrengthLabel = new System.Windows.Forms.Label();
            this.AddParametersButton = new System.Windows.Forms.Button();
            this.RunTestsButton = new System.Windows.Forms.Button();
            this.PlanarSmokeRB = new System.Windows.Forms.RadioButton();
            this.RingACRB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.StackLengthUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StackCountUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetACUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmokeStrengthUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanarSmokeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RingACUD)).BeginInit();
            this.SuspendLayout();
            // 
            // StackLengthUD
            // 
            this.StackLengthUD.Location = new System.Drawing.Point(105, 12);
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
            this.StackLengthLabel.Location = new System.Drawing.Point(12, 16);
            this.StackLengthLabel.Name = "StackLengthLabel";
            this.StackLengthLabel.Size = new System.Drawing.Size(75, 15);
            this.StackLengthLabel.TabIndex = 1;
            this.StackLengthLabel.Text = "Stack Length";
            // 
            // StackCountLabel
            // 
            this.StackCountLabel.AutoSize = true;
            this.StackCountLabel.Location = new System.Drawing.Point(12, 46);
            this.StackCountLabel.Name = "StackCountLabel";
            this.StackCountLabel.Size = new System.Drawing.Size(71, 15);
            this.StackCountLabel.TabIndex = 3;
            this.StackCountLabel.Text = "Stack Count";
            // 
            // StackCountUD
            // 
            this.StackCountUD.Location = new System.Drawing.Point(105, 42);
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
            this.TargetACLabel.Location = new System.Drawing.Point(12, 76);
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
            this.TargetACUD.Location = new System.Drawing.Point(105, 72);
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
            this.SmokeStrengthUD.Location = new System.Drawing.Point(329, 12);
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
            this.PlanarSmokeUD.Location = new System.Drawing.Point(329, 42);
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
            this.RingACUD.Location = new System.Drawing.Point(329, 72);
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
            // SmokeStrengthLabel
            // 
            this.SmokeStrengthLabel.AutoSize = true;
            this.SmokeStrengthLabel.Location = new System.Drawing.Point(187, 16);
            this.SmokeStrengthLabel.Name = "SmokeStrengthLabel";
            this.SmokeStrengthLabel.Size = new System.Drawing.Size(91, 15);
            this.SmokeStrengthLabel.TabIndex = 7;
            this.SmokeStrengthLabel.Text = "Smoke Strength";
            // 
            // AddParametersButton
            // 
            this.AddParametersButton.Location = new System.Drawing.Point(12, 126);
            this.AddParametersButton.Name = "AddParametersButton";
            this.AddParametersButton.Size = new System.Drawing.Size(153, 50);
            this.AddParametersButton.TabIndex = 10;
            this.AddParametersButton.Text = "Add Parameters to Queue";
            this.AddParametersButton.UseVisualStyleBackColor = true;
            // 
            // RunTestsButton
            // 
            this.RunTestsButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RunTestsButton.Enabled = false;
            this.RunTestsButton.Location = new System.Drawing.Point(187, 126);
            this.RunTestsButton.Name = "RunTestsButton";
            this.RunTestsButton.Size = new System.Drawing.Size(202, 50);
            this.RunTestsButton.TabIndex = 11;
            this.RunTestsButton.Text = "Run Tests";
            this.RunTestsButton.UseVisualStyleBackColor = false;
            // 
            // PlanarSmokeRB
            // 
            this.PlanarSmokeRB.AutoSize = true;
            this.PlanarSmokeRB.Checked = true;
            this.PlanarSmokeRB.Location = new System.Drawing.Point(171, 44);
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
            this.RingACRB.Location = new System.Drawing.Point(171, 71);
            this.RingACRB.Name = "RingACRB";
            this.RingACRB.Size = new System.Drawing.Size(139, 19);
            this.RingACRB.TabIndex = 13;
            this.RingACRB.Text = "Ring Shield AC Bonus";
            this.RingACRB.UseVisualStyleBackColor = true;
            this.RingACRB.CheckedChanged += new System.EventHandler(this.RingACRB_CheckedChanged);
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 191);
            this.Controls.Add(this.RingACUD);
            this.Controls.Add(this.RingACRB);
            this.Controls.Add(this.PlanarSmokeRB);
            this.Controls.Add(this.RunTestsButton);
            this.Controls.Add(this.AddParametersButton);
            this.Controls.Add(this.PlanarSmokeUD);
            this.Controls.Add(this.SmokeStrengthLabel);
            this.Controls.Add(this.SmokeStrengthUD);
            this.Controls.Add(this.TargetACLabel);
            this.Controls.Add(this.TargetACUD);
            this.Controls.Add(this.StackCountLabel);
            this.Controls.Add(this.StackCountUD);
            this.Controls.Add(this.StackLengthLabel);
            this.Controls.Add(this.StackLengthUD);
            this.Name = "Input";
            this.Text = "Laser Calc";
            ((System.ComponentModel.ISupportInitialize)(this.StackLengthUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StackCountUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetACUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmokeStrengthUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanarSmokeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RingACUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button AddParametersButton;
        private System.Windows.Forms.Button RunTestsButton;
        private System.Windows.Forms.RadioButton PlanarSmokeRB;
        private System.Windows.Forms.RadioButton RingACRB;
        private System.Windows.Forms.NumericUpDown RingACUD;
    }
}

