using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class MasterTrack: MixerTrack
    {
        public override int Read(float[] buffer, int offset, int count)
        {
            foreach(NoteChannel nc in Program.NoteChannels) nc.Update();
            
            foreach(Generator gen in Program.Generators) // render all generators
            {
                float[] temp = new float[count];
                gen.Read(temp, 0, count);
                WaveGen.AddBuffer(ref gen.Target.Buffer, ref temp, offset, count);
            }
            base.Read(buffer, offset, count); // load master buffer
            foreach(MixerTrack t in Program.Tracks) // add everything to master
            {
                float[] temp = new float[count];
                t.Read(temp, 0, count);
                WaveGen.AddBuffer(ref buffer, ref temp, offset, count);
            }
            for(int i = offset; i < offset + count; i++) buffer[i] *= Volume;
            return count;
        }
    }
}
