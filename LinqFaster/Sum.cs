using System;
using System.Collections.Generic;


namespace JM.LinqFaster
{    
    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS  --------------------------------------------
        public static int Sum(this int[] a)
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

        public static int Sum<T>(this T[] a, Func<T, int> selector)
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

        public static long Sum(this long[] a)
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

        public static long Sum<T>(this T[] a, Func<T, long> selector)
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


        public static float Sum(this float[] a)
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

        public static float Sum<T>(this T[] a, Func<T, float> selector)
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


        public static double Sum(this double[] a)
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

        public static double Sum<T>(this T[] a, Func<T, double> selector)
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

        public static decimal Sum(this decimal[] a)
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

        public static decimal Sum<T>(this T[] a, Func<T, decimal> selector)
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
        
        public static int Sum(this List<int> a)
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

        public static int Sum<T>(this List<T> a, Func<T, int> selector)
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

        public static long Sum(this List<long> a)
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

        public static long Sum<T>(this List<T> a, Func<T, long> selector)
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


        public static float Sum(this List<float> a)
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

        public static float Sum<T>(this List<T> a, Func<T, float> selector)
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


        public static double Sum(this List<double> a)
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

        public static double Sum<T>(this List<T> a, Func<T, double> selector)
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

        public static decimal Sum(this List<decimal> a)
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

        public static decimal Sum<T>(this List<T> a, Func<T, decimal> selector)
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
