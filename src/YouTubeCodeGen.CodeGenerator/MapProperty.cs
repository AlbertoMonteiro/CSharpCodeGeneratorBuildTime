using System;

namespace YouTubeCodeGen.CodeGenerator
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class MapProperty : Attribute
    {
        public MapProperty(string source, string destination)
        {
            Source = source;
            Destination = destination;
        }

        public string Source { get; }
        public string Destination { get; }
    }
}
