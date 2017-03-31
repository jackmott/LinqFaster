using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        // --------------------------  ARRAYS  --------------------------------------------
        public static bool ContainsF<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (comparer == null)
            {
                comparer = EqualityComparer<TSource>.Default;
            }


            for (long i = 0; i < source.LongLength; i++)
            {
                if (comparer.Equals(source[i], value))
                {
                    return true;
                }
            }

            return false;
        }

        // --------------------------  Lists --------------------------------------------
        public static bool ContainsF<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (comparer == null)
            {
                comparer = EqualityComparer<TSource>.Default;
            }


            for (int i = 0; i < source.Count; i++)
            {
                if (comparer.Equals(source[i], value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
