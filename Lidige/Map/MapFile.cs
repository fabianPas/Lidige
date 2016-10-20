using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Map
{
    public class MapFile : IMapFile
    {
        private string _json;

        public MapFile(string filePath)
        {
            Load(filePath);
        }

        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new MapNotFoundException(filePath);

            _json = File.ReadAllText(filePath);
        }

        public string Json
        {
            get { return _json; }
        }
    }
}
