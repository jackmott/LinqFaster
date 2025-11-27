using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFasterSpan;
using JM.LinqFaster.SIMD;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarkSum
    {
        private static readonly Func<int, int> sumDivide = (x) => x / 2;

        [BenchmarkCategory("BSumbyteArray"), Benchmark(Baseline = true)]
        public int ByteArraySumLinq()
        {
            return Benchmarks.byteArray.Aggregate(0, (current, b1) => current + b1);
        }

        [BenchmarkCategory("BSumbyteArray"), Benchmark]
        public uint ByteArraySumFast()
        {
            return Benchmarks.byteArray.SumF();
        }


        [BenchmarkCategory("BSumshortArray"), Benchmark(Baseline = true)]
        public int ShortArraySumLinq()
        {
            return Benchmarks.shortArray.Aggregate(0, (current, s1) => current + s1);
        }

        [BenchmarkCategory("BSumshortArray"), Benchmark]
        public int ShortArraySumFast()
        {
            return Benchmarks.shortArray.SumF();
        }


        [BenchmarkCategory("BSumintArray"), Benchmark(Baseline = true)]
        public int IntArraySumLinq()
        {
            return Benchmarks.intArray.Sum();
        }

        [BenchmarkCategory("BSumintArray"), Benchmark]
        public int IntArraySumFast()
        {
            return Benchmarks.intArray.SumF();
        }

        [BenchmarkCategory("BSumintArray"), Benchmark]
        public int IntArraySumFastSIMD()
        {
            return Benchmarks.intArray.SumS();
        }

        [BenchmarkCategory("BSumintArraySpan"), Benchmark(Baseline = true)]
        public int IntSpanSumFor()
        {
            int val = 0;
            Span<int> span = Benchmarks.intArray.AsSpan();
            for (int index = 0; index < span.Length; index++)
            {
                val += span[index];
            }

            return val;
        }

        [BenchmarkCategory("BSumintArraySpan"), Benchmark]
        public int IntSpanSumFast()
        {
            return Benchmarks.intArray.AsSpan().SumF();
        }

        [BenchmarkCategory("BSumintList"), Benchmark(Baseline = true)]
        public int IntListSumLinq()
        {
            return Benchmarks.intList.Sum();
        }

        [BenchmarkCategory("BSumintList"), Benchmark]
        public int IntListSumFast()
        {
            return Benchmarks.intList.SumF();
        }


        [BenchmarkCategory("BSumIntArrayAggregate"), Benchmark(Baseline = true)]
        public int IntArraySumLinqSelect()
        {
            return Benchmarks.intArray.Sum(sumDivide);
        }

        [BenchmarkCategory("BSumIntArrayAggregate"), Benchmark]
        public int IntArraySumFastSelect()
        {
            return Benchmarks.intArray.SumF(sumDivide);
        }

        [BenchmarkCategory("BSumintArrayAsReadOnly"), Benchmark(Baseline = true)]
        public double IntReadOnlyArraySumWithSelectLinq()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Sum(sumDivide);
        }

        [BenchmarkCategory("BSumintArrayAsReadOnly"), Benchmark]
        public double IntReadOnlyArraySumWithSelectFast()
        {
            return Array.AsReadOnly(Benchmarks.intArray).SumF(sumDivide);
        }

        [BenchmarkCategory("BSumintNullArray"), Benchmark(Baseline = true)]
        public int? IntNullArraySumLinq()
        {
            return Benchmarks.intNullArray.Sum();
        }

        [BenchmarkCategory("BSumintNullArray"), Benchmark]
        public int? IntNullArraySumFast()
        {
            return Benchmarks.intNullArray.SumF();
        }

        [BenchmarkCategory("BSumintNullArraySelect"), Benchmark(Baseline = true)]
        public int IntNullArraySumLinqSelect()
        {
            return Benchmarks.intNullArray.Sum(x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BSumintNullArraySelect"), Benchmark]
        public int IntNullArraySumFastSelect()
        {
            return Benchmarks.intNullArray.SumF(x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BSumfloatArray"), Benchmark(Baseline = true)]
        public float FloatArraySumLinq()
        {
            return Benchmarks.floatArray.Sum();
        }

        [BenchmarkCategory("BSumfloatArray"), Benchmark]
        public float FloatArraySumFast()
        {
            return Benchmarks.floatArray.SumF();
        }

        [BenchmarkCategory("BSumfloatList"), Benchmark(Baseline = true)]
        public float FloatListSumLinq()
        {
            return Benchmarks.floatList.Sum();
        }

        [BenchmarkCategory("BSumfloatList"), Benchmark]
        public float FloatListSumFast()
        {
            return Benchmarks.floatList.SumF();
        }

        [BenchmarkCategory("BSumfloatArraySelect"), Benchmark(Baseline = true)]
        public float FloatArraySumLinqSelect()
        {
            return Benchmarks.floatArray.Sum(x => x / 2);
        }

        [BenchmarkCategory("BSumfloatArraySelect"), Benchmark]
        public float FloatArraySumFastSelect()
        {
            return Benchmarks.floatArray.SumF(x => x / 2);
        }

        [BenchmarkCategory("BSumfloatNullArray"), Benchmark(Baseline = true)]
        public float? FloatNullArraySumLinq()
        {
            return Benchmarks.floatNullArray.Sum();
        }

        [BenchmarkCategory("BSumfloatNullArray"), Benchmark]
        public float? FloatNullArraySumFast()
        {
            return Benchmarks.floatNullArray.SumF();
        }

        [BenchmarkCategory("BSumfloatNullArraySelect"), Benchmark(Baseline = true)]
        public float FloatNullArraySumLinqSelect()
        {
            return Benchmarks.floatNullArray.Sum(x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BSumfloatNullArraySelect"), Benchmark]
        public float FloatNullArraySumFastSelect()
        {
            return Benchmarks.floatNullArray.SumF(x => x / 2 ?? 0);
        }


        [BenchmarkCategory("BSumdoubleArray"), Benchmark(Baseline = true)]
        public double DoubleArraySumLinq()
        {
            return Benchmarks.doubleArray.Sum();
        }

        [BenchmarkCategory("BSumdoubleArray"), Benchmark]
        public double DoubleArraySumFast()
        {
            return Benchmarks.doubleArray.SumF();
        }

        [BenchmarkCategory("BSumdoubleList"), Benchmark(Baseline = true)]
        public double DoubleListSumLinq()
        {
            return Benchmarks.doubleList.Sum();
        }

        [BenchmarkCategory("BSumdoubleList"), Benchmark]
        public double DoubleListSumFast()
        {
            return Benchmarks.doubleList.SumF();
        }

        [BenchmarkCategory("BSumdoubleArraySelect"), Benchmark(Baseline = true)]
        public double DoubleArraySumLinqSelect()
        {
            return Benchmarks.doubleArray.Sum(x => x / 2);
        }

        [BenchmarkCategory("BSumdoubleArraySelect"), Benchmark]
        public double DoubleArraySumFastSelect()
        {
            return Benchmarks.doubleArray.SumF(x => x / 2);
        }

        [BenchmarkCategory("BSumdoubleNullArray"), Benchmark(Baseline = true)]
        public double? DoubleNullArraySumLinq()
        {
            return Benchmarks.doubleNullArray.Sum();
        }

        [BenchmarkCategory("BSumdoubleNullArray"), Benchmark]
        public double? DoubleNullArraySumFast()
        {
            return Benchmarks.doubleNullArray.SumF();
        }

        [BenchmarkCategory("BSumdoubleNullArraySelect"), Benchmark(Baseline = true)]
        public double? DoubleNullArraySumLinqSelect()
        {
            return Benchmarks.doubleNullArray.Sum(x => x / 2 ?? 0);
        }

        [BenchmarkCategory("BSumdoubleNullArraySelect"), Benchmark]
        public double? DoubleNullArraySumFastSelect()
        {
            return Benchmarks.doubleNullArray.SumF(x => x / 2 ?? 0);
        }
    }
}
