using Newtonsoft.Json;

namespace TiledMapPipeline
{
    public class TiledTileset
    {
        [JsonProperty("image")]
        public string Image;

        [JsonProperty("imagewidth")]
        public int Width;

        [JsonProperty("imageheight")]
        public int Height;
    }
}