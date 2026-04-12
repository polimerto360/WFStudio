using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class FilterWrap : ModProperties
    {
        public FilterWrap(double cutoff, double q, FilterType type) 
        { 
            Filter = BiQuadFilter.AllPassFilter((float)SampleRate, 0, 1);
            Cutoff = cutoff;
            Q = q;
            Type = type;
        }
        public BiQuadFilter Filter;
        public List<string> Properties { get; } = new List<string>
        {
            "Cutoff",
            "Q"
        };
        public double SampleRate = Program.audio_output.OutputWaveFormat.SampleRate;
        private double cutoff;
        public double Cutoff {
            get
            {
                return cutoff;
            }
            set
            {
                cutoff = Math.Min(value, 20000);
                UpdateFilter();
            }
        }
        private double q;
        public double Q
        {
            get 
            { 
                return q; 
            }
            set 
            { 
                q = Math.Max(0.01, value);
                UpdateFilter(); 
            }
        }
        public void UpdateFilter()
        {
            switch (Type)
            {
                case FilterType.LOWPASS: Filter.SetLowPassFilter((float)SampleRate, (float)Cutoff, (float)Q); break;
                case FilterType.HIGHPASS: Filter.SetHighPassFilter((float)SampleRate, (float)Cutoff, (float)Q); break;
                case FilterType.BANDPASS: Filter = BiQuadFilter.BandPassFilterConstantPeakGain((float)SampleRate, (float)Cutoff, (float)Q); break;
            }
        }
        public enum FilterType
        {
            OFF,
            HIGHPASS,
            LOWPASS,
            BANDPASS
        }
        private FilterType type;
        public FilterType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                switch (type)
                {
                    case FilterType.LOWPASS: Filter.SetLowPassFilter((float)SampleRate, (float)Cutoff, (float)Q); break;
                    case FilterType.HIGHPASS: Filter.SetHighPassFilter((float)SampleRate, (float)Cutoff, (float)Q); break;
                    case FilterType.BANDPASS: Filter = BiQuadFilter.BandPassFilterConstantPeakGain((float)SampleRate, (float)Cutoff, (float)Q); break;
                }
            }
        }
        public bool SetProperty(string property, double value)
        {
            switch (property)
            {
                case "Cutoff": Cutoff = Math.Abs(440 * Math.Pow(2, value * 5.5)); return true;
                case "Q": Q = value * 10 + 0.01; return true;
            }
            return false;
        }
        public double GetBaseValue(string property)
        {
            switch (property)
            {
                case "Cutoff": return Cutoff;
                case "Resonance": return Q;
            }
            return 0;
        }
    }
}
