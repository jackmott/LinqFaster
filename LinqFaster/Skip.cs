using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        public static T[] Skip<T>(this T[] a, int count)
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
                return new T[0];
            }

            var result = new T[a.Length - count];
            Array.Copy(a, count, result, 0, count);
            return result;
        }

        public static T[] SkipWhile<T>(this T[] a, Func<T, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            int i = 0;
            for (; i < a.Length; i++)
            {
                if (predicate(a[i])) break;
            }
            var result = new T[a.Length - i];
            Array.Copy(a, i, result, 0, result.Length);
            return result;
        }

        public static T[] SkipLast<T>(this T[] a,int count)
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

        // ------------- Lists ----------------

        public static List<T> Skip<T>(this List<T> a, int count)
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
                return new List<T>();
            }

            var result = new List<T>(a.Count - count);
            for (int i = count; i < a.Count;i++)
            {
                result.Add(a[i]);
            }
            return result;
        }

        public static List<T> SkipWhile<T>(this List<T> a, Func<T, bool> predicate)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            int i = 0;
            for (; i < a.Count; i++)
            {
                if (predicate(a[i])) break;
            }
            var result = new List<T>(a.Count - i);
            for (;i < a.Count;i++)
            {
                result.Add(a[i]);
            }
            return result;
        }

        public static List<T> SkipLast<T>(this List<T> a, int count)
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
    }
}
