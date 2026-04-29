using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class MasterTrack: MixerTrack
    {
        public static bool Paused = false;
        //public static bool Stopped = false;
        public static event Action<float[], int> OnRead;
        
        public override int Read(float[] buffer, int offset, int count)
        {
            Program.TotalSample += count;
            //if (Stopped)
            //{
            //    for(int i = offset; i < offset + count; i++) buffer[i] = 0;
            //    return count;
            //}
            float[] temp = new float[count];
            foreach(Generator gen in Program.Generators) // render all generators
            {
                if(!Paused) gen.noteChannel.Update();
                gen.Read(temp, 0, count);
                WaveGen.AddBuffer(gen.Target.Buffer, temp, offset, count);
            }
            base.Read(buffer, offset, count); // load master buffer
            foreach(MixerTrack t in Program.Tracks) // add everything to master
            {
                t.Read(temp, 0, count);
                WaveGen.AddBuffer(buffer, temp, offset, count);
            }
            for(int i = offset; i < offset + count; i++) buffer[i] *= Volume;
            OnRead?.Invoke(buffer, count);

            if (!Paused) Program.CurSample += count;
            return count;
        }
    }
}
