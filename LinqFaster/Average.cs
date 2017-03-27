using System;
using System.Collections.Generic;

namespace LinqFaster
{
    public static class AverageFuncs
    {
        // --------------------------  ARRAYS  --------------------------------------------
        public static double Average(this int[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            checked
            {
                for (long i = 0; i < source.LongLength; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.LongLength;
        }

        public static double Average<T>(this T[] source, Func<T,int> selector)
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

            long sum = 0;
            checked
            {
                for (long i = 0; i < source.LongLength; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.LongLength;
        }

        public static double Average<T>(this T[] source, Func<T,long> selector)
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

            long sum = 0;
            checked
            {
                for (long i = 0; i < source.LongLength; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.LongLength;
        }

        public static double Average(this float[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            for (long i = 0; i < source.LongLength; i++)
            {
                sum += source[i];
            }

            return sum / source.LongLength;
        }

        public static double Average<T>(this T[] source, Func<T,float> selector)
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

            double sum = 0;

            for (long i = 0; i < source.LongLength; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.LongLength;
        }

        public static double Average(this double[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            for (long i = 0; i < source.LongLength; i++)
            {
                sum += source[i];
            }

            return sum / source.LongLength;
        }

        public static double Average<T>(this T[] source, Func<T,double> selector)
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

            double sum = 0;

            for (long i = 0; i < source.LongLength; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.LongLength;
        }

        public static decimal Average(this decimal[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            decimal sum = 0;

            for (long i = 0; i < source.LongLength; i++)
            {
                sum += source[i];
            }

            return sum / source.LongLength;
        }

        public static decimal Average<T>(this T[] source, Func<T,decimal> selector)
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


            decimal sum = 0;

            for (long i = 0; i < source.LongLength; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.LongLength;
        }

        // --------------------------  Lists  --------------------------------------------
        public static double Average(this List<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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

        public static double Average<T>(this List<T> source, Func<T, int> selector)
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

        public static double Average<T>(this List<T> source, Func<T, long> selector)
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

        public static double Average(this List<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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

        public static double Average<T>(this List<T> source, Func<T, float> selector)
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

            double sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Count;
        }

        public static double Average(this List<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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

        public static double Average<T>(this List<T> source, Func<T, double> selector)
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

            double sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Count;
        }

        public static decimal Average(this List<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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

        public static decimal Average<T>(this List<T> source, Func<T, decimal> selector)
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


            decimal sum = 0;

            for (int i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Count;
        }
    }
}
