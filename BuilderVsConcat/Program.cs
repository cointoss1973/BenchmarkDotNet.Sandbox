using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Text;

namespace BuilderVsConcat
{
    [SimpleJob(RuntimeMoniker.Net461, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp22)]
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [RPlotExporter]
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

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BuilderVsConcat>();
        }
    }
}
