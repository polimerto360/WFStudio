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
    public partial class Gain : Form, Effect
    {
        public float Volume = 1f;
        public double Mix { get; set; } =  1;
        public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] *= Volume;
            }
            return count;
        }
        public List<string> Properties { get; } = new List<string>
        {
            "Volume"
        };
        public bool SetProperty(string name, double value)
        {
            if (name == "Volume")
            {
                Volume = (float)value;
                return true;
            }
            return false;
        }
        public double GetBaseValue(string name) { return 0; }
        public Gain()
        {
            InitializeComponent();
            KeyDown += Program.mainWindow.keyboard.KeyDown;
            KeyUp += Program.mainWindow.keyboard.KeyUp;
            KeyPreview = true;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void pot1_ValueChanged(object sender, EventArgs e)
        {
            Volume = (float)Math.Pow(pot1.Value * 2, 2);
            label1.Text = Volume.ToString("0.00");
        }
    }
}
