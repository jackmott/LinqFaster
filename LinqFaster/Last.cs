using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable UnusedMember.Global

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        // --------------------------  Arrays --------------------------------------------

        /// <summary>
        /// Returns the last element of a sequence.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>The value at the last position in the source sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastF<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            return source[source.Length - 1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">A sequence to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (int i = source.Length - 1; i >= 0; i--)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }
            throw Error.NoMatch();
        }

        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>default value if the source sequence is empty; otherwise, 
        /// the last element in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefaultF<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                return default(T);
            }
            return source[source.Length - 1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
        /// </summary>        
        /// <param name="source">A sequence to return the last element of.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>default value if the sequence is empty or if no elements pass the test 
        /// in the predicate function; otherwise, the last element that passes the test in the 
        /// predicate function.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefaultF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (int i = source.Length - 1; i >= 0; i--)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }
            return default(T);
        }



        /// <summary>
        /// Returns the first element of an Array / List / IReadOnlyList.
        /// </summary>        
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>The first element in the specified array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastF<T>(this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            return source[source.Count - 1];
        }

        /// <summary>
        /// Returns the first element in an array / List / IReadOnlyList that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">An IReadOnlyList to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The first element that satisfies the condition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastF<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case T[] sa:
                    return sa.LastF(predicate);
                default:
                    for (int i = source.Count - 1; i >= 0; i--)
                    {
                        if (predicate(source[i]))
                        {
                            return source[i];
                        }
                    }

                    break;
            }

            throw Error.NoMatch();
        }

        /// <summary>
        /// Returns the first element of an array, or a default value if the
        /// array contains no elements.
        /// </summary>             
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>default value if source is empty, otherwise, the first element
        /// in source.</returns>        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefaultF<T>(this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Count == 0)
            {
                return default(T);
            }
            return source[source.Count - 1];
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a 
        /// default value if no such element is found.
        /// </summary>        
        /// <param name="source">An IEnumerable to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T LastOrDefaultF<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case T[] sa:
                    return sa.LastOrDefaultF(predicate);
                default:
                    for (int i = source.Count - 1; i >= 0; i--)
                    {
                        if (predicate(source[i]))
                        {
                            return source[i];
                        }
                    }
                    break;
            }

            return default(T);
        }

        // --------------------------  Lists --------------------------------------------

        /// <summary>
        /// Returns the first element of a list
        /// </summary>        
        /// <param name="source">The list to return the first element of.</param>
        /// <returns>The first element in the specified list.</returns>   
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            return source[source.Count - 1];
        }

        /// <summary>
        /// Returns the first element in a list that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">An list to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The first element in the list that satisfies the condition.</returns>       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastF<T>(this List<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (int i = source.Count - 1; i >= 0; i--)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }

            throw Error.NoMatch();
        }

        /// <summary>
        /// Returns the first element of an array, or a default value if the
        /// array contains no elements.
        /// </summary>             
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>default value if source is empty, otherwise, the first element
        /// in source.</returns>      
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefaultF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Count == 0)
            {
                return default(T);
            }
            return source[source.Count - 1];
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a 
        /// default value if no such element is found.
        /// </summary>        
        /// <param name="source">An IEnumerable to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefaultF<T>(this List<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (int i = source.Count - 1; i >= 0; i--)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }
            return default(T);
        }

        
    }
}
