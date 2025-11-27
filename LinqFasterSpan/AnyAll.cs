using System;
using System.Runtime.CompilerServices;

namespace JM.LinqFasterSpan
{
    public static partial class LinqFasterSpan
    {

        
        // --------------------------  this SpanS --------------------------------------------

        /// <summary>
        /// Determines whether an array contains any elements
        /// </summary>        
        /// <param name="source">The array to check for emptiness</param>
        /// <returns>true if the source array contains any elements, otherwise, false/</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            return source.Length > 0;
        }



        /// <summary>
        /// Determines whether any element of an array satisfies a condition.
        /// </summary>        
        /// <param name="source">An array whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if any elements in the source array pass the test in the specified predicate; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyF<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (predicate(source[i])) return true;
            }
            return false;
        }


        /// <summary>
        /// Determines whether all elements of an array satisfy a condition.
        /// </summary>        
        /// <param name="source">An array that contains the elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if every element of the source array passes the test in the specified
        /// predicate, or if the array is empty; otherwise, false</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllF<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (!predicate(source[i])) return false;
            }
            return true;
        }


    }
}