using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class MixerTrack : ISampleProvider
    {
        public float[] Buffer = new float[100000];
        public float Volume = 1f;
        public List<Effect> Effects = new List<Effect>();

        public virtual int Read(float[] buffer, int offset, int count) // output this track's buffer into input buffer
        {
            for(int i = offset; i < offset + count; i++)
            {
                buffer[i] = Buffer[i] * Volume; // update buffer
                Buffer[i] = 0f;
            }
            foreach(Effect e in Effects)
            {
                e.Read(buffer, offset, count); // apply effects
            }
            return count;
        }
        public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
    }
}
