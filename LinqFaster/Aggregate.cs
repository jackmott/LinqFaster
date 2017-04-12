using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    /// <summary>
    /// Provides faster array and list specific extension methods with
    /// the same semantics as the Linq extensions methods.
    /// </summary>
    public static partial class LinqFaster
    {

        // ------------------------------ Arrays --------------------------

        /// <summary>
        /// Applies an accumulator function over an array.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TSource AggregateF<TSource>(this TSource[] source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            TSource result = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over an array. The specified seed
        /// value is used as the initial accumulator value.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TAccumulate AggregateF<TSource, TAccumulate>(this TSource[] source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            TAccumulate result = seed;
            foreach (var v in source)
            {
                result = func(result, v);
            }
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over an array. The specified seed
        /// value is used as the initial accumulator value, and the specified 
        /// function is used to select the result value.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
        /// <returns>The transformed final accumulator value</returns>
        public static TResult AggregateF<TSource, TAccumulate, TResult>(this TSource[] source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
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
            foreach (var v in source)
            {
                result = func(result, v);
            }
            return resultSelector(result);
        }

        // ------------------------------ Lists --------------------------

        /// <summary>
        /// Applies an accumulator function over a List.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">A List to aggregate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TSource AggregateF<TSource>(this List<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
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
            for (int i = 1; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over a List. The specified seed
        /// value is used as the initial accumulator value.
        /// </summary>        
        /// <param name="source">A List to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TAccumulate AggregateF<TSource, TAccumulate>(this List<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            TAccumulate result = seed;
            for (int i = 0; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over a List. The specified seed
        /// value is used as the initial accumulator value, and the specified 
        /// function is used to select the result value.
        /// </summary>        
        /// <param name="source">A List to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
        /// <returns>The transformed final accumulator value</returns>
        public static TResult AggregateF<TSource, TAccumulate, TResult>(this List<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
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
            for (int i = 0; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return resultSelector(result);
        }

    }
}