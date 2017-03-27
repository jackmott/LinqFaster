using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFaster
{
    public static class SelectManyFuncs
    {
        // --------------------------  Arrays --------------------------------------------
        public static TResult[] SelectMany<TSource, TResult>(this TSource[] source, Func<TSource, TResult[]> selector)
        {
            var result = new List<TResult>();            
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

         public static TResult[] SelectMany<TSource, TResult>(this TSource[] source, Func<TSource,int, TResult[]> selector)
        {
            var result = new List<TResult>();            
            for (int i = 0; i < source.Length; i++)
            {
                var va = selector(source[i],i);
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
            var result = new List<TResult>();
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

        public static List<TResult> SelectMany<TSource, TResult>(this List<TSource> source, Func<TSource,int, List<TResult>> selector)
        {
            var result = new List<TResult>();
            for (int i = 0; i < source.Count; i++)
            {
                var va = selector(source[i],i);
                for (int j = 0; j < va.Count; j++)
                {
                    result.Add(va[j]);
                }
            }
            return result;
        }
    }
}
