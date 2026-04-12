using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    internal interface Controller
    {
        ModProperties Target { get; set; }
        string TargetProperty { get; set; }
        double Base { get; set; }
        double Amplitude { get; set; }
        void Update(int samples);
    }
}
