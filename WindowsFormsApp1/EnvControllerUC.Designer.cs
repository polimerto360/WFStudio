namespace WFStudio
{
    partial class EnvControlerUC
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
            this.release_tension_label = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.release_tension_pot = new NAudio.Gui.Pot();
            this.release_value_label = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.release_value_pot = new NAudio.Gui.Pot();
            this.decay_tension_label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.decay_tension_pot = new NAudio.Gui.Pot();
            this.decay_value_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.decay_value_pot = new NAudio.Gui.Pot();
            this.sustain_value_label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sustain_pot = new NAudio.Gui.Pot();
            this.attack_tension_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.attack_tension_pot = new NAudio.Gui.Pot();
            this.attack_value_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.attack_value_pot = new NAudio.Gui.Pot();
            this.target_cb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.base_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.base_pot = new NAudio.Gui.Pot();
            this.amplitude_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.amplitude_pot = new NAudio.Gui.Pot();
            this.SuspendLayout();
            // 
            // release_tension_label
            // 
            this.release_tension_label.AutoSize = true;
            this.release_tension_label.Location = new System.Drawing.Point(248, 26);
            this.release_tension_label.Name = "release_tension_label";
            this.release_tension_label.Size = new System.Drawing.Size(13, 13);
            this.release_tension_label.TabIndex = 48;
            this.release_tension_label.Text = "0";
            this.release_tension_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(241, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Tension";
            // 
            // release_tension_pot
            // 
            this.release_tension_pot.Location = new System.Drawing.Point(244, 44);
            this.release_tension_pot.Maximum = 1D;
            this.release_tension_pot.Minimum = 0D;
            this.release_tension_pot.Name = "release_tension_pot";
            this.release_tension_pot.Size = new System.Drawing.Size(32, 32);
            this.release_tension_pot.TabIndex = 46;
            this.release_tension_pot.Value = 0.5D;
            this.release_tension_pot.ValueChanged += new System.EventHandler(this.release_tension_pot_ValueChanged);
            // 
            // release_value_label
            // 
            this.release_value_label.AutoSize = true;
            this.release_value_label.Location = new System.Drawing.Point(210, 26);
            this.release_value_label.Name = "release_value_label";
            this.release_value_label.Size = new System.Drawing.Size(13, 13);
            this.release_value_label.TabIndex = 45;
            this.release_value_label.Text = "0";
            this.release_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(203, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Release";
            // 
            // release_value_pot
            // 
            this.release_value_pot.Location = new System.Drawing.Point(206, 44);
            this.release_value_pot.Maximum = 1D;
            this.release_value_pot.Minimum = 0D;
            this.release_value_pot.Name = "release_value_pot";
            this.release_value_pot.Size = new System.Drawing.Size(32, 32);
            this.release_value_pot.TabIndex = 43;
            this.release_value_pot.Value = 0.5D;
            this.release_value_pot.ValueChanged += new System.EventHandler(this.release_value_pot_ValueChanged);
            // 
            // decay_tension_label
            // 
            this.decay_tension_label.AutoSize = true;
            this.decay_tension_label.Location = new System.Drawing.Point(172, 26);
            this.decay_tension_label.Name = "decay_tension_label";
            this.decay_tension_label.Size = new System.Drawing.Size(13, 13);
            this.decay_tension_label.TabIndex = 42;
            this.decay_tension_label.Text = "0";
            this.decay_tension_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(165, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Tension";
            // 
            // decay_tension_pot
            // 
            this.decay_tension_pot.Location = new System.Drawing.Point(168, 44);
            this.decay_tension_pot.Maximum = 1D;
            this.decay_tension_pot.Minimum = 0D;
            this.decay_tension_pot.Name = "decay_tension_pot";
            this.decay_tension_pot.Size = new System.Drawing.Size(32, 32);
            this.decay_tension_pot.TabIndex = 40;
            this.decay_tension_pot.Value = 0.5D;
            this.decay_tension_pot.ValueChanged += new System.EventHandler(this.decay_tension_pot_ValueChanged);
            // 
            // decay_value_label
            // 
            this.decay_value_label.AutoSize = true;
            this.decay_value_label.Location = new System.Drawing.Point(134, 26);
            this.decay_value_label.Name = "decay_value_label";
            this.decay_value_label.Size = new System.Drawing.Size(13, 13);
            this.decay_value_label.TabIndex = 39;
            this.decay_value_label.Text = "0";
            this.decay_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Decay";
            // 
            // decay_value_pot
            // 
            this.decay_value_pot.Location = new System.Drawing.Point(130, 44);
            this.decay_value_pot.Maximum = 1D;
            this.decay_value_pot.Minimum = 0D;
            this.decay_value_pot.Name = "decay_value_pot";
            this.decay_value_pot.Size = new System.Drawing.Size(32, 32);
            this.decay_value_pot.TabIndex = 37;
            this.decay_value_pot.Value = 0.5D;
            this.decay_value_pot.ValueChanged += new System.EventHandler(this.decay_value_pot_ValueChanged);
            // 
            // sustain_value_label
            // 
            this.sustain_value_label.AutoSize = true;
            this.sustain_value_label.Location = new System.Drawing.Point(96, 26);
            this.sustain_value_label.Name = "sustain_value_label";
            this.sustain_value_label.Size = new System.Drawing.Size(13, 13);
            this.sustain_value_label.TabIndex = 36;
            this.sustain_value_label.Text = "0";
            this.sustain_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Sustain";
            // 
            // sustain_pot
            // 
            this.sustain_pot.Location = new System.Drawing.Point(92, 44);
            this.sustain_pot.Maximum = 1D;
            this.sustain_pot.Minimum = 0D;
            this.sustain_pot.Name = "sustain_pot";
            this.sustain_pot.Size = new System.Drawing.Size(32, 32);
            this.sustain_pot.TabIndex = 34;
            this.sustain_pot.Value = 0.5D;
            this.sustain_pot.ValueChanged += new System.EventHandler(this.sustain_pot_ValueChanged);
            // 
            // attack_tension_label
            // 
            this.attack_tension_label.AutoSize = true;
            this.attack_tension_label.Location = new System.Drawing.Point(58, 26);
            this.attack_tension_label.Name = "attack_tension_label";
            this.attack_tension_label.Size = new System.Drawing.Size(13, 13);
            this.attack_tension_label.TabIndex = 33;
            this.attack_tension_label.Text = "0";
            this.attack_tension_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Tension";
            // 
            // attack_tension_pot
            // 
            this.attack_tension_pot.Location = new System.Drawing.Point(54, 44);
            this.attack_tension_pot.Maximum = 1D;
            this.attack_tension_pot.Minimum = 0D;
            this.attack_tension_pot.Name = "attack_tension_pot";
            this.attack_tension_pot.Size = new System.Drawing.Size(32, 32);
            this.attack_tension_pot.TabIndex = 31;
            this.attack_tension_pot.Value = 0.5D;
            this.attack_tension_pot.ValueChanged += new System.EventHandler(this.attack_tension_pot_ValueChanged);
            // 
            // attack_value_label
            // 
            this.attack_value_label.AutoSize = true;
            this.attack_value_label.Location = new System.Drawing.Point(20, 26);
            this.attack_value_label.Name = "attack_value_label";
            this.attack_value_label.Size = new System.Drawing.Size(13, 13);
            this.attack_value_label.TabIndex = 30;
            this.attack_value_label.Text = "0";
            this.attack_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Attack";
            // 
            // attack_value_pot
            // 
            this.attack_value_pot.Location = new System.Drawing.Point(16, 44);
            this.attack_value_pot.Maximum = 1D;
            this.attack_value_pot.Minimum = 0D;
            this.attack_value_pot.Name = "attack_value_pot";
            this.attack_value_pot.Size = new System.Drawing.Size(32, 32);
            this.attack_value_pot.TabIndex = 28;
            this.attack_value_pot.Value = 0.5D;
            this.attack_value_pot.ValueChanged += new System.EventHandler(this.attack_value_pot_ValueChanged);
            // 
            // target_cb
            // 
            this.target_cb.FormattingEnabled = true;
            this.target_cb.Location = new System.Drawing.Point(302, 55);
            this.target_cb.Name = "target_cb";
            this.target_cb.Size = new System.Drawing.Size(121, 21);
            this.target_cb.TabIndex = 49;
            this.target_cb.SelectedValueChanged += new System.EventHandler(this.target_cb_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Target";
            // 
            // base_label
            // 
            this.base_label.AutoSize = true;
            this.base_label.Location = new System.Drawing.Point(445, 26);
            this.base_label.Name = "base_label";
            this.base_label.Size = new System.Drawing.Size(13, 13);
            this.base_label.TabIndex = 53;
            this.base_label.Text = "0";
            this.base_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Base";
            // 
            // base_pot
            // 
            this.base_pot.Location = new System.Drawing.Point(441, 44);
            this.base_pot.Maximum = 1D;
            this.base_pot.Minimum = 0D;
            this.base_pot.Name = "base_pot";
            this.base_pot.Size = new System.Drawing.Size(32, 32);
            this.base_pot.TabIndex = 51;
            this.base_pot.Value = 0.5D;
            this.base_pot.ValueChanged += new System.EventHandler(this.base_pot_ValueChanged);
            // 
            // amplitude_label
            // 
            this.amplitude_label.AutoSize = true;
            this.amplitude_label.Location = new System.Drawing.Point(483, 26);
            this.amplitude_label.Name = "amplitude_label";
            this.amplitude_label.Size = new System.Drawing.Size(13, 13);
            this.amplitude_label.TabIndex = 56;
            this.amplitude_label.Text = "0";
            this.amplitude_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(476, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Amplitude";
            // 
            // amplitude_pot
            // 
            this.amplitude_pot.Location = new System.Drawing.Point(479, 44);
            this.amplitude_pot.Maximum = 1D;
            this.amplitude_pot.Minimum = 0D;
            this.amplitude_pot.Name = "amplitude_pot";
            this.amplitude_pot.Size = new System.Drawing.Size(32, 32);
            this.amplitude_pot.TabIndex = 54;
            this.amplitude_pot.Value = 0.5D;
            this.amplitude_pot.ValueChanged += new System.EventHandler(this.amplitude_pot_ValueChanged);
            // 
            // EnvControlerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.amplitude_label);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.amplitude_pot);
            this.Controls.Add(this.base_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.base_pot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.target_cb);
            this.Controls.Add(this.release_tension_label);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.release_tension_pot);
            this.Controls.Add(this.release_value_label);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.release_value_pot);
            this.Controls.Add(this.decay_tension_label);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.decay_tension_pot);
            this.Controls.Add(this.decay_value_label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.decay_value_pot);
            this.Controls.Add(this.sustain_value_label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sustain_pot);
            this.Controls.Add(this.attack_tension_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.attack_tension_pot);
            this.Controls.Add(this.attack_value_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.attack_value_pot);
            this.Name = "EnvControlerUC";
            this.Size = new System.Drawing.Size(582, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label release_tension_label;
        private System.Windows.Forms.Label label14;
        private NAudio.Gui.Pot release_tension_pot;
        private System.Windows.Forms.Label release_value_label;
        private System.Windows.Forms.Label label12;
        private NAudio.Gui.Pot release_value_pot;
        private System.Windows.Forms.Label decay_tension_label;
        private System.Windows.Forms.Label label10;
        private NAudio.Gui.Pot decay_tension_pot;
        private System.Windows.Forms.Label decay_value_label;
        private System.Windows.Forms.Label label8;
        private NAudio.Gui.Pot decay_value_pot;
        private System.Windows.Forms.Label sustain_value_label;
        private System.Windows.Forms.Label label6;
        private NAudio.Gui.Pot sustain_pot;
        private System.Windows.Forms.Label attack_tension_label;
        private System.Windows.Forms.Label label4;
        private NAudio.Gui.Pot attack_tension_pot;
        private System.Windows.Forms.Label attack_value_label;
        private System.Windows.Forms.Label label2;
        private NAudio.Gui.Pot attack_value_pot;
        private System.Windows.Forms.ComboBox target_cb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label base_label;
        private System.Windows.Forms.Label label5;
        private NAudio.Gui.Pot base_pot;
        private System.Windows.Forms.Label amplitude_label;
        private System.Windows.Forms.Label label9;
        private NAudio.Gui.Pot amplitude_pot;
    }
}
