using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        public static T[] ReverseF<T>(this T[] source)
        {
            var result = new T[source.Length];
            long lenLessOne = source.Length - 1;
            for (long i = 0; i < result.LongLength; i++)
            {
                result[i] = source[lenLessOne - i];
            }
            return result;
        }

        public static List<T> ReverseListF<T>(this List<T> source)
        {
            var result = new List<T>(source.Count);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                result.Add(source[i]);
            }
            return result;
        }


    }
}
