using CodeGeneration.Roslyn;
using System;
using System.Diagnostics;

namespace YouTubeCodeGen.CodeGenerator
{
    [AttributeUsage(AttributeTargets.Interface, Inherited = false, AllowMultiple = true)]
    [CodeGenerationAttribute(typeof(MapObjectGenerator))]
    [Conditional("CodeGeneration")]
    public class MapObjectAttribute : Attribute
    {
    }
}
