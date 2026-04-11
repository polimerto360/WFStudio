using NAudio.Gui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public partial class LFOControl : UserControl
    {
        public LFOControl()
        {
            InitializeComponent();

        }
        private LFO lfo;
        public LFO Lfo 
        { 
            get
            {
                return lfo;
            }
            set
            {
                lfo = value;
                if (lfo == null) return;
                base_pot.Value = (Lfo.Base + 1) / 2;
                base_label.Text = Lfo.Base.ToString("f2");

                freq_pot.Value = (Math.Log(Lfo.Frequency) / Math.Log(20) + 1) / 2;
                freq_label.Text = Lfo.Frequency.ToString("f2");

                amp_pot.Value = (Lfo.Amplitude + 1) / 2;
                amp_label.Text = Lfo.Amplitude.ToString("f2");

                targetcb.Text = Lfo.TargetProperty;
                wavetypecb.Text = Lfo.WaveType.ToString();

                foreach (string s in Lfo.Target.Properties)
                {
                    targetcb.Items.Add(s);
                }
            }
        }
        private void base_pot_ValueChanged(object sender, EventArgs e)
        {
            Lfo.SetProperty("Base", base_pot.Value * 2 - 1.0);
            base_label.Text = Lfo.Base.ToString("f2");
        }

        private void freq_pot_ValueChanged(object sender, EventArgs e)
        {
            Lfo.SetProperty("Frequency", freq_pot.Value * 2 - 1.0);
            freq_label.Text = Lfo.Frequency.ToString("f2");
        }

        private void amp_pot_ValueChanged(object sender, EventArgs e)
        {
            Lfo.SetProperty("Amplitude", amp_pot.Value * 2 - 1.0);
            amp_label.Text = Lfo.Amplitude.ToString("f2");
        }

        private void targetcb_SelectedValueChanged(object sender, EventArgs e)
        {
            Lfo.TargetProperty = targetcb.SelectedItem.ToString();
        }

        private void wavetypecb_SelectedValueChanged(object sender, EventArgs e)
        {
            Lfo.WaveType = (WaveGen.Waves)wavetypecb.SelectedIndex;
        }
    }
}
