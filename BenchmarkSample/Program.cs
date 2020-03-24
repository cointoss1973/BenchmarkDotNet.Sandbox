using BenchmarkDotNet.Running;
using BenchmarkSample.Benchmarks;
using System;

namespace BenchmarkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var benchmarkSwitcher = new BenchmarkSwitcher(new[]
            {
                typeof(Md5VsSha256),
                typeof(BuilderVsConcat),
            });
            benchmarkSwitcher.RunAll();
        }
    }
}
