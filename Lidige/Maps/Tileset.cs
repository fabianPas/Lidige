using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Maps
{
    public class Tileset
    {
        private int _width;
        private int _height;

        private Texture2D _texture;

        public Tileset(int width, int height, Texture2D texture)
        {
            _width = width;
            _height = height;
            _texture = texture;
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }
    }
}
