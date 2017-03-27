using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LinqFaster;


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
            Array.Sort(array);
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
