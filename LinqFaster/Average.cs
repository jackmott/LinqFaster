using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF(this int[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF<T>(this T[] source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF(this long[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Length;
        }


        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF<T>(this T[] source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageF(this float[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageF<T>(this T[] source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            double sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF(this double[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF<T>(this T[] source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            double sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageF(this decimal[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            decimal sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageF<T>(this T[] source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }


            decimal sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Length;
        }

        // --------------------------  Lists  --------------------------------------------

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name="source">The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static double AverageF(this List<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Count; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF<T>(this List<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Count; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name="source">The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static double AverageF(this List<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Count; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF<T>(this List<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < source.Count; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name="source">The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static float AverageF(this List<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return (float)(sum / source.Count);
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageF<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            double sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return (float)(sum / source.Count);
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name="source">The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static double AverageF(this List<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageF<T>(this List<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            double sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name="source">The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static decimal AverageF(this List<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            decimal sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageF<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }


            decimal sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Count;
        }
    }
}
