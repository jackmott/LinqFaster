using System;
using System.Collections.Generic;

namespace JM.LinqFasterSpan
{
    public static partial class LinqFasterSpan
    {
        

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>        
        /// <param name="source">A sequence of values to reverse.</param>
        /// <returns>A sequence whose elements correspond to those of the input sequence in reverse order.</returns>
        public static T[] ReverseF<T>(this Span<T> source)
        {
            T[] result = new T[source.Length];
            int lenLessOne = source.Length - 1;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = source[lenLessOne - i];
            }
            return result;
        }
        /// <summary>
        /// Inverts the order of the elements in a sequence in place.
        /// </summary>        
        /// <param name="source">A sequence of values to reverse.</param>        
        public static void ReverseInPlaceF<T>(this Span<T> source)
        {
            source.Reverse();
        }

    }
}
