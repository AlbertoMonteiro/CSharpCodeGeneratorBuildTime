using CodeGeneration.Roslyn;
using System;
using System.Diagnostics;

namespace YouTubeCodeGen.CodeGenerator
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    [CodeGenerationAttribute(typeof(DuplicateWithSuffixGenerator))]
    [Conditional("CodeGeneration")]
    public class DuplicateWithSuffixAttribute : Attribute
    {
        public DuplicateWithSuffixAttribute(string suffix)
        {
            Suffix = suffix;
        }

        public string Suffix { get; }
    }
}
