using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable UnusedMember.Global
// ReSharper disable LoopCanBeConvertedToQuery

namespace JM.LinqFasterSpan
{
    // Common types optimised: int, long, float, double, decimal
    // Other types will be handled via the templates which are approx 2 time longer than 
    // the above optimised base types
    public static partial class LinqFasterSpan
    {
        // Note: although there is a lot of shared code in the following
        // comparers, we do not incorporate it into a base class for perf
        // reasons. Adding another base class (even one with no fields)
        // means another generic instantiation, which can be costly esp.
        // for value types.

        // --------------------------  this Spans  --------------------------------------------

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxF<T>(this Span<T> source)
            where T : IComparable<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = source[0];
            if (default(T) == null)
            {
                for (int i = 1; i < source.Length; i++)
                {
                    T item = source[i];
                    if (item != null
                        && item.CompareTo(r) > 0)
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 1; i < source.Length; i++)
                {
                    T item = source[i];
                    if (item.CompareTo(r) > 0)
                    {
                        r = item;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MaxF<T, TResult>(this Span<T> source, Func<T, TResult> selector)
            where TResult : IComparable<TResult>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            TResult r = selector(source[0]);
            if (default(TResult) == null)
            {
                for (int i = 1; i < source.Length; i++)
                {
                    TResult item = selector(source[i]);
                    if (item != null
                        && item.CompareTo(r) > 0)
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 1; i < source.Length; i++)
                {
                    TResult item = selector(source[i]);
                    if (item.CompareTo(r) > 0)
                    {
                        r = item;
                    }

                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MaxF(this Span<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            int r = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MaxF<T>(this Span<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int r = selector(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                int v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MaxF(this Span<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            long r = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }


        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MaxF<T>(this Span<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long r = selector(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                long v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MaxF(this Span<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            float r = source[0];
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (float.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MaxF<T>(this Span<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            float r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                float v = selector(source[startIndex]);
                if (float.IsNaN(v)) continue;
                r = v;
                break;
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                float v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MaxF(this Span<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            double r = source[0];
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (double.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MaxF<T>(this Span<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                double v = selector(source[startIndex]);
                if (!double.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                double v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }


        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MaxF(this Span<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            decimal r = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MaxF<T>(this Span<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            decimal r = selector(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                decimal v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }

        // --------------------------  ReadOnlySpans  --------------------------------------------

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxF<T>(this ReadOnlySpan<T> source)
            where T : IComparable<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = source[0];
            if (default(T) == null)
            {
                for (int i = 1; i < source.Length; i++)
                {
                    T item = source[i];
                    if (item != null
                        && item.CompareTo(r) > 0)
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 1; i < source.Length; i++)
                {
                    T item = source[i];
                    if (item.CompareTo(r) > 0)
                    {
                        r = item;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MaxF<T, TResult>(this ReadOnlySpan<T> source, Func<T, TResult> selector)
            where TResult : IComparable<TResult>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            TResult r = selector(source[0]);
            if (default(TResult) == null)
            {
                for (int i = 1; i < source.Length; i++)
                {
                    TResult item = selector(source[i]);
                    if (item != null
                        && item.CompareTo(r) > 0)
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 1; i < source.Length; i++)
                {
                    TResult item = selector(source[i]);
                    if (item.CompareTo(r) > 0)
                    {
                        r = item;
                    }

                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MaxF(this ReadOnlySpan<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            int r = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MaxF<T>(this ReadOnlySpan<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int r = selector(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                int v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MaxF(this ReadOnlySpan<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            long r = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }


        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MaxF<T>(this ReadOnlySpan<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long r = selector(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                long v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MaxF(this ReadOnlySpan<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            float r = source[0];
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (float.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MaxF<T>(this ReadOnlySpan<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            float r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                float v = selector(source[startIndex]);
                if (float.IsNaN(v)) continue;
                r = v;
                break;
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                float v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MaxF(this ReadOnlySpan<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            double r = source[0];
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (double.IsNaN(source[startIndex])) continue;
                r = source[startIndex];
                break;
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MaxF<T>(this ReadOnlySpan<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double r = selector(source[0]);
            int startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                double v = selector(source[startIndex]);
                if (!double.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (int i = startIndex; i < source.Length; i++)
            {
                double v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }


        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MaxF(this ReadOnlySpan<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            decimal r = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > r)
                    r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal MaxF<T>(this ReadOnlySpan<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            decimal r = selector(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                decimal v = selector(source[i]);
                if (v > r)
                    r = v;
            }
            return r;
        }


    }
}