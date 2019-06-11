using System;
using BenchmarkDotNet.Attributes;

namespace Phlogopite
{
    public abstract class TraceBenchmark
    {
        [Benchmark(Baseline = true)]
        public int Phlogopite()
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        public int Serilog()
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        public int Extensions()
        {
            throw new NotImplementedException();
        }
    }
}
