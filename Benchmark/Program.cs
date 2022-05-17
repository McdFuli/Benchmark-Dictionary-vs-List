using System;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run(typeof(Demo).Assembly);
            //var result = new Demo();
            //var addList = result.AddToList();
            //var addDic =result.AddToDictionary();
            //var findOnList = result.findOnList();
            //var findOnDicByKey = result.findOnDictionaryByKey();
            //var findOnDicByValue = result.findOnDictionaryByValue();

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}