using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Phlogopite.Extensions;
using Phlogopite.Sinks;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Phlogopite
{
    public abstract class TraceBenchmark
    {
        private ILogger _extensionsLogger;
        private DateTime _now;
        private Mediator _phlogopiteMediator;
        private Logger _serilogLogger;
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

        [GlobalSetup(Target = nameof(TraceToPhlogopite))]
        public void GlobalSetupPhlogopite()
        {
            _phlogopiteMediator = new MediatorBuilder { MinimumLevel = Level.Debug }
                .AddSink(TraceSink.Default)
                .Build();
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
            var writer = new Writer(_phlogopiteMediator, Level.Verbose, nameof(TraceBenchmark), null);
            writer.I("Hello, world!", ("now", _now), ("e", Math.E), ("username", _username));
            return _username;
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
