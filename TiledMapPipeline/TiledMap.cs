using Newtonsoft.Json;

namespace TiledMapPipeline
{
    public class TiledMap
    {
        [JsonProperty("width")]
        public int Width;

        [JsonProperty("height")]
        public int Height;
        
    }
}