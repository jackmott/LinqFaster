using System;
using System.Numerics;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        /// <summary>
        /// Projects each element of a sequence into a new form with SIMD.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to transform.</param>
        /// <param name="slectorSIMD">A transformation function that operates on Vectors.</param>
        /// <param name="selector">An optional selection function to transform the leftover values.</param>
        /// <returns>A sequence of transformed values.</returns>        
        public static U[] SelectS<T,U>(this T[] source, Func<Vector<T>,Vector<U>> slectorSIMD, Func<T,U> selector = null) 
            where T : struct 
            where U : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }            
            if (slectorSIMD == null)
            {
                throw Error.ArgumentNull("selectorSIMD");
            }
        
            int count = Vector<T>.Count;

            if (count != Vector<U>.Count)
            {
                throw Error.ArgumentOutOfRange("selectorSIMD");
            }

            U[] result = new U[source.Length];

            int i = 0;
            for (; i <= source.Length-count;i+=count)
            {
                slectorSIMD(new Vector<T>(source, i)).CopyTo(result, i);
            }

            if (selector != null)
            {
                i = source.Length - source.Length % count;
                for (; i < result.Length; i++)
                {
                    result[i] = selector(source[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Selects/Maps in place each element of a sequence into a new form with SIMD.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to transform.</param>
        /// <param name="slectorSIMD">A transformation function that operates on Vectors.</param>
        /// <param name="selector">An optional selection function to transform the leftover values.</param>        
        public static void SelectInPlaceS<T>(this T[] source, Func<Vector<T>, Vector<T>> slectorSIMD, Func<T, T> selector = null)
            where T : struct            
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            if (slectorSIMD == null)
            {
                throw Error.ArgumentNull("selectorSIMD");
            }

            int count = Vector<T>.Count;
                        

            int i = 0;
            for (; i <= source.Length - count; i += count)
            {
                slectorSIMD(new Vector<T>(source, i)).CopyTo(source, i);
            }

            if (selector != null)
            {
                i = source.Length - source.Length % count;
                for (; i < source.Length; i++)
                {
                    source[i] = selector(source[i]);
                }
            }            
        }

    }
}
