using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;

namespace Benchmarks
{
    internal class Config : ManualConfig
    {
        public Config()
        {
            // KeepBenchmarkFiles = true;

            //Add(Job.Default.With(CsProjClassicNetToolchain.Net472));
            Add(Job.Default.With(CsProjClassicNetToolchain.From("net48")));
            //Add(Job.Default.With(CsProjCoreToolchain.Current.Value));

            //var toolchain = CsProjCoreToolchain.Current.Value;
            //var jobWithCustomConfiguration = Job.Dry.WithCustomBuildConfiguration("CUSTOM").With(toolchain);
            //Add(jobWithCustomConfiguration);

        }
    }
}
