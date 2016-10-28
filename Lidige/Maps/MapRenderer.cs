using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

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
            RenderLayer(map, "Ground");

            RenderLayer(map, "Mask 1");
            RenderLayer(map, "Mask 2");

            RenderLayer(map, "Fringe 1");
            RenderLayer(map, "Fringe 2");
        }

        public void RenderLayer(Map map, string name)
        {
            var tileset = map.Tilesets.First();
            var layer = map.GetLayer(name);

            var top = Math.Max((int)Math.Floor(_camera.Position.Y / 32), 0);
            var bottom = Math.Min(top + (800 / 32) + 2, 64);

            var left = Math.Max((int)Math.Floor(_camera.Position.X / 32), 0);
            var right = Math.Min(left + (1024 / 32) + 2, 64);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    var tile = layer.Tiles[x][y];

                    if (tile == 0)
                        continue;

                    var sourceX = (tile - 1) % (tileset.Width / 32);
                    var sourceY = (tile - 1) / (tileset.Width / 32);

                    _spriteBatch.Draw(tileset.Texture, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(sourceX * 32, sourceY * 32, 32, 32), Color.White);
                }
            }
        }
    }
}
