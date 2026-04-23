namespace WFStudio
{
    partial class GeneratorUC
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
            this.toggle_button = new System.Windows.Forms.Button();
            this.pianoroll_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.remove_channel = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // toggle_button
            // 
            this.toggle_button.Location = new System.Drawing.Point(17, 47);
            this.toggle_button.Name = "toggle_button";
            this.toggle_button.Size = new System.Drawing.Size(100, 23);
            this.toggle_button.TabIndex = 0;
            this.toggle_button.Text = "Toggle panel";
            this.toggle_button.UseVisualStyleBackColor = true;
            this.toggle_button.Click += new System.EventHandler(this.toggle_button_Click);
            // 
            // pianoroll_button
            // 
            this.pianoroll_button.Location = new System.Drawing.Point(139, 47);
            this.pianoroll_button.Name = "pianoroll_button";
            this.pianoroll_button.Size = new System.Drawing.Size(110, 23);
            this.pianoroll_button.TabIndex = 1;
            this.pianoroll_button.Text = "Open Piano roll";
            this.pianoroll_button.UseVisualStyleBackColor = true;
            this.pianoroll_button.Click += new System.EventHandler(this.pianoroll_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Synth";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mixer channel:";
            // 
            // remove_channel
            // 
            this.remove_channel.BackColor = System.Drawing.Color.OrangeRed;
            this.remove_channel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.remove_channel.Location = new System.Drawing.Point(358, 3);
            this.remove_channel.Name = "remove_channel";
            this.remove_channel.Size = new System.Drawing.Size(23, 23);
            this.remove_channel.TabIndex = 5;
            this.remove_channel.Text = "X";
            this.remove_channel.UseVisualStyleBackColor = false;
            this.remove_channel.Click += new System.EventHandler(this.remove_channel_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(340, 49);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // GeneratorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.remove_channel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pianoroll_button);
            this.Controls.Add(this.toggle_button);
            this.Name = "GeneratorUC";
            this.Size = new System.Drawing.Size(405, 96);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toggle_button;
        private System.Windows.Forms.Button pianoroll_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button remove_channel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
