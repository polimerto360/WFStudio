using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public static class WaveGen
    {
        public static void AddBuffer(ref float[] buffer1, ref float[] buffer2, int offset, int count)
        {
            for(int i = 0; i < count; i++)
            {
                buffer1[i + offset] += buffer2[i];
                buffer1[i + offset] = (float)Math.Min(Math.Max(buffer1[i + offset], -1.0), 1.0);
            }
        }
        public static void Sine(ref float[] buffer, ref Note n, double volume = 1.0)
        {
            double sample_rate = Program.audio_output.OutputWaveFormat.SampleRate;
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] += (float)(Math.Sin(n.Phase) * volume);
                buffer[i] = (float)Math.Min(Math.Max(buffer[i], -1.0), 1.0);
                n.Phase += 2 * Math.PI * n.Pitch / sample_rate;
                n.Phase = Math.IEEERemainder(n.Phase, 2 * Math.PI);
            }
        }
        /*
          public static void Sine(ref float[] buffer, int offset, int count, Envelope env, ref Note n, double volume = 1.0, double sample_rate = 44100)
        {
            double begin_env = env.At(n.TimeElapsed, n.TimeSinceRelease, n.LastEnv);
            double end_env = env.At(n.TimeElapsed + count / sample_rate, (n.TimeSinceRelease > 0 ? n.TimeSinceRelease + count / sample_rate : -1), n.LastEnv);
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] += (float)(Math.Sin(n.Phase) * volume * Envelope.Lerp(begin_env, end_env, ((double)i /(double)count)));
                buffer[i] = (float)Math.Min(Math.Max(buffer[i], -1.0), 1.0);
                n.Phase += 2 * Math.PI * n.Pitch / sample_rate;
            }
            if (n.TimeSinceRelease < 0) n.LastEnv = end_env;
        }
         */
    }
}
