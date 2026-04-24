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
            KeyDown += Program.mainWindow.keyboard.KeyDown;
            KeyUp += Program.mainWindow.keyboard.KeyUp;
            KeyPreview = true;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.Items[comboBox1.SelectedIndex])
            {
                case "Gain": Target.Effects.Add(new Gain()); break;
                case "Compressor": Target.Effects.Add(new Compressor()); break;
                default: return;
            }
            flowLayoutPanel1.Controls.Add(new EffectUC(Target.Effects.Last(), Target));
            comboBox1.Text = "Add effect";
        }
    }
}
