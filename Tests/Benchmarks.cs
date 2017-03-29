using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using JM.LinqFaster;
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


        /*
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

        [Benchmark]
        public double ListSelectSumLinqFaster()
        {
            return list.Select(x => x / 2).Sum();
        }

        [Benchmark]
        public double ListSelectSumLinq()
        {
            return System.Linq.Enumerable.Sum(System.Linq.Enumerable.Select(list, x => x / 2));
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

        [Benchmark]
        public double ArraySelectSumLinqFaster()
        {
            return array.Select(x => x / 2).Sum();
        }

        [Benchmark]
        public double ArraySelectSumLinq()
        {
            return System.Linq.Enumerable.Sum(System.Linq.Enumerable.Select(array, x => x / 2));
        }

        [Benchmark]
        public double ArrayWhereSumLinqFaster()
        {
            return array.Where(x => x % 2 == 0).Sum();
        }

        [Benchmark]
        public double ArrayWhereSumLinq()
        {
            return System.Linq.Enumerable.Sum(System.Linq.Enumerable.Where(array, x => x % 2 == 0));
        }

        [Benchmark]
        public double ListWhereSumLinqFaster()
        {
            return list.Where(x => x % 2 == 0).Sum();
        }

        [Benchmark]
        public double ListWhereSumLinq()
        {
            return System.Linq.Enumerable.Sum(System.Linq.Enumerable.Where(list, x => x % 2 == 0));
        }

       
        [Benchmark]
        public int ArrayMinLinqFaster()
        {
            return array.Min();
        }

        [Benchmark]
        public int ArrayMinLinq()
        {
            return System.Linq.Enumerable.Min(array);
        }

        [Benchmark]
        public int ListMinLinqFaster()
        {
            return list.Min();
        }

        [Benchmark]
        public int ListMinLinq()
        {
            return System.Linq.Enumerable.Min(list);
        }

        [Benchmark]
        public int ArraySelectManySumLinqFaster()
        {
            return array.SelectMany(x =>
            {
                int[] result = new int[5];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = 1;
                }
                return result;
            }).Sum();
        }

        [Benchmark]
        public int ArraySelectManySumLinq()
        {
            return System.Linq.Enumerable.Sum(
                System.Linq.Enumerable.SelectMany(array, (x =>
             {
                 int[] result = new int[5];
                 for (int i = 0; i < result.Length; i++)
                 {
                     result[i] = 1;
                 }
                 return result;
             })));
        }

        [Benchmark]
        public int ListSelectManySumLinqFaster()
        {            
            return list.SelectMany(x =>
            {
                var result = new List<int>(5);
                for (int i = 0; i < result.Count; i++)
                {
                    result.Add(1);
                }
                return result;
            }).Sum();
        }

        [Benchmark]
        public int ListSelectManySumLinq()
        {
            return System.Linq.Enumerable.Sum(
                System.Linq.Enumerable.SelectMany(list, (x =>
                {
                    var result = new List<int>(5);
                    for (int i = 0; i < result.Count; i++)
                    {
                        result.Add(1);
                    }
                    return result;
                })));
        }

        [Benchmark]
        public double ArrayRangeAverageLinqFaster()
        {
            
            return LinqFaster.RangeArray(0, TEST_SIZE).Average();
        }

        [Benchmark]
        public double RangeAverageLinq()
        {
            return System.Linq.Enumerable.Average(System.Linq.Enumerable.Range(0, TEST_SIZE));
        }

        [Benchmark]
        public double ListRangeAverageLinqFaster()
        {
            return LinqFaster.RangeArray(0, TEST_SIZE).Average();
        }

        [Benchmark]
        public int ArrayAggregateLinqFaster()
        {
            return array.Aggregate((x, i) => i = i + x/2);
        }

        [Benchmark]
        public int ArrayAggregateLinq()
        {
            return System.Linq.Enumerable.Aggregate(array,(x, i) => i = i + x/2);
        }

        [Benchmark]
        public int ListAggregateLinqFaster()
        {
            return list.Aggregate((x, i) => i = i + x / 2);
        }

        [Benchmark]
        public int ListAggregateLinq()
        {
            return System.Linq.Enumerable.Aggregate(list, (x, i) => i = i + x / 2);
        }
        

        [Benchmark]
        public double ArrayWhereAggregateLinqFaster() {
            return list.WhereAggregate(x => x % 2 == 0,0,(x,acc) => acc += x,x => x/array.Length);
        }
        
        
        [Benchmark]
        public double arrayWhereAggregteLinq()
        {
            return
                    System.Linq.Enumerable.Aggregate(
                        System.Linq.Enumerable.Where(list,x => x % 2 == 0),0,(x,acc) => acc += x,x => x/array.Length);
        }

       
        [Benchmark]
        public int ArrayDistinctSumLinqFaster()
        {            
            return array.Distinct().Sum();
        }


        [Benchmark]
        public int arrayDistinctSumLinq()
        {
            return
                    System.Linq.Enumerable.Sum(System.Linq.Enumerable.Distinct(array));
        }

        [Benchmark]
        public bool ArraySequenceEqualLinqFaster()
        {
            return LinqFaster.SequenceEqual(list, list);
        }

        [Benchmark]
        public bool ArraySequenceEqualLinq()
        {
            return System.Linq.Enumerable.SequenceEqual(list, list);
        }*/

        [Benchmark]
        public int ArraySkipWhileSumLinqFaster()
        {
            return array.SkipWhile(x => x != 0).Sum();
        }

        [Benchmark]
        public int ArraySequenceEqualLinq()
        {
            return System.Linq.Enumerable.Sum(System.Linq.Enumerable.SkipWhile(array,x => x != 0));
        }

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();

        }

    }
}
