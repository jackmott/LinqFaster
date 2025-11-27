using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable UnusedMember.Global

namespace JM.LinqFaster
{
    /// <summary>
    /// Provides faster array and list specific extension methods with
    /// the same semantics as the Linq extensions methods.
    /// </summary>
    public static partial class LinqFaster
    {
        // Note: Lists can have items added and removed whilst these API's are in use
        // The IReadOnlyList<T> represents a list in which the _number_ and _order_ of list elements is read-only.
        //

        /// <summary>
        /// Applies an accumulator function over an array[T] / List{T} / or IReadOnlyList{T}.
        /// </summary>        
        /// <param name="source">An IReadOnlyList to aggregate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource AggregateF<TSource>(this IReadOnlyList<TSource> source, 
            Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            TSource result = source[0];
            switch (source)
            {
                case TSource[] sa:
                    for (int i = 1; i < sa.Length; i++)
                    {
                        result = func(result, sa[i]);
                    }
                    break;
                case List<TSource> sl:
                    for (int i = 1; i < sl.Count; i++)
                    {
                        result = func(result, sl[i]);
                    }
                    break;
                default:
                    for (int i = 1; i < source.Count; i++)
                    {
                        result = func(result, source[i]);
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// The specified seed value is used as the initial accumulator value.
        /// Applies an accumulator function over an array[T] / List{T} / or IReadOnlyList{T}.
        /// </summary>        
        /// <param name="source">An IReadOnlyList to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAccumulate AggregateF<TSource, TAccumulate>(this IReadOnlyList<TSource> source, TAccumulate seed, 
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            TAccumulate result = seed;
            switch (source)
            {
                case TSource[] sa:
                    for (int i = 0; i < sa.Length; i++)
                    {
                        result = func(result, sa[i]);
                    }
                    break;
                case List<TSource> sl:
                    for (int i = 0; i < sl.Count; i++)
                    {
                        result = func(result, sl[i]);
                    }
                    break;
                default:
                    for (int i = 0; i < source.Count; i++)
                    {
                        result = func(result, source[i]);
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// The specified seed value is used as the initial accumulator value,
        /// and the specified function is used to select the result value.
        /// Applies an accumulator function over an array[T] / List{T} / or IReadOnlyList{T}.
        /// </summary>        
        /// <param name="source">An IReadOnlyList to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
        /// <returns>The transformed final accumulator value</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult AggregateF<TSource, TAccumulate, TResult>(this IReadOnlyList<TSource> source, TAccumulate seed, 
            Func<TAccumulate, TSource, TAccumulate> func, 
            Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (resultSelector == null)
            {
                throw Error.ArgumentNull("resultSelector");
            }

            TAccumulate result = seed;
            switch (source)
            {
                case TSource[] sa:
                    for (int i = 0; i < sa.Length; i++)
                    {
                        result = func(result, sa[i]);
                    }
                    break;
                case List<TSource> sl:
                    for (int i = 0; i < sl.Count; i++)
                    {
                        result = func(result, sl[i]);
                    }
                    break;
                default:
                    for (int i = 0; i < source.Count; i++)
                    {
                        result = func(result, source[i]);
                    }
                    break;
            }

            return resultSelector(result);
        }

    }
}