using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Phlogopite
{
    public abstract class TraceBenchmark
    {
        private Microsoft.Extensions.Logging.ILogger _extensionsLogger;
        private Serilog.Core.Logger _serilogLogger;
        private DateTime _now;
        private string _username;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _now = DateTime.Now;
            _username = Environment.UserName;
        }

        [GlobalSetup(Target = nameof(TraceToExtensions))]
        public void GlobalSetupExtensions()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(Configure);
            using (loggerFactory)
            {
                _extensionsLogger = loggerFactory.CreateLogger(nameof(TraceBenchmark));
            }

            void Configure(ILoggingBuilder builder)
            {
                var sourceSwitch = new SourceSwitch(nameof(TraceBenchmark)) { Level = SourceLevels.All };
                builder.AddTraceSource(sourceSwitch);
            }
        }

        [GlobalSetup(Target = nameof(TraceToSerilog))]
        public void GlobalSetupSerilog()
        {
            _serilogLogger = new LoggerConfiguration()
                .WriteTo.Trace(LogEventLevel.Verbose,
                    $"{{Level:u1}} {{Timestamp:HH:mm:ss.fff}} [{nameof(TraceBenchmark)}] {{Message}}")
                .CreateLogger();
        }

        [Benchmark]
        public string TraceToExtensions()
        {
            _extensionsLogger.LogInformation("Hello, world! now: {now}, e: {e}, username: {username}",
                _now, Math.E, _username);
            return _username;
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
    }
}
