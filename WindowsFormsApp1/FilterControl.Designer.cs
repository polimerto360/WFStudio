namespace WFStudio
{
    partial class FilterControl
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
            this.cf_pot = new NAudio.Gui.Pot();
            this.label1 = new System.Windows.Forms.Label();
            this.cf_label = new System.Windows.Forms.Label();
            this.q_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.q_pot = new NAudio.Gui.Pot();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cf_pot
            // 
            this.cf_pot.Location = new System.Drawing.Point(35, 51);
            this.cf_pot.Maximum = 1D;
            this.cf_pot.Minimum = 0D;
            this.cf_pot.Name = "cf_pot";
            this.cf_pot.Size = new System.Drawing.Size(32, 32);
            this.cf_pot.TabIndex = 0;
            this.cf_pot.Value = 0.5D;
            this.cf_pot.ValueChanged += new System.EventHandler(this.cf_pot_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cutoff freq";
            // 
            // cf_label
            // 
            this.cf_label.AutoSize = true;
            this.cf_label.Location = new System.Drawing.Point(35, 39);
            this.cf_label.Name = "cf_label";
            this.cf_label.Size = new System.Drawing.Size(31, 13);
            this.cf_label.TabIndex = 2;
            this.cf_label.Text = "1000";
            this.cf_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // q_label
            // 
            this.q_label.AutoSize = true;
            this.q_label.Location = new System.Drawing.Point(104, 39);
            this.q_label.Name = "q_label";
            this.q_label.Size = new System.Drawing.Size(13, 13);
            this.q_label.TabIndex = 5;
            this.q_label.Text = "1";
            this.q_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filter Q";
            // 
            // q_pot
            // 
            this.q_pot.Location = new System.Drawing.Point(95, 51);
            this.q_pot.Maximum = 1D;
            this.q_pot.Minimum = 0D;
            this.q_pot.Name = "q_pot";
            this.q_pot.Size = new System.Drawing.Size(32, 32);
            this.q_pot.TabIndex = 3;
            this.q_pot.Value = 0.5D;
            this.q_pot.ValueChanged += new System.EventHandler(this.q_pot_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Off",
            "High pass",
            "Low pass",
            "Band pass"});
            this.comboBox1.Location = new System.Drawing.Point(148, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter Type";
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.q_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.q_pot);
            this.Controls.Add(this.cf_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cf_pot);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(288, 113);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NAudio.Gui.Pot cf_pot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cf_label;
        private System.Windows.Forms.Label q_label;
        private System.Windows.Forms.Label label3;
        private NAudio.Gui.Pot q_pot;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}
