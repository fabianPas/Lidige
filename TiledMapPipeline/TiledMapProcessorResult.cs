using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiledMapPipeline
{
    public class TiledMapProcessorResult
    {
        public TiledMap Map;
        public ContentBuildLogger Logger;

        public TiledMapProcessorResult(TiledMap map, ContentBuildLogger logger)
        {
            Map = map;
            Logger = logger;
        }
    }
}
