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
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static TResult[] WhereSelectF<T, TResult>(this T[] source, Func<T, bool> predicate, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
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

        /// <summary>
        /// Combined Where and Select for optimal performance that uses the index in the 
        /// predicate and selector.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static TResult[] WhereSelectF<T, TResult>(this T[] source, Func<T, int, bool> predicate, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = new TResult[source.Length];
            int idx = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result[idx] = selector(source[i], idx);
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }


        // --------------------------  LISTS --------------------------------------------

        /// <summary>
        /// Combined Where and Select for optimal performance.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static List<TResult> WhereSelectF<T, TResult>(this List<T> source, Func<T, bool> predicate, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var r = new List<TResult>();
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i])) r.Add(selector(source[i]));
            }
            return r;
        }

        /// <summary>
        /// Combined Where and Select for optimal performance that uses the index in the 
        /// predicate and selector.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static List<TResult> WhereSelectF<T, TResult>(this List<T> source, Func<T, int, bool> predicate, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var r = new List<TResult>();
            int idx = 0;
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i], i)) {
                    r.Add(selector(source[i], idx));
                    idx++;
                }
            }


            return r;
        }

    }
}
