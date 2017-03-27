using System;

namespace LinqFaster
{
    public static class SingleFuncs
    {
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
            for (int i = 0; i < source.Length; i++)
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
            for (int i = 0; i < source.Length; i++)
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
