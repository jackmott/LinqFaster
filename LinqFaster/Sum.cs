using System;
using System.Collections.Generic;


namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS  --------------------------------------------
        public static int SumF(this int[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            int sum = 0;
            checked
            {
                foreach (var v in a)
                {
                    sum += v;
                }
            }
            return sum;
        }

        public static int SumF<T>(this T[] a, Func<T, int> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int sum = 0;
            checked
            {
                foreach (var v in a)
                {
                    sum += selector(v);
                }
            }
            return sum;
        }

        public static long SumF(this long[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            long sum = 0;
            checked
            {
                foreach (var v in a)
                {
                    sum += v;
                }
            }
            return sum;
        }

        public static long SumF<T>(this T[] a, Func<T, long> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            checked
            {
                foreach (var v in a)
                {
                    sum += selector(v);
                }
            }
            return sum;
        }


        public static float SumF(this float[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;

            foreach (var v in a)
            {
                sum += v;
            }

            return (float)sum;
        }

        public static float SumF<T>(this T[] a, Func<T, float> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            foreach (var v in a)
            {
                sum += selector(v);
            }

            return (float)sum;
        }


        public static double SumF(this double[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;
            foreach (var v in a)
            {
                sum += v;
            }

            return sum;
        }

        public static double SumF<T>(this T[] a, Func<T, double> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            foreach (var v in a)
            {
                sum += selector(v);
            }

            return sum;
        }

        public static decimal SumF(this decimal[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            decimal sum = 0;

            foreach (var v in a)
            {
                sum += v;
            }

            return sum;
        }

        public static decimal SumF<T>(this T[] a, Func<T, decimal> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            decimal sum = 0;
            foreach (var v in a)
            {
                sum += selector(v);
            }

            return sum;
        }

        // --------------------------  LISTS  --------------------------------------------

        public static int SumF(this List<int> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            int sum = 0;
            checked
            {
                for (int i = 0; i < a.Count; i++)
                {
                    sum += a[i];
                }
            }
            return sum;
        }

        public static int SumF<T>(this List<T> a, Func<T, int> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int sum = 0;
            checked
            {
                for (int i = 0; i < a.Count; i++)
                {
                    sum += selector(a[i]);
                }
            }
            return sum;
        }

        public static long SumF(this List<long> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            long sum = 0;
            checked
            {
                for (int i = 0; i < a.Count; i++)
                {
                    sum += a[i];
                }
            }
            return sum;
        }

        public static long SumF<T>(this List<T> a, Func<T, long> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            checked
            {
                for (int i = 0; i < a.Count; i++)
                {
                    sum += selector(a[i]);
                }
            }
            return sum;
        }


        public static float SumF(this List<float> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;

            for (int i = 0; i < a.Count; i++)
            {
                sum += a[i];
            }

            return (float)sum;
        }

        public static float SumF<T>(this List<T> a, Func<T, float> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += selector(a[i]);
            }

            return (float)sum;
        }


        public static double SumF(this List<double> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += a[i];
            }

            return sum;
        }

        public static double SumF<T>(this List<T> a, Func<T, double> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += selector(a[i]);
            }

            return sum;
        }

        public static decimal SumF(this List<decimal> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            decimal sum = 0;

            for (int i = 0; i < a.Count; i++)
            {
                sum += a[i];
            }

            return sum;
        }

        public static decimal SumF<T>(this List<T> a, Func<T, decimal> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            decimal sum = 0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += selector(a[i]);
            }

            return sum;
        }

    }
}
