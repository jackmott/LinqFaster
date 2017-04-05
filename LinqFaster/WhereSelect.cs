using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{

    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS --------------------------------------------
        

        /// <summary>
        /// Combined Where and Select for optimal performance.
        /// </summary>        
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult[] WhereSelectF<T, TResult>(this T[] source, Func<T, bool> predicate, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = new TResult[source.Length];
            int idx = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result[idx] = selector(source[i]);
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }
       
        public static TResult[] WhereSelectF<T, TResult>(this T[] a, Func<T, int, bool> predicate, Func<T, int, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = new TResult[a.Length];
            int idx = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (predicate(a[i], i))
                {
                    result[idx] = selector(a[i], idx);
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }
        

        // --------------------------  LISTS --------------------------------------------

        public static List<TResult> WhereSelectF<T, TResult>(this List<T> a, Func<T, bool> predicate, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var r = new List<TResult>();
            for (int i = 0; i < a.Count; i++)
            {
                if (predicate(a[i])) r.Add(selector(a[i]));
            }
            return r;
        }

        public static List<TResult> WhereSelectF<T, TResult>(this List<T> a, Func<T, int, bool> predicate, Func<T, int, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var r = new List<TResult>();
            int idx = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (predicate(a[i], i)) {
                    r.Add(selector(a[i], idx));
                    idx++;
                }
            }


            return r;
        }

    }
}
