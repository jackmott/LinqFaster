using System;
using System.Collections.Generic;

namespace JM.LinqFasterSpan
{
   
    public static partial class LinqFasterSpan
    {
        
        /*------------- SPans ---------------- */

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>        
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
        /// <returns>A sequence that contains the elements that occur after the specified index in the input sequence.</returns>
        public static T[] SkipF<T>(this Span<T> source, int count)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > source.Length)
            {
                return new T[0];
            }

            T[] result = new T[source.Length - count];
            for (int i = count; i < source.Length; i++)
            {
                result[i - count] = source[i];
            }            
            return result;
        }

        /// <summary>
        ///  Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
        /// </summary>
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains the elements from the input sequence starting at the first element in the linear series that does not pass the test specified by predicate.</returns>
        public static T[] SkipWhileF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            int count = 0;
            for (; count < source.Length; count++)
            {
                if (!predicate(source[count])) break;
            }
            T[] result = new T[source.Length - count];
            for (int i = count; i < source.Length; i++)
            {
                result[i - count] = source[i];
            }
            return result;
        }

    }
}
