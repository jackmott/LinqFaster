using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using JM.LinqFaster.Utils;

// ReSharper disable UnusedMember.Global
// ReSharper disable PossibleInvalidOperationException

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        /// <remarks>
        /// Special case for floats to be equivalent to IEnumerable !
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AverageF<T>(this IReadOnlyList<T> source, Func<T, float> selector)
        {
            if (source.Count == 0)
            {
                return 0;
            }

            return source.SumF(selector) / source.Count;
        }
        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF<T, T2>(this IReadOnlyList<T> source, Func<T, T2> selector)
            where T2 : IConvertible
        {
            if (source.Count == 0)
            {
                return 0;
            }

            return source.SumF(selector).ToDouble(CultureInfo.InvariantCulture) / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<byte> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<sbyte> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<ushort> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<short> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<uint> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<int> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<ulong> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<long> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return (double)source.SumF() / source.Count;
        }


        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AverageF(this IReadOnlyList<float> source)
        {
            // Have to get at the double directly, because the aggressive inlining sometimes makes a bollox answer
            // Failed : Tests.AverageTests.AverageArrayFloat
            // Expected: 0.905460358f
            // But was:  0.905460417f
            // at Tests.AverageTests.AverageArrayFloat() in C:\projects\linqfaster\Tests\AverageTests.cs:line 41
            double sum = 0D;
            switch (source)
            {
                case null:
                    throw Error.ArgumentNull(nameof(source));
                case float[] sa:
                    sum = NumericPolicies.Instance.SumF<NumericPolicies, float, double>(sa);
                    break;
                case List<float> sl:
                    sum = NumericPolicies.Instance.SumF<NumericPolicies, float, double>(sl);
                    break;
                default:
                    int sourceCount = source.Count;
                    for (int i = 0; i < sourceCount; i++)
                    {
                        sum = sum + source[i];
                    }
                    break;
            }
            return (float)(sum / source.Count);
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AverageF(this IReadOnlyList<double> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal AverageF(this IReadOnlyList<decimal> source)
        {
            if (source.Count == 0)
            {
                return 0;
            }
            return source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal AverageF<T>(this IReadOnlyList<T> source, Func<T, decimal> selector)
        {
            if (source.Count == 0)
            {
                return 0;
            }

            return source.SumF(selector) / source.Count;
        }

        #region Nullable types
        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<byte?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<sbyte?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<ushort?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<short?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<uint?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<int?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<ulong?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<long?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }


        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<float?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return (double)source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double? AverageF(this IReadOnlyList<double?> source)
        {
            if (source.Count == 0)
            {
                return new double?();
            }
            return source.SumF() / source.Count;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal? AverageF(this IReadOnlyList<decimal?> source)
        {
            if (source.Count == 0)
            {
                return new decimal?();
            }
            return source.SumF() / source.Count;
        }
        #endregion Nullable Types
    }
}
