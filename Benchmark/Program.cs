using System;

namespace Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var result = BenchmarkRunner.Run<Demo>();
            var result = new Demo();
            result.AddToList();

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}