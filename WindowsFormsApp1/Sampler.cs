using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave;

namespace WFStudio
{
    public partial class Sampler : Form, Generator
    {
        public List<Note> CurNotes { get; set; } = new List<Note>();
        public event Action<Note> NotePlayed;
        public event Action<Note> NoteReleased;
        public int VoiceCount { get; set; } = 100;
        public NoteChannel noteChannel { get; set; }
        public MixerTrack Target { get; set; } = Program.Master;
        public WaveFileReader filereader;
        public List<float> samplebuffer;
        public double BasePitch = 261.63;
        public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
        public void PlayNote(Note note)
        {
            CurNotes.Add(note);
            NotePlayed?.Invoke(note);
        }
        public void ReleaseNote(Note note)
        {
            CurNotes.Remove(note);
            NoteReleased?.Invoke(note);
        }

        public void StopAll() { 
            CurNotes.Clear(); 
        }

        public int Read(float[] buffer, int offset, int count)
        {
            if(samplebuffer != null)
            foreach(Note n in CurNotes.ToArray()) {
                WaveGen.AddBufferResampled(buffer, samplebuffer.ToArray(), offset, count, n.ElapsedSamples, n.Pitch / BasePitch);
            }
            return count;
        }
        public Sampler()
        {
            InitializeComponent();
            GotFocus += (object sedner, EventArgs e) => { Program.mainWindow.keyboard.gen = this; };
            noteChannel = new NoteChannel(this);
            OnGotFocus(null);

            KeyDown += Program.mainWindow.keyboard.KeyDown; KeyUp += Program.mainWindow.keyboard.KeyUp;
            Program.Generators.Add(this);
            openFileDialog1.ShowDialog(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                filereader = new WaveFileReader(openFileDialog1.FileName);
                samplebuffer = new List<float>();
                for (int i = 0; i < filereader.SampleCount; i++)
                {
                   samplebuffer.AddRange(filereader.ReadNextSampleFrame());
                }
                label1.Text = "Current: " + openFileDialog1.FileName;

            } catch(FormatException er)
            {
                MessageBox.Show(er.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Text = "Current: None";
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
    }
}
