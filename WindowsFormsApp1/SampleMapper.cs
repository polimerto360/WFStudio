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
    [Serializable]
    public partial class SampleMapper : Form, Generator
    {
        public List<Note> CurNotes { get; set; } = new List<Note>();
        public event Action<Note> NotePlayed;
        public event Action<Note> NoteReleased;
        public int VoiceCount { get; set; } = 100;
        public NoteChannel noteChannel { get; set; }
        public MixerTrack Target { get; set; } = Program.CurProject.Master;
        public WaveFileReader filereader;
        public Dictionary<int, string> samplepaths = new Dictionary<int, string>();
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
            Program.CurProject.Generators.Add(this);
        }
        public void loadsample(int note, string path)
        {
            try
            {
                filereader = new WaveFileReader(path);
                if (!samplebuffer.ContainsKey(note))
                {
                    samplebuffer.Add(note, new List<float>());
                    samplepaths.Add(note, path);
                    SMSampleUC smuc = new SMSampleUC(this, note);
                    flowLayoutPanel1.Controls.Add(smuc);
                    Note tmp = new Note((double)note);
                    smuc.label1.Text = $"Note: {tmp.Letter}{tmp.Octave}; Sample: {path}";
                }
                else
                {
                    foreach (var c in flowLayoutPanel1.Controls)
                    {
                        if (c is SMSampleUC)
                        {
                            SMSampleUC smuc = (SMSampleUC)c;
                            if (smuc.NoteSt == note)
                            {
                                Note tmp = new Note((double)note);
                                smuc.label1.Text = $"Note: {tmp.Letter}{tmp.Octave}; Sample: {path}";
                                break;
                            }
                        }
                    }
                }
                List<float> curbuffer = samplebuffer[note];

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
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loadsample((int)numericUpDown1.Value, openFileDialog1.FileName);
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

        public object ToJsonObj()
        {
            return new
            {
                samples = samplepaths,
                target = Program.CurProject.Tracks.IndexOf(Target),
                notechannel = noteChannel

            };
        }

        public Jsonconvertible FromJson(dynamic json)
        {
            foreach(KeyValuePair<int, string> kp in json.samples.ToObject<Dictionary<int, string>>())
            loadsample(kp.Key, kp.Value);

            if (Convert.ToInt32(json.target) == -1) Target = Program.CurProject.Master;
            else Target = Program.CurProject.Tracks[Convert.ToInt32(json.target)];

            noteChannel = new NoteChannel(this);
            noteChannel.NotesByStart = json.notechannel.NotesByStart.ToObject<List<Note>>();

            return this;
        }
    }
}
