using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using JM.LinqFasterSpan;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarksMin
    {
        private static readonly Func<int, int> MinInts = (x) => x + 1;

        [BenchmarkCategory("BMinintArray"), Benchmark(Baseline = true)]
        public double IntArrayMinLinq()
        {
            return Benchmarks.intArray.Min();
        }

        [BenchmarkCategory("BMinintArray"), Benchmark]
        public double IntArrayMinFast()
        {
            return Benchmarks.intArray.MinF();
        }

        [BenchmarkCategory("BMinintArray"), Benchmark]
        public int IntArrayMinFastSIMD()
        {
            return Benchmarks.intArray.MinS();
        }

        [BenchmarkCategory("BMinlocalArray.AsSpan"), Benchmark(Baseline = true)]
        public double IntSpanMinForEach()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            int Min = int.MinValue;
            foreach (int i in asSpan)
            {
                if (Min > i)
                {
                    Min = i;
                }
            }

            return Min;
        }

        [BenchmarkCategory("BMinlocalArray.AsSpan"), Benchmark]
        public double IntSpanMinFast()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            return asSpan.MinF();
        }

        [BenchmarkCategory("BMinintList"), Benchmark(Baseline = true)]
        public double IntListMinLinq()
        {
            return Benchmarks.intList.Min();
        }

        [BenchmarkCategory("BMinintList"), Benchmark]
        public double IntListMinFast()
        {
            return Benchmarks.intList.MinF();
        }

        [BenchmarkCategory("BMinintList.AsReadOnly"), Benchmark(Baseline = true)]
        public double IntAsListReadOnlyMinLinq()
        {
            return Benchmarks.intList.AsReadOnly().Min();
        }

        [BenchmarkCategory("BMinArray.AsReadOnly"), Benchmark]
        public double IntAsListReadOnlyMinFast()
        {
            return Benchmarks.intList.AsReadOnly().MinF();
        }

        [BenchmarkCategory("BMinArray.AsReadOnly"), Benchmark(Baseline = true)]
        public double IntArrayAsReadOnlyMinLinq()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Min();
        }

        [BenchmarkCategory("BMinintArraySelector"), Benchmark]
        public double IntArrayAsReadOnlyMinFast()
        {
            return Array.AsReadOnly(Benchmarks.intArray).MinF();
        }


        [BenchmarkCategory("BMinintArraySelector"), Benchmark(Baseline = true)]
        public double IntArrayMinLinqSelector()
        {
            return Benchmarks.intArray.Min(MinInts);
        }

        [BenchmarkCategory("BMinIntArrayAggregate"), Benchmark]
        public double IntArrayMinFastSelector()
        {
            return Benchmarks.intArray.MinF(MinInts);
        }

        [BenchmarkCategory("BMinlocalArray.AsSpanSelector"), Benchmark(Baseline = true)]
        public double IntSpanMinForEachSelector()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            int Min = int.MinValue;
            foreach (int i in asSpan)
            {
                int l = MinInts(i);
                if (Min > l)
                {
                    Min = l;
                }
            }

            return Min;
        }

        [BenchmarkCategory("BMinlocalArray.AsSpanSelector"), Benchmark]
        public double IntSpanMinFastSelector()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            return asSpan.MinF(MinInts);
        }

        [BenchmarkCategory("BMinintListSelector"), Benchmark(Baseline = true)]
        public double IntListMinLinqSelector()
        {
            return Benchmarks.intList.Min(MinInts);
        }

        [BenchmarkCategory("BMinintListSelector"), Benchmark]
        public double IntListMinFastSelector()
        {
            return Benchmarks.intList.MinF(MinInts);
        }

        [BenchmarkCategory("BMinintList.AsReadOnlySelector"), Benchmark(Baseline = true)]
        public double IntAsListReadOnlyMinLinqSelector()
        {
            return Benchmarks.intList.AsReadOnly().Min(MinInts);
        }

        [BenchmarkCategory("BMinintList.AsReadOnlySelector"), Benchmark]
        public double IntAsListReadOnlyMinFastSelector()
        {
            return Benchmarks.intList.AsReadOnly().MinF(MinInts);
        }

        [BenchmarkCategory("BMinArray.AsReadOnlySelector"), Benchmark(Baseline = true)]
        public double IntArrayAsReadOnlyMinLinqSelector()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Min(MinInts);
        }

        [BenchmarkCategory("BMinArray.AsReadOnlySelector"), Benchmark]
        public double IntArrayAsReadOnlyMinFastSelector()
        {
            return Array.AsReadOnly(Benchmarks.intArray).MinF(MinInts);
        }

    }
}
