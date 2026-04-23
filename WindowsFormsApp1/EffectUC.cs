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
    public partial class EffectUC : UserControl
    {
        public Effect Target;
        public Form TargetForm;
        public MixerTrack Track;
        public EffectUC(Effect targetForm, MixerTrack track)
        {
            InitializeComponent();
            Target = targetForm;
            TargetForm = (Form)targetForm;
            label1.Text = Target.GetType().Name;
            Track = track;
        }
        public EffectUC(Effect target, Form targetForm, MixerTrack track)
        {
            InitializeComponent();
            Target = target;
            TargetForm = targetForm;
            label1.Text = target.GetType().Name;
            Track = track;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TargetForm == null) return;

            if (TargetForm.Visible) TargetForm.Hide();
            else
            {
                TargetForm.Show();
                TargetForm.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Track.Effects.Remove(Target);
            TargetForm.Close();
            TargetForm.Dispose();
            Parent.Controls.Remove(this);
        }

        private void pot1_ValueChanged(object sender, EventArgs e)
        {
            Target.Mix = pot1.Value;
        }
    }
}
