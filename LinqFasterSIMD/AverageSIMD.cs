using System;
using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
        /// <summary>
        /// Calculates the average value of an array using SIMD.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to average</param>
        /// <returns>The average of the sequence of values as a double</returns>
        public static double AverageS<T>(this T[] source) where T : struct
        {
            return Divide(SumS(source),source.Length);
        }

        /// <summary>
        /// Calculates the average value of an array via a selector using SIMD.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to transform then average</param>
        /// <returns>The average of the transformed sequence of values as a double</returns>
        public static double AverageS<T,U>(this T[] a, Func<Vector<T>, Vector<U>> selectorSIMD, Func<T, U> selector = null) 
            where T : struct
            where U : struct
        {

            return Divide(SumS(a,selectorSIMD,selector), a.Length);
        }

        /// <summary>
        /// Calculates the average value of an array using SIMD.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to average</param>
        /// <returns>The average of the sequence of values as a float</returns>
        public static float AverageSf<T>(this T[] source) where T : struct
        {
            return DivideFloat(SumS(source), source.Length);
        }

        /// <summary>
        /// Calculates the average value of an array via a selector using SIMD.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to transform then average</param>
        /// <returns>The average of the transformed sequence of values as a float</returns>
        public static float AverageSf<T, U>(this T[] a, Func<Vector<T>, Vector<U>> selectorSIMD, Func<T, U> selector = null)
            where T : struct
            where U : struct
        {

            return DivideFloat(SumS(a, selectorSIMD, selector), a.Length);
        }

    }
}
