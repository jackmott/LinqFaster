using System;
using System.Globalization;
using System.Runtime.CompilerServices;

using JM.LinqFaster.Utils;
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable MemberCanBePrivate.Global

namespace JM.LinqFasterSpan
{
    public static partial class LinqFasterSpan
    {
        /*
         * Since Span is actually a struct and it does not inherit from IEnumerable,
         * we can’t use LINQ against it.
         * This is a big minus when compared to C# collections.
         */

        #region Normal Span<T>
        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this Span<byte> source, Func<byte, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, byte, uint>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this Span<sbyte> source, Func<sbyte, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, sbyte, int>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this Span<ushort> source, Func<ushort, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, ushort, uint>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this Span<short> source, Func<short, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, short, int>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this Span<uint> source, Func<uint, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this Span<int> source, Func<int, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong WhereSumF(this Span<ulong> source, Func<ulong, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long WhereSumF(this Span<long> source, Func<long, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float WhereSumF(this Span<float> source, Func<float, bool> predicate)
        {
            return (float)NumericPolicies.Instance.WhereSumF<NumericPolicies, float, double>(source, predicate);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        /// <remarks>
        /// Special case for floats, as IEnumerable does the sums on doubles before returning the type.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 WhereSumF<T2>(this Span<float> source, Func<float, bool> predicate, Func<float, T2> selector)
            where T2 : struct, IConvertible // Make sure these are not nullable
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            INumericPolicy<double> p = NumericPolicies.Instance;
            double a = 0;
            checked
            {
                foreach (float b in source)
                {
                    if (predicate(b))
                    {
                        a = p.Add(a, selector(b).ToDouble(CultureInfo.InvariantCulture));
                    }
                }
            }

            return (T2)Convert.ChangeType(a, typeof(T2));
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WhereSumF(this Span<double> source, Func<double, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal WhereSumF(this Span<decimal> source, Func<decimal, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 WhereSumF<T, T2>(this Span<T> source, Func<T, bool> predicate, Func<T, T2> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            T2 a = default(T2);
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = GenericOperators.Add(a, selector(source[index]));
                    }
                }
            }

            return a;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 WhereSumF<P, T1, T2>(this P p, Span<T1> source, Func<T1, bool> predicate)
            where P : INumericPolicy<T1, T2>
            where T1 : IConvertible
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T2 a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = p.Add(a, source[index]);
                    }
                }
            }

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T WhereSumF<P, T>(this P p, Span<T> source, Func<T, bool> predicate)
            where P : INumericPolicy<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = p.Add(a, source[index]);
                    }
                }
            }

            return a;
        }
        #endregion Normal Span<T>

        #region ReadOnlySpan<T>
        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this ReadOnlySpan<byte> source, Func<byte, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, byte, uint>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this ReadOnlySpan<sbyte> source, Func<sbyte, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, sbyte, int>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this ReadOnlySpan<ushort> source, Func<ushort, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, ushort, uint>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this ReadOnlySpan<short> source, Func<short, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF<NumericPolicies, short, int>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this ReadOnlySpan<uint> source, Func<uint, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this ReadOnlySpan<int> source, Func<int, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong WhereSumF(this ReadOnlySpan<ulong> source, Func<ulong, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long WhereSumF(this ReadOnlySpan<long> source, Func<long, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float WhereSumF(this ReadOnlySpan<float> source, Func<float, bool> predicate)
        {
            return (float)NumericPolicies.Instance.WhereSumF<NumericPolicies, float, double>(source, predicate);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        /// <remarks>
        /// Special case for floats, as IEnumerable does the sums on doubles before returning the type.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 WhereSumF<T2>(this ReadOnlySpan<float> source, Func<float, bool> predicate, Func<float, T2> selector)
            where T2 : struct, IConvertible // Make sure these are not nullable
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            INumericPolicy<double> p = NumericPolicies.Instance;
            double a = 0;
            checked
            {
                foreach (float b in source)
                {
                    if (predicate(b))
                    {
                        a = p.Add(a, selector(b).ToDouble(CultureInfo.InvariantCulture));
                    }
                }
            }

            return (T2)Convert.ChangeType(a, typeof(T2));
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WhereSumF(this ReadOnlySpan<double> source, Func<double, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal WhereSumF(this ReadOnlySpan<decimal> source, Func<decimal, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumF(source, predicate);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 WhereSumF<T, T2>(this ReadOnlySpan<T> source, Func<T, bool> predicate, Func<T, T2> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            T2 a = default(T2);
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = GenericOperators.Add(a, selector(source[index]));
                    }
                }
            }

            return a;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 WhereSumF<P, T1, T2>(this P p, ReadOnlySpan<T1> source, Func<T1, bool> predicate)
            where P : INumericPolicy<T1, T2>
            where T1 : IConvertible
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T2 a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = p.Add(a, source[index]);
                    }
                }
            }

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T WhereSumF<P, T>(this P p, ReadOnlySpan<T> source, Func<T, bool> predicate)
            where P : INumericPolicy<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = p.Add(a, source[index]);
                    }
                }
            }

            return a;
        }
        #endregion ReadOnlySpan<T>
    }
}
