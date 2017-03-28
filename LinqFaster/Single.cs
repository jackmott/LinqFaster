using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        // --------------------------- Arrays ----------------------------
        public static T Single<T>(this T[] source)
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

        public static T SingleOrDefault<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                return default(T);
            }

            return source[0];
        }


        public static T Single<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T result = default(T);
            bool foundMatch = false;
            for (long i = 0; i < source.LongLength; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw Error.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            if (foundMatch)
            {
                return result;
            }
            else
            {
                throw Error.NoMatch();
            }
        }

        public static T SingleOrDefault<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T result = default(T);
            bool foundMatch = false;
            for (long i = 0; i < source.LongLength; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw Error.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            return result;
        }


        // --------------------------- Lists ----------------------------
        public static T Single<T>(this List<T> source)
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

        public static T SingleOrDefault<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                return default(T);
            }

            return source[0];
        }


        public static T Single<T>(this List<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T result = default(T);
            bool foundMatch = false;
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw Error.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            if (foundMatch)
            {
                return result;
            }
            else
            {
                throw Error.NoMatch();
            }
        }

        public static T SingleOrDefault<T>(this List<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            T result = default(T);
            bool foundMatch = false;
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw Error.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            return result;
        }

    }
}
