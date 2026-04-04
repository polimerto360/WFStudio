using NAudio.Dsp;
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
    public partial class Synth : Form, Generator
    {
        public int VoiceCount { get; set; } = 16;
        Envelope env = new Envelope();
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
                        WaveGen.Sine(ref buffer, offset, count, env, ref note);
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
            InitializeComponent();
        }
    }
}
