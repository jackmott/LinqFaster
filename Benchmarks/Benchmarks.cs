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

        const int LARGE_TEST_SIZE = 1000000;
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


        
      

       

        public static void Main(string[] args)
        {

            var summary = BenchmarkRunner.Run<Benchmarks>();

        }

    }
}
