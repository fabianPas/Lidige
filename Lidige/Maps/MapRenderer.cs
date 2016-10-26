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
            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            RenderLayer(map, "Ground");

            RenderLayer(map, "Mask 1");
            RenderLayer(map, "Mask 2");

            RenderLayer(map, "Fringe 1");
            RenderLayer(map, "Fringe 2");

            _spriteBatch.End();
        }

        public void RenderLayer(Map map, string name)
        {
            var tileset = map.Tilesets.First();
            var layer = map.GetLayer(name);

            var sourceIndex = 0;

            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                {
                    var tile = layer.Tiles[sourceIndex++];

                    if (tile == 0)
                        continue;

                    var sourceX = (tile % (tileset.Width / 32) - 1) * 32;
                    var sourceY = tile / (tileset.Width / 32) * 32;

                    _spriteBatch.Draw(tileset.Texture, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(sourceX, sourceY, 32, 32), Color.White);
                }
            }
        }
    }
}
