using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        // --------------------------  Arrays --------------------------------------------

        public static T FirstF<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            return source[0];
        }

        public static T FirstF<T>(this T[] source, Func<T, bool> predicate)
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
                    return source[i];
                }
            }

            throw Error.NoMatch();
        }

        public static T FirstOrDefaultF<T>(this T[] source, Func<T, bool> predicate)
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
                    return source[i];
                }
            }

            return default(T);
        }

        // --------------------------  Lists --------------------------------------------

        public static T FirstF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            return source[0];
        }

        public static T FirstF<T>(this List<T> source, Func<T, bool> predicate)
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
                    return source[i];
                }
            }

            throw Error.NoMatch();
        }

        public static T FirstOrDefaultF<T>(this List<T> source, Func<T, bool> predicate)
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
                    return source[i];
                }
            }

            return default(T);
        }
    }
}
