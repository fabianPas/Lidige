using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Maps
{
    public class Layer
    {
        private string _name;
        private List<int> _tiles;

        public Layer(string name, List<int> tiles)
        {
            _name = name;
            _tiles = tiles;
        }

        public List<int> Tiles
        {
            get { return _tiles; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
