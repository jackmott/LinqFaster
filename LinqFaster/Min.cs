using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    //int, long, float,double, decimal
    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinF<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                r = source[0];
                for (int i = 1; i < source.Length; i++)
                {
                    if (source[i] != null && comparer.Compare(source[i], r) < 0) r = source[i];
                }
            }
            else
            {
                r = source[0];
                for (int i = 1; i < source.Length; i++)
                {
                    if (comparer.Compare(source[i], r) < 0) r = source[i];
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
        public static TResult MinF<T, TResult>(this T[] source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult r = default(TResult);
            if (r == null)
            {
                r = selector(source[0]);
                for (int i = 1; i < source.Length; i++)
                {
                    var v = selector(source[i]);
                    if (v != null && comparer.Compare(v, r) < 0) r = v;
                }
            }
            else
            {
                r = selector(source[0]);
                for (int i = 1; i < source.Length; i++)
                {
                    var v = selector(source[i]);
                    if (comparer.Compare(v, r) < 0) r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinF(this int[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            int r = int.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r) r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static int MinF<T>(this T[] source, Func<T, int> selector)
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

            int r = int.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinF(this long[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            long r = long.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r) r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static long MinF<T>(this T[] source, Func<T, long> selector)
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

            long r = long.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinF(this float[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            float r = float.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r) r = source[i];
                else if (float.IsNaN(source[i])) return source[i];

            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static float MinF<T>(this T[] source, Func<T, float> selector)
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
            float r = float.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
                else if (float.IsNaN(v)) return v;

            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinF(this double[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            double r = double.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r) r = source[i];
                else if (double.IsNaN(source[i])) return source[i];
            }

            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static double MinF<T>(this T[] source, Func<T, double> selector)
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
            double r = double.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
                else if (double.IsNaN(v)) return v;

            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinF(this decimal[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            decimal r = decimal.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < r) r = source[i];
            }
            return r;
        }
        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static decimal MinF<T>(this T[] source, Func<T, decimal> selector)
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
            decimal r = decimal.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }

        // --------------------------  LISTS  --------------------------------------------

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                r = source[0];
                for (int i = 1; i < source.Count; i++)
                {
                    if (source[i] != null && comparer.Compare(source[i], r) < 0) r = source[i];
                }
            }
            else
            {
                r = source[0];     
                for (int i = 1; i < source.Count; i++)
                {
                    if (comparer.Compare(source[i], r) < 0) r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinF(this List<int>source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            int r = int.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] < r) r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static int MinF<T>(this List<T> source, Func<T, int> selector)
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

            int r = int.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinF(this List<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            long r = long.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] < r) r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static long MinF<T>(this List<T> source, Func<T, long> selector)
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
                throw Error.ArgumentNull("source");
            }
            long r = long.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinF(this List<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            float r = float.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] < r) r = source[i];
                else if (float.IsNaN(source[i])) return source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static float MinF<T>(this List<T> source, Func<T, float> selector)
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

            float r = float.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
                else if (float.IsNaN(v)) return v;
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinF(this List<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            double r = double.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] < r) r = source[i];
                else if (double.IsNaN(source[i])) return source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static double MinF<T>(this List<T> source, Func<T, double> selector)
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

            double r = double.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
                else if (double.IsNaN(v)) return v;
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinF(this List<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal r = decimal.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] < r) r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static decimal MinF<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal r = decimal.MaxValue;
            for (int i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static TResult MinF<T, TResult>(this List<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult r = default(TResult);
            if (r == null)
            {
                r = selector(source[0]);
                for (int i = 1; i < source.Count; i++)
                {
                    var v = selector(source[i]);
                    if (v != null && comparer.Compare(v, r) < 0) r = v;
                }
            }
            else
            {
                r = selector(source[0]);
                for (int i = 1; i < source.Count; i++)
                {
                    var v = selector(source[i]);
                    if (comparer.Compare(v, r) < 0) r = v;
                }
            }
            return r;
        }

    }
}
