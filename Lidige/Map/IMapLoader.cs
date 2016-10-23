using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Map
{
    public interface IMapLoader
    {
        Map Load(string filePath);
    }
}
