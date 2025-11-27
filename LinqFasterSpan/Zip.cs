using System;
using System.Collections.Generic;

namespace JM.LinqFasterSpan
{
    public static partial class LinqFasterSpan
    {

        /// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="selector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>A sequence that contains merged elements of two input sequences.</returns>
        public static R[] ZipF<T, U, R>(this Span<T> first, Span<U> second, Func<T, U, R> selector)
        {
            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }
            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            //maintain array bounds elision
            if (first.Length < second.Length)
            {
                R[] result = new R[first.Length];
                for (int i = 0; i < first.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;

            }
            else
            {
                R[] result = new R[second.Length];
                for (int i = 0; i < second.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;
            }

        }
    }
}
