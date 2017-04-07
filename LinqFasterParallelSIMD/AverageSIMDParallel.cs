using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {
        
        public static double AverageSP<T>(this T[] source, int? batchSize = null) where T : struct
        {
            return Divide(SumSP(source,batchSize),source.Length);
        }

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
