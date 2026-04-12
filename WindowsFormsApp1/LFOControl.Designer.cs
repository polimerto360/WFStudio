namespace WFStudio
{
    partial class LFOControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.amp_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.amp_pot = new NAudio.Gui.Pot();
            this.freq_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.freq_pot = new NAudio.Gui.Pot();
            this.base_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.base_pot = new NAudio.Gui.Pot();
            this.targetcb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wavetypecb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // amp_label
            // 
            this.amp_label.AutoSize = true;
            this.amp_label.Location = new System.Drawing.Point(116, 26);
            this.amp_label.Name = "amp_label";
            this.amp_label.Size = new System.Drawing.Size(13, 13);
            this.amp_label.TabIndex = 39;
            this.amp_label.Text = "0";
            this.amp_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Amplitude";
            // 
            // amp_pot
            // 
            this.amp_pot.Location = new System.Drawing.Point(112, 44);
            this.amp_pot.Maximum = 1D;
            this.amp_pot.Minimum = 0D;
            this.amp_pot.Name = "amp_pot";
            this.amp_pot.Size = new System.Drawing.Size(32, 32);
            this.amp_pot.TabIndex = 37;
            this.amp_pot.Value = 0.5D;
            this.amp_pot.ValueChanged += new System.EventHandler(this.amp_pot_ValueChanged);
            // 
            // freq_label
            // 
            this.freq_label.AutoSize = true;
            this.freq_label.Location = new System.Drawing.Point(58, 26);
            this.freq_label.Name = "freq_label";
            this.freq_label.Size = new System.Drawing.Size(13, 13);
            this.freq_label.TabIndex = 33;
            this.freq_label.Text = "0";
            this.freq_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Frequency";
            // 
            // freq_pot
            // 
            this.freq_pot.Location = new System.Drawing.Point(54, 44);
            this.freq_pot.Maximum = 1D;
            this.freq_pot.Minimum = 0D;
            this.freq_pot.Name = "freq_pot";
            this.freq_pot.Size = new System.Drawing.Size(32, 32);
            this.freq_pot.TabIndex = 31;
            this.freq_pot.Value = 0.5D;
            this.freq_pot.ValueChanged += new System.EventHandler(this.freq_pot_ValueChanged);
            // 
            // base_label
            // 
            this.base_label.AutoSize = true;
            this.base_label.Location = new System.Drawing.Point(20, 26);
            this.base_label.Name = "base_label";
            this.base_label.Size = new System.Drawing.Size(13, 13);
            this.base_label.TabIndex = 30;
            this.base_label.Text = "0";
            this.base_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Base";
            // 
            // base_pot
            // 
            this.base_pot.Location = new System.Drawing.Point(16, 44);
            this.base_pot.Maximum = 1D;
            this.base_pot.Minimum = 0D;
            this.base_pot.Name = "base_pot";
            this.base_pot.Size = new System.Drawing.Size(32, 32);
            this.base_pot.TabIndex = 28;
            this.base_pot.Value = 0.5D;
            this.base_pot.ValueChanged += new System.EventHandler(this.base_pot_ValueChanged);
            // 
            // targetcb
            // 
            this.targetcb.FormattingEnabled = true;
            this.targetcb.Location = new System.Drawing.Point(164, 55);
            this.targetcb.Name = "targetcb";
            this.targetcb.Size = new System.Drawing.Size(121, 21);
            this.targetcb.TabIndex = 40;
            this.targetcb.SelectedValueChanged += new System.EventHandler(this.targetcb_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Target";
            // 
            // wavetypecb
            // 
            this.wavetypecb.FormattingEnabled = true;
            this.wavetypecb.Items.AddRange(new object[] {
            "Sine",
            "Saw",
            "Square",
            "Noise",
            "Pseudo noise"});
            this.wavetypecb.Location = new System.Drawing.Point(302, 55);
            this.wavetypecb.Name = "wavetypecb";
            this.wavetypecb.Size = new System.Drawing.Size(121, 21);
            this.wavetypecb.TabIndex = 42;
            this.wavetypecb.SelectedValueChanged += new System.EventHandler(this.wavetypecb_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Wave Type";
            // 
            // LFOControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wavetypecb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetcb);
            this.Controls.Add(this.amp_label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.amp_pot);
            this.Controls.Add(this.freq_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.freq_pot);
            this.Controls.Add(this.base_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.base_pot);
            this.Name = "LFOControl";
            this.Size = new System.Drawing.Size(443, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label amp_label;
        private System.Windows.Forms.Label label8;
        private NAudio.Gui.Pot amp_pot;
        private System.Windows.Forms.Label freq_label;
        private System.Windows.Forms.Label label4;
        private NAudio.Gui.Pot freq_pot;
        private System.Windows.Forms.Label base_label;
        private System.Windows.Forms.Label label2;
        private NAudio.Gui.Pot base_pot;
        private System.Windows.Forms.ComboBox targetcb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox wavetypecb;
        private System.Windows.Forms.Label label3;
    }
}
