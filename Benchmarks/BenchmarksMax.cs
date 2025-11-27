using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFasterSpan;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarksMax
    {
        private static readonly Func<int, int> MaxInts = (x) => x + 1;

        [BenchmarkCategory("BMaxintArray"), Benchmark(Baseline = true)]
        public double IntArrayMaxLinq()
        {
            return Benchmarks.intArray.Max();
        }

        [BenchmarkCategory("BMaxintArray"), Benchmark]
        public double IntArrayMaxFast()
        {
            return Benchmarks.intArray.MaxF();
        }

        [BenchmarkCategory("BMaxlocalArray.AsSpan"), Benchmark(Baseline = true)]
        public double IntSpanMaxForEach()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            int max = int.MinValue;
            foreach (int i in asSpan)
            {
                if (max > i)
                {
                    max = i;
                }
            }

            return max;
        }

        [BenchmarkCategory("BMaxlocalArray.AsSpan"), Benchmark]
        public double IntSpanMaxFast()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            return asSpan.MaxF();
        }

        [BenchmarkCategory("BMaxintList"), Benchmark(Baseline = true)]
        public double IntListMaxLinq()
        {
            return Benchmarks.intList.Max();
        }

        [BenchmarkCategory("BMaxintList"), Benchmark]
        public double IntListMaxFast()
        {
            return Benchmarks.intList.MaxF();
        }

        [BenchmarkCategory("BMaxintList.AsReadOnly"), Benchmark(Baseline = true)]
        public double IntAsListReadOnlyMaxLinq()
        {
            return Benchmarks.intList.AsReadOnly().Max();
        }

        [BenchmarkCategory("BMaxintList.AsReadOnly"), Benchmark]
        public double IntAsListReadOnlyMaxFast()
        {
            return Benchmarks.intList.AsReadOnly().MaxF();
        }

        [BenchmarkCategory("BMaxArray.AsReadOnly"), Benchmark(Baseline = true)]
        public double IntArrayAsReadOnlyMaxLinq()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Max();
        }

        [BenchmarkCategory("BMaxArray.AsReadOnly"), Benchmark]
        public double IntArrayAsReadOnlyMaxFast()
        {
            return Array.AsReadOnly(Benchmarks.intArray).MaxF();
        }


        [BenchmarkCategory("BMaxintArraySelector"), Benchmark(Baseline = true)]
        public double IntArrayMaxLinqSelector()
        {
            return Benchmarks.intArray.Max(MaxInts);
        }

        [BenchmarkCategory("BMaxintArraySelector"), Benchmark]
        public double IntArrayMaxFastSelector()
        {
            return Benchmarks.intArray.MaxF(MaxInts);
        }

        [BenchmarkCategory("BMaxlocalArray.AsSpanSelector"), Benchmark(Baseline = true)]
        public double IntSpanMaxForEachSelector()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            int max = int.MinValue;
            foreach (int i in asSpan)
            {
                int l = MaxInts(i);
                if (max > l)
                {
                    max = l;
                }
            }

            return max;
        }

        [BenchmarkCategory("BMaxlocalArray.AsSpanSelector"), Benchmark]
        public double IntSpanMaxFastSelector()
        {
            int[] localArray = Benchmarks.intArray;
            Span<int> asSpan = localArray.AsSpan();
            return asSpan.MaxF(MaxInts);
        }

        [BenchmarkCategory("BMaxintListSelect"), Benchmark(Baseline = true)]
        public double IntListMaxLinqSelector()
        {
            return Benchmarks.intList.Max(MaxInts);
        }

        [BenchmarkCategory("BMaxintListSelect"), Benchmark]
        public double IntListMaxFastSelector()
        {
            return Benchmarks.intList.MaxF(MaxInts);
        }

        [BenchmarkCategory("BMaxintList.AsReadOnlySelector"), Benchmark(Baseline = true)]
        public double IntAsListReadOnlyMaxLinqSelector()
        {
            return Benchmarks.intList.AsReadOnly().Max(MaxInts);
        }

        [BenchmarkCategory("BMaxintList.AsReadOnlySelector"), Benchmark]
        public double IntAsListReadOnlyMaxFastSelector()
        {
            return Benchmarks.intList.AsReadOnly().MaxF(MaxInts);
        }

        [BenchmarkCategory("BMaxArray.AsReadOnlySelector"), Benchmark(Baseline = true)]
        public double IntArrayAsReadOnlyMaxLinqSelector()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Max(MaxInts);
        }

        [BenchmarkCategory("BMaxArray.AsReadOnlySelector"), Benchmark]
        public double IntArrayAsReadOnlyMaxFastSelector()
        {
            return Array.AsReadOnly(Benchmarks.intArray).MaxF(MaxInts);
        }

    }
}
