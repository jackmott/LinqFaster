using System.Collections.Generic;

namespace LinqFaster
{
    public static class ReverseFuncs
    {
        public static T[] Reverse<T>(this T[] source)
        {
            var result = new T[source.Length];
            long lenLessOne = source.Length - 1;
            for (long i = 0; i < result.LongLength;i++)
            {
                result[i] = source[lenLessOne - i];
            }
            return result;
        }

        public static List<T> Reverse<T>(this List<T> source)
        {
            var result = new List<T>(source.Count);                        
            for (int i = result.Count-1; i >= 0; i--)
            {
                result.Add(source[i]);
            }
            return result;
        }


    }
}
