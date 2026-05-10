using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WFStudio
{
    public partial class GeneratorUC : UserControl
    {
        public Generator Gen;
        public Form GenUI;
        public GeneratorUC()
        {
            InitializeComponent();
        }

        private void toggle_button_Click(object sender, EventArgs e)
        {
            if (GenUI == null) return;
            if (GenUI.Visible) GenUI.Hide();
            else GenUI.Show();
        }


        private void pianoroll_button_Click(object sender, EventArgs e)
        {
            Program.mainWindow.AddPianoroll(Gen);
        }

        private void remove_channel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to remove this channel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            GenUI.Close();
            if(Program.mainWindow.pianoroll != null && Program.mainWindow.pianoroll.Gen == Gen)
            {
                Program.mainWindow.pianoroll.Close();
                Program.mainWindow.pianoroll = null;
            }
            Program.CurProject.Generators.Remove(Gen);
            Parent.Controls.Remove(this);
            //TODO: Remove from parent
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int ind = (int)numericUpDown1.Value;
            if (ind <= Program.CurProject.Tracks.Count)
            {
                if (ind == 0) Gen.Target = Program.CurProject.Master;
                else Gen.Target = Program.CurProject.Tracks[ind - 1];
            }
            else numericUpDown1.Value = Program.CurProject.Tracks.Count;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
