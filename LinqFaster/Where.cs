using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{

    public static partial class LinqFaster
    {
        // --------------------------  ARRAYS --------------------------------------------

        public static T[] WhereF<T>(this T[] a, Func<T, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T[] result = new T[a.Length];
            int idx = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (predicate(a[i]))
                {
                    result[idx] = a[i];
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        public static T[] WhereF<T>(this T[] a, Func<T, int, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T[] result = new T[a.Length];
            int idx = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (predicate(a[i], i))
                {
                    result[idx] = a[i];
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        // --------------------------  LISTS --------------------------------------------

        public static List<T> WhereF<T>(this List<T> a, Func<T, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            List<T> r = new List<T>();
            for (int i = 0; i < a.Count; i++)
            {
                if (predicate(a[i])) r.Add(a[i]);
            }
            return r;
        }

        public static List<T> WhereF<T>(this List<T> a, Func<T, int, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            List<T> r = new List<T>();
            for (int i = 0; i < a.Count; i++)
            {
                if (predicate(a[i], i)) r.Add(a[i]);
            }
            return r;
        }

    }
}
