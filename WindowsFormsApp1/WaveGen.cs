using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Dsp;
using NAudio.Wave;

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
            PSEUDO_NOISE,
            TRIANGLE
        }
        public static void AddBuffer(float[] buffer1, float[] buffer2, int offset, int count, long offset2 = 0)
        {
            for(int i = 0; i < count; i++)
            {
                if (i + offset2 >= buffer2.Length) return;
                buffer1[i + offset] += buffer2[i + offset2];
                buffer1[i + offset] = (float)Math.Min(Math.Max(buffer1[i + offset], -1.0), 1.0);
            }
        }
        public static void AddBufferResampled(float[] buffer1, float[] buffer2, int offset, int count, long offset2 = 0, double resampleFactor = 1)
        {
            for (int i = 0; i < count; i++)
            {
                double curSample = (i + offset2) * resampleFactor;
                if (curSample + 1 >= buffer2.Length) return;
                buffer1[i + offset] += (float)Envelope.Lerp(buffer2[(int)curSample], buffer2[(int)curSample + 1], curSample - Math.Floor(curSample));
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
        public static double TrianglePoint(double phase)
        {
            return Math.Abs(phase) / Math.PI * 2 - 1;
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
                case Waves.TRIANGLE:
                    return TrianglePoint(phase);
            }
            return 0;
        }
        public static void ApplyFilter(ref float[] buffer, int offset, int count, FilterWrap filter)
        {
            if(filter.Type == FilterWrap.FilterType.OFF) return;
            
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] = filter.Filter.Transform(buffer[i]);
            }
        }
        public static float[] temp_buf = new float[100000];
        public static void Mix(float[] buffer, int offset, int count, double mix)
        {
            for(int i = offset; i < offset + count; i++)
            {
                buffer[i] = (float)Envelope.Lerp(buffer[i], temp_buf[i-offset], mix);
            }
        }
    }
}
