using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        public static T[] TakeF<T>(this T[] a, int count)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > a.Length)
            {
                count = a.Length;
            }

            var result = new T[count];
            Array.Copy(a, 0, result, 0, count);
            return result;
        }

        public static T[] TakeWhileF<T>(this T[] a, Func<T, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = new List<T>();
            for (int i = 0; i < a.Length; i++)
            {
                if (predicate(a[i]))
                    result.Add(a[i]);
                else
                    return result.ToArray();
            }
            return result.ToArray();
        }

        public static T[] TakeLastF<T>(this T[] a, int count)
        {

            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > a.Length)
            {
                count = a.Length;
            }

            var result = new T[count];
            Array.Copy(a, a.Length - count, result, 0, count);
            return result;

        }

        // ------------- Lists ----------------

        public static List<T> TakeF<T>(this List<T> a, int count)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > a.Count)
            {
                count = a.Count;
            }

            var result = new List<T>(count);
            for (int i = 0; i < count; i++)
            {
                result.Add(a[i]);
            }
            return result;
        }

        public static List<T> TakeWhileF<T>(this List<T> a, Func<T, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = new List<T>();
            for (int i = 0; i < a.Count; i++)
            {
                if (predicate(a[i]))
                {
                    result.Add(a[i]);
                }
                else
                {
                    return result;
                }
            }

            return result;
        }

        public static List<T> TakeLastF<T>(this List<T> a, int count)
        {

            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > a.Count)
            {
                count = a.Count;
            }

            var result = new List<T>(count);
            for (int i = a.Count - count; i < count; i++)
            {
                result.Add(a[i]);
            }
            return result;

        }
    }
}
