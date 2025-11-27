using System;
using System.Collections.Generic;

namespace JM.LinqFasterSpan
{

    public static partial class LinqFasterSpan
    {
       

        // --------------------------  this Spans --------------------------------------------

        /// <summary>
        /// Combines Select and Where into a single call for optimal
        /// performance.
        /// </summary>        
        /// <param name="source">The input sequence to filter and select</param>
        /// <param name="selector">The transformation to apply before filtering.</param>
        /// <param name="predicate">The predicate with which to filter result.</param>
        /// <returns>A sequence transformed and then filtered by selector and predicate.</returns>
        public static TResult[] SelectWhereF<T, TResult>(this Span<T> source, Func<T, TResult> selector, Func<TResult, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            TResult[] result = new TResult[source.Length];
            int idx = 0;
            for (int i = 0; i < source.Length; i++)
            {
                TResult s = selector(source[i]);
                if (predicate(s))
                {
                    result[idx] = s;
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        /// <summary>
        /// Combines Select and Where with indexes into a single call for optimal
        /// performance.
        /// </summary>        
        /// <param name="source">The input sequence to filter and select</param>
        /// <param name="selector">The transformation with index to apply before filtering.</param>
        /// <param name="predicate">The predicate with index with which to filter result.</param>
        /// <returns>A sequence transformed and then filtered by selector and predicate with indexes.</returns>
        public static TResult[] SelectWhereF<T, TResult>(this Span<T> source, Func<T, int, TResult> selector, Func<TResult, int, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            TResult[] result = new TResult[source.Length];
            int idx = 0;
            for (int i = 0; i < source.Length; i++)
            {
                TResult s = selector(source[i], i);
                if (predicate(s, i))
                {
                    result[idx] = s;
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

    }
}
