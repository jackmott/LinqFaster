using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        // ------------------------------ Arrays --------------------------
        public static TSource Aggregate<TSource>(this TSource[] source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            TSource result = source[0];
            for (int i = 1; i < source.Length;i++)
            {                
                result = func(result, source[i]);
            }
            return result;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this TSource[] source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            TAccumulate result = seed;
            foreach (var v in source)
            {
                result = func(result, v);
            }
            return result;
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(this TSource[] source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
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
            foreach (var v in source)
            {
                result = func(result, v);
            }
            return resultSelector(result);
        }

        // ------------------------------ Lists --------------------------
        public static TSource Aggregate<TSource>(this List<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            TSource result = source[0];
            for (int i = 1; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this List<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            TAccumulate result = seed;
            for (int i = 0; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(this List<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
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
            for (int i = 0; i < source.Count;i++)
            {
                result = func(result, source[i]);
            }
            return resultSelector(result);
        }

    }
}