using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        // --------------------------  ARRAYS --------------------------------------------

        public static bool AnyF<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            return source.Length > 0;
        }

        public static bool AnyF<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (long i = 0; i < source.LongLength; i++)
            {
                if (predicate(source[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool AnyF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            return source.Count > 0;
        }


        public static bool AllF<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (long i = 0; i < source.LongLength; i++)
            {
                if (!predicate(source[i]))
                {
                    return false;
                }
            }

            return true;
        }

        // --------------------------  Lists --------------------------------------------

        public static bool AnyF<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool AllF<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            for (int i = 0; i < source.Count; i++)
            {
                if (!predicate(source[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}