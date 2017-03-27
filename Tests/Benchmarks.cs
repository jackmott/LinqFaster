using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LinqFaster;
using System.Collections.Generic;

namespace Tests
{
    public class Benchmarks
    {

        const int LARGE_TEST_SIZE = 10000000;
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
        public double ListSumLinqFaster()
        {
            return list.Sum();                                 
        }

        [Benchmark]
        public double  ListSumLinq()
        {
            return
                System.Linq.Enumerable.Sum(list);                
        }

        [Benchmark]
        public double ListAverageLinqFaster()
        {
            return list.Average();
        }

        [Benchmark]
        public double ListAverageLinq()
        {
            return
                System.Linq.Enumerable.Average(list);
        }

        // arrays

        [Benchmark]
        public double ArraySumLinqFaster()
        {
            return array.Sum();
        }

        [Benchmark]
        public double ArraySumLinq()
        {
            return
                System.Linq.Enumerable.Sum(array);
        }

        [Benchmark]
        public double ArrayAverageLinqFaster()
        {
            return array.Average();
        }

        [Benchmark]
        public double ArrayAverageLinq()
        {
            return
                System.Linq.Enumerable.Average(array);
        }



        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();

        }

    }
}
