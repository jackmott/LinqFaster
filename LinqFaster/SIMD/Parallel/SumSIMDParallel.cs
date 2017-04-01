using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;
using static JM.LinqFaster.Utils.ParallelUtils;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {
                     
                       
        public static T SumSP<T>(this T[] a) where T : struct
        {
            var state = Vector<T>.Zero;
            int count = Vector<T>.Count;

            var vectorLen = a.Length - a.Length % count;

            state = ForVectorAggregate(a,0, vectorLen, count, state, AddVectors);

            T result = default(T);
            for (int i = vectorLen;i < a.Length;i++)
            {
                result = Add(result, a[i]);
            }

            for (int i = 0; i < count; i++)
            {
                result = Add(result, state[i]);
            }
            return result;
        }

    }
}
