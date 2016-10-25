using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Maps
{
    public class MapRenderer
    {
        private SpriteBatch _spriteBatch;

        public MapRenderer(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Render(Map map)
        {
            var tileset = map.Tilesets.First();

            var tileX = 0;
            var tileY = 0;

            _spriteBatch.Begin();

            foreach(var layer in map.Layers)
            {
                foreach(var tile in layer.Tiles)
                {
                    
                    var sourceY = (int)Math.Ceiling((decimal)tile / tileset.Width) - 1;
                    var sourceX = tile - (tileset.Width * sourceY) - 1;

                    _spriteBatch.Draw(tileset.Texture, new Vector2(0, 0), new Rectangle(sourceX, sourceY, 32, 32));
                }
            }

            _spriteBatch.End();
        }
    }
}
