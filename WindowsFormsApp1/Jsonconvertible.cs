using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public interface Jsonconvertible
    {
        object ToJsonObj();
        Jsonconvertible FromJson(dynamic json);
    }
}
