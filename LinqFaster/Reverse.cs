using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>        
        /// <param name="source">A sequence of values to reverse.</param>
        /// <returns>A sequence whose elements correspond to those of the input sequence in reverse order.</returns>
        public static T[] ReverseF<T>(this T[] source)
        {
            var result = new T[source.Length];
            long lenLessOne = source.Length - 1;
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
        public static void ReverseInPlaceF<T>(this T[] source)
        {
            Array.Reverse(source);
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>        
        /// <param name="source">A sequence of values to reverse.</param>
        /// <returns>A sequence whose elements correspond to those of the input sequence in reverse order.</returns>
        public static List<T> ReverseF<T>(this List<T> source)
        {
            var result = new List<T>(source.Count);
            for (int i = source.Count - 1; i >= 0; i--)
            {
                result.Add(source[i]);
            }
            return result;
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence in place.
        /// </summary>        
        /// <param name="source">A sequence of values to reverse.</param>        
        public static void ReverseInPlaceF<T>(this List<T> source)
        {
            source.Reverse();            
        }
    }
}
