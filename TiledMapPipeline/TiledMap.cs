using System.Collections.Generic;
using Newtonsoft.Json;

namespace TiledMapPipeline
{
    public class TiledMap
    {
        [JsonProperty("width")]
        public int Width;

        [JsonProperty("height")]
        public int Height;

        [JsonProperty("layers")]
        public List<TiledLayer> Layers;

        [JsonProperty("tilesets")]
        public List<TiledTileset> Tilesets;
    }
}