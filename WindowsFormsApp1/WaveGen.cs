using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public static class WaveGen
    {
        public static void Sine(ref float[] buffer, int offset, int count, ref Voice v, Note n, double volume = 1.0, double sample_rate = 44100)
        {
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] += (float)(Math.Sin(v.Phase) * volume * v.env.At(n.TimeElapsed, n.TimeSinceRelease));
                buffer[i] = (float)Math.Min(Math.Max(buffer[i], -1.0), 1.0);
                v.Phase += 2 * Math.PI * n.Pitch / sample_rate;
            }
        }
    }
}
