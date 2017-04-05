using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {
        
        public static double AverageSP<T>(this T[] a) where T : struct
        {
            return Divide(SumSP(a),a.Length);
        }

    }
}
