using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (a.Length == 0)
            {
                throw Error.NoElements();
            }
            Comparer<T> comparer = Comparer<T>.Default;
            T r = default(T);
            if (r == null)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != null && comparer.Compare(a[i], r) < 0) r = a[i];
                }
            } else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (comparer.Compare(a[i], r) < 0) r = a[i];
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < r) r = a[i];
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < r) r = a[i];
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < r) r = a[i];
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < r) r = a[i];
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
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < r) r = a[i];
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
            if (a.Count == 0)
            {
                throw Error.NoElements();
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
    }
}
