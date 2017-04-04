using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [SetUpFixture]
    public class Test
    {
        public const int TEST_SIZE = 1000;
        public static int[] intArray;
        public static long[] longArray;
        public static float[] floatArray;
        public static double[] doubleArray;
        public static decimal[] decimalArray;
        public static string[] stringArray;

        public static List<int> intList;
        public static List<long> longList;
        public static List<float> floatList;
        public static List<double> doubleList;
        public static List<decimal> decimalList;
        public static List<string> stringList;

        public static Func<int, bool> onlyEvenInts;
        public static Func<int, int> squaredInts;
        public static Func<int, int, int> addXInts;

        public static Func<float, bool> onlyPositiveFloats;
        public static Func<float, float> squaredFloats;



        [OneTimeSetUp]
        public void Setup()
        {
            onlyPositiveFloats = (x => x > 0.0f);
            squaredFloats = (x => x * x);
            onlyEvenInts = (x => x % 2 == 0);
            squaredInts = (x => x * x);
            addXInts = (x, acc) => acc += x;

            intArray = new int[TEST_SIZE];
            floatArray = new float[TEST_SIZE];
            intList = new List<int>(TEST_SIZE);
            floatList = new List<float>(TEST_SIZE);
            stringArray = new string[TEST_SIZE];
            stringList = new List<string>(TEST_SIZE);
            decimalArray = new decimal[TEST_SIZE];
            decimalList = new List<decimal>(TEST_SIZE);
            doubleArray = new double[TEST_SIZE];
            doubleList = new List<double>(TEST_SIZE);
            longArray = new long[TEST_SIZE];
            longList = new List<long>(TEST_SIZE);
            Random rand = new Random();
            for (int i = 0; i < intArray.Length;i++)
            {
                intArray[i] = rand.Next(-100, 100);
                intList.Add(intArray[i]);
                longArray[i] = intArray[i];
                longList.Add(intArray[i]);
                floatArray[i] = (float)rand.NextDouble() * 100.0f - 50f;
                floatList.Add(intArray[i]);
                stringArray[i] = intArray[i].ToString();
                stringList.Add(stringArray[i]);
                decimalArray[i] = (decimal)floatArray[i];
                decimalList.Add(decimalArray[i]);
                doubleArray[i] = rand.NextDouble() * 10000.0 - 5000.0;
                doubleList.Add(doubleArray[i]);
            }
        }

        public Test()
        {

        }

      
    }
}
