using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFaster.SIMD;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarkSelect
    {
        [BenchmarkCategory("BSintArray.Select"), Benchmark(Baseline = true)]
        public int[] IntArraySelectLinq()
        {
            return Benchmarks.intArray.Select(x => x * x).ToArray();
        }

        [BenchmarkCategory("BSintArray.Select"), Benchmark]
        public int[] IntArraySelectFast()
        {
            return Benchmarks.intArray.SelectF(x => x * x);
        }

        [BenchmarkCategory("BSintArray.Select"), Benchmark]
        public int[] IntArraySelectFastSIMD()
        {
            return Benchmarks.intArray.SelectS(x => x * x, x => x * x);
        }


    }
}
