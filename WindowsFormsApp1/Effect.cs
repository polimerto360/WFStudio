using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public interface Effect: ISampleProvider, ModProperties
    {
        double Mix { get; set; }
    }
}
