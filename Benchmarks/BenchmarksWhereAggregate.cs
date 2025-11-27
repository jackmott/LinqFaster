using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using JM.LinqFaster;

namespace Tests
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarksWhereAggregate
    {
        private static readonly Func<double, int, double> mulXInts = (acc, x) => acc += x * x;


        [BenchmarkCategory("BWAintArray.WhereAggregateSelect"), Benchmark(Baseline = true)]
        public double IntArrayWhereAggregateLinq()
        {
            return Benchmarks.intArray.Where(x => x % 2 == 0).Aggregate(0.0, mulXInts, acc => acc / Benchmarks.intArray.Length);
        }

        [BenchmarkCategory("BWAintArray.WhereAggregateSelect"), Benchmark]
        public double IntArrayWhereAggregateFast()
        {
            return Benchmarks.intArray.WhereAggregateF(x => x % 2 == 0, 0.0, mulXInts, acc => acc / Benchmarks.intArray.Length);
        }
    }
}
