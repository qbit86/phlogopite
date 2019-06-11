using System;
using BenchmarkDotNet.Attributes;
using Serilog;

namespace Phlogopite
{
    public abstract class TraceBenchmark
    {
        private Serilog.Core.Logger _serilogLogger;
        private DateTime _now;
        private string _username;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _now = DateTime.Now;
            _username = Environment.UserName;
        }

        [GlobalSetup(Target = nameof(TraceToSerilog))]
        public void GlobalSetupSerilog()
        {
            _serilogLogger = new LoggerConfiguration()
                .WriteTo.Trace(Serilog.Events.LogEventLevel.Verbose,
                    $"{{Level:u1}} {{Timestamp:HH:mm:ss.fff}} [{nameof(TraceBenchmark)}] {{Message}}")
                .CreateLogger();
        }

        [Benchmark(Baseline = true)]
        public string TraceToPhlogopite()
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        public string TraceToSerilog()
        {
            _serilogLogger.Information("Hello, world! now: {now}, e: {e}, username: {username}",
                _now, Math.E, _username);
            return _username;
        }

        [Benchmark]
        public string TraceToExtensions()
        {
            throw new NotImplementedException();
        }
    }
}
