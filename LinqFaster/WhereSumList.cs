using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

using JM.LinqFaster.Utils;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForCanBeConvertedToForeach


namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        // Note: Lists can have items added and removed whilst these API's are in use
        // The IReadOnlyList<T> represents a list in which the _number_ and _order_ of list elements is read-only.
        //

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this IReadOnlyList<byte> source, Func<byte, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case byte[] sa:
                    return sa.WhereSumF(predicate);
                case List<byte> sl:
                    return NumericPolicies.Instance.WhereSumF<NumericPolicies, byte, uint>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    uint sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this IReadOnlyList<sbyte> source, Func<sbyte, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case sbyte[] sa:
                    return sa.WhereSumF(predicate);
                case List<sbyte> sl:
                    return NumericPolicies.Instance.WhereSumF<NumericPolicies, sbyte, int>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    int sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this IReadOnlyList<ushort> source, Func<ushort, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case ushort[] sa:
                    return sa.WhereSumF(predicate);
                case List<ushort> sl:
                    return NumericPolicies.Instance.WhereSumF<NumericPolicies, ushort, uint>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    uint sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this IReadOnlyList<short> source, Func<short, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case short[] sa:
                    return sa.WhereSumF(predicate);
                case List<short> sl:
                    return NumericPolicies.Instance.WhereSumF<NumericPolicies, short, int>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    int sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WhereSumF(this IReadOnlyList<uint> source, Func<uint, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case uint[] sa:
                    return sa.WhereSumF(predicate);
                case List<uint> sl:
                    return NumericPolicies.Instance.WhereSumF(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    uint sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WhereSumF(this IReadOnlyList<int> source, Func<int, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case int[] sa:
                    return sa.WhereSumF(predicate);
                case List<int> sl:
                    return NumericPolicies.Instance.WhereSumF(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    int sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong WhereSumF(this IReadOnlyList<ulong> source, Func<ulong, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case ulong[] sa:
                    return sa.WhereSumF(predicate);
                case List<ulong> sl:
                    return NumericPolicies.Instance.WhereSumF(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    ulong sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long WhereSumF(this IReadOnlyList<long> source, Func<long, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case long[] sa:
                    return sa.WhereSumF(predicate);
                case List<long> sl:
                    return NumericPolicies.Instance.WhereSumF(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    long sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float WhereSumF(this IReadOnlyList<float> source, Func<float, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case float[] sa:
                    return sa.WhereSumF(predicate);
                case List<float> sl:
                    return (float)NumericPolicies.Instance.WhereSumF<NumericPolicies, float, double>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    double sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return (float)sum;
            }
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
        public static T2 WhereSumF<T2>(this List<float> source, Func<float, bool> predicate, Func<float, T2> selector)
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
        public static double WhereSumF(this IReadOnlyList<double> source, Func<double, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case double[] sa:
                    return sa.WhereSumF(predicate);
                case List<double> sl:
                    return NumericPolicies.Instance.WhereSumF(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    double sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal WhereSumF(this IReadOnlyList<decimal> source, Func<decimal, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case decimal[] sa:
                    return sa.WhereSumF(predicate);
                case List<decimal> sl:
                    return NumericPolicies.Instance.WhereSumF(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    decimal sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i];
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 WhereSumF<T, T2>(this List<T> source, Func<T, bool> predicate, Func<T, T2> selector)
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
                for (int index = 0; index < source.Count; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = GenericOperators.Add(a, selector(source[index]));
                    }
                }
            }

            return a;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T2 WhereSumF<T, T2>(this IReadOnlyList<T> source, Func<T, bool> predicate, Func<T, T2> selector)
        {
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case T[] sa:
                    return sa.WhereSumF(predicate, selector);
                case List<T> sl:
                    return sl.WhereSumF(predicate, selector);
                default:
                    {
                        if (predicate == null)
                        {
                            throw Error.ArgumentNull(nameof(predicate));
                        }
                        if (selector == null)
                        {
                            throw Error.ArgumentNull(nameof(selector));
                        }

                        int sourceCount = source.Count;
                        T2 a = default(T2);
                        checked
                        {
                            for (int index = 0; index < sourceCount; index++)
                            {
                                if (predicate(source[index]))
                                {
                                    a = GenericOperators.Add(a, selector(source[index]));
                                }
                            }
                        }

                        return a;
                    }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 WhereSumF<P, T1, T2>(this P p, List<T1> source, Func<T1, bool> predicate)
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
                for (int index = 0; index < source.Count; index++)
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
        private static T WhereSumF<P, T>(this P p, List<T> source, Func<T, bool> predicate)
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
                for (int index = 0; index < source.Count; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = p.Add(a, source[index]);
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
        public static uint? WhereSumF(this IReadOnlyList<byte?> source, Func<byte?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case byte?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<byte?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, byte, uint>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    uint sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? WhereSumF(this IReadOnlyList<sbyte?> source, Func<sbyte?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case sbyte?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<sbyte?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, sbyte, int>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    int sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? WhereSumF(this IReadOnlyList<ushort?> source, Func<ushort?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case ushort?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<ushort?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, ushort, uint>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    uint sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? WhereSumF(this IReadOnlyList<short?> source, Func<short?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case short?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<short?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, short, int>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    int sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? WhereSumF(this IReadOnlyList<uint?> source, Func<uint?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case uint?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<uint?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    uint sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? WhereSumF(this IReadOnlyList<int?> source, Func<int?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case int?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<int?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    int sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong? WhereSumF(this IReadOnlyList<ulong?> source, Func<ulong?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case ulong?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<ulong?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    ulong sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long? WhereSumF(this IReadOnlyList<long?> source, Func<long?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case long?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<long?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    long sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float? WhereSumF(this IReadOnlyList<float?> source, Func<float?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case float?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<float?> sl:
                    return (float?)NumericPolicies.Instance.WhereSumFNullable<NumericPolicies, float, double>(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    double sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return (float?)sum;
            }
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
        public static T2 WhereSumF<T2>(this List<float?> source, Func<float?, bool> predicate, Func<float?, T2> selector)
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
                for (int index = 0; index < source.Count; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = p.Add(a, selector(source[index]).ToDouble(CultureInfo.InvariantCulture));
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
        public static double? WhereSumF(this IReadOnlyList<double?> source, Func<double?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case double?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<double?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    double sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal? WhereSumF(this IReadOnlyList<decimal?> source, Func<decimal?, bool> predicate)
        {
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case decimal?[] sa:
                    return WhereSumF(sa, predicate); // Do this to prevent compiler causing recursion in to this same function
                case List<decimal?> sl:
                    return NumericPolicies.Instance.WhereSumFNullable(sl, predicate);
                default:
                    int sourceCount = source.Count;
                    decimal sum = 0;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        if (predicate(source[i]))
                        {
                            sum = sum + source[i] ?? 0;
                        }
                    }
                    return sum;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T2 WhereSumFNullable<P, T, T2>(this P p, List<T?> source, Func<T?, bool> predicate)
            where P : INullableNumericPolicy<T, T2>
            where T : struct, IConvertible
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
                for (int index = 0; index < source.Count; index++)
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
        private static T WhereSumFNullable<P, T>(this P p, List<T?> source, Func<T?, bool> predicate)
            where P : INullableNumericPolicy<T>
            where T : struct, IConvertible
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
                for (int index = 0; index < source.Count; index++)
                {
                    if (predicate(source[index]))
                    {
                        a = p.Add(a, source[index]);
                    }
                }
            }

            return a;
        }

        #endregion Nullable Types
    }
}
