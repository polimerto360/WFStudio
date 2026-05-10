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
    [Serializable]
    public class LFO : Controller, ModProperties
    {
        public LFO(ModProperties target, string targetProperty, double frequency, double amp, double _base, WaveGen.Waves waveType, double phase)
        {
            Target = target;
            TargetProperty = targetProperty;
            Frequency = frequency;
            Amplitude = amp;
            Base = _base;
            WaveType = waveType;
            Phase = phase;
        }

        public ModProperties Target { get; set; }
        public string TargetProperty { get; set; }
        public double Frequency { get; set; } = 1;
        public double Amplitude { get; set; } = 1;
        public double Base { get; set; } = 0;
        public WaveGen.Waves WaveType { get; set; } = WaveGen.Waves.SINE;
        public double Phase { get; set; } = 0;
        public void Update(int samples)
        {
            if (Target != null && TargetProperty != null)
            {
                Target.SetProperty(TargetProperty, Target.GetBaseValue(TargetProperty) + WaveGen.GetPoint(WaveType, Phase) * Amplitude + Base);
                Debug.Assert(WaveGen.GetPoint(WaveType, Phase) >= -1 && WaveGen.GetPoint(WaveType, Phase) <= 1);

            }
            Phase += 2 * Math.PI * Frequency * samples / Program.audio_output.OutputWaveFormat.SampleRate;
            Phase = Math.IEEERemainder(Phase, 2 * Math.PI);
            //Debug.Assert(Phase >= 0 && Phase <= 2 * Math.PI);
        }

        public List<string> Properties { get; } = new List<string>
        {
            "Frequency",
            "Amplitude",
            "Base",
            "Phase"
        };

        public bool SetProperty(string property, double value)
        {
            switch (property)
            {
                case "Frequency": Frequency = Math.Pow(20, value); return true;
                case "Amplitude": Amplitude = value; return true;
                case "Base": Base = value; return true;
                case "Phase": Phase = value * Math.PI; return true;
            }
            return false;
        }

        public double GetBaseValue(string property)
        {
            return 0;
        }

        public object ToJsonObj()
        {
            return new
            {
                tgproperty = TargetProperty,
                freq = Frequency,
                amp = Amplitude,
                bas = Base,
                phase = Phase,
                wavetype = WaveType
            };
        }

        public Jsonconvertible FromJson(dynamic json)
        {
            TargetProperty = json.tgproperty;
            Frequency = json.freq;
            Amplitude = json.amp;
            Base = json.bas;
            Phase = json.phase;
            WaveType = json.wavetype;

            return this;
        }
    }
}
