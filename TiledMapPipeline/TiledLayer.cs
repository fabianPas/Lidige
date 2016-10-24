using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TiledMapPipeline
{
    public class TiledLayer
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("data")]
        public List<int> Data;
    }
}
