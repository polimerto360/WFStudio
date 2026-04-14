using NAudio.Gui;
using NAudio.Wave;
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
    public partial class MainWindow : Form
    {
        public Pianoroll pianoroll;
        public event Action OnReset;
        public MainWindow()
        {
            InitializeComponent();
            KeyDown += keyboard.KeyDown;
            KeyUp += keyboard.KeyUp;

            MasterTrack.OnRead += (float[] buffer, int count) =>
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        for (int i = 0; i < count; i++)
                        {
                            waveformPainter1.AddMax(buffer[i]);
                        }
                        waveformPainter1.Refresh();
                        time_label.Text = "Time: " + Program.SamplesToTime(Program.CurSample).ToString("0.00") + "s";
                    }));
                }
            };

        }
        public Keyboard keyboard = new Keyboard();
        private void button1_Click(object sender, EventArgs e)
        {
            Synth p = new Synth();
            //keyboard.gen = p;
            p.Show();
            GeneratorUC g = new GeneratorUC();
            g.Gen = p;
            g.GenUI = p;
            //g.Location = new Point(0, flowLayoutPanel1.Controls.Count * g.Height);
            flowLayoutPanel1.Controls.Add(g);
            
            //p.KeyDown += keyboard.KeyDown;
            //p.KeyUp += keyboard.KeyUp;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyboard.KeyDown(sender, e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyboard.KeyUp(sender, e);
        }
        public void AddPianoroll(Generator gen)
        {
            if(pianoroll != null)
            {
                pianoroll.Close();
            }
            pianoroll = new Pianoroll(gen);
            pianoroll.Show();
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            MasterTrack.Paused = false;
            MasterTrack.Stopped = false;
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            MasterTrack.Paused = true;
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            MasterTrack.Stopped = true;
            Program.CurSample = 0;
            OnReset?.Invoke();
        }
    }
}
