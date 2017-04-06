using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>A sequence that contains the specified number of elements from the start of the input sequence.</returns>
        public static T[] TakeF<T>(this T[] source, int count)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > source.Length)
            {
                count = source.Length;
            }

            var result = new T[count];
            Array.Copy(source, 0, result, 0, count);
            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>        
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains the elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static T[] TakeWhileF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = new List<T>();
            for (int i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                    result.Add(source[i]);
                else
                    return result.ToArray();
            }
            return result.ToArray();
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence that contains elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static T[] TakeWhileF<T>(this T[] source, Func<T,int, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = new List<T>();
            for (int i = 0; i < source.Length; i++)
            {
                if (predicate(source[i],i))
                    result.Add(source[i]);
                else
                    return result.ToArray();
            }
            return result.ToArray();
        }



        // ------------- Lists ----------------

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>A sequence that contains the specified number of elements from the start of the input sequence.</returns>
        public static List<T> TakeF<T>(this List<T> source, int count)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > source.Count)
            {
                count = source.Count;
            }

            var result = new List<T>(count);
            for (int i = 0; i < count; i++)
            {
                result.Add(source[i]);
            }
            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>        
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains the elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static List<T> TakeWhileF<T>(this List<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = new List<T>();
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    result.Add(source[i]);
                }
                else
                {
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence that contains elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static List<T> TakeWhileF<T>(this List<T> source, Func<T, int, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = new List<T>();
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i], i))
                    result.Add(source[i]);
                else
                    return result;
            }
            return result;
        }



    }
}
