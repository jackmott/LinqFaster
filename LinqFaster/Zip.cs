using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        /// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="selector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>A sequence that contains merged elements of two input sequences.</returns>
        public static R[] ZipF<T, U, R>(this T[] first, U[] second, Func<T, U, R> selector)
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
                throw Error.ArgumentNull("selector");
            }

            //maintain array bounds elision
            if (first.Length < second.Length)
            {
                var result = new R[first.Length];
                for (int i = 0; i < first.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;

            }
            else
            {
                var result = new R[second.Length];
                for (int i = 0; i < second.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;
            }

        }

        /// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="selector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>A sequence that contains merged elements of two input sequences.</returns>
        public static List<R> ZipF<T, U, R>(this List<T> first, List<U> second, Func<T, U, R> selector)
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
                throw Error.ArgumentNull("selector");
            }

            //maintain array bounds elision
            if (first.Count < second.Count)
            {
                var result = new List<R>(first.Count);
                for (int i = 0; i < first.Count; i++)
                {
                    result.Add(selector(first[i], second[i]));
                }
                return result;

            }
            else
            {
                var result = new List<R>(second.Count);
                for (int i = 0; i < second.Count; i++)
                {
                    result.Add(selector(first[i], second[i]));
                }
                return result;
            }

        }
    }
}
