using System;
using System.Collections.Generic;

namespace LinqFaster
{
    public static class AnyAllFuncs
    {

        // --------------------------  ARRAYS --------------------------------------------

        public static bool Any<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            return source.Length > 0;
        }

        public static bool Any<TSource>(this TSource[] source, Func<TSource, bool> predicate)
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

        public static bool Any<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            return source.Count > 0;
        }


        public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate)
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

        public static bool Any<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
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

        public static bool All<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
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