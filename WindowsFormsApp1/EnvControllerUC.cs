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
    public partial class EnvControlerUC : UserControl
    {
        public EnvControlerUC()
        {
            InitializeComponent();
        }
        private EnvController ec;
        public EnvController EC
        { 
            get
            {
                return ec;
            }
            set
            {
                ec = value;
                if (ec == null) return;
                
                attack_value_pot.Value = EC.Env.Attack / 10;
                attack_value_label.Text = EC.Env.Attack.ToString("f2");
                
                attack_tension_pot.Value = (EC.Env.Attack_tension + 1) / 2;
                attack_tension_label.Text = EC.Env.Attack_tension.ToString("f2");
                
                sustain_pot.Value = EC.Env.Sustain;
                sustain_value_label.Text = EC.Env.Sustain.ToString("f2");
                
                decay_value_pot.Value = EC.Env.Decay / 10;
                decay_value_label.Text = EC.Env.Decay.ToString("f2");
                
                decay_tension_pot.Value = (EC.Env.Decay_tension + 1) / 2;
                decay_tension_label.Text = EC.Env.Decay_tension.ToString("f2");
                
                release_value_pot.Value = EC.Env.Release / 10;
                release_value_label.Text = EC.Env.Release.ToString("f2");

                release_tension_pot.Value = (EC.Env.Release_tension + 1) / 2;
                release_tension_label.Text = EC.Env.Release_tension.ToString("f2");

                base_pot.Value = (EC.Base + 1) / 2;
                base_label.Text = EC.Base.ToString("f2");

                amplitude_pot.Value = (EC.Amplitude + 1) / 2;
                amplitude_label.Text = EC.Amplitude.ToString("f2");

                target_cb.Text = EC.TargetProperty;

                foreach (string s in EC.Target.Properties)
                {
                    target_cb.Items.Add(s);
                }
            }
        }
        private void attack_value_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Env.SetProperty("Attack", attack_value_pot.Value);
            attack_value_label.Text = EC.Env.Attack.ToString("f2");
        }

        private void attack_tension_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Env.SetProperty("Attack_tension", attack_tension_pot.Value * 2 - 1.0);
            attack_tension_label.Text = EC.Env.Attack_tension.ToString("f2");
        }

        private void sustain_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Env.SetProperty("Sustain", sustain_pot.Value);
            sustain_value_label.Text = EC.Env.Sustain.ToString("f2");
        }

        private void decay_value_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Env.SetProperty("Decay", decay_value_pot.Value);
            decay_value_label.Text = EC.Env.Decay.ToString("f2");
        }

        private void decay_tension_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Env.SetProperty("Decay_tension", decay_tension_pot.Value * 2 - 1.0);
            decay_tension_label.Text = EC.Env.Decay_tension.ToString("f2");
        }

        private void release_value_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Env.SetProperty("Release", release_value_pot.Value);
            release_value_label.Text = EC.Env.Release.ToString("f2");
        }

        private void release_tension_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Env.SetProperty("Release_tension", release_tension_pot.Value * 2 - 1.0);
            release_tension_label.Text = EC.Env.Release_tension.ToString("f2");
        }

        private void target_cb_SelectedValueChanged(object sender, EventArgs e)
        {
            EC.TargetProperty = target_cb.Text;
        }

        private void base_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Base = base_pot.Value * 2 - 1.0;
            base_label.Text = EC.Base.ToString("f2");
        }

        private void amplitude_pot_ValueChanged(object sender, EventArgs e)
        {
            EC.Amplitude = amplitude_pot.Value * 2 - 1.0;
            amplitude_label.Text = EC.Amplitude.ToString("f2");
        }
    }
}
