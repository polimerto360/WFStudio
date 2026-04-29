using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public partial class Compressor : Form, Effect
    {
        public double Mix { get; set; } =  1;
        public float Ratio = 0.9f;
        public float ActivationLevel = 0;
        public float Treshold = 0.5f;
        public float Attack = 0.08f;
        public float Release = 0.2f;
        public float PostGain = 1f;
        public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
        public int Read(float[] buffer, int offset, int count)
        {
            float peak = 0;
            for (int i = offset; i < offset + count; i++)
            {
                peak = Math.Max(peak, buffer[i]);
            }
            
            if(peak >= Treshold)
            {
                ActivationLevel = (float)Math.Min(Math.Max(ActivationLevel + Program.SamplesToTime(count) / Attack, 0), 1);
            } else
            {
                ActivationLevel = (float)Math.Min(Math.Max(ActivationLevel - Program.SamplesToTime(count) / Release, 0), 1);
            }

            for (int i = offset; i < offset + count; i++)
            {
                WaveGen.temp_buf[i-offset] = buffer[i];
                
                WaveGen.temp_buf[i - offset] *= (float)Envelope.Lerp(1, Treshold, Envelope.Lerp(0, Ratio, ActivationLevel));
                
                WaveGen.temp_buf[i - offset] *= PostGain;
            }
            WaveGen.Mix(buffer, offset, count, Mix);

            return count;
        }
        public List<string> Properties { get; } = new List<string>
        {
            "Ratio",
            "Treshold",
            "Attack",
            "Release",
            "PostGain"
        };
        public bool SetProperty(string name, double value)
        {
            switch(name)
            {
                case "Ratio": Ratio = (float)value; break;
                case "Treshold": Treshold = (float)value; break;
                case "Attack": Attack = (float)value; break;
                case "Release": Release = (float)value; break;
                case "PostGain": PostGain = (float)value * 10; break;
            }
            return false;
        }
        public double GetBaseValue(string name) { return 0; }
        public Compressor()
        {
            InitializeComponent();
            KeyDown += Program.mainWindow.keyboard.KeyDown;
            KeyUp += Program.mainWindow.keyboard.KeyUp;
            KeyPreview = true;
            ratio_pot.Value = Ratio;
            treshold_pot.Value = Treshold;
            attack_pot.Value = Attack;
            release_pot.Value = Release;
            gain_pot.Value = PostGain / 10;
            pot1_ValueChanged(null, null);
            ratio_pot_ValueChanged(null, null);
            attack_pot_ValueChanged(null, null);
            release_pot_ValueChanged(null, null);
            gain_pot_ValueChanged(null, null);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void pot1_ValueChanged(object sender, EventArgs e)
        {
            Treshold = (float)treshold_pot.Value;
            treshold_label.Text = Treshold.ToString("0.00");
        }

        private void ratio_pot_ValueChanged(object sender, EventArgs e)
        {
            Ratio = (float)ratio_pot.Value;
            ratio_label.Text = Ratio.ToString("0.00");
        }

        private void attack_pot_ValueChanged(object sender, EventArgs e)
        {
            Attack = (float)attack_pot.Value;
            attack_label.Text = Attack.ToString("0.00") + " s";
        }

        private void release_pot_ValueChanged(object sender, EventArgs e)
        {
            Release = (float)release_pot.Value;
            release_label.Text = Release.ToString("0.00") + " s";
        }

        private void gain_pot_ValueChanged(object sender, EventArgs e)
        {
            PostGain = (float)gain_pot.Value * 10;
            gain_label.Text = PostGain.ToString("0.00");
        }
    }
}
