using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFaster.SIMD;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarksAverage
    {

        [BenchmarkCategory("BAvintArray"), Benchmark(Baseline = true)]
        public double IntArrayAverageLinq()
        {
            return Benchmarks.intArray.Average();
        }

        [BenchmarkCategory("BAvintArray"), Benchmark]
        public double IntArrayAverageFast()
        {
            return Benchmarks.intArray.AverageF();
        }

        [BenchmarkCategory("BAvintArray"), Benchmark]
        public double IntArrayAverageFastSIMD()
        {
            return Benchmarks.intArray.AverageS();
        }


        [BenchmarkCategory("BAvintList"), Benchmark(Baseline = true)]
        public double IntListAverageLinq()
        {
            return Benchmarks.intList.Average();
        }

        [BenchmarkCategory("BAvintList"), Benchmark]
        public double IntListAverageFast()
        {
            return Benchmarks.intList.AverageF();
        }

        //[BenchmarkCategory("BAvintList"), Benchmark]
        //public double IntListAverageFastSIMD()
        //{
        //    return Benchmarks.intList.AverageS();
        //}

    }
}
