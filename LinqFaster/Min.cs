using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    //int, long, float,double, decimal
    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS  --------------------------------------------

        public static T MinF<T>(this T[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                r = a[0];
                for (long i = 1; i < a.LongLength; i++)
                {
                    if (a[i] != null && comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            else
            {
                r = a[0];
                for (long i = 1; i < a.LongLength; i++)
                {
                    if (comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            return r;
        }

        public static TResult MinF<T, TResult>(this T[] a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }

            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult r = default(TResult);
            if (r == null)
            {
                r = selector(a[0]);
                for (long i = 1; i < a.LongLength; i++)
                {
                    var v = selector(a[i]);
                    if (v != null && comparer.Compare(v, r) < 0) r = v;
                }
            }
            else
            {
                r = selector(a[0]);
                for (long i = 1; i < a.LongLength; i++)
                {
                    var v = selector(a[i]);
                    if (comparer.Compare(v, r) < 0) r = v;
                }
            }
            return r;
        }

        public static int MinF(this int[] a)
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

        public static int MinF<T>(this T[] a, Func<T, int> selector)
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

            int r = int.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }

        public static long MinF(this long[] a)
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

        public static long MinF<T>(this T[] a, Func<T, long> selector)
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

            long r = long.MaxValue;
            for (long i = 0; i < a.LongLength; i++)
            {
                var v = selector(a[i]);
                if (v < r) r = v;
            }
            return r;
        }


        public static float MinF(this float[] a)
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

        public static float MinF<T>(this T[] a, Func<T, float> selector)
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

        public static double MinF(this double[] a)
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

        public static double MinF<T>(this T[] a, Func<T, double> selector)
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

        public static decimal MinF(this decimal[] a)
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

        public static decimal MinF<T>(this T[] a, Func<T, decimal> selector)
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
        public static T MinF<T>(this List<T> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                r = a[0];
                for (int i = 1; i < a.Count; i++)
                {
                    if (a[i] != null && comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            else
            {
                r = a[0];     
                for (int i = 1; i < a.Count; i++)
                {
                    if (comparer.Compare(a[i], r) < 0) r = a[i];
                }
            }
            return r;
        }

        public static int MinF(this List<int> a)
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

        public static int MinF<T>(this List<T> a, Func<T, int> selector)
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


        public static long MinF(this List<long> a)
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

        public static long MinF<T>(this List<T> a, Func<T, long> selector)
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


        public static float MinF(this List<float> a)
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

        public static float MinF<T>(this List<T> a, Func<T, float> selector)
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


        public static double MinF(this List<double> a)
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

        public static double MinF<T>(this List<T> a, Func<T, double> selector)
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

        public static decimal MinF(this List<decimal> a)
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

        public static decimal MinF<T>(this List<T> a, Func<T, decimal> selector)
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

        public static TResult MinF<T, TResult>(this List<T> a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            if (a.Count == 0)
            {
                throw Error.NoElements();
            }

            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult r = default(TResult);
            if (r == null)
            {
                r = selector(a[0]);
                for (int i = 1; i < a.Count; i++)
                {
                    var v = selector(a[i]);
                    if (v != null && comparer.Compare(v, r) < 0) r = v;
                }
            }
            else
            {
                r = selector(a[0]);
                for (int i = 1; i < a.Count; i++)
                {
                    var v = selector(a[i]);
                    if (comparer.Compare(v, r) < 0) r = v;
                }
            }
            return r;
        }

    }
}
