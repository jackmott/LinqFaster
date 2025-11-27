using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFasterSpan;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarksLast
    {
        private static readonly Func<int, bool> LastInts = (x) => x > 0;


        [BenchmarkCategory("BLintArray"), Benchmark(Baseline = true)]
        public double IntArrayLastLinqSelector()
        {
            return Benchmarks.intArray.Last(LastInts);
        }

        [BenchmarkCategory("BLintArray"), Benchmark]
        public double IntArrayLastArrayFindSelector()
        {
            Predicate<int> predicate = new Predicate<int>(LastInts);
            return Array.FindLast(Benchmarks.intArray, predicate);
        }

        [BenchmarkCategory("BLintArray"), Benchmark]
        public double IntArrayLastFastSelector()
        {
            return Benchmarks.intArray.LastF(LastInts);
        }



        [BenchmarkCategory("BLlocalArray.AsSpan"), Benchmark(Baseline = true)]
        public double IntSpanLastForEachSelector()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            foreach (int i in asSpan)
            {
                if (LastInts(i))
                {
                    return i;
                }
            }

            return 0;
        }

        [BenchmarkCategory("BLlocalArray.AsSpan"), Benchmark]
        public double IntSpanLastFastSelector()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            return asSpan.LastF(LastInts);
        }

        [BenchmarkCategory("BLintList"), Benchmark(Baseline = true)]
        public double IntListLastLinqSelector()
        {
            return Benchmarks.intList.Last(LastInts);
        }

        [BenchmarkCategory("BLintList"), Benchmark]
        public double IntListLastFastSelector()
        {
            return Benchmarks.intList.LastF(LastInts);
        }

        [BenchmarkCategory("BLintList.AsReadOnly"), Benchmark(Baseline = true)]
        public double IntAsListReadOnlyLastLinqSelector()
        {
            return Benchmarks.intList.AsReadOnly().Last(LastInts);
        }

        [BenchmarkCategory("BLintList.AsReadOnly"), Benchmark]
        public double IntAsListReadOnlyLastFastSelector()
        {
            return Benchmarks.intList.AsReadOnly().LastF(LastInts);
        }

        [BenchmarkCategory("BLArray.AsReadOnly"), Benchmark(Baseline = true)]
        public double IntArrayAsReadOnlyLastLinqSelector()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Last(LastInts);
        }

        [BenchmarkCategory("BLArray.AsReadOnly"), Benchmark]
        public double IntArrayAsReadOnlyLastFastSelector()
        {
            return Array.AsReadOnly(Benchmarks.intArray).LastF(LastInts);
        }
    }
}
