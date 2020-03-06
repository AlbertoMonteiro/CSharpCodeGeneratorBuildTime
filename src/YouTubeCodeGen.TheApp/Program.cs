using System;

namespace YouTubeCodeGen.TheApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var type in typeof(Program).Assembly.GetTypes())
                Console.WriteLine(type.FullName);

            //var tobe = new ToBe();
        }
    }
}
