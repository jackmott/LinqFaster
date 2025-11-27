using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using JM.LinqFaster.Utils;

// ReSharper disable UnusedMember.Global
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ConvertToCompoundAssignment
// ReSharper disable ForCanBeConvertedToForeach


namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this byte[] source, Func<byte, bool> predicate)
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
        public static int WhereSumF(this sbyte[] source, Func<sbyte, bool> predicate)
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
        public static uint WhereSumF(this ushort[] source, Func<ushort, bool> predicate)
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
        public static int WhereSumF(this short[] source, Func<short, bool> predicate)
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
        public static uint WhereSumF(this uint[] source, Func<uint, bool> predicate)
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
        public static int WhereSumF(this int[] source, Func<int, bool> predicate)
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
        public static ulong WhereSumF(this ulong[] source, Func<ulong, bool> predicate)
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
        public static long WhereSumF(this long[] source, Func<long, bool> predicate)
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
        public static float WhereSumF(this float[] source, Func<float, bool> predicate)
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
        public static T2 WhereSumF<T2>(this float[] source, Func<float, bool> predicate, Func<float, T2> selector)
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
        public static double WhereSumF(this double[] source, Func<double, bool> predicate)
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
        public static decimal WhereSumF(this decimal[] source, Func<decimal, bool> predicate)
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
        public static T2 WhereSumF<T, T2>(this T[] source, Func<T, bool> predicate, Func<T, T2> selector)
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
                foreach (T b in source)
                {
                    if (predicate(b))
                    {
                        a = GenericOperators.Add(a, selector(b));
                    }
                }
            }

            return a;
        }

        #region Nullable types

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? WhereSumF(this byte?[] source, Func<byte?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, byte, uint>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? WhereSumF(this sbyte?[] source, Func<sbyte?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, sbyte, int>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? WhereSumF(this ushort?[] source, Func<ushort?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, ushort, uint>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? WhereSumF(this short?[] source, Func<short?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, short, int>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? WhereSumF(this uint?[] source, Func<uint?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? WhereSumF(this int?[] source, Func<int?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong? WhereSumF(this ulong?[] source, Func<ulong?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long? WhereSumF(this long?[] source, Func<long?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float? WhereSumF(this float?[] source, Func<float?, bool> predicate)
        {
            return (float)NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, float, double>(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? WhereSumF(this double?[] source, Func<double?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable(source, predicate);
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal? WhereSumF(this decimal?[] source, Func<decimal?, bool> predicate)
        {
            return NumericPolicies.Instance.WhereSumFNullable(source, predicate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 WhereSumF<P, T1, T2>(this P p, T1[] source, Func<T1, bool> predicate)
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
                foreach (T1 b in source)
                {
                    if (predicate(b))
                    {
                        a = p.Add(a, b);
                    }
                }
            }

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T WhereSumF<P, T>(this P p, T[] source, Func<T, bool> predicate)
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
                foreach (T b in source)
                {
                    if (predicate(b))
                    {
                        a = p.Add(a, b);
                    }
                }
            }

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 WhereSumFNullable<P, T1, T2>(this P p, T1?[] source, Func<T1?, bool> predicate)
            where P : INullableNumericPolicy<T1, T2>
            where T1 : struct, IConvertible
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
                foreach (T1? b in source)
                {
                    if (predicate(b))
                    {
                        a = p.Add(a, b);
                    }
                }
            }

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T WhereSumFNullable<P, T>(this P p, T?[] source, Func<T?, bool> predicate)
            where P : INullableNumericPolicy<T>
            where T : struct
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
                foreach (T? b in source)
                {
                    if (predicate(b))
                    {
                        a = p.Add(a, b);
                    }
                }
            }

            return a;
        }

        #endregion Nullable types

    
    }
}
