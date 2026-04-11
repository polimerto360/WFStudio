using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public interface ModProperties
    {
        List<string> Properties { get; }
        bool SetProperty(string name, double value); // returns true if property was set
        double GetBaseValue(string name);
    }
}
