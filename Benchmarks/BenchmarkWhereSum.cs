using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFasterSpan;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarkWhereSum
    {

        [BenchmarkCategory("BWSbyteArray"), Benchmark(Baseline = true)]
        public int ByteArrayWhereSumLinq()
        {
            return Benchmarks.byteArray.Where(x => x > 0).Aggregate(0, (current, b1) => current + b1);
        }

        [BenchmarkCategory("BWSbyteArray"), Benchmark]
        public uint ByteArrayWhereSumFast()
        {
            return Benchmarks.byteArray.WhereSumF(x => x > 0);
        }


        [BenchmarkCategory("BWSshortArray"), Benchmark(Baseline = true)]
        public int ShortArrayWhereSumLinq()
        {
            return Benchmarks.shortArray.Where(x => x > 0).Aggregate(0, (current, s1) => current + s1);
        }

        [BenchmarkCategory("BWSshortArray"), Benchmark]
        public int ShortArrayWhereSumFast()
        {
            return Benchmarks.shortArray.WhereSumF(x => x > 0);
        }


        [BenchmarkCategory("BWSintArray"), Benchmark(Baseline = true)]
        public int IntArrayWhereSumLinq()
        {
            return Benchmarks.intArray.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSintArray"), Benchmark]
        public int IntArrayWhereSumFast()
        {
            return Benchmarks.intArray.WhereSumF(x => x > 0);
        }

        /*
        [BenchmarkCategory("BWSintArray"), Benchmark]
        public int IntArrayWhereSumFastSIMD()
        {
            return intArray.WhereSumS(x => x > 0);
        }
        */


        [BenchmarkCategory("BWSintArray.AsSpan"), Benchmark(Baseline = true)]
        public int IntSpanWhereSumFor()
        {
            int val = 0;
            Span<int> span = Benchmarks.intArray.AsSpan();
            for (int index = 0; index < span.Length; index++)
            {
                if (span[index] > 0)
                {
                    val += span[index];
                }
            }

            return val;
        }

        [BenchmarkCategory("BWSintArray.AsSpan"), Benchmark]
        public int IntSpanWhereSumFast()
        {
            return Benchmarks.intArray.AsSpan().WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSintList"), Benchmark(Baseline = true)]
        public int IntListWhereSumLinq()
        {
            return Benchmarks.intList.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSintList"), Benchmark]
        public int IntListWhereSumFast()
        {
            return Benchmarks.intList.WhereSumF(x => x > 0);
        }


        [BenchmarkCategory("BWSintArraySelect"), Benchmark(Baseline = true)]
        public int IntArrayWhereSumLinqSelect()
        {
            return Benchmarks.intArray.Where(x => x > 0).Sum(x => x / 2);
        }

        [BenchmarkCategory("BWSintArraySelect"), Benchmark]
        public int IntArrayWhereSumFastSelect()
        {
            return Benchmarks.intArray.WhereSumF(x => x > 0, x => x / 2);
        }

        [BenchmarkCategory("BWSArray.AsReadOnlySelect"), Benchmark(Baseline = true)]
        public double IntReadOnlyArraySumWithSelectLinq()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Where(x => x > 0).Sum(x => x / 2);
        }

        [BenchmarkCategory("BWSArray.AsReadOnlySelect"), Benchmark]
        public double IntReadOnlyArraySumWithSelectFast()
        {
            return Array.AsReadOnly(Benchmarks.intArray).WhereSumF(x => x > 0, x => x / 2);
        }


        [BenchmarkCategory("BWSintNullArray"), Benchmark(Baseline = true)]
        public int? IntNullArrayWhereSumLinq()
        {
            return Benchmarks.intNullArray.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSintNullArray"), Benchmark]
        public int? IntNullArrayWhereSumFast()
        {
            return Benchmarks.intNullArray.WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSintNullArraySelect"), Benchmark(Baseline = true)]
        public int IntNullArrayWhereSumLinqSelect()
        {
            return Benchmarks.intNullArray.Where(x => x > 0).Sum(x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BWSintNullArraySelect"), Benchmark]
        public int IntNullArrayWhereSumFastSelect()
        {
            return Benchmarks.intNullArray.WhereSumF(x => x > 0, x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BWSfloatArray"), Benchmark(Baseline = true)]
        public float FloatArrayWhereSumLinq()
        {
            return Benchmarks.floatArray.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSfloatArray"), Benchmark]
        public float FloatArrayWhereSumFast()
        {
            return Benchmarks.floatArray.WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSfloatList"), Benchmark(Baseline = true)]
        public float FloatListWhereSumLinq()
        {
            return Benchmarks.floatList.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSfloatList"), Benchmark]
        public float FloatListWhereSumFast()
        {
            return Benchmarks.floatList.WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSfloatArraySelect"), Benchmark(Baseline = true)]
        public float FloatArrayWhereSumLinqSelect()
        {
            return Benchmarks.floatArray.Where(x => x > 0).Sum(x => x / 2);
        }

        [BenchmarkCategory("BWSfloatArraySelect"), Benchmark]
        public float FloatArrayWhereSumFastSelect()
        {
            return Benchmarks.floatArray.WhereSumF(x => x > 0, x => x / 2);
        }

        [BenchmarkCategory("BWSfloatNullArray"), Benchmark(Baseline = true)]
        public float? FloatNullArrayWhereSumLinq()
        {
            return Benchmarks.floatNullArray.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSfloatNullArray"), Benchmark]
        public float? FloatNullArrayWhereSumFast()
        {
            return Benchmarks.floatNullArray.WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSfloatNullArraySelect"), Benchmark(Baseline = true)]
        public float FloatNullArrayWhereSumLinqSelect()
        {
            return Benchmarks.floatNullArray.Where(x => x > 0).Sum(x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BWSfloatNullArraySelect"), Benchmark]
        public float FloatNullArrayWhereSumFastSelect()
        {
            return Benchmarks.floatNullArray.WhereSumF(x => x > 0, x => x / 2 ?? 0);
        }


        [BenchmarkCategory("BWSdoubleArray"), Benchmark(Baseline = true)]
        public double DoubleArrayWhereSumLinq()
        {
            return Benchmarks.doubleArray.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSdoubleArray"), Benchmark]
        public double DoubleArrayWhereSumFast()
        {
            return Benchmarks.doubleArray.WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSdoubleList"), Benchmark(Baseline = true)]
        public double DoubleListWhereSumLinq()
        {
            return Benchmarks.doubleList.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSdoubleList"), Benchmark]
        public double DoubleListWhereSumFast()
        {
            return Benchmarks.doubleList.WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSdoubleArraySelect"), Benchmark(Baseline = true)]
        public double DoubleArrayWhereSumLinqSelect()
        {
            return Benchmarks.doubleArray.Where(x => x > 0).Sum(x => x / 2);
        }

        [BenchmarkCategory("BWSdoubleArraySelect"), Benchmark]
        public double DoubleArrayWhereSumFastSelect()
        {
            return Benchmarks.doubleArray.WhereSumF(x => x > 0, x => x / 2);
        }

        [BenchmarkCategory("BWSdoubleNullArray"), Benchmark(Baseline = true)]
        public double? DoubleNullArrayWhereSumLinq()
        {
            return Benchmarks.doubleNullArray.Where(x => x > 0).Sum();
        }

        [BenchmarkCategory("BWSdoubleNullArray"), Benchmark]
        public double? DoubleNullArrayWhereSumFast()
        {
            return Benchmarks.doubleNullArray.WhereSumF(x => x > 0);
        }

        [BenchmarkCategory("BWSdoubleNullArraySelect"), Benchmark(Baseline = true)]
        public double? DoubleNullArrayWhereSumLinqSelect()
        {
            return Benchmarks.doubleNullArray.Where(x => x > 0).Sum(x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BWSdoubleNullArraySelect"), Benchmark]
        public double? DoubleNullArrayWhereSumFastSelect()
        {
            return Benchmarks.doubleNullArray.WhereSumF(x => x > 0, x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BWSintListSelect"), Benchmark(Baseline = true)]
        public int IntListSumWithSelectLinq()
        {
            return Benchmarks.intList.Where(x => x > 0).Sum(x => x / 2);
        }

        [BenchmarkCategory("BWSintListSelect"), Benchmark]
        public int IntListSumWithSelectFast()
        {
            return Benchmarks.intList.WhereSumF(x => x > 0, x => x / 2);
        }

        [BenchmarkCategory("BWSintList.AsReadOnlySelect"), Benchmark(Baseline = true)]
        public double IntReadOnlyListSumWithSelectLinq()
        {
            return Benchmarks.intList.AsReadOnly().Where(x => x > 0).Sum(x => x / 2);
        }

        [BenchmarkCategory("BWSintList.AsReadOnlySelect"), Benchmark]
        public double IntReadOnlyListSumWithSelectFast()
        {
            return Benchmarks.intList.AsReadOnly().WhereSumF(x => x > 0, x => x / 2);
        }

    }
}
