using System;

namespace Lidige.Maps
{
    public class MapNotFoundException : Exception
    {
        public MapNotFoundException(string path) 
            : base("Map not found for path " + path) { }
    }
}