using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using RunMode = BenchmarkDotNet.Jobs.RunMode;

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            // https://benchmarkdotnet.org/articles/configs/configs.html
            Job coreRyuJitJob = new Job(Job.Default)
                .With(Runtime.Core)
                .With(Platform.X64)
                .With(Jit.RyuJit)
                .WithBaseline(true)
                .ApplyAndFreeze(RunMode.Short);

            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .With(MemoryDiagnoser.Default)
                .With(coreRyuJitJob);

            Summary _ = BenchmarkRunner.Run<TraceBenchmark>(config);
        }
    }
}
