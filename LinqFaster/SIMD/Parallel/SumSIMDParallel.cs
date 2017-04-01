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

            state = ForStrideAggregate(0, a.Length, count, state, (i, acc) => acc + (new Vector<T>(a, i)), AddVectors);

            T result = default(T);
            for (int i = a.Length-a.Length%count;i < a.Length;i++)
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
