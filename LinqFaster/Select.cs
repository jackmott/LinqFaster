using System;
using System.Collections.Generic;


namespace LinqFaster
{
    public static class SelectFuncs
    {

        // --------------------------  ARRAYS  --------------------------------------------

        public static TResult[] Select<T, TResult>(this T[] a, Func<T, TResult> selector)
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
                r[i] = selector.Invoke(a[i]);
            }
            return r;
        }

        public static TResult[] Select<T, TResult>(this T[] a, Func<T, int, TResult> selector)
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
                r[i] = selector.Invoke(a[i], i);
            }
            return r;
        }

        // --------------------------  LISTS --------------------------------------------

        public static List<TResult> Select<T, TResult>(this List<T> a, Func<T, TResult> selector)
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
                r.Add(selector.Invoke(a[i]));
            }
            return r;
        }

        public static List<TResult> Select<T, TResult>(this List<T> a, Func<T, int, TResult> selector)
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
                r.Add(selector.Invoke(a[i], i));
            }
            return r;
        }






    }
}
