using System;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run(typeof(Demo).Assembly);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}