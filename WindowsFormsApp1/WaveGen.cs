using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Dsp;

namespace WFStudio
{
    public static class WaveGen
    {
        public static Random Rng = new Random();
        public enum Waves
        {
            SINE,
            SAW,
            SQUARE,
            NOISE,
            PSEUDO_NOISE
        }
        public static void AddBuffer(ref float[] buffer1, ref float[] buffer2, int offset, int count)
        {
            for(int i = 0; i < count; i++)
            {
                buffer1[i + offset] += buffer2[i];
                buffer1[i + offset] = (float)Math.Min(Math.Max(buffer1[i + offset], -1.0), 1.0);
            }
        }
        public static double SinePoint(double phase)
        {
            return Math.Sin(phase);
        }
        public static double SawPoint(double phase)
        {
            return phase / Math.PI;
        }
        public static double SquarePoint(double phase)
        {
            return (phase < 0) ? -1 : 1;
        }
        public static double NoisePoint()
        {
            return Rng.NextDouble() * 2 - 1;
        }
        public static double PseudoNoisePoint(double phase)
        {
            return new Random((int)(phase * 100)).NextDouble() * 2 - 1;
        }
        public static double Generate(ref float[] buffer, Waves wave_type, double phase, double pitch, double volume = 1.0)
        {
            double sample_rate = Program.audio_output.OutputWaveFormat.SampleRate;
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] += (float)(GetPoint(wave_type, phase) * volume);
                //buffer[i] = (float)Math.Min(Math.Max(buffer[i], -1.0), 1.0);
                phase += 2 * Math.PI * pitch / sample_rate;
                phase = Math.IEEERemainder(phase, 2 * Math.PI);
            }
            return phase;
        }
        public static double GetPoint(Waves wave_type, double phase = 0)
        {
            switch (wave_type)
            {
                case Waves.SINE:
                    return SinePoint(phase);
                case Waves.SAW:
                    return SawPoint(phase);
                case Waves.SQUARE:
                    return SquarePoint(phase);
                case Waves.NOISE:
                    return NoisePoint();
                case Waves.PSEUDO_NOISE:
                    return PseudoNoisePoint(phase);
            }
            return 0;
        }
        public static void ApplyFilter(ref float[] buffer, int offset, int count, BiQuadFilter filter)
        {
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] = filter.Transform(buffer[i]);
            }
        }
    }
}
