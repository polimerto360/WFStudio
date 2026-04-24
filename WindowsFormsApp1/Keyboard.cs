using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public class Keyboard
    {
        int octave = 5;
        public Dictionary<Keys, Note> notes = new Dictionary<Keys, Note>();
        public Generator gen;
        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MasterTrack.Paused = !MasterTrack.Paused;
                if (MasterTrack.Paused)
                {
                    Program.CurSample = 0;
                    Program.mainWindow.OnReset?.Invoke();
                }


                return;
            }
            if (e.KeyCode == Keys.Up && e.Control)
            {
                octave++;
                return;
            }
            if (e.KeyCode == Keys.Down && e.Control)
            {
                octave--;
                return;
            }
            
            if (notes.ContainsKey(e.KeyCode) || gen == null) return;
            int semitones = -1;
            switch (e.KeyCode)
            {
                case Keys.Z: semitones = 0; break;
                case Keys.S: semitones = 1; break;
                case Keys.X: semitones = 2; break;
                case Keys.D: semitones = 3; break;
                case Keys.C: semitones = 4; break;
                case Keys.V: semitones = 5; break;
                case Keys.G: semitones = 6; break;
                case Keys.B: semitones = 7; break;
                case Keys.H: semitones = 8; break;
                case Keys.N: semitones = 9; break;
                case Keys.J: semitones = 10; break;
                case Keys.M: semitones = 11; break;
                case Keys.Oemcomma: semitones = 12; break;
                case Keys.L: semitones = 13; break;
                case Keys.OemPeriod: semitones = 14; break;
                case Keys.OemSemicolon: semitones = 15; break;
                case Keys.OemQuestion: semitones = 16; break;

                case Keys.Q: semitones = 12; break;
                case Keys.D2: semitones = 13; break;
                case Keys.W: semitones = 14; break;
                case Keys.D3: semitones = 15; break;
                case Keys.E: semitones = 16; break;
                case Keys.R: semitones = 17; break;
                case Keys.D5: semitones = 18; break;
                case Keys.T: semitones = 19; break;
                case Keys.D6: semitones = 20; break;
                case Keys.Y: semitones = 21; break;
                case Keys.D7: semitones = 22; break;
                case Keys.U: semitones = 23; break;
                case Keys.I: semitones = 24; break;
                case Keys.D9: semitones = 25; break;
                case Keys.O: semitones = 26; break;
                case Keys.D0: semitones = 27; break;
                case Keys.P: semitones = 28; break;
                case Keys.OemOpenBrackets: semitones = 29; break;
                case Keys.Oemplus: semitones = 30; break;
                case Keys.OemCloseBrackets: semitones = 31; break;
            }
            if (semitones < 0) return;
            
            Note n = new Note();
            n.Octave = octave;
            n.Length = -1;
            n.Start = Program.TotalSample;
            n.Semitones += semitones;

            if (!notes.ContainsKey(e.KeyCode) && notes.Count < gen.VoiceCount)
            {
                notes.Add(e.KeyCode, n);
                gen.PlayNote(n);
            }
        }
        public void KeyUp(object sender, KeyEventArgs e)
        {
            if(notes.ContainsKey(e.KeyCode)) gen.ReleaseNote(notes[e.KeyCode]);
            notes.Remove(e.KeyCode);
        }
    }
}
