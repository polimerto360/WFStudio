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
        public Mixer mixer;
        public Action OnReset;
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
            numericUpDown1.Value = (decimal)Program.BPM;

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
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            MasterTrack.Paused = true;
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            //MasterTrack.Stopped = true;
            MasterTrack.Paused = true;
            Program.CurSample = 0;
            Program.StopAll();
            OnReset?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mixer == null)
            {
                mixer = new Mixer();
            }
            mixer.Show();
            mixer.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sampler p = new Sampler();
            //keyboard.gen = p;
            p.Show();
            GeneratorUC g = new GeneratorUC();
            g.Gen = p;
            g.GenUI = p;
            //g.Location = new Point(0, flowLayoutPanel1.Controls.Count * g.Height);
            flowLayoutPanel1.Controls.Add(g);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Program.BPM = (double)numericUpDown1.Value;
            if(pianoroll != null) pianoroll.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SampleMapper p = new SampleMapper();
            //keyboard.gen = p;
            p.Show();
            GeneratorUC g = new GeneratorUC();
            g.Gen = p;
            g.GenUI = p;
            //g.Location = new Point(0, flowLayoutPanel1.Controls.Count * g.Height);
            flowLayoutPanel1.Controls.Add(g);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Program.CurProject.filepath = saveFileDialog1.FileName;
            Program.CurProject.Save();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Program.CurProject.filepath;
            saveFileDialog1.DefaultExt = "wfp";
            saveFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Generator g in Program.CurProject.Generators) ((Form)g).Visible = false;
            Program.CurProject.Generators.Clear();

            if (pianoroll != null)
            {
                pianoroll.closing = true;
                pianoroll.Close();
            }
            if (mixer != null)
            {
                mixer.closing = true;
                mixer.Close();
            }

            Program.LoadProject(openFileDialog1.FileName);
            foreach(Generator g in Program.CurProject.Generators)
            {
                GeneratorUC guc = new GeneratorUC();
                guc.Gen = g;
                guc.GenUI = (Form)g;
                guc.numericUpDown1.Value = Program.CurProject.Tracks.IndexOf(g.Target) + 1;
                flowLayoutPanel1.Controls.Add(guc);
            }
        }
    }
}
