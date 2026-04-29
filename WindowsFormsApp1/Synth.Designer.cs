using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;

namespace WFStudio
{
    partial class Synth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Synth));
            this.label1 = new System.Windows.Forms.Label();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.volumeSlider1 = new NAudio.Gui.VolumeSlider();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pot8 = new NAudio.Gui.Pot();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pot9 = new NAudio.Gui.Pot();
            this.envControlerUC1 = new WFStudio.EnvControlerUC();
            this.filterControl1 = new WFStudio.FilterControl();
            this.lfoControl1 = new WFStudio.LFOControl();
            this.envControl1 = new WFStudio.EnvControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wave type";
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0.1F;
            this.volumeMeter1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.volumeMeter1.Location = new System.Drawing.Point(27, 330);
            this.volumeMeter1.MaxDb = 18F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Size = new System.Drawing.Size(75, 153);
            this.volumeMeter1.TabIndex = 5;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // volumeSlider1
            // 
            this.volumeSlider1.Location = new System.Drawing.Point(122, 389);
            this.volumeSlider1.Name = "volumeSlider1";
            this.volumeSlider1.Size = new System.Drawing.Size(96, 16);
            this.volumeSlider1.TabIndex = 6;
            this.volumeSlider1.VolumeChanged += new System.EventHandler(this.volumeSlider1_VolumeChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Sine",
            "Saw",
            "Square",
            "Noise",
            "Pseudo noise",
            "Triangle"});
            this.listBox1.Location = new System.Drawing.Point(65, 76);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 56);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(74, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "0";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(67, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Coarse pitch";
            // 
            // pot8
            // 
            this.pot8.Location = new System.Drawing.Point(70, 179);
            this.pot8.Maximum = 1D;
            this.pot8.Minimum = 0D;
            this.pot8.Name = "pot8";
            this.pot8.Size = new System.Drawing.Size(32, 32);
            this.pot8.TabIndex = 28;
            this.pot8.Value = 0.5D;
            this.pot8.ValueChanged += new System.EventHandler(this.pot8_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(157, 161);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "0";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(150, 148);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Fine pitch";
            // 
            // pot9
            // 
            this.pot9.Location = new System.Drawing.Point(153, 179);
            this.pot9.Maximum = 1D;
            this.pot9.Minimum = 0D;
            this.pot9.Name = "pot9";
            this.pot9.Size = new System.Drawing.Size(32, 32);
            this.pot9.TabIndex = 31;
            this.pot9.Value = 0.5D;
            this.pot9.ValueChanged += new System.EventHandler(this.pot9_ValueChanged);
            // 
            // envControlerUC1
            // 
            this.envControlerUC1.EC = null;
            this.envControlerUC1.Location = new System.Drawing.Point(259, 389);
            this.envControlerUC1.Name = "envControlerUC1";
            this.envControlerUC1.Size = new System.Drawing.Size(582, 88);
            this.envControlerUC1.TabIndex = 37;
            // 
            // filterControl1
            // 
            this.filterControl1.Filter = null;
            this.filterControl1.Location = new System.Drawing.Point(27, 211);
            this.filterControl1.Name = "filterControl1";
            this.filterControl1.Size = new System.Drawing.Size(288, 113);
            this.filterControl1.TabIndex = 36;
            // 
            // lfoControl1
            // 
            this.lfoControl1.Lfo = null;
            this.lfoControl1.Location = new System.Drawing.Point(398, 295);
            this.lfoControl1.Name = "lfoControl1";
            this.lfoControl1.Size = new System.Drawing.Size(443, 88);
            this.lfoControl1.TabIndex = 35;
            // 
            // envControl1
            // 
            this.envControl1.Env = null;
            this.envControl1.Location = new System.Drawing.Point(259, 44);
            this.envControl1.Name = "envControl1";
            this.envControl1.Size = new System.Drawing.Size(297, 88);
            this.envControl1.TabIndex = 34;
            // 
            // Synth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 495);
            this.Controls.Add(this.envControlerUC1);
            this.Controls.Add(this.filterControl1);
            this.Controls.Add(this.lfoControl1);
            this.Controls.Add(this.envControl1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.pot9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pot8);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.volumeSlider1);
            this.Controls.Add(this.volumeMeter1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Synth";
            this.Text = "Synth";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Synth_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private NAudio.Gui.VolumeMeter volumeMeter1;
        private NAudio.Gui.VolumeSlider volumeSlider1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private NAudio.Gui.Pot pot8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private NAudio.Gui.Pot pot9;
        private EnvControl envControl1;
        private LFOControl lfoControl1;
        private FilterControl filterControl1;
        private EnvControlerUC envControlerUC1;
    }
}