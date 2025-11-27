using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable UnusedMember.Global
// ReSharper disable LoopCanBeConvertedToQuery

namespace JM.LinqFaster
{
    // Common types optimised: int, long, float, double, decimal
    // Other types will be handled via the templates which are approx 2 time longer than 
    // the above optimised base types
    public static partial class LinqFaster
    {
        // Note: although there is a lot of shared code in the following
        // comparers, we do not incorporate it into a base class for perf
        // reasons. Adding another base class (even one with no fields)
        // means another generic instantiation, which can be costly esp.
        // for value types.

        // Note: Lists can have items added and removed whilst these API's are in use
        // The IReadOnlyList<T> represents a list in which the _number_ and _order_ of list elements is read-only.
        //

        // --------------------------  LISTS  --------------------------------------------

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinF<T>(this List<T> source)
            where T : IComparable<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            T r = source[0];
            if (default(T) == null)
            {
                for (int i = 1; i < source.Count; i++)
                {
                    T item = source[i];
                    if (item != null
                        && item.CompareTo(r) < 0)
                        r = item;
                }
            }
            else
            {
                for (int i = 1; i < source.Count; i++)
                {
                    T item = source[i];
                    if (item.CompareTo(r) < 0)
                        r = item;
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MinF<T, TResult>(this List<T> source, Func<T, TResult> selector)
            where TResult : IComparable<TResult>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            TResult r = selector(source[0]);
            if (default(TResult) == null)
            {
                for (int i = 1; i < source.Count; i++)
                {
                    TResult item = selector(source[i]);
                    if (item != null
                        && item.CompareTo(r) < 0)
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 1; i < source.Count; i++)
                {
                    TResult item = selector(source[i]);
                    if (item.CompareTo(r) < 0)
                        r = item;
                }
            }
            return r;
        }


        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinF(this List<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            int r = source[0];
            for (int i = 1; i < source.Count; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinF<T>(this List<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int r = selector(source[0]);
            for (int i = 1; i < source.Count; i++)
            {
                int v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MinF(this List<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            long r = source[0];
            for (int i = 1; i < source.Count; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MinF<T>(this List<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            long r = selector(source[0]);
            for (int i = 1; i < source.Count; i++)
            {
                long v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinF(this List<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            float r = source[0];
            int startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                if (float.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < source.Count; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinF<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            float r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                float v = selector(source[startIndex]);
                if (float.IsNaN(v)) continue;
                r = v;
                break;
            }
            for (int i = startIndex; i < source.Count; i++)
            {
                float v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinF(this List<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            double r = source[0];
            int startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                if (double.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < source.Count; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinF<T>(this List<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            double r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                double v = selector(source[startIndex]);
                if (double.IsNaN(v)) continue;
                r = v;
                break;
            }
            for (int i = startIndex; i < source.Count; i++)
            {
                double v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MinF(this List<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal r = source[0];
            for (int i = 1; i < source.Count; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MinF<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal r = selector(source[0]);
            for (int i = 1; i < source.Count; i++)
            {
                decimal v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        // --------------------------  IReadOnlyList  --------------------------------------------

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinF<T>(this IReadOnlyList<T> source)
            where T : IComparable<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }

            T r = source[0];
            if (default(T) == null)
            {
                for (int i = 1; i < sourceCount; i++)
                {
                    T item = source[i];
                    if (item != null
                        && item.CompareTo(r) > 0)
                        r = item;
                }
            }
            else
            {
                for (int i = 1; i < sourceCount; i++)
                {
                    T item = source[i];
                    if (item.CompareTo(r) < 0)
                        r = item;
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MinF<T, TResult>(this IReadOnlyList<T> source, Func<T, TResult> selector)
            where TResult : IComparable<TResult>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }

            TResult r = selector(source[0]);
            if (default(TResult) == null)
            {
                for (int i = 1; i < sourceCount; i++)
                {
                    TResult item = selector(source[i]);
                    if (item != null
                        && item.CompareTo(r) < 0)
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 1; i < sourceCount; i++)
                {
                    TResult item = selector(source[i]);
                    if (item.CompareTo(r) < 0)
                        r = item;
                }
            }
            return r;
        }


        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinF(this IReadOnlyList<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            int r = source[0];
            for (int i = 1; i < sourceCount; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinF<T>(this IReadOnlyList<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int r = selector(source[0]);
            for (int i = 1; i < sourceCount; i++)
            {
                int v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MinF(this IReadOnlyList<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            long r = source[0];
            for (int i = 1; i < sourceCount; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MinF<T>(this IReadOnlyList<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            long r = selector(source[0]);
            for (int i = 1; i < sourceCount; i++)
            {
                long v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinF(this IReadOnlyList<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            float r = source[0];
            int startIndex = 0;
            for (; startIndex < sourceCount; startIndex++)
            {
                if (float.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < sourceCount; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinF<T>(this IReadOnlyList<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            float r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < sourceCount; startIndex++)
            {
                float v = selector(source[startIndex]);
                if (float.IsNaN(v)) continue;
                r = v;
                break;
            }
            for (int i = startIndex; i < sourceCount; i++)
            {
                float v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinF(this IReadOnlyList<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            double r = source[0];
            int startIndex = 0;
            for (; startIndex < sourceCount; startIndex++)
            {
                if (double.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < sourceCount; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinF<T>(this IReadOnlyList<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            double r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < sourceCount; startIndex++)
            {
                double v = selector(source[startIndex]);
                if (double.IsNaN(v)) continue;
                r = v;
                break;
            }
            for (int i = startIndex; i < sourceCount; i++)
            {
                double v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MinF(this IReadOnlyList<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            decimal r = source[0];
            for (int i = 1; i < sourceCount; i++)
            {
                if (source[i] < r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the Minimum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Minimum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MinF<T>(this IReadOnlyList<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int sourceCount = source.Count;
            if (sourceCount == 0)
            {
                throw Error.NoElements();
            }
            decimal r = selector(source[0]);
            for (int i = 1; i < sourceCount; i++)
            {
                decimal v = selector(source[i]);
                if (v < r)
                    r = v;
            }
            return r;
        }


    }
}
