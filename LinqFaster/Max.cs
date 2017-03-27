using System;
using System.Collections.Generic;

namespace LinqFaster
{
    //int, long, float,double, decimal
    public static class MaxFuncs
    {
        // --------------------------  ARRAYS  --------------------------------------------
        public static T Max<T>(this T[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != null && comparer.Compare(a[i], r) > 0) r = a[i];
                }
            }
            else
            {
                if (a.Length == 0)
                {
                    throw Error.NoElements();
                }
                for (int i = 0; i < a.Length; i++)
                {
                    if (comparer.Compare(a[i], r) > 0) r = a[i];
                }
            }
            return r;
        }

        public static TResult Max<T, TResult>(this T[] a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult r = default(TResult);
            if (r == null)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    var v = selector(a[i]);
                    if (v != null && comparer.Compare(v, r) > 0) r = v;
                }
            }
            else
            {
                if (a.Length == 0)
                {
                    throw Error.NoElements();
                }
                for (int i = 0; i < a.Length; i++)
                {
                    var v = selector(a[i]);
                    if (comparer.Compare(v, r) > 0) r = v;
                }
            }
            return r;
        }

        public static int Max(this int[] a)
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static int Max<T>(this T[] a, Func<T,int> selector)
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
            for (int i = 0; i < a.Length; i++)
            {
                var v = selector(a[i]);
                if (v > r) r = v;
            }
            return r;
        }

        public static long Max(this long[] a)
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > r) r = a[i];
            }
            return r;
        }



        public static long Max<T>(this T[] a, Func<T, long> selector)
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
            for (int i = 0; i < a.Length; i++)
            {
                var v = selector(a[i]);
                if (v > r) r = v;
            }
            return r;
        }

        public static float Max(this float[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            float r = a[0];
            int startIndex = 0;
            for (;startIndex < a.Length;startIndex++)
            {
                if (!float.IsNaN(a[startIndex]))
                {
                    r = a[startIndex];
                    break;
                }
            }
            for (int i = startIndex; i < a.Length; i++)
            {
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static float Max<T>(this T[] a, Func<T,float> selector)
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

            float r = selector(a[0]);
            int startIndex = 0;
            for (; startIndex < a.Length; startIndex++)
            {
                var v = selector(a[startIndex]);
                if (!float.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (int i = startIndex; i < a.Length; i++)
            {
                var v = selector(a[i]);
                if (v > r) r = v;
            }
            return r;
        }

        public static double Max(this double[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            double r = a[0];
            int startIndex = 0;
            for (; startIndex < a.Length; startIndex++)
            {
                if (!double.IsNaN(a[startIndex]))
                {
                    r = a[startIndex];
                    break;
                }
            }
            for (int i = startIndex; i < a.Length; i++)
            {
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static double Max<T>(this T[] a, Func<T, double> selector)
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

            double r = selector(a[0]);
            int startIndex = 0;
            for (; startIndex < a.Length; startIndex++)
            {
                var v = selector(a[startIndex]);
                if (!double.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (int i = startIndex; i < a.Length; i++)
            {
                var v = selector(a[i]);
                if (v > r) r = v;
            }
            return r;
        }


        public static decimal Max(this decimal[] a)
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static decimal Max<T>(this T[] a, Func<T,decimal> selector)
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
            for (int i = 0; i < a.Length; i++)
            {
                var v = selector(a[i]);
                if (v > r) r = v;
            }
            return r;
        }

        // --------------------------  LISTS  --------------------------------------------
        public static T Max<T>(this List<T> a)
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
                    if (a[i] != null && comparer.Compare(a[i], r) > 0) r = a[i];
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
                    if (comparer.Compare(a[i], r) > 0) r = a[i];
                }
            }
            return r;
        }

        public static TResult Max<T,TResult>(this List<T> a, Func<T,TResult> selector)
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
                 for (int i = 0; i < a.Count; i++)
                {
                    var v = selector(a[i]);
                    if (v != null && comparer.Compare(v, r) > 0) r = v;
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
                    var v = selector(a[i]);
                    if (comparer.Compare(v, r) > 0) r = v;
                }
            }
            return r;
        }


        public static int Max(this List<int> a)
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
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static int Max<T>(this List<T> a,Func<T,int> selector)
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
                if (v > r) r = v;
            }
            return r;
        }

        public static long Max(this List<long> a)
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
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static long Max<T>(this List<T> a, Func<T,long> selector)
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
                if (v > r) r = v;
            }
            return r;
        }

        public static float Max(this List<float> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            float r = a[0];
            int startIndex = 0;
            for (; startIndex < a.Count; startIndex++)
            {
                if (!float.IsNaN(a[startIndex]))
                {
                    r = a[startIndex];
                    break;
                }
            }
            for (int i = startIndex; i < a.Count; i++)
            {
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static float Max<T>(this List<T> a,Func<T,float> selector)
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
            float r = selector(a[0]);
            int startIndex = 0;
            for (; startIndex < a.Count; startIndex++)
            {
                var v = selector(a[startIndex]);
                if (!float.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (int i = startIndex; i < a.Count; i++)
            {
                var v = selector(a[i]);
                if (v > r) r = v;
            }
            return r;
        }

        public static double Max(this List<double> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Count == 0)
            {
                throw Error.NoElements();
            }
            double r = a[0];
            int startIndex = 0;
            for (; startIndex < a.Count; startIndex++)
            {
                if (!double.IsNaN(a[startIndex]))
                {
                    r = a[startIndex];
                    break;
                }
            }
            for (int i = startIndex; i < a.Count; i++)
            {
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static double Max<T>(this List<T> a, Func<T,double> selector)
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
            double r = selector(a[0]);
            int startIndex = 0;
            for (; startIndex < a.Count; startIndex++)
            {
                var v = selector(a[startIndex]);
                if (!double.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (int i = startIndex; i < a.Count; i++)
            {
                var v = selector(a[i]);
                if (v > r) r = v;
            }
            return r;
        }
        public static decimal Max(this List<decimal> a)
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
                if (a[i] > r) r = a[i];
            }
            return r;
        }

        public static decimal Max<T>(this List<T> a, Func<T,decimal> selector)
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
                if (v > r) r = v;
            }
            return r;
        }


    }
}
