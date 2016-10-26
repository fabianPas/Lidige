using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace TiledMapPipeline
{
    [ContentTypeWriter]
    public class TiledMapWriter : ContentTypeWriter<TiledMapProcessorResult>
    {
        protected override void Write(ContentWriter output, TiledMapProcessorResult value)
        {
            output.Write(value.Map.Width);
            output.Write(value.Map.Height);

            output.Write(value.Map.Layers.Count);

            foreach(var layer in value.Map.Layers)
            {
                output.Write(layer.Name);
                output.Write(layer.Data.Count);

                foreach(var tile in layer.Data)
                {
                    output.Write(tile);
                }
            }

            output.Write(value.Map.Tilesets.Count);

            foreach(var tileset in value.Map.Tilesets)
            {
                output.Write(tileset.Width);
                output.Write(tileset.Height);
                output.Write(tileset.Image);
            }
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return typeof(TiledMap).AssemblyQualifiedName;
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "Lidige.Maps.MapReader, Lidige";
        }
    }
}
