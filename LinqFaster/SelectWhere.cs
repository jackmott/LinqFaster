using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{

    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS --------------------------------------------

        public static TResult[] SelectWhere<T, TResult>(this T[] a, Func<T, TResult> selector, Func<TResult, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = new TResult[a.Length];
            int idx = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var s = selector(a[i]);
                if (predicate(s))
                {
                    result[idx] = s;
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        public static TResult[] SelectWhere<T, TResult>(this T[] a, Func<T, int, TResult> selector, Func<TResult, int, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = new TResult[a.Length];
            int idx = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var s = selector(a[i],i);
                if (predicate(s,i))
                {
                    result[idx] = s;
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        // --------------------------  LISTS --------------------------------------------

        public static List<TResult> SelectWhere<T, TResult>(this List<T> a, Func<T, TResult> selector, Func<TResult, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var r = new List<TResult>();
            for (int i = 0; i < a.Count; i++)
            {
                var s = selector(a[i]);
                if (predicate(s)) r.Add(s);
            }
            return r;
        }

        public static List<TResult> SelectWhere<T, TResult>(this List<T> a, Func<T, int, TResult> selector,Func<TResult, int, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var r = new List<TResult>();
            for (int i = 0; i < a.Count; i++)
            {
                var s = selector(a[i],i);
                if (predicate(s,i)) r.Add(s);
            }
            return r;
        }

    }
}
