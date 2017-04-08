using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD.Parallel
{

    /// <summary>
    /// Provides Linq style extension methods that use both
    /// SIMD and multiple threads / tasks.
    /// </summary>
    public static partial class LinqFasterSIMDParallel
    {

        /// <summary>
        /// Calculates the average value of an array using SIMD and
        /// multiple threads/tasks.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to average</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The average of the sequence of values as a double</returns>
        public static double AverageSP<T>(this T[] source, int? batchSize = null) where T : struct
        {
            return Divide(SumSP(source,batchSize),source.Length);
        }

        /// <summary>
        /// Calculates the average value of an array using SIMD and
        /// multiple threads/tasks.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to average</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The average of the sequence of values as a double</returns>
        public static float AverageSPf<T>(this T[] source, int? batchSize = null) where T : struct
        {
            return DivideFloat(SumSP(source,batchSize), source.Length);
        }

        /*
        public static double AverageSP<T,U>(this T[] source, Func<Vector<T>,Vector<U>> selectorSIMD, Func<T,U> selector, int? batchSize = null ) 
            where T : struct
            where U : struct
        {
            return Divide(SumSP(source,selectorSIMD,selector,batchSize), source.Length);
        }

        public static float AverageSPf<T, U>(this T[] source, Func<Vector<T>, Vector<U>> selectorSIMD, Func<T, U> selector, int? batchSize = null)
           where T : struct
           where U : struct
        {
            return DivideFloat(SumSP(source, selectorSIMD, selector, batchSize), source.Length);
        }
        */
    }
}
