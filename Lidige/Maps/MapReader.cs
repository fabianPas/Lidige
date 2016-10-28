using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Maps
{
    public class MapReader : ContentTypeReader<Map>
    {
        protected override Map Read(ContentReader input, Map existingInstance)
        {
            var width = input.ReadInt32();
            var height = input.ReadInt32();

            var map = new Map(width, height);

            var layerCount = input.ReadInt32();
            for(int i = 0; i < layerCount; i++)
            {
                var layerName = input.ReadString();
                var tileCount = input.ReadInt32();

                var layerTiles = new int[width][];

                for (int k = 0; k < height; k++)
                    layerTiles[k] = new int[height];

                for(int j = 0; j < tileCount; j++)
                {
                    var tileId = input.ReadInt32();

                    var x = j % width;
                    var y = j / width;
                    layerTiles[x][y] = tileId;
                }

                var layer = new Layer(layerName, layerTiles);
                map.Layers.Add(layer);
            }

            var tilesetCount = input.ReadInt32();
            for(int k = 0; k < tilesetCount; k++)
            {
                var tilesetWidth = input.ReadInt32();
                var tilesetHeight = input.ReadInt32();
                var tilesetImage = input.ReadString();

                // @TODO Manage tilesets and images and names correctly
                var texture = input.ContentManager.Load<Texture2D>("Tilesets/" + tilesetImage.Replace(".png", ""));
                var tileset = new Tileset(tilesetWidth, tilesetHeight, texture);

                map.Tilesets.Add(tileset);
            }

            return map;
        }
    }
}
