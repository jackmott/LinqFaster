using System;
using System.Collections.Generic;

namespace JM.LinqFasterSpan
{
    public static partial class LinqFasterSpan
    {
        
        // --------------------------  this Spans --------------------------------------------

        /// <summary>
        /// Projects each element of a sequence to another sequence and flattens the resulting sequences into one sequence.
        /// Yo dawg, I heard you like sequences.
        /// </summary>                    
        /// <param name="source">A sequence of values to project.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>A sequence whose elements are the result of invoking the one-to-many transform function on each element of the input sequence.</returns>
        public static TResult[] SelectManyF<TSource, TResult>(this Span<TSource> source, Func<TSource, TResult[]> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            List<TResult> result = new List<TResult>(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                TResult[] va = selector(source[i]);
                for (int j = 0; j < va.Length; j++)
                {
                    result.Add(va[j]);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Projects each element of a sequence to another sequence and flattens the resulting sequences into one sequence
        /// utilizing the index of each element.
        /// </summary>                    
        /// <param name="source">A sequence of values to project.</param>
        /// <param name="selector">A transform function to apply to each element and it's index.</param>
        /// <returns>A sequence whose elements are the result of invoking the one-to-many transform function on each element and index of the input sequence.</returns>
        public static TResult[] SelectManyF<TSource, TResult>(this Span<TSource> source, Func<TSource, int, TResult[]> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            List<TResult> result = new List<TResult>(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                TResult[] va = selector(source[i], i);
                for (int j = 0; j < va.Length; j++)
                {
                    result.Add(va[j]);
                }
            }
            return result.ToArray();
        }
    }
}
