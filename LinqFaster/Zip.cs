using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        public static R[] Zip<T, U, R>(this T[] first, U[] second, Func<T, U, R> selector)
        {
            if (first == null)
            {
                throw Error.ArgumentNull(nameof(first));
            }
            if (second == null)
            {
                throw Error.ArgumentNull(nameof(second));
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            //maintain array bounds elision
            if (first.Length < second.Length)
            {
                var result = new R[first.Length];
                for (int i = 0; i < first.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;

            }
            else
            {
                var result = new R[second.Length];
                for (int i = 0; i < second.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;
            }

        }

        public static List<R> Zip<T, U, R>(this List<T> first, List<U> second, Func<T, U, R> selector)
        {
            if (first == null)
            {
                throw Error.ArgumentNull(nameof(first));
            }
            if (second == null)
            {
                throw Error.ArgumentNull(nameof(second));
            }
            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            //maintain array bounds elision
            if (first.Count < second.Count)
            {
                var result = new List<R>(first.Count);
                for (int i = 0; i < first.Count; i++)
                {
                    result.Add(selector(first[i], second[i]));
                }
                return result;

            }
            else
            {
                var result = new List<R>(second.Count);
                for (int i = 0; i < second.Count; i++)
                {
                    result.Add(selector(first[i], second[i]));
                }
                return result;
            }

        }
    }
}
