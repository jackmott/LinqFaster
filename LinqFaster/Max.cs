using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFaster
{
    //int, long, float,double, decimal
    public static class MaxFuncs
    {
        // --------------------------  ARRAYS  --------------------------------------------
        public static T Max<T>(this T[] a) where T : IComparable
        {
            if(a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            for (int i = 0; i < a.Length;i++)
            {
                if (a[i] != null && r.CompareTo(a[i]) > 0) r = a[i];
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
            for (int i =0; i < a.Length;i++)
            {
                if (a[i] > r) r = a[i];
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
            float r = float.MaxValue;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > r) r = a[i];
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
            double r = double.MaxValue;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > r) r = a[i];
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

        // --------------------------  LISTS  --------------------------------------------
        public static T Max<T>(this List<T> a) where T : IComparable
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
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != null && r.CompareTo(a[i]) > 0) r = a[i];
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
            float r = float.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > r) r = a[i];
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
            double r = double.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > r) r = a[i];
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
    }
}
