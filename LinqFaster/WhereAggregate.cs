using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{

    public static partial class LinqFaster
    {
        // ----------------------------- Arrays ------------------
        public static T WhereAggregateF<T>(this T[] a, Func<T, bool> predicate, Func<T, T, T> func)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }
            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            var result = default(T);

            int i = 0;
            for (; i < a.Length; i++)
            {
                if (predicate(a[i]))
                {
                    result = a[i];
                    i++;
                    break;
                }
            }
            for (; i < a.Length; i++)
            {
                if (predicate(a[i]))
                {
                    result = func(result, a[i]);
                }
            }
            return result;
        }

        public static T WhereAggregateF<T>(this T[] a, Func<T, int, bool> predicate, Func<T, T, int, T> func)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = default(T);

            int i = 0;
            for (; i < a.Length; i++)
            {
                if (predicate(a[i], i))
                {
                    result = a[i];
                    i++;
                    break;
                }
            }
            int idx = 0;
            for (; i < a.Length; i++)
            {
                if (predicate(a[i], i))
                {
                    result = func(result, a[i], idx);
                    idx++;
                }
            }
            return result;
        }

        public static TAccumulate WhereAggregateF<TSource, TAccumulate>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            TAccumulate result = seed;
            foreach (var v in source)
            {
                if (predicate(v))
                    result = func(result, v);
            }
            return result;
        }

        public static TResult WhereAggregateF<TSource, TAccumulate, TResult>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (resultSelector == null)
            {
                throw Error.ArgumentNull(nameof(resultSelector));
            }

            TAccumulate result = seed;
            foreach (var v in source)
            {
                if (predicate(v))
                    result = func(result, v);
            }
            return resultSelector(result);
        }

        
        // --------------------------- Lists -------------------------
        public static T WhereAggregateF<T>(this List<T> a, Func<T, bool> predicate, Func<T, T, T> func)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            var result = default(T);

            int i = 0;
            for (; i < a.Count; i++)
            {
                if (predicate(a[i]))
                {
                    result = a[i];
                    i++;
                    break;
                }
            }
            for (; i < a.Count; i++)
            {
                if (predicate(a[i]))
                {
                    result = func(result, a[i]);
                }
            }
            return result;
        }

        public static T WhereAggregateF<T>(this List<T> a, Func<T, int, bool> predicate, Func<T, T, int, T> func)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            var result = default(T);

            int i = 0;
            for (; i < a.Count; i++)
            {
                if (predicate(a[i], i))
                {
                    result = a[i];
                    i++;
                    break;
                }
            }
            int idx = 0;
            for (; i < a.Count; i++)
            {
                if (predicate(a[i], i))
                {
                    result = func(result, a[i], idx);
                    idx++;
                }
            }
            return result;
        }

        public static TAccumulate WhereAggregateF<TSource, TAccumulate>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            TAccumulate result = seed;
            for (int i = 0; i < source.Count; i++)
            {
                var v = source[i];
                if (predicate(v))
                    result = func(result, v);
            }
            return result;
        }

        public static TResult WhereAggregateF<TSource, TAccumulate, TResult>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (resultSelector == null)
            {
                throw Error.ArgumentNull(nameof(resultSelector));
            }

            TAccumulate result = seed;
            for (int i = 0; i < source.Count; i++)
            {
                var v = source[i];
                if (predicate(v))
                    result = func(result, v);
            }
            return resultSelector(result);
        }
    }
}