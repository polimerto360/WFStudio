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
    public partial class Sampler : Form, Generator
    {
        public List<Note> CurNotes { get; set; } = new List<Note>();
        public event Action<Note> NotePlayed;
        public event Action<Note> NoteReleased;
        public int VoiceCount { get; set; } = 100;
        public NoteChannel noteChannel { get; set; }
        public MixerTrack Target { get; set; } = Program.CurProject.Master;
        public WaveFileReader filereader;
        public List<float> samplebuffer;
        public string samplefilepath;
        public double BasePitch = 261.63;

        public long SampleOffset = 0;
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
                WaveGen.AddBufferResampled(buffer, samplebuffer.ToArray(), offset, count, n.ElapsedSamples + SampleOffset, n.Pitch / BasePitch);
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
            Program.CurProject.Generators.Add(this);
            openFileDialog1.ShowDialog(this);
        }
        public void loadsample(string path)
        {
            try
            {
                filereader = new WaveFileReader(path);
                samplebuffer = new List<float>();
                for (int i = 0; i < filereader.SampleCount; i++)
                {
                    samplebuffer.AddRange(filereader.ReadNextSampleFrame());
                }
                label1.Text = "Current: " + path;
                pot1.Value = 0.0;
                pot1_ValueChanged(null, null);
                samplefilepath = path;

            }
            catch (FormatException er)
            {
                MessageBox.Show(er.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Text = "Current: None";
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loadsample(openFileDialog1.FileName);
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

        private void pot1_ValueChanged(object sender, EventArgs e)
        {
            SampleOffset = (long)(pot1.Value * samplebuffer.Count);
            offset_label.Text = (SampleOffset / (double)Program.audio_output.OutputWaveFormat.SampleRate).ToString("0.00") + " s";
        }

        public object ToJsonObj()
        {
            return new
            {
                sample = samplefilepath,
                target = Program.CurProject.Tracks.IndexOf(Target),
                notechannel = noteChannel

            };
        }

        public Jsonconvertible FromJson(dynamic json)
        {
            loadsample(json.sample);

            if (Convert.ToInt32(json.target) == -1) Target = Program.CurProject.Master;
            else Target = Program.CurProject.Tracks[Convert.ToInt32(json.target)];

            noteChannel = new NoteChannel(this);
            noteChannel.NotesByStart = json.notechannel.NotesByStart.ToObject<List<Note>>();

            return this;
        }
    }
}
