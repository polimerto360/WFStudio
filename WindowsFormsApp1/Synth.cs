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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WFStudio
{
    public partial class Synth : Form, Generator, ModProperties
    {
        public int VoiceCount { get; set; } = 16;
        public MixerTrack Target { get; set; } = Program.Master;
        public WaveGen.Waves WaveType { get; set; } = WaveGen.Waves.SAW;
        public double Volume = 1.0;
        public List<string> Properties { get; private set; } = new List<string>
        {
            "Off",
            "Pitch shift",
            "Volume"
        };
        public Envelope env = new Envelope(attack: 0.05, sustain: 0, decay: 0.5, decay_tension: -0.3, release: 0.1);
        public LFO lfo;
        public FilterWrap Filter = new FilterWrap(1000, 2, FilterWrap.FilterType.LOWPASS);
        public EnvController EC;
        public List<Note> CurNotes { get; set; } = new List<Note>();
        
        public double pitch_shift = 1;
        public void PlayNote(Note n)
        {
            CurNotes.Add(n);
            EC.CurNote = new Note(n.Semitones, n.Length, n.Start);
        }
        public void ReleaseNote(Note n)
        {
            n.ReleasedTime = Program.Time;
            if(EC.CurNote != null && EC.CurNote.Pitch == n.Pitch) EC.CurNote.ReleasedTime = Program.Time;
        }
        public void StopAll()
        {
            CurNotes = new List<Note>();
        }
        
        public int Read(float[] buffer, int offset, int count)
        {
            float[] note_buffer = new float[count];
            // Controller updates
            if (lfo != null) lfo.Update(count);
            if (EC != null) EC.Update(count);

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
                        for(int j = 0; j < count; j++) note_buffer[j] = 0f;
                        
                        note.Phase = WaveGen.Generate(ref note_buffer, WaveType, note.Phase, note.Pitch * pitch_shift, Volume * note.Velocity);
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
            WaveGen.ApplyFilter(ref buffer, offset, count, Filter);
            
            float amplitude = 0f;
            for (int i = offset; i < offset + count; i++)
                amplitude = Math.Max(amplitude, Math.Abs(buffer[i]));

            // marshal update (safe)
            if (volumeMeter1 != null && !(volumeMeter1.IsDisposed || volumeMeter1.Disposing))
            {
                if (volumeMeter1.InvokeRequired)
                    volumeMeter1.BeginInvoke((Action)(() => volumeMeter1.Amplitude = amplitude));
                else
                    volumeMeter1.Amplitude = amplitude;
            }

            return count;
        }
        public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);

        public Synth()
        {
            foreach (string s in env.Properties)
            {
                Properties.Add("Envelope." + s);
            }
            foreach (string s in Filter.Properties)
            {
                Properties.Add("Filter." + s);
            }
            GotFocus += (object sedner, EventArgs e) => { Program.mainWindow.keyboard.gen = this; };
            OnGotFocus(null);
               
            KeyDown += Program.mainWindow.keyboard.KeyDown; KeyUp += Program.mainWindow.keyboard.KeyUp;
            InitializeComponent();
            // Initialization for controls
            envControl1.Env = env;

            lfo = new LFO(this, "Pitch shift", 5, 0.1, 0, WaveGen.Waves.SINE, 0);
            lfoControl1.Lfo = lfo;
            
            EC = new EnvController(this, "Pitch shift", new Envelope(), 0, 1);
            envControlerUC1.EC = EC;

            filterControl1.Filter = Filter;

            // Ready
            Program.Generators.Add(this);
        }
        public bool SetProperty(string name, double value)
        {
            if(name.IndexOf('.') > -1)
            {
                switch(name.Substring(0, name.IndexOf('.')))
                {
                    case "Envelope": return env.SetProperty(name.Substring(name.IndexOf('.')+1), value);
                    case "Filter": return Filter.SetProperty(name.Substring(name.IndexOf('.') + 1), value);
                }
                return false;
            }

            switch (name)
            {
                case "VoiceCount": VoiceCount = (value < 0 ? int.MaxValue : (int)(value * 32)); return true;
                case "Pitch shift": pitch_shift = Math.Pow(2, value); return true;
                case "Volume": volumeSlider1.Volume = (float)Math.Abs(value); return true;
            }
            return false;
        }

        public double GetBaseValue(string name)
        {
            //if (name.IndexOf('.') > -1)
              //  if (env.GetBaseValue(name.Substring(name.IndexOf('.'))) != 0) return env.GetBaseValue(name.Substring(name.IndexOf('.')));
            switch (name)
            {
                case "Pitch shift": return pot8.Value * 4 - 2.0 + (pot9.Value * 2 - 1.0) / 12;
            }
            return 0;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            WaveType = (WaveGen.Waves)listBox1.SelectedIndex;
        }

        private void pot8_ValueChanged(object sender, EventArgs e)
        {
            pot8.Value = Math.Round(pot8.Value * 48) / 48;
            label15.Text = ((int)(pot8.Value * 48 - 24)).ToString();
            SetProperty("Pitch shift", pot8.Value * 4 - 2.0 + (pot9.Value * 2 - 1.0) / 12);
        }

        private void pot9_ValueChanged(object sender, EventArgs e)
        {
            label17.Text = (pot9.Value * 200 - 100).ToString("f2");
            SetProperty("Pitch shift", pot8.Value * 4 - 2.0 + (pot9.Value * 2 - 1.0) / 12);
        }

        private void Synth_MouseClick(object sender, MouseEventArgs e)
        {
            Program.mainWindow.keyboard.gen = this;
        }

        private void volumeSlider1_VolumeChanged(object sender, EventArgs e)
        {
            Volume = volumeSlider1.Volume;
        }
    }
}
