using System;
using System.Runtime.CompilerServices;
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable UnusedMember.Global

namespace JM.LinqFasterSpan
{
    // LINQ's DefaultIfEmpty-method checks if the sequence is empty.
    // If that is the case, it will return a singleton sequence:
    // A sequence containing exactly one element.
    // This one element has the default value of the sequence's type.
    // If the sequence does contain elements, the DefaultIfEmpty-method will
    // simply return the sequence itself.
    // Note: DefaultIfEmpty also has an overload that takes a user-provided default value
    public static partial class LinqFasterSpan
    {
        // --------------------------  Arrays --------------------------------------------

        /// <summary>
        /// Returns source or (if needed) an array (For speed) with a single value set to default{T}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>source or new array{1}</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> DefaultIfEmptyF<T>(this Span<T> source)
        {
            if ((source == null)
                || (source.Length == 0)
                )
            {
                return new Span < T > (new T[] { default(T) });
            }
            return source;
        }
    }
}
