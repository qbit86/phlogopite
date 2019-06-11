using System;
using BenchmarkDotNet.Attributes;
using Serilog;

namespace Phlogopite
{
    public abstract class TraceBenchmark
    {
        private Serilog.Core.Logger _serilogLogger;

        [GlobalSetup(Target = nameof(TraceToSerilog))]
        public void GlobalSetupSerilog()
        {
            _serilogLogger = new LoggerConfiguration()
                .WriteTo.Trace(Serilog.Events.LogEventLevel.Verbose,
                    $"{{Level:u1}} {{Timestamp:HH:mm:ss.fff}} [{nameof(TraceBenchmark)}] {{Message}}")
                .CreateLogger();
        }

        [Benchmark(Baseline = true)]
        public int TraceToPhlogopite()
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        public int TraceToSerilog()
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        public int TraceToExtensions()
        {
            throw new NotImplementedException();
        }
    }
}
