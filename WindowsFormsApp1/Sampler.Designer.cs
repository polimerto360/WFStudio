namespace WFStudio
{
    partial class Sampler
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pot1 = new NAudio.Gui.Pot();
            this.label2 = new System.Windows.Forms.Label();
            this.offset_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open WAV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current: None";
            // 
            // pot1
            // 
            this.pot1.Location = new System.Drawing.Point(25, 84);
            this.pot1.Maximum = 1D;
            this.pot1.Minimum = 0D;
            this.pot1.Name = "pot1";
            this.pot1.Size = new System.Drawing.Size(32, 32);
            this.pot1.TabIndex = 2;
            this.pot1.Value = 0.5D;
            this.pot1.ValueChanged += new System.EventHandler(this.pot1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start offset";
            // 
            // offset_label
            // 
            this.offset_label.AutoSize = true;
            this.offset_label.Location = new System.Drawing.Point(27, 119);
            this.offset_label.Name = "offset_label";
            this.offset_label.Size = new System.Drawing.Size(30, 13);
            this.offset_label.TabIndex = 4;
            this.offset_label.Text = "0.0 s";
            // 
            // Sampler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 148);
            this.Controls.Add(this.offset_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pot1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Sampler";
            this.Text = "Sampler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private NAudio.Gui.Pot pot1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label offset_label;
    }
}