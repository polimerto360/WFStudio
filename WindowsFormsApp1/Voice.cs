using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class Voice
    {
        public double Phase = 0.0;
        public SignalGeneratorType Type = SignalGeneratorType.Sin;
        public Envelope env = new Envelope();
    }
}
