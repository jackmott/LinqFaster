using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;

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

        
        [Benchmark]
        public int OrderByFast()
        {
            return array.OrderByF((x => x -1)).Sum();
        }

        [Benchmark]
        public int OrderByLinq()
        {
            return array.OrderBy((x => x -1)).Sum();
        }

        [Benchmark]
        public int MinFast()
        {
            return array.MinF();
        }

        [Benchmark]
        public int MinLinq()
        {
            return array.Min();
        }

        [Benchmark]
        public int SumFast()
        {
            return array.SumF();
        }

        [Benchmark]
        public int SumLinq()
        {
            return array.Sum();
        }

        [Benchmark]
        public int SumWithSelectFast()
        {
            return array.SumF(x => x/2);
        }

        [Benchmark]
        public int SumWithSelectLinq()
        {
            return array.Sum(x => x/2);
        }

        [Benchmark]
        public double WhereSelectAverageFast()
        {
            return array.WhereSelectAverageF(x => x % 2 == 0, x=> x*x);
        }

        [Benchmark]
        public double WhereSelectAverageLinq()
        {
            return array.Where(x => x % 2 == 0).Average(x => x * x);
        }



        public static void Main(string[] args)
        {
                       
            var summary = BenchmarkRunner.Run<Benchmarks>();

        }

    }
}
