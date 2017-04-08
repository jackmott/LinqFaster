using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using JM.LinqFaster;
using JM.LinqFaster.Parallel;
using JM.LinqFaster.SIMD;
using JM.LinqFaster.SIMD.Parallel;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Tests
{
    [MemoryDiagnoser]
    public class Benchmarks
    {

        const int LARGE_TEST_SIZE = 1000000;
        const int SMALL_TEST_SIZE = 100;



        public List<int> list;
        public int[] array;
        public float[] floatArray;
        public string[] strarray;
        

        [Params(100000)]
        public int TEST_SIZE { get; set; }

        public Benchmarks()
        {

            
        }

        [Setup]
        public void Setup()
        {
            Random r = new Random();
            array = new int[TEST_SIZE];
            floatArray = new float[TEST_SIZE];
            list = new List<int>(TEST_SIZE);
            strarray = new string[TEST_SIZE];
                                    
            for (int i = 0; i < TEST_SIZE; i++)
            {
                array[i] = i - (TEST_SIZE)/2;
                list.Add(array[i]);
                strarray[i] = array[i].ToString();
                floatArray[i] = array[i];
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
        }*/

        [Benchmark]
        public int MinLinq()
        {
            return array.Min();
        }

        [Benchmark]
        public int MinLF()
        {

            return array.MinF();
        }

        [Benchmark]
        public int SumLinq()
        {
            return array.Sum();
        }

        [Benchmark]
        public int SumLF()
        {
            return array.SumF();
        }

        [Benchmark]
        public int[] WhereSelectLinq()
        {            
            return array.Where(x => x%2 == 0).Select(x=>x*x).ToArray();
        }

        [Benchmark]
        public int[] WhereSelectLF()
        {
            return array.WhereSelectF(x=>x%2 == 0,x=>x*x);
        }





        public static void Main(string[] args)
        {
            //Create an array of with values -500 to 500
            var myArray = LinqFaster.RangeArrayF(-500, 500);
            //Create a List<T> with 1000 elements all set to 5.0
            var myList = LinqFaster.RepeatListF(5.0, 1000);

            //Compute sum, average, max,min
            var sum = myArray.SumF();
            var average = myArray.AverageF();
            var min = myArray.Min();
            var max = myArray.Max();

            //As above but on a transformation
            var sum2 = myArray.SumF(x => x*x);
            var average2 = myArray.AverageF(x => x*x);
            var min2 = myArray.Min(x => x*x);
            var max2 = myArray.Max(x => x*x);

            //Do a where and a select or select and where in a single pass
            var newArray = myArray.WhereSelectF(x => x % 2 == 0,x=>x*x);
            var newArray2 = myArray.SelectWhereF(x => x * x,x => x % 2 == 0);

            //Compute the sum of only the even values in a single pass
            var filteredSum = myArray.WhereAggregateF(x => x % 2 == 0, (acc, x) => acc + x);

            //New in-place methods are provided where appropriate
            myArray.SelectInPlaceF(x => x * x);
            myArray.ReverseInPlaceF();




            /*  Benchmarks b = new Benchmarks();
               b.TEST_SIZE = 100000;
               b.Setup();
               b.array.WhereSelectPB(x => x % 2 == 0, x => Math.Sqrt(x */

            var summary = BenchmarkRunner.Run<Benchmarks>(ManualConfig.Create(DefaultConfig.Instance).With(Job.RyuJitX64));

        }

    }
}
