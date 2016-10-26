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
        private Camera _camera;

        public MapRenderer(SpriteBatch spriteBatch, Camera camera)
        {
            _spriteBatch = spriteBatch;
            _camera = camera;
        }

        public void Render(Map map)
        {
            var tileset = map.Tilesets.First();

            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            foreach (var layer in map.Layers)
            {
                for (int y = 0; y < 64; y++)
                {
                    for (int x = 0; x < 64; x++)
                    {
                        var tile = layer.Tiles[x * y];

                        if (tile == 0)
                            continue;

                        var sourceX = (tile % (tileset.Width / 32) - 1) * 32;
                        var sourceY = tile / (tileset.Width / 32) * 32;

                        _spriteBatch.Draw(tileset.Texture, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(sourceX, sourceY, 32, 32), Color.White);
                    }
                }
            }

            _spriteBatch.End();
        }
    }
}
