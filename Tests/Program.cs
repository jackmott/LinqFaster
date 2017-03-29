using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    [SetUpFixture]
    public class Program
    {
        const int TEST_SIZE = 1000;
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


        [OneTimeSetUp]
        public void Setup()
        {
            intArray = new int[TEST_SIZE];
            floatArray = new float[TEST_SIZE];
            intList = new List<int>(TEST_SIZE);
            floatList = new List<float>(TEST_SIZE);
            stringArray = new string[TEST_SIZE];
            stringList = new List<string>(TEST_SIZE);
            decimalArray = new decimal[TEST_SIZE];
            decimalList = new List<decimal>(TEST_SIZE);
            Random rand = new Random();
            for (int i = 0; i < intArray.Length;i++)
            {
                intArray[i] = rand.Next(-100, 100);
                intList.Add(intArray[i]);
                floatArray[i] = (float)rand.NextDouble() * 100.0f - 50f;
                floatList.Add(intArray[i]);
                stringArray[i] = floatArray[i].ToString();
                stringList.Add(stringArray[i]);
                decimalArray[i] = (decimal)floatArray[i];
                decimalList.Add(decimalArray[i]);
            }
        }

        public Program()
        {

        }

      
    }
}
