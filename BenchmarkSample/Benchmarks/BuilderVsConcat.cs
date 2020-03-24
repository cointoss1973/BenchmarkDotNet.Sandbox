using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Linq;
using System.Text;

namespace BenchmarkSample.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net461, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp21)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    //[RPlotExporter]
    public class BuilderVsConcat
    {
        private readonly int N = 10000;

        [Benchmark]
        public string StringConcat()
        {
            return string.Concat(Enumerable.Repeat("a", N).ToArray());
        }

        [Benchmark]
        public string StringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('a', N);
            return sb.ToString();
        }
    }
}
