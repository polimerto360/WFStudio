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
    public partial class EffectsRack : Form
    {
        public MixerTrack Target;
        public EffectsRack(MixerTrack target)
        {
            InitializeComponent();
            Target = target;
            foreach (Effect effect in Target.Effects)
            {
                flowLayoutPanel1.Controls.Add(new EffectUC(effect, Target));
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Target.Effects.Add(new Gain());
            flowLayoutPanel1.Controls.Add(new EffectUC(Target.Effects.Last(), Target));
        }
    }
}
