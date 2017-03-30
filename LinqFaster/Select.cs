using System;
using System.Collections.Generic;


namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        // --------------------------  ARRAYS  --------------------------------------------

        public static TResult[] SelectF<T, TResult>(this T[] a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            var r = new TResult[a.Length];
            for (long i = 0; i < a.LongLength; i++)
            {
                r[i] = selector(a[i]);
            }
            return r;
        }

        public static TResult[] SelectF<T, TResult>(this T[] a, Func<T, int, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            var r = new TResult[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                r[i] = selector(a[i], i);
            }
            return r;
        }

        // --------------------------  LISTS --------------------------------------------

        public static List<TResult> SelectF<T, TResult>(this List<T> a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            var r = new List<TResult>(a.Count);

            for (int i = 0; i < a.Count; i++)
            {
                r.Add(selector(a[i]));
            }

            return r;
        }


        public static List<TResult> SelectF<T, TResult>(this List<T> a, Func<T, int, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            var r = new List<TResult>(a.Count);

            for (int i = 0; i < a.Count; i++)
            {
                r.Add(selector(a[i],i));
            }

            return r;
        }






    }
}
