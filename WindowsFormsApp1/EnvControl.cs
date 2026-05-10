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

    public partial class EnvControl : UserControl
    {
        public EnvControl()
        {
            InitializeComponent();
        }
        private Envelope env;
        public Envelope Env 
        { 
            get
            {
                return env;
            }
            set
            {
                env = value;
                if (env == null) return;
                attack_value_pot.Value = Env.Attack / 10;
                attack_value_label.Text = Env.Attack.ToString("f2");
                attack_tension_pot.Value = (Env.Attack_tension + 1) / 2;
                attack_tension_label.Text = Env.Attack_tension.ToString("f2");
                sustain_pot.Value = Env.Sustain;
                sustain_value_label.Text = Env.Sustain.ToString("f2");
                decay_value_pot.Value = Env.Decay / 10;
                decay_value_label.Text = Env.Decay.ToString("f2");
                decay_tension_pot.Value = (Env.Decay_tension + 1) / 2;
                decay_tension_label.Text = Env.Decay_tension.ToString("f2");
                release_value_pot.Value = Env.Release / 10;
                release_value_label.Text = Env.Release.ToString("f2");
                release_tension_pot.Value = (Env.Release_tension + 1) / 2;
                release_tension_label.Text = Env.Release_tension.ToString("f2");
            }
        }
        private void attack_value_pot_ValueChanged(object sender, EventArgs e)
        {
            Env.SetProperty("Attack", attack_value_pot.Value);
            attack_value_label.Text = Env.Attack.ToString("f2");
        }

        private void attack_tension_pot_ValueChanged(object sender, EventArgs e)
        {
            Env.SetProperty("Attack_tension", attack_tension_pot.Value * 2 - 1.0);
            attack_tension_label.Text = Env.Attack_tension.ToString("f2");
        }

        private void sustain_pot_ValueChanged(object sender, EventArgs e)
        {
            Env.SetProperty("Sustain", sustain_pot.Value);
            sustain_value_label.Text = Env.Sustain.ToString("f2");
        }

        private void decay_value_pot_ValueChanged(object sender, EventArgs e)
        {
            Env.SetProperty("Decay", decay_value_pot.Value);
            decay_value_label.Text = Env.Decay.ToString("f2");
        }

        private void decay_tension_pot_ValueChanged(object sender, EventArgs e)
        {
            Env.SetProperty("Decay_tension", decay_tension_pot.Value * 2 - 1.0);
            decay_tension_label.Text = Env.Decay_tension.ToString("f2");
        }

        private void release_value_pot_ValueChanged(object sender, EventArgs e)
        {
            Env.SetProperty("Release", release_value_pot.Value);
            release_value_label.Text = Env.Release.ToString("f2");
        }

        private void release_tension_pot_ValueChanged(object sender, EventArgs e)
        {
            Env.SetProperty("Release_tension", release_tension_pot.Value * 2 - 1.0);
            release_tension_label.Text = Env.Release_tension.ToString("f2");
        }
    }
}
