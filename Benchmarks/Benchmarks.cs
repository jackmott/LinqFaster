using System;
using System.Collections.Generic;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Tests
{
    [MemoryDiagnoser]
    public partial class Benchmarks
    {
        private const int LARGE_TEST_SIZE = 1000000;
        private const int SMALL_TEST_SIZE = 100;

        internal static List<int> list;
        internal static byte[] byteArray;
        internal static short[] shortArray;
        internal static int[] intArray;
        internal static List<int> intList;
        internal static int?[] intNullArray;
        internal static int[] array2;
        internal static float[] floatArray;
        internal static List<float> floatList;
        internal static float?[] floatNullArray;
        internal static double[] doubleArray;
        internal static List<double> doubleList;
        internal static double?[] doubleNullArray;
        internal static string[] strarray;


        internal static int TEST_SIZE => LARGE_TEST_SIZE;

        static Benchmarks()
        {
            byteArray = new byte[TEST_SIZE];
            shortArray = new short[TEST_SIZE];
            intArray = new int[TEST_SIZE];
            intNullArray = new int?[TEST_SIZE];
            intList = new List<int>(TEST_SIZE);
            array2 = new int[TEST_SIZE];
            floatArray = new float[TEST_SIZE];
            floatList = new List<float>(TEST_SIZE);
            floatNullArray = new float?[TEST_SIZE];
            doubleArray = new double[TEST_SIZE];
            doubleList = new List<double>(TEST_SIZE);
            doubleNullArray = new double?[TEST_SIZE];
            list = new List<int>(TEST_SIZE);
            strarray = new string[TEST_SIZE];

            for (int i = 0; i < TEST_SIZE; i++)
            {
                intArray[i] = i % 2;
                byteArray[i] = (byte)intArray[i];
                shortArray[i] = (short)intArray[i];
                intNullArray[i] = intArray[i];
                intList.Add(intArray[i]);
                array2[i] = i % 2;
                list.Add(intArray[i]);
                strarray[i] = intArray[i].ToString();
                floatArray[i] = intArray[i];
                floatList.Add(floatArray[i]);
                floatNullArray[i] = floatArray[i];
                doubleArray[i] = floatArray[i];
                doubleList.Add(doubleArray[i]);
                doubleNullArray[i] = doubleArray[i];
            }
            array2[TEST_SIZE / 2] = 0;
        }



        public static void Main(string[] args)
        {
            ManualConfig config = (ManualConfig)ManualConfig.Create(DefaultConfig.Instance).With(Job.RyuJitX64);
            config.Options |= ConfigOptions.JoinSummary;

            BenchmarkRunInfo[] benchmarkRunInfos =
            {
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarkSum), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksAverage), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksFirst), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksLast), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksMax), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksMin), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksAggregate), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksRepeat), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarkOrderBy), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarkSequenceEqual), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarkSelect), config),
                BenchmarkConverter.TypeToBenchmarks(typeof (BenchmarksWhereAggregate), config),
                //BenchmarkConverter.TypeToBenchmarks(typeof (
        };
            Summary[] summaries = BenchmarkRunner.Run(benchmarkRunInfos);
            Console.WriteLine("Press enter to close");
            Console.ReadLine();
        }

    }
}
