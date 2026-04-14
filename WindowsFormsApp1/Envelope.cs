using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public class Envelope : ModProperties
    {
        public static double Lerp(double a, double b, double w)
        {
            return a + (b - a) * Math.Max(0, Math.Min(1, w));
        }
        public static double Tension(double from, double to, double w, double tension) //tension (-1, 1)
        {
            Debug.Assert(!double.IsNaN(Math.Pow(Lerp(from, to, w), Math.Pow(10, -tension))));
            return Math.Pow(Lerp(from, to, w), Math.Pow(10, -tension));
        }
        public double Attack;
        public double Attack_tension;
        public double Sustain;
        public double Decay;
        public double Decay_tension;
        public double Release;
        public double Release_tension;

        public List<string> Properties { get; } = new List<string>
        {
            "Attack",
            "Attack_tension",
            "Sustain",
            "Decay",
            "Decay_tension",
            "Release",
            "Release_tension"
        };

        public bool SetProperty(string property, double value)
        {
            switch (property)
            {
                case "Attack": Attack = Math.Pow(value, 2) * 10; return true;
                case "Attack_tension": Attack_tension = value; return true;
                case "Sustain": Sustain = Math.Abs(value); return true;
                case "Decay": Decay = Math.Pow(value, 2) * 10; return true;
                case "Decay_tension": Decay_tension = value; return true;
                case "Release": Release = Math.Pow(value, 2) * 10; return true;
                case "Release_tension": Release_tension = value; return true;
            }
            return false;
        }

        public double GetBaseValue(string property)
        {
            /*switch (property)
            {
                case "Attack": return Attack;
                case "Attack_tension": return Attack_tension;
                case "Sustain": return Sustain;
                case "Decay": return Decay;
                case "Decay_tension": return Decay_tension;
                case "Release": return Release;
                case "Release_tension": return Release_tension;
            }*/
            return 0;
        }

        public double last_value;
        public Envelope(double attack = 0.1, double attack_tension = 0, double sustain = 0.8, double decay = 0.5, double decay_tension = 0, double release = 0.5, double release_tension = 0)
        {
            Attack = attack;
            Attack_tension = attack_tension;
            Sustain = sustain;
            Decay = decay;
            Decay_tension = decay_tension;
            Release = release;
            Release_tension = release_tension;
        }

        public double At(double t, double time_since_released = -1, double last_value = 0)
        {
            if (time_since_released > 0)
            {
                return Tension(last_value, 0, time_since_released / Release, Release_tension);
            }
            if (Attack > 0 && t < Attack)
            {
                return Tension(0, 1, t / Attack, Attack_tension);

            }
            else if (t < Attack + Decay && Decay > 0)
            {
                return Sustain + Tension(1 - Sustain, 0, (t - Attack) / Decay, Decay_tension);
            }
            else
            {
                return Sustain;
            }
        }

        public double At(ref Note note, bool update_note = true)
        {
            double ret = At(Program.SamplesToTime(note.ElapsedSamples), note.TimeSinceRelease, note.LastEnv);
            if (note.TimeSinceRelease < 0 && update_note) note.LastEnv = ret;
            return ret;
        }
        public static void Apply(ref float[] buffer, Envelope env, ref Note n, double volume = 1.0)
        {
            double sample_rate = Program.audio_output.OutputWaveFormat.SampleRate;
            double begin_env = env.At(ref n, false);
            double end_env = env.At(Program.SamplesToTime(n.ElapsedSamples) + buffer.Length / sample_rate, (n.TimeSinceRelease > 0 ? n.TimeSinceRelease + buffer.Length / sample_rate : -1), n.LastEnv);

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] *= (float)(volume * Envelope.Lerp(begin_env, end_env, ((double)i / (double)buffer.Length)));
                buffer[i] = (float)Math.Min(Math.Max(buffer[i], -1.0), 1.0);
            }
            if (n.TimeSinceRelease < 0) n.LastEnv = end_env;
        }
    }
}
