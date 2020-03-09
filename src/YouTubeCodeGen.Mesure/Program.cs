using BenchmarkDotNet.Running;

namespace YouTubeCodeGen.Mesure
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ObjectMapping>();
        }
    }
}
