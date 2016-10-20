using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Map
{
    public interface IMapConverter
    {
        IMap Convert(IMapFile file);
    }
}
