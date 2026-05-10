using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class EnvController: Controller
    {
        public EnvController(ModProperties target, string targetProperty, Envelope env, double _base, double amp)
        {
            Target = target;
            TargetProperty = targetProperty;
            Env = env;
            Base = _base;
            Amplitude = amp;
        }
        public Note CurNote;
        public Envelope Env;
        public ModProperties Target { get; set; }
        public string TargetProperty { get; set; }
        public double Base { get; set; } = 0;
        public double Amplitude { get; set; } = 1;
        public void Update(int samples)
        {
            if (CurNote == null || CurNote.TimeSinceRelease > Env.Release) return;
            Target.SetProperty(TargetProperty, Target.GetBaseValue(TargetProperty) + Base + Amplitude * Env.At(ref CurNote));
        }

        public object ToJsonObj()
        {
            return new
            {
                tgproperty = TargetProperty,
                bas = Base,
                amp = Amplitude,
                env = Env.ToJsonObj()
            };
        }

        public Jsonconvertible FromJson(dynamic json)
        {
            TargetProperty = json.tgproperty;
            Amplitude = json.amp;
            Base = json.bas;
            Env = (Envelope)Env.FromJson(json.env);

            return this;
        }

    }
}
