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
    public partial class Mixer : Form
    {
        public Mixer()
        {
            InitializeComponent();
            KeyDown += Program.mainWindow.keyboard.KeyDown;
            KeyUp += Program.mainWindow.keyboard.KeyUp;
            flowLayoutPanel1.Controls.Add(new MixerTrackUC(Program.Master));
            foreach (MixerTrack t in Program.Tracks)
            {
                flowLayoutPanel1.Controls.Add(new MixerTrackUC(t));
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MixerTrack t = new MixerTrack();
            Program.Tracks.Add(t);
            flowLayoutPanel1.Controls.Add(new MixerTrackUC(t));
        }
    }
}
