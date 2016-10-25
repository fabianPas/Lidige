using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Maps
{
    public class Map
    {
        private int _width;
        private int _height;

        private List<Layer> _layers = new List<Layer>();
        private List<Tileset> _tilesets = new List<Tileset>();

        public Map(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public List<Layer> Layers
        {
            get { return _layers; }
        }

        public List<Tileset> Tilesets
        {
            get { return _tilesets; }
        }
    }
}
