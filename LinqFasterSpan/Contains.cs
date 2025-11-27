using System;
using System.Collections.Generic;

namespace JM.LinqFasterSpan
{
    public static partial class LinqFasterSpan
    {

        
        // --------------------------  this SpanS  --------------------------------------------

        /// <summary>
        /// Determines whether an array contains a specified element by using the 
        /// provided IEqualityComparer.
        /// </summary>        
        /// <param name="source">An array in which to locate a value.</param>
        /// <param name="value">The value to locate.</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
        public static bool ContainsF<TSource>(this Span<TSource> source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (comparer == null)
            {
                comparer = EqualityComparer<TSource>.Default;
            }


            for (int i = 0; i < source.Length;i++)
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
