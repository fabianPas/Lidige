using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using Newtonsoft.Json;

namespace TiledMapPipeline
{
    //http://dylanwilson.net/creating-custom-content-importers-for-the-monogame-pipeline

    [ContentImporter(".json", DefaultProcessor = "TiledMapProcessor",
    DisplayName = "Tiled Map Importer")]
    public class TiledMapImporter : ContentImporter<TiledMap>
    {
        public override TiledMap Import(string filename, ContentImporterContext context)
        {
            context.Logger.LogMessage("Importing JSON map: {0}", filename);

            Debugger.Launch();

            using (var file = File.OpenText(filename))
            {
                var serializer = new JsonSerializer();
                return (TiledMap) serializer.Deserialize(file, typeof (TiledMap));
            }
        }
    }
}