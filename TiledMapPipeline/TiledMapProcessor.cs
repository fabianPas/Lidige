using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiledMapPipeline
{
    [ContentProcessor(DisplayName = "Tiled Map Processor")]
    public class TiledMapProcessor : ContentProcessor<TiledMap, TiledMapProcessorResult>
    {
        public override TiledMapProcessorResult Process(TiledMap map, ContentProcessorContext context)
        {
            return new TiledMapProcessorResult(map, context.Logger);
        }
    }
}
