using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Newtonsoft.Json;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.Net60)]
    public class Demo
    {
        private readonly string path = Path.Combine(AppContext.BaseDirectory, "JSON\\data.json");
        private const int IdKeyOrValue = 700;

        public Demo()
        {
        }

        [Benchmark]
        public List<BenchmarkModel> AddToList()
        {
            List<BenchmarkModel> benchList = new List<BenchmarkModel>();

            List<BenchmarkModel> gm = getJson(path);

            foreach (var benc in gm)
            {
                int i = 0;
                benchList.Add(new BenchmarkModel()
                {
                    Id = i,
                    Choices = benc.Choices,
                    Code = benc.Code,
                    Dimensions = benc.Dimensions,
                    Images = benc.Images,
                    IsInOutage = benc.IsInOutage,
                    Names = benc.Names,
                    PriceTags = benc.PriceTags,
                    SelectedGrill = benc.SelectedGrill,
                    ShouldShow = benc.ShouldShow
                });
                i++;
            }
            return benchList;
        }

        [Benchmark]
        public Dictionary<int, BenchmarkModel> AddToDictionary()
        {
            var benchDictionary = new Dictionary<int, BenchmarkModel>();

            var gm = getJson(path);

            for (int i = 0; i < gm.Count; i++)
            {
                benchDictionary.Add(i, new BenchmarkModel()
                {
                    Id = i,
                    Choices = gm[i].Choices,
                    Code = gm[i].Code,
                    Dimensions = gm[i].Dimensions,
                    Images = gm[i].Images,
                    IsInOutage = gm[i].IsInOutage,
                    Names = gm[i].Names,
                    PriceTags = gm[i].PriceTags,
                    SelectedGrill = gm[i].SelectedGrill,
                    ShouldShow = gm[i].ShouldShow
                });
            }

            return benchDictionary;
        }

        [Benchmark]
        public BenchmarkModel findOnList()
        {
            var list = AddToList();

            BenchmarkModel di = list.FirstOrDefault(c => c.Id == IdKeyOrValue);

            return di;
        }

        [Benchmark]
        public BenchmarkModel findOnDictionaryByKey()
        {
            var dic = AddToDictionary();

            var di = dic[IdKeyOrValue];

            return di;
        }

        [Benchmark]
        public BenchmarkModel findOnDictionaryByValue()
        {
            var dic = AddToDictionary();

            var di = dic.FirstOrDefault(d => d.Value.Id == IdKeyOrValue).Value;

            return di;
        }

        public List<BenchmarkModel> getJson(string path)
        {
            List<BenchmarkModel> gm = JsonConvert.DeserializeObject<List<BenchmarkModel>>(File.ReadAllText(path));
            return gm;
        }
    }
}