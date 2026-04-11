using NAudio.Dmo.Effect;
using NAudio.Dsp;
using NAudio.Mixer;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
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
    public partial class Synth : Form, Generator, ModProperties
    {
        public int VoiceCount { get; set; } = 16;
        public MixerTrack Target { get; set; } = Program.Master;
        public List<string> Properties { get; private set; } = new List<string>
        {
            "VoiceCount",
            "OscShape"
        };
        Envelope env = new Envelope(attack: 0.05, sustain: 0, decay: 0.5, decay_tension: -0.3, release: 0.1);
        public List<Note> CurNotes { get; set; } = new List<Note>();
        public void PlayNote(Note n)
        {
            CurNotes.Add(n);
        }
        public void ReleaseNote(Note n)
        {
            n.ReleasedTime = Program.Time;
        }
        public void StopAll()
        {
            CurNotes = new List<Note>();
        }
        
        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++) buffer[i] = 0f;
            for (int i = 0; i < CurNotes.Count; i++)
            {
                Note note = CurNotes[i];
                if(note.TimeSinceRelease >= env.Release)
                {
                    CurNotes.RemoveAt(i--);
                    continue;
                }

                if (Program.Time > note.Start)
                {
                    if (Program.Time <= note.Start + note.Length || note.Length < 0)
                    {
                        float[] note_buffer = new float[count];
                        WaveGen.Saw(ref note_buffer, ref note);
                        Envelope.Apply(ref note_buffer, env, ref note);
                        WaveGen.AddBuffer(ref buffer, ref note_buffer, offset, count);
                        //BiQuadFilter.LowPassFilter(44100, 10000, 2).
                        //DmoEffectWaveProvider<DmoCompressor> n = new DmoEffectWaveProvider<DmoCompressor>();
                        
                    }
                    else
                    {
                        CurNotes.RemoveAt(i--);
                    }
                }
            }
            return count;
        }
        public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);

        public Synth()
        {
            Program.Generators.Add(this);
            foreach (string s in env.Properties)
            {
                Properties.Add("Envelope." + s);
            }
            GotFocus += (object sedner, EventArgs e) => { Program.mainWindow.keyboard.gen = this; };
            KeyDown += Program.mainWindow.keyboard.KeyDown; KeyUp += Program.mainWindow.keyboard.KeyUp;
            InitializeComponent();
        }
        public bool SetProperty(string name, double value)
        {
            if (env.SetProperty(name.Substring(name.IndexOf('.')), value)) return true;
            switch(name)
            {
                case "VoiceCount": VoiceCount = (value < 0 ? int.MaxValue : (int)(value * 32)); return true;
                case "OscShape": return true;
            }
            return false;
        }
    }
}
