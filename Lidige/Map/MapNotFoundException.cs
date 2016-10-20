using System;

namespace Lidige.Map
{
    public class MapNotFoundException : Exception
    {
        public MapNotFoundException(string path) 
            : base("Map not found for path " + path) { }
    }
}