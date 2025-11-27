using System;
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

        // --------------------------  ARRAYS  --------------------------------------------
        //
        // It has been found that by starting the sequence _always_ at zero, then the for loop is optimsed even more !
        //

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinF<T>(this T[] source)
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

            T r = source[0];
            if (default(T) == null)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    T item = source[i];
                    if ((item != null)
                        && ((r == null)
                            || (item.CompareTo(r) < 0)
                            )
                        )
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i].CompareTo(r) < 0)
                    {
                        r = source[i];
                    }
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
        public static TResult MinF<T, TResult>(this T[] source, Func<T, TResult> selector)
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
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            TResult r = selector(source[0]);
            if (default(T) == null)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    TResult item = selector(source[i]);
                    if ((item != null)
                        && ((r == null)
                            || (item.CompareTo(r) < 0)
                        )
                    )
                    {
                        r = item;
                    }
                }
            }
            else
            {
                for (int i = 0; i < source.Length; i++)
                {
                    TResult v = selector(source[i]);
                    if (v.CompareTo(r) < 0)
                    {
                        r = v;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        /// <remarks>
        /// This is faster than the templated functions above.
        /// Probably because the comparator function os only run once and there is not stack invloved
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinF(this int[] source)
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
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
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
        /// <remarks>
        /// This is faster than the templated functions above.
        /// Probably because the comparator function os only run once and there is not stack invloved
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinF<T>(this T[] source, Func<T, int> selector)
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
            for (int i = 0; i < source.Length; i++)
            {
                int v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        /// <remarks>
        /// This is faster than the templated functions above.
        /// Probably because the comparator function os only run once and there is not stack invloved
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MinF(this long[] source)
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
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
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
        /// <remarks>
        /// This is faster than the templated functions above.
        /// Probably because the comparator function os only run once and there is not stack invloved
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long MinF<T>(this T[] source, Func<T, long> selector)
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
            for (int i = 0; i < source.Length; i++)
            {
                long v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the Minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Minimum of.</param>
        /// <returns>The Minimum value in the sequence</returns>
        /// <remarks>
        /// Special case to deal with NAN's
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinF(this float[] source)
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
        /// <remarks>
        /// Special case to deal with NAN's
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinF<T>(this T[] source, Func<T, float> selector)
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
        /// <remarks>
        /// Special case to deal with NAN's
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinF(this double[] source)
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
        /// <remarks>
        /// Special case to deal with NAN's
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinF<T>(this T[] source, Func<T, double> selector)
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
                if (double.IsNaN(v)) continue;
                r = v;
                break;
            }
            for (int i = startIndex; i < source.Length; i++)
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
        public static decimal MinF(this decimal[] source)
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
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
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
        public static decimal MinF<T>(this T[] source, Func<T, decimal> selector)
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
            for (int i = 0; i < source.Length; i++)
            {
                decimal v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }


    }
}
