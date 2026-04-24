namespace WFStudio
{
    partial class Compressor
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
            this.treshold_pot = new NAudio.Gui.Pot();
            this.treshold_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ratio_label = new System.Windows.Forms.Label();
            this.ratio_pot = new NAudio.Gui.Pot();
            this.label3 = new System.Windows.Forms.Label();
            this.attack_label = new System.Windows.Forms.Label();
            this.attack_pot = new NAudio.Gui.Pot();
            this.label4 = new System.Windows.Forms.Label();
            this.release_label = new System.Windows.Forms.Label();
            this.release_pot = new NAudio.Gui.Pot();
            this.label5 = new System.Windows.Forms.Label();
            this.gain_label = new System.Windows.Forms.Label();
            this.gain_pot = new NAudio.Gui.Pot();
            this.SuspendLayout();
            // 
            // treshold_pot
            // 
            this.treshold_pot.Location = new System.Drawing.Point(19, 36);
            this.treshold_pot.Maximum = 1D;
            this.treshold_pot.Minimum = 0D;
            this.treshold_pot.Name = "treshold_pot";
            this.treshold_pot.Size = new System.Drawing.Size(32, 32);
            this.treshold_pot.TabIndex = 0;
            this.treshold_pot.Value = 0.5D;
            this.treshold_pot.ValueChanged += new System.EventHandler(this.pot1_ValueChanged);
            // 
            // treshold_label
            // 
            this.treshold_label.AutoSize = true;
            this.treshold_label.Location = new System.Drawing.Point(21, 71);
            this.treshold_label.Name = "treshold_label";
            this.treshold_label.Size = new System.Drawing.Size(28, 13);
            this.treshold_label.TabIndex = 1;
            this.treshold_label.Text = "1.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Treshold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ratio";
            // 
            // ratio_label
            // 
            this.ratio_label.AutoSize = true;
            this.ratio_label.Location = new System.Drawing.Point(60, 71);
            this.ratio_label.Name = "ratio_label";
            this.ratio_label.Size = new System.Drawing.Size(28, 13);
            this.ratio_label.TabIndex = 4;
            this.ratio_label.Text = "1.00";
            // 
            // ratio_pot
            // 
            this.ratio_pot.Location = new System.Drawing.Point(57, 36);
            this.ratio_pot.Maximum = 1D;
            this.ratio_pot.Minimum = 0D;
            this.ratio_pot.Name = "ratio_pot";
            this.ratio_pot.Size = new System.Drawing.Size(32, 32);
            this.ratio_pot.TabIndex = 3;
            this.ratio_pot.Value = 0.5D;
            this.ratio_pot.ValueChanged += new System.EventHandler(this.ratio_pot_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Attack";
            // 
            // attack_label
            // 
            this.attack_label.AutoSize = true;
            this.attack_label.Location = new System.Drawing.Point(100, 71);
            this.attack_label.Name = "attack_label";
            this.attack_label.Size = new System.Drawing.Size(28, 13);
            this.attack_label.TabIndex = 7;
            this.attack_label.Text = "1.00";
            // 
            // attack_pot
            // 
            this.attack_pot.Location = new System.Drawing.Point(97, 36);
            this.attack_pot.Maximum = 1D;
            this.attack_pot.Minimum = 0D;
            this.attack_pot.Name = "attack_pot";
            this.attack_pot.Size = new System.Drawing.Size(32, 32);
            this.attack_pot.TabIndex = 6;
            this.attack_pot.Value = 0.5D;
            this.attack_pot.ValueChanged += new System.EventHandler(this.attack_pot_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Release";
            // 
            // release_label
            // 
            this.release_label.AutoSize = true;
            this.release_label.Location = new System.Drawing.Point(148, 71);
            this.release_label.Name = "release_label";
            this.release_label.Size = new System.Drawing.Size(28, 13);
            this.release_label.TabIndex = 10;
            this.release_label.Text = "1.00";
            // 
            // release_pot
            // 
            this.release_pot.Location = new System.Drawing.Point(145, 36);
            this.release_pot.Maximum = 1D;
            this.release_pot.Minimum = 0D;
            this.release_pot.Name = "release_pot";
            this.release_pot.Size = new System.Drawing.Size(32, 32);
            this.release_pot.TabIndex = 9;
            this.release_pot.Value = 0.5D;
            this.release_pot.ValueChanged += new System.EventHandler(this.release_pot_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Post Gain";
            // 
            // gain_label
            // 
            this.gain_label.AutoSize = true;
            this.gain_label.Location = new System.Drawing.Point(197, 71);
            this.gain_label.Name = "gain_label";
            this.gain_label.Size = new System.Drawing.Size(28, 13);
            this.gain_label.TabIndex = 13;
            this.gain_label.Text = "1.00";
            // 
            // gain_pot
            // 
            this.gain_pot.Location = new System.Drawing.Point(194, 36);
            this.gain_pot.Maximum = 1D;
            this.gain_pot.Minimum = 0D;
            this.gain_pot.Name = "gain_pot";
            this.gain_pot.Size = new System.Drawing.Size(32, 32);
            this.gain_pot.TabIndex = 12;
            this.gain_pot.Value = 0.5D;
            this.gain_pot.ValueChanged += new System.EventHandler(this.gain_pot_ValueChanged);
            // 
            // Compressor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 105);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gain_label);
            this.Controls.Add(this.gain_pot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.release_label);
            this.Controls.Add(this.release_pot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.attack_label);
            this.Controls.Add(this.attack_pot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ratio_label);
            this.Controls.Add(this.ratio_pot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treshold_label);
            this.Controls.Add(this.treshold_pot);
            this.Name = "Compressor";
            this.Text = "Compressor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NAudio.Gui.Pot treshold_pot;
        private System.Windows.Forms.Label treshold_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ratio_label;
        private NAudio.Gui.Pot ratio_pot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label attack_label;
        private NAudio.Gui.Pot attack_pot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label release_label;
        private NAudio.Gui.Pot release_pot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label gain_label;
        private NAudio.Gui.Pot gain_pot;
    }
}