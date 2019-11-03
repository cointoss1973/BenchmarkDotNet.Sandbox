using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Text;

namespace BuilderVsConcat
{
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
