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
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SumF(this Span<byte> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, byte, uint>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumF(this Span<sbyte> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, sbyte, int>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SumF(this Span<ushort> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, ushort, uint>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumF(this Span<short> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, short, int>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SumF(this Span<uint> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumF(this Span<int> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SumF(this Span<ulong> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long SumF(this Span<long> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SumF(this Span<float> source)
        {
            return (float)NumericPolicies.Instance.SumF<NumericPolicies, float, double>(source);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        /// <remarks>
        /// Special case for floats, as IEnumerable does the sums on doubles before returning the type.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 SumF<T2>(this Span<float> source, Func<float, T2> selector)
            where T2 : struct, IConvertible // Make sure these are not nullable
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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
                    a = p.Add(a, selector(b).ToDouble(CultureInfo.InvariantCulture));
                }
            }

            return (T2)Convert.ChangeType(a, typeof(T2));
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SumF(this Span<double> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal SumF(this Span<decimal> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 SumF<T, T2>(this Span<T> source, Func<T, T2> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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
                    a = GenericOperators.Add(a, selector(source[index]));
                }
            }

            return a;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 SumF<P, T1, T2>(this P p, Span<T1> source)
            where P : INumericPolicy<T1, T2>
            where T1 : IConvertible
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            T2 a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    a = p.Add(a, source[index]);
                }
            }

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T SumF<P, T>(this P p, Span<T> source)
            where P : INumericPolicy<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            T a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    a = p.Add(a, source[index]);
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
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SumF(this ReadOnlySpan<byte> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, byte, uint>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumF(this ReadOnlySpan<sbyte> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, sbyte, int>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SumF(this ReadOnlySpan<ushort> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, ushort, uint>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumF(this ReadOnlySpan<short> source)
        {
            return NumericPolicies.Instance.SumF<NumericPolicies, short, int>(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SumF(this ReadOnlySpan<uint> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumF(this ReadOnlySpan<int> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SumF(this ReadOnlySpan<ulong> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long SumF(this ReadOnlySpan<long> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SumF(this ReadOnlySpan<float> source)
        {
            return (float)NumericPolicies.Instance.SumF<NumericPolicies, float, double>(source);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        /// <remarks>
        /// Special case for floats, as IEnumerable does the sums on doubles before returning the type.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 SumF<T2>(this ReadOnlySpan<float> source, Func<float, T2> selector)
            where T2 : struct, IConvertible // Make sure these are not nullable
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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
                    a = p.Add(a, selector(b).ToDouble(CultureInfo.InvariantCulture));
                }
            }

            return (T2)Convert.ChangeType(a, typeof(T2));
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SumF(this ReadOnlySpan<double> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal SumF(this ReadOnlySpan<decimal> source)
        {
            return NumericPolicies.Instance.SumF(source);
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 SumF<T, T2>(this ReadOnlySpan<T> source, Func<T, T2> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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
                    a = GenericOperators.Add(a, selector(source[index]));
                }
            }

            return a;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 SumF<P, T1, T2>(this P p, ReadOnlySpan<T1> source)
            where P : INumericPolicy<T1, T2>
            where T1 : IConvertible
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            T2 a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    a = p.Add(a, source[index]);
                }
            }

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T SumF<P, T>(this P p, ReadOnlySpan<T> source)
            where P : INumericPolicy<T>
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            T a = p.Zero();
            checked
            {
                for (int index = 0; index < source.Length; index++)
                {
                    a = p.Add(a, source[index]);
                }
            }

            return a;
        }
        #endregion ReadOnlySpan<T>
    }
}
