using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Jobs;

namespace BenchMarkDotNet.SandBox
{
    //[SimpleJob(RuntimeMoniker.Net461, baseline: true)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp22)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [ClrJob]
    [CoreJob]
    [RPlotExporter]
    public class Md5VsSha256
    {
        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();
        private byte[] data;

        public int N = 1000;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }
}