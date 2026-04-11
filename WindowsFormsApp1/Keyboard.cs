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
            if (notes.ContainsKey(e.KeyCode) || gen == null) return;
            Note n = new Note();
            n.Octave = octave;
            n.Length = -1;
            n.Start = Program.Time;
            switch (e.KeyCode)
            {
                case Keys.Z: n.Semitones += 0; break;
                case Keys.S: n.Semitones += 1; break;
                case Keys.X: n.Semitones += 2; break;
                case Keys.D: n.Semitones += 3; break;
                case Keys.C: n.Semitones += 4; break;
                case Keys.V: n.Semitones += 5; break;
                case Keys.G: n.Semitones += 6; break;
                case Keys.B: n.Semitones += 7; break;
                case Keys.H: n.Semitones += 8; break;
                case Keys.N: n.Semitones += 9; break;
                case Keys.J: n.Semitones += 10; break;
                case Keys.M: n.Semitones += 11; break;
                case Keys.Oemcomma: n.Semitones += 12; break;
                case Keys.L: n.Semitones += 13; break;
                case Keys.OemPeriod: n.Semitones += 14; break;
                case Keys.OemSemicolon: n.Semitones += 15; break;
                case Keys.OemQuestion: n.Semitones += 16; break;

                case Keys.Q: n.Semitones += 12; break;
                case Keys.D2: n.Semitones += 13; break;
                case Keys.W: n.Semitones += 14; break;
                case Keys.D3: n.Semitones += 15; break;
                case Keys.E: n.Semitones += 16; break;
                case Keys.R: n.Semitones += 17; break;
                case Keys.D5: n.Semitones += 18; break;
                case Keys.T: n.Semitones += 19; break;
                case Keys.D6: n.Semitones += 20; break;
                case Keys.Y: n.Semitones += 21; break;
                case Keys.D7: n.Semitones += 22; break;
                case Keys.U: n.Semitones += 23; break;
                case Keys.I: n.Semitones += 24; break;
                case Keys.D9: n.Semitones += 25; break;
                case Keys.O: n.Semitones += 26; break;
                case Keys.D0: n.Semitones += 27; break;
                case Keys.P: n.Semitones += 28; break;
                case Keys.OemOpenBrackets: n.Semitones += 29; break;
                case Keys.Oemplus: n.Semitones += 30; break;
                case Keys.OemCloseBrackets: n.Semitones += 31; break;
            }
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
