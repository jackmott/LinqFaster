using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;
using JM.LinqFasterSpan;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarksAggregate
    {
        private static readonly Func<double, int, double> mulXInts = (acc, x) => acc += x * x;

        [BenchmarkCategory("BAg_IntArrayAggregate"), Benchmark(Baseline = true)]
        public double IntArrayAggregateLinq()
        {
            return Benchmarks.intArray.Aggregate(0.0D, mulXInts);
        }

        [BenchmarkCategory("BAg_IntArrayAggregate"), Benchmark]
        public double IntArrayAggregateFast()
        {
            return Benchmarks.intArray.AggregateF(0.0D, mulXInts);
        }

        [BenchmarkCategory("BAg_IntReadOnlyArrayAggregate"), Benchmark(Baseline = true)]
        public double IntReadOnlyArrayAggregateLinq()
        {
            return Array.AsReadOnly(Benchmarks.intArray).Aggregate(0.0D, mulXInts);
        }

        [BenchmarkCategory("BAg_IntReadOnlyArrayAggregate"), Benchmark]
        public double IntReadOnlyArrayAggregateFast()
        {
            return Array.AsReadOnly(Benchmarks.intArray).AggregateF(0.0D, mulXInts);
        }

        [BenchmarkCategory("BAg_IntSpanAggregate"), Benchmark(Baseline = true)]
        public double IntSpanAggregateForEach()
        {
            //return intArray.AsSpan().Aggregate(0.0, mulXInts);
            double result = 0.0D;
            foreach (var v in Benchmarks.intArray.AsSpan())
            {
                result = mulXInts(result, v);
            }
            return result;
        }

        [BenchmarkCategory("BAg_IntSpanAggregate"), Benchmark]
        public double IntSpanAggregateFast()
        {
            return Benchmarks.intArray.AsSpan().AggregateF(0.0, mulXInts);
        }

        [BenchmarkCategory("BAg_intList.Aggregate.Select"), Benchmark(Baseline = true)]
        public double IntArrayAggregateLinqSelector()
        {
            return Benchmarks.intArray.Aggregate(0.0, mulXInts, acc => acc / Benchmarks.intArray.Length);
        }

        [BenchmarkCategory("BAg_intList.Aggregate.Select"), Benchmark]
        public double IntArrayAggregateFastSelector()
        {
            return Benchmarks.intArray.AggregateF(0.0, mulXInts, acc => acc / Benchmarks.intArray.Length);
        }

        [BenchmarkCategory("BAg_intList.Aggregate"), Benchmark(Baseline = true)]
        public double IntListAggregateLinq()
        {
            return Benchmarks.intList.Aggregate(0.0, mulXInts);
        }

        [BenchmarkCategory("BAg_intList.Aggregate"), Benchmark]
        public double IntListAggregateFast()
        {
            return Benchmarks.intList.AggregateF(0.0, mulXInts);
        }

        [BenchmarkCategory("BAg_intList.AsReadOnly"), Benchmark(Baseline = true)]
        public double IntReadOnlyListAggregateLinq()
        {
            return Benchmarks.intList.AsReadOnly().Aggregate(0.0, mulXInts);
        }

        [BenchmarkCategory("BAg_intList.AsReadOnly"), Benchmark]
        public double IntReadOnlyListAggregateFast()
        {
            return Benchmarks.intList.AsReadOnly().AggregateF(0.0, mulXInts);
        }
    }
}
