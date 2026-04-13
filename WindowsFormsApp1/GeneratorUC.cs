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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int ind = -1;
            if(int.TryParse(textBox2.Text, out ind) && ind >= 0 && ind < Program.Tracks.Count)
            {
                if(ind == 0) Gen.Target = Program.Master;
                else Gen.Target = Program.Tracks[ind-1];
            }
        }

        private void pianoroll_button_Click(object sender, EventArgs e)
        {
            //TODO: Pianoroll
        }

        private void remove_channel_Click(object sender, EventArgs e)
        {
            GenUI.Close();
            Program.Generators.Remove(Gen);
            //TODO: Remove from parent
        }
    }
}
