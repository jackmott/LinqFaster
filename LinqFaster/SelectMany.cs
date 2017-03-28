using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        // --------------------------  Arrays --------------------------------------------
        public static TResult[] SelectMany<TSource, TResult>(this TSource[] source, Func<TSource, TResult[]> selector)
        {
            var result = new List<TResult>(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                var va = selector(source[i]);
                for (int j = 0; j < va.Length; j++)
                {
                    result.Add(va[j]);
                }
            }
            return result.ToArray();
        }

        public static TResult[] SelectMany<TSource, TResult>(this TSource[] source, Func<TSource, int, TResult[]> selector)
        {
            var result = new List<TResult>(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                var va = selector(source[i], i);
                for (int j = 0; j < va.Length; j++)
                {
                    result.Add(va[j]);
                }
            }
            return result.ToArray();
        }

        // --------------------------  LISTS --------------------------------------------
        public static List<TResult> SelectMany<TSource, TResult>(this List<TSource> source, Func<TSource, List<TResult>> selector)
        {
            var result = new List<TResult>(source.Count);
            for (int i = 0; i < source.Count; i++)
            {
                var va = selector(source[i]);
                for (int j = 0; j < va.Count; j++)
                {
                    result.Add(va[j]);
                }
            }
            return result;
        }

        public static List<TResult> SelectMany<TSource, TResult>(this List<TSource> source, Func<TSource, int, List<TResult>> selector)
        {
            var result = new List<TResult>(source.Count);
            for (int i = 0; i < source.Count; i++)
            {
                var va = selector(source[i], i);
                for (int j = 0; j < va.Count; j++)
                {
                    result.Add(va[j]);
                }
            }
            return result;
        }
    }
}
