using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System.Numerics;

namespace Tests
{
    [MemoryDiagnoser]
    public class Benchmarks
    {

        const int LARGE_TEST_SIZE = 100000;
        const int SMALL_TEST_SIZE = 100;



        public List<int> list;
        public int[] array;
        

        [Params(LARGE_TEST_SIZE)]
        public int TEST_SIZE { get; set; }

        public Benchmarks()
        {

            
        }

        [Setup]
        public void Setup()
        {
            Random r = new Random();
            array = new int[TEST_SIZE];
            list = new List<int>(TEST_SIZE);
        
                                    
            for (int i = 0; i < TEST_SIZE; i++)
            {
                array[i] = r.Next(-100, 100);
                list.Add(array[i]);
            }
        }


        /*
        [Benchmark]
        public int OrderByLinq()
        {
            return array.OrderBy((x => x -1)).Sum();
        }

        [Benchmark]
        public int OrderByFast()
        {
            return array.OrderByF((x => x - 1)).Sum();
        }
        

        

        [Benchmark]
        public int SumLinq()
        {
            return array.Sum();
        }

        [Benchmark]
        public int SumFast()
        {
            return array.SumF();
        }

        [Benchmark]
        public int SumFastSIMD()
        {
            return array.SumS();
        }

        [Benchmark]
        public double AverageLinq()
        {
            return array.Average();
        }

        [Benchmark]
        public double AverageFast()
        {
            return array.AverageF();
        }

        [Benchmark]
        public double AverageFastSIMD()
        {
            return array.AverageS();
        }

        [Benchmark]
        public int SumWithSelectLinq()
        {
            return array.Sum(x => x / 2);
        }

        [Benchmark]
        public int SumWithSelectFast()
        {
            return array.SumF(x => x/2);
        }

        
        [Benchmark]
        public double WhereAggregateLinq()
        {        
            return array.Where(x => x % 2 == 0).Aggregate(0.0, (acc, x) => acc += x * x, acc => acc / array.Length);
        }

        [Benchmark]
        public double WhereAggregateFast()
        {
            return array.WhereAggregateF(x => x % 2 == 0,0.0,(acc,x)=> acc += x*x,acc => acc/array.Length);
        }

        [Benchmark]
        public int[] SelectFast()
        {
            return array.SelectF(x => x * x);
        }

        [Benchmark]
        public int[] SelectFastSIMD()
        {
            return array.SelectS(x => x * x, x=>x*x);
        }

        

        [Benchmark]
        public int[] RepeatLinq()
        {
            return Enumerable.Repeat(5, TEST_SIZE).ToArray();
        }

        [Benchmark]
        public int[] RepeastFast()
        {
            return LinqFaster.RepeatArrayF(5, TEST_SIZE);
        }


        [Benchmark]
        public int[] RepeastFastSIMD()
        {
            return LinqFasterSIMD.RepeatS(5, TEST_SIZE);
        }

        [Benchmark]
        public int[] RepeastFastSIMDB()
        {
            return LinqFasterSIMD.RepeatSB(5, TEST_SIZE);
        }
        */
        [Benchmark]
        public int MinLinq()
        {
            return array.Min();
        }

        [Benchmark]
        public int MinFast()
        {
            return array.MinF();
        }

        [Benchmark]
        public int MinFastSIMD()
        {            
            return array.MinS();
        }

        public static void Main(string[] args)
        {

            var summary = BenchmarkRunner.Run<Benchmarks>(ManualConfig.Create(DefaultConfig.Instance).With(Job.RyuJitX64));

        }

    }
}
