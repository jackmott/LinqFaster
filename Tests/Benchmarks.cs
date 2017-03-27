using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqFaster;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Tests
{
    public class Benchmarks
    {
        const int TEN_MILLION = 10000000;
        public int[] array;

        public Benchmarks()
        {
            array = new int[TEN_MILLION];
        }

        [Benchmark]
        public int[] LongIter()
        {
            for (long i = 0; i < array.LongLength; i++)
            {
                array[i] = 5;
            }
            return array;
        }

        [Benchmark]
        public int[] IntIter()
        {
            for (int i = 0; i < array.Length;i++)
            {
                array[i] = 5;
            }
            return array;
        }

        

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
        
    }
}
