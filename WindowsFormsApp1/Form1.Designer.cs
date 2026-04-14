namespace WFStudio
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.volumeSlider1 = new NAudio.Gui.VolumeSlider();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.waveformPainter1 = new NAudio.Gui.WaveformPainter();
            this.time_label = new System.Windows.Forms.Label();
            this.play_button = new System.Windows.Forms.Button();
            this.pause_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // volumeSlider1
            // 
            this.volumeSlider1.Location = new System.Drawing.Point(692, 410);
            this.volumeSlider1.Name = "volumeSlider1";
            this.volumeSlider1.Size = new System.Drawing.Size(96, 28);
            this.volumeSlider1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create Synth";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(503, 331);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Location = new System.Drawing.Point(552, 51);
            this.waveformPainter1.Name = "waveformPainter1";
            this.waveformPainter1.Size = new System.Drawing.Size(236, 158);
            this.waveformPainter1.TabIndex = 5;
            this.waveformPainter1.Text = "waveformPainter1";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(147, 18);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(42, 13);
            this.time_label.TabIndex = 6;
            this.time_label.Text = "Time: 0";
            // 
            // play_button
            // 
            this.play_button.Location = new System.Drawing.Point(22, 13);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(24, 23);
            this.play_button.TabIndex = 7;
            this.play_button.Text = "▶︎";
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(52, 13);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(26, 23);
            this.pause_button.TabIndex = 8;
            this.pause_button.Text = "❚❚";
            this.pause_button.UseVisualStyleBackColor = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(84, 13);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(26, 23);
            this.stop_button.TabIndex = 9;
            this.stop_button.Text = "█";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.pause_button);
            this.Controls.Add(this.play_button);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.waveformPainter1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.volumeSlider1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NAudio.Gui.VolumeSlider volumeSlider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private NAudio.Gui.WaveformPainter waveformPainter1;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Button play_button;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.Button stop_button;
    }
}

