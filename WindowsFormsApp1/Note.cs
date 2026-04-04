using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public class Note
    {
        public static double twelveth_root_of_2 = Math.Pow(2, 1.0 / 12.0);
        public double Semitones = 0;
        public Note() { }
        public Note(double st, double length = 0, double start = 0) { // negative length plays forever
            Semitones = st;
            Length = length;
            Start = start;
        }
        public double Pitch
        {
            get
            {
                return Tuning * Math.Pow(twelveth_root_of_2, Semitones-69);
            }
            set
            {
                Semitones = Math.Log(value / Tuning) / Math.Log(twelveth_root_of_2) + 69;
            }
        }
        public double Tuning = 440; // A4 = 440 (st 69)
        public int Octave
        {
            get
            {
                return (int)Math.Floor(Semitones / 12);
            }
            set
            {
                Semitones += 12 * (value - Octave);
            }
        }
        public string Letter
        {
            get
            {
                switch((int) Math.Round(Semitones) % 12)
                {
                    case 0: return "C";
                    case 1: return "C#";
                    case 2: return "D";
                    case 3: return "D#";
                    case 4: return "E";
                    case 5: return "F";
                    case 6: return "F#";
                    case 7: return "G";
                    case 8: return "G#";
                    case 9: return "A";
                    case 10: return "A#";
                    case 11: return "B"; 
                }
                throw new Exception("Math is broken");
            }
        }
        public double Start = 0;
        public double Length = 0;
        public double ReleasedTime = -1;
        public double TimeSinceRelease
        {
            get
            {
                if (ReleasedTime < 0) return -1;
                return Program.Time - ReleasedTime;
            }
        }
        public double TimeElapsed
        {
            get
            {
                return Program.Time - Start;
            }
        }

    }
}
