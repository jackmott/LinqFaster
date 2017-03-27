using System;
using System.Collections.Generic;

namespace LinqFaster
{
    //int, long, float,double, decimal
    public static class MinFuncs
    {
        // --------------------------  ARRAYS  --------------------------------------------

        public static T Min<T>(this T[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                for (long i = 0; i < a.LongLength; i++)
                {
                    if (a[i] != null && comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            else
            {
                if (a.Length == 0)
                {
                    throw Error.NoElements();
                }
                for (long i = 0; i < a.LongLength; i++)
                {
                    if (comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            return r;
        }

        public static TResult Min<T, TResult>(this T[] a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult r = default(TResult);
            if (r == null)
            {
                for (long i = 0; i < a.LongLength; i++)
                {
                    var v = selector(a[i]);
                    if (v != null && comparer.Compare(v, r) < 0) r = v;
                }
            }
            else
            {
                if (a.Length == 0)
                {
                    throw Error.NoElements();
                }
                for (long i = 0; i < a.LongLength; i++)
                {
                    var v = selector(a[i]);
                    if (comparer.Compare(v, r) < 0) r = v;
                }
            }
            return r;
        }

        public static int Min(this int[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            int r = int.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                if (a[i] < r) r = a[i];
            }
            return r;
        }

        public static int Min<T>(this T[] a, Func<T, int> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int r = int.MinValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }

        public static long Min(this long[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            long r = long.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                if (a[i] < r) r = a[i];
            }
            return r;
        }

        public static long Min<T>(this T[] a, Func<T, long> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long r = long.MinValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }

     
        public static float Min(this float[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            float r = float.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                if (a[i] < r) r = a[i];
                else if (float.IsNaN(a[i])) return a[i];
                  
            }
            return r;
        }

        public static float Min<T>(this T[] a, Func<T,float> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            float r = float.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
                else if (float.IsNaN(v)) return v;

            }
            return r;
        }

        public static double Min(this double[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            double r = double.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                if (a[i] < r) r = a[i];
                else if (double.IsNaN(a[i])) return a[i];
            }
            
            return r;
        }

        public static double Min<T>(this T[] a, Func<T, double> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            double r = double.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
                else if (double.IsNaN(v)) return v;

            }
            return r;
        }

        public static decimal Min(this decimal[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            decimal r = decimal.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                if (a[i] < r) r = a[i];
            }
            return r;
        }

        public static decimal Min<T>(this T[] a, Func<T,decimal> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            decimal r = decimal.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }

        // --------------------------  LISTS  --------------------------------------------
        public static T Min<T>(this List<T> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] != null && comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            else
            {
                if (a.Count == 0)
                {
                    throw Error.NoElements();
                }
                for (int i = 0; i < a.Count; i++)
                {
                    if (comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            return r;
        }

        public static int Min(this List<int> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            int r = int.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < r) r = a[i];
            }
            return r;
        }

        public static int Min<T>(this List<T> a, Func<T, int> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int r = int.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }


        public static long Min(this List<long> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            long r = long.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < r) r = a[i];
            }
            return r;
        }

        public static long Min<T>(this List<T> a, Func<T, long> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            long r = long.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }


        public static float Min(this List<float> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            float r = float.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < r) r = a[i];
                else if (float.IsNaN(a[i])) return a[i];
            }
            return r;
        }

        public static float Min<T>(this List<T> a, Func<T, float> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            float r = float.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
                else if (float.IsNaN(v)) return v;
            }
            return r;
        }


        public static double Min(this List<double> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            double r = double.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < r) r = a[i];
                else if (double.IsNaN(a[i])) return a[i];
            }
            return r;
        }

        public static double Min<T>(this List<T> a, Func<T,double> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double r = double.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
                else if (double.IsNaN(v)) return v;
            }
            return r;
        }

        public static decimal Min(this List<decimal> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal r = decimal.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < r) r = a[i];
            }
            return r;
        }

        public static decimal Min<T>(this List<T> a, Func<T, decimal> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            decimal r = decimal.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }

    }
}
