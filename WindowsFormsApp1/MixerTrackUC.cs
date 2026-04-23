using NAudio.Wave.SampleProviders;
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
    public partial class MixerTrackUC : UserControl
    {
        public MixerTrack Target;
        public EffectsRack rack;
        public MixerTrackUC(MixerTrack target)
        {
            InitializeComponent();
            Target = target;
            MasterTrack.OnRead += (float[] buffer, int count) =>
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        volumeMeter1.Amplitude = Target.maxamp;
                    }));
                }
            };
            label1.Text = "Track " + (Program.Tracks.IndexOf(target) + 1);
            if (Target == Program.Master) button2.Hide();


        }

        private void volumeSlider1_VolumeChanged(object sender, EventArgs e)
        {
            Target.Volume = volumeSlider1.Volume;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rack != null) { rack.Show(); rack.Focus(); return; }
            rack = new EffectsRack(Target);
            rack.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Target == Program.Master) return;
            if(MessageBox.Show("Are you sure you want to remove this channel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Program.Tracks.Remove(Target);
                Parent.Controls.Remove(this);
            }
        }
    }
}
