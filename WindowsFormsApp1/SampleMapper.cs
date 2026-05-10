using NAudio.Gui;
using NAudio.Wave;
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
    public partial class SampleMapper : Form, Generator
    {
        public List<Note> CurNotes { get; set; } = new List<Note>();
        public event Action<Note> NotePlayed;
        public event Action<Note> NoteReleased;
        public int VoiceCount { get; set; } = 100;
        public NoteChannel noteChannel { get; set; }
        public MixerTrack Target { get; set; } = Program.Master;
        public WaveFileReader filereader;
        public Dictionary<int, List<float>> samplebuffer = new Dictionary<int, List<float>>();
        
       public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
        public void PlayNote(Note note)
        {
            if (!samplebuffer.ContainsKey((int)note.Semitones)) return;
            CurNotes.Add(note);
            NotePlayed?.Invoke(note);
        }
        public void ReleaseNote(Note note)
        {
            CurNotes.Remove(note);
            NoteReleased?.Invoke(note);
        }

        public void StopAll()
        {
            CurNotes.Clear();
        }

        public int Read(float[] buffer, int offset, int count)
        {
            if (samplebuffer != null)
            foreach (Note n in CurNotes.ToArray())
            {
                if (!samplebuffer.ContainsKey((int)n.Semitones)) continue;
                WaveGen.AddBufferResampled(buffer, samplebuffer[(int)n.Semitones].ToArray(), offset, count, n.ElapsedSamples, 2);
            }
            return count;
        }
        public SampleMapper()
        {
            InitializeComponent();
            GotFocus += (object sedner, EventArgs e) => { Program.mainWindow.keyboard.gen = this; };
            noteChannel = new NoteChannel(this);
            OnGotFocus(null);

            KeyDown += Program.mainWindow.keyboard.KeyDown; KeyUp += Program.mainWindow.keyboard.KeyUp;
            Program.Generators.Add(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                filereader = new WaveFileReader(openFileDialog1.FileName);
                if(!samplebuffer.ContainsKey((int)numericUpDown1.Value))
                {
                    samplebuffer.Add((int)numericUpDown1.Value, new List<float>());
                    SMSampleUC smuc = new SMSampleUC(this, (int)numericUpDown1.Value);
                    flowLayoutPanel1.Controls.Add(smuc);
                    Note tmp = new Note((double)numericUpDown1.Value);
                    smuc.label1.Text = $"Note: {tmp.Letter}{tmp.Octave}; Sample: {openFileDialog1.FileName}";
                } else
                {
                    foreach(var c in flowLayoutPanel1.Controls)
                    {
                        if(c is SMSampleUC)
                        {
                            SMSampleUC smuc = (SMSampleUC)c;
                            if (smuc.NoteSt == (int)numericUpDown1.Value)
                            {
                                Note tmp = new Note((double)numericUpDown1.Value);
                                smuc.label1.Text = $"Note: {tmp.Letter}{tmp.Octave}; Sample: {openFileDialog1.FileName}";
                                break;
                            }
                        }
                    }
                }
                List<float> curbuffer = samplebuffer[(int)numericUpDown1.Value];

                for (int i = 0; i < filereader.SampleCount; i++)
                {
                    curbuffer.AddRange(filereader.ReadNextSampleFrame());
                }
            }
            catch (FormatException er)
            {
                MessageBox.Show(er.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Note tmp = new Note((double)numericUpDown1.Value);
            label2.Text = $"({tmp.Letter}{tmp.Octave})";
        }
    }
}
