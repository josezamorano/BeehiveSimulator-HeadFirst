namespace WorldGraphicsBehive
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReset = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FramesRateLabelNumber = new System.Windows.Forms.Label();
            this.FramesRateLabel = new System.Windows.Forms.Label();
            this.FramesRunLabelNumber = new System.Windows.Forms.Label();
            this.FramesRunLabel = new System.Windows.Forms.Label();
            this.FieldNectarLabelNumber = new System.Windows.Forms.Label();
            this.TotalNecterInFieldLabel = new System.Windows.Forms.Label();
            this.HiveHoneyLabelNumber = new System.Windows.Forms.Label();
            this.HoneyInHivelabel = new System.Windows.Forms.Label();
            this.FlowerLabelNumber = new System.Windows.Forms.Label();
            this.FlowerLabel = new System.Windows.Forms.Label();
            this.BeeLabel = new System.Windows.Forms.Label();
            this.BeesLabelNumber = new System.Windows.Forms.Label();
            this.StatusBeeListBox = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusFlowerListBox = new System.Windows.Forms.ListBox();
            this.BeesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BeeSelectorLabel = new System.Windows.Forms.Label();
            this.FlowersSelectorLabel = new System.Windows.Forms.Label();
            this.FlowersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PollenSelectorLabel = new System.Windows.Forms.Label();
            this.PollenNumberComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowersNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(300, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonStart.Text = "Start Simulation";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonReset
            // 
            this.toolStripButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReset.Image")));
            this.toolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReset.Name = "toolStripButtonReset";
            this.toolStripButtonReset.Size = new System.Drawing.Size(39, 22);
            this.toolStripButtonReset.Text = "Reset";
            this.toolStripButtonReset.Click += new System.EventHandler(this.toolStripButtonReset_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.FramesRateLabelNumber, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.FramesRateLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.FramesRunLabelNumber, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.FramesRunLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.FieldNectarLabelNumber, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.TotalNecterInFieldLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.HiveHoneyLabelNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.HoneyInHivelabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.FlowerLabelNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.FlowerLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BeeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BeesLabelNumber, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 98);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(276, 149);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // FramesRateLabelNumber
            // 
            this.FramesRateLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRateLabelNumber.AutoSize = true;
            this.FramesRateLabelNumber.Location = new System.Drawing.Point(141, 128);
            this.FramesRateLabelNumber.Name = "FramesRateLabelNumber";
            this.FramesRateLabelNumber.Size = new System.Drawing.Size(64, 13);
            this.FramesRateLabelNumber.TabIndex = 11;
            this.FramesRateLabelNumber.Text = "FramesRate";
            // 
            // FramesRateLabel
            // 
            this.FramesRateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRateLabel.AutoSize = true;
            this.FramesRateLabel.Location = new System.Drawing.Point(3, 128);
            this.FramesRateLabel.Name = "FramesRateLabel";
            this.FramesRateLabel.Size = new System.Drawing.Size(67, 13);
            this.FramesRateLabel.TabIndex = 10;
            this.FramesRateLabel.Text = "Frames Rate";
            // 
            // FramesRunLabelNumber
            // 
            this.FramesRunLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRunLabelNumber.AutoSize = true;
            this.FramesRunLabelNumber.Location = new System.Drawing.Point(141, 104);
            this.FramesRunLabelNumber.Name = "FramesRunLabelNumber";
            this.FramesRunLabelNumber.Size = new System.Drawing.Size(61, 13);
            this.FramesRunLabelNumber.TabIndex = 9;
            this.FramesRunLabelNumber.Text = "FramesRun";
            // 
            // FramesRunLabel
            // 
            this.FramesRunLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRunLabel.AutoSize = true;
            this.FramesRunLabel.Location = new System.Drawing.Point(3, 104);
            this.FramesRunLabel.Name = "FramesRunLabel";
            this.FramesRunLabel.Size = new System.Drawing.Size(64, 13);
            this.FramesRunLabel.TabIndex = 8;
            this.FramesRunLabel.Text = "Frames Run";
            // 
            // FieldNectarLabelNumber
            // 
            this.FieldNectarLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FieldNectarLabelNumber.AutoSize = true;
            this.FieldNectarLabelNumber.Location = new System.Drawing.Point(141, 82);
            this.FieldNectarLabelNumber.Name = "FieldNectarLabelNumber";
            this.FieldNectarLabelNumber.Size = new System.Drawing.Size(64, 13);
            this.FieldNectarLabelNumber.TabIndex = 7;
            this.FieldNectarLabelNumber.Text = "Field Nectar";
            // 
            // TotalNecterInFieldLabel
            // 
            this.TotalNecterInFieldLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TotalNecterInFieldLabel.AutoSize = true;
            this.TotalNecterInFieldLabel.Location = new System.Drawing.Point(3, 82);
            this.TotalNecterInFieldLabel.Name = "TotalNecterInFieldLabel";
            this.TotalNecterInFieldLabel.Size = new System.Drawing.Size(120, 13);
            this.TotalNecterInFieldLabel.TabIndex = 6;
            this.TotalNecterInFieldLabel.Text = "Total Nectar in the Field";
            // 
            // HiveHoneyLabelNumber
            // 
            this.HiveHoneyLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HiveHoneyLabelNumber.AutoSize = true;
            this.HiveHoneyLabelNumber.Location = new System.Drawing.Point(141, 57);
            this.HiveHoneyLabelNumber.Name = "HiveHoneyLabelNumber";
            this.HiveHoneyLabelNumber.Size = new System.Drawing.Size(63, 13);
            this.HiveHoneyLabelNumber.TabIndex = 5;
            this.HiveHoneyLabelNumber.Text = "Hive Honey";
            // 
            // HoneyInHivelabel
            // 
            this.HoneyInHivelabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HoneyInHivelabel.AutoSize = true;
            this.HoneyInHivelabel.Location = new System.Drawing.Point(3, 57);
            this.HoneyInHivelabel.Name = "HoneyInHivelabel";
            this.HoneyInHivelabel.Size = new System.Drawing.Size(119, 13);
            this.HoneyInHivelabel.TabIndex = 4;
            this.HoneyInHivelabel.Text = "Total Honey in the Hive";
            // 
            // FlowerLabelNumber
            // 
            this.FlowerLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlowerLabelNumber.AutoSize = true;
            this.FlowerLabelNumber.Location = new System.Drawing.Point(141, 31);
            this.FlowerLabelNumber.Name = "FlowerLabelNumber";
            this.FlowerLabelNumber.Size = new System.Drawing.Size(43, 13);
            this.FlowerLabelNumber.TabIndex = 3;
            this.FlowerLabelNumber.Text = "Flowers";
            // 
            // FlowerLabel
            // 
            this.FlowerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlowerLabel.AutoSize = true;
            this.FlowerLabel.Location = new System.Drawing.Point(3, 31);
            this.FlowerLabel.Name = "FlowerLabel";
            this.FlowerLabel.Size = new System.Drawing.Size(53, 13);
            this.FlowerLabel.TabIndex = 2;
            this.FlowerLabel.Text = "# Flowers";
            // 
            // BeeLabel
            // 
            this.BeeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BeeLabel.AutoSize = true;
            this.BeeLabel.Location = new System.Drawing.Point(3, 6);
            this.BeeLabel.Name = "BeeLabel";
            this.BeeLabel.Size = new System.Drawing.Size(41, 13);
            this.BeeLabel.TabIndex = 0;
            this.BeeLabel.Text = "# Bees";
            // 
            // BeesLabelNumber
            // 
            this.BeesLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BeesLabelNumber.AutoSize = true;
            this.BeesLabelNumber.Location = new System.Drawing.Point(141, 6);
            this.BeesLabelNumber.Name = "BeesLabelNumber";
            this.BeesLabelNumber.Size = new System.Drawing.Size(31, 13);
            this.BeesLabelNumber.TabIndex = 1;
            this.BeesLabelNumber.Text = "Bees";
            // 
            // StatusBeeListBox
            // 
            this.StatusBeeListBox.FormattingEnabled = true;
            this.StatusBeeListBox.Location = new System.Drawing.Point(12, 253);
            this.StatusBeeListBox.Name = "StatusBeeListBox";
            this.StatusBeeListBox.Size = new System.Drawing.Size(276, 95);
            this.StatusBeeListBox.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(300, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // StatusFlowerListBox
            // 
            this.StatusFlowerListBox.FormattingEnabled = true;
            this.StatusFlowerListBox.Location = new System.Drawing.Point(12, 354);
            this.StatusFlowerListBox.Name = "StatusFlowerListBox";
            this.StatusFlowerListBox.Size = new System.Drawing.Size(276, 95);
            this.StatusFlowerListBox.TabIndex = 4;
            // 
            // BeesNumericUpDown
            // 
            this.BeesNumericUpDown.Location = new System.Drawing.Point(131, 26);
            this.BeesNumericUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.BeesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BeesNumericUpDown.Name = "BeesNumericUpDown";
            this.BeesNumericUpDown.Size = new System.Drawing.Size(38, 20);
            this.BeesNumericUpDown.TabIndex = 5;
            this.BeesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BeeSelectorLabel
            // 
            this.BeeSelectorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BeeSelectorLabel.AutoSize = true;
            this.BeeSelectorLabel.Location = new System.Drawing.Point(9, 28);
            this.BeeSelectorLabel.Name = "BeeSelectorLabel";
            this.BeeSelectorLabel.Size = new System.Drawing.Size(101, 13);
            this.BeeSelectorLabel.TabIndex = 6;
            this.BeeSelectorLabel.Text = "Select Bees In Field";
            // 
            // FlowersSelectorLabel
            // 
            this.FlowersSelectorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlowersSelectorLabel.AutoSize = true;
            this.FlowersSelectorLabel.Location = new System.Drawing.Point(12, 51);
            this.FlowersSelectorLabel.Name = "FlowersSelectorLabel";
            this.FlowersSelectorLabel.Size = new System.Drawing.Size(113, 13);
            this.FlowersSelectorLabel.TabIndex = 7;
            this.FlowersSelectorLabel.Text = "Select Flowers In Field";
            // 
            // FlowersNumericUpDown
            // 
            this.FlowersNumericUpDown.Location = new System.Drawing.Point(131, 49);
            this.FlowersNumericUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.FlowersNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FlowersNumericUpDown.Name = "FlowersNumericUpDown";
            this.FlowersNumericUpDown.Size = new System.Drawing.Size(38, 20);
            this.FlowersNumericUpDown.TabIndex = 8;
            this.FlowersNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PollenSelectorLabel
            // 
            this.PollenSelectorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PollenSelectorLabel.AutoSize = true;
            this.PollenSelectorLabel.Location = new System.Drawing.Point(12, 72);
            this.PollenSelectorLabel.Name = "PollenSelectorLabel";
            this.PollenSelectorLabel.Size = new System.Drawing.Size(156, 13);
            this.PollenSelectorLabel.TabIndex = 9;
            this.PollenSelectorLabel.Text = "Pollen Required For a New Bee";
            // 
            // PollenNumberComboBox
            // 
            this.PollenNumberComboBox.FormattingEnabled = true;
            this.PollenNumberComboBox.Location = new System.Drawing.Point(175, 69);
            this.PollenNumberComboBox.Name = "PollenNumberComboBox";
            this.PollenNumberComboBox.Size = new System.Drawing.Size(68, 21);
            this.PollenNumberComboBox.TabIndex = 10;
            this.PollenNumberComboBox.Text = "Select";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 474);
            this.Controls.Add(this.PollenNumberComboBox);
            this.Controls.Add(this.PollenSelectorLabel);
            this.Controls.Add(this.FlowersNumericUpDown);
            this.Controls.Add(this.FlowersSelectorLabel);
            this.Controls.Add(this.BeeSelectorLabel);
            this.Controls.Add(this.BeesNumericUpDown);
            this.Controls.Add(this.StatusFlowerListBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StatusBeeListBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Move += new System.EventHandler(this.DashboardForm_Move);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowersNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label BeeLabel;
        private System.Windows.Forms.Label FramesRateLabelNumber;
        private System.Windows.Forms.Label FramesRateLabel;
        private System.Windows.Forms.Label FramesRunLabelNumber;
        private System.Windows.Forms.Label FramesRunLabel;
        private System.Windows.Forms.Label FieldNectarLabelNumber;
        private System.Windows.Forms.Label TotalNecterInFieldLabel;
        private System.Windows.Forms.Label HiveHoneyLabelNumber;
        private System.Windows.Forms.Label HoneyInHivelabel;
        private System.Windows.Forms.Label FlowerLabelNumber;
        private System.Windows.Forms.Label FlowerLabel;
        private System.Windows.Forms.Label BeesLabelNumber;
        private System.Windows.Forms.ListBox StatusBeeListBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListBox StatusFlowerListBox;
        private System.Windows.Forms.NumericUpDown BeesNumericUpDown;
        private System.Windows.Forms.Label BeeSelectorLabel;
        private System.Windows.Forms.Label FlowersSelectorLabel;
        private System.Windows.Forms.NumericUpDown FlowersNumericUpDown;
        private System.Windows.Forms.Label PollenSelectorLabel;
        private System.Windows.Forms.ComboBox PollenNumberComboBox;
      
    }
}