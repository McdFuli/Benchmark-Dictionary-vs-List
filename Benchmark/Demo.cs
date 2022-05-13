using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Benchmark
{
    public class Demo
    {
        private readonly string path = @"C:\Users\gfuli\Documents\Estudos\Benchmark\Benchmark\JSON\data.json";
        public Demo()
        {
        }

        //[Benchmark]
        public void AddToList(string currentPath = null)
        {
            List<BenchmarkModel> benchList = new List<BenchmarkModel>();

            StreamReader json = new StreamReader(path);

                object benc = GetJson(json.ReadToEnd());

            for (int i = 0; i < 1000; i++)
            {
                
                benchList.Add(new BenchmarkModel()
                {
                });
            }
        }

        //[Benchmark]
        public void AddToDictionary()
        {
            var benchDictionary = new Dictionary<int, BenchmarkModel>();

            for (int i = 0; i < 1000; i++)
            {
                benchDictionary.Add(i, new BenchmarkModel()
                {
                });
            }
        }

        public object GetJson(string json)
        {
            var jsonDeserialized = JsonConvert.DeserializeObject(json);

            return jsonDeserialized;
        }
    }
}