using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class Envelope
    {
        public static double Lerp(double a, double b, double w)
        {
            return a + (b - a) * w;
        }
        public static double Tension(double from, double to, double w, double tension) //tension (-1, 1)
        {
            return Math.Pow(Lerp(from, to, w), Math.Pow(10, -tension));
        }
        public double Attack;
        public double Attack_tension;
        public double Sustain;
        public double Decay;
        public double Decay_tension;
        public double Release;
        public double Release_tension;

        public double last_value;
        public Envelope(double attack = 0.1, double attack_tension = 0, double sustain = 0.8, double decay = 0.5, double decay_tension = 0, double release = 0.5, double release_tension = 0)
        {
            Attack = attack;
            Attack_tension = attack_tension;
            Sustain = sustain;
            Decay = decay;
            Decay_tension = decay_tension;
            Release = release;
            Release_tension = release_tension;
        }

        public double At(double t, double time_since_released = -1)
        {
            if(time_since_released > 0)
            {
                return Tension(last_value, 0, time_since_released / Release, Release_tension);
            }
            if (Attack > 0 && t < Attack)
            {
                last_value = Tension(0, 1, t / Attack, Attack_tension);
                
            } else if(t < Attack + Decay && Decay > 0)
            {
                last_value = Sustain + Tension(1 - Sustain, 0, (t - Attack) / Decay, Decay_tension);
            } else
            {
                last_value = Sustain;
            }
            return last_value;
        }
    }
}
