using System;

namespace LinqFaster
{
    public static class ContainsFuncs
    {
        public static bool Contains<TSource>(this TSource[] source, Func<TSource, bool> predicate)
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
    }
}
