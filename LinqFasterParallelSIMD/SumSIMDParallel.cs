using System;
using System.Collections.Concurrent;
using System.Numerics;
using System.Threading;
using static JM.LinqFaster.Utils.GenericOperators;
using static JM.LinqFaster.Utils.ParallelUtils;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {
        
        //assumes evenly divisible by vector Width             
        private static T SumSPHelper<T>(T[] a, int start, int end)
            where T : struct
        {
         
            var state = Vector<T>.Zero;
            var count = Vector<T>.Count;
            
            for (int i = start; i < end; i += count)
            {
                state = state + new Vector<T>(a, i);
            }

            var result = default(T);

            for (int i = 0; i < count; i++)
            {
                result = Add(result, state[i]);
            }

            return result;
        }   
             
        public static T SumSP<T>(this T[] a) where T : struct
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            
            T acc = default(T);
            acc = ForVectorAggregate(a,acc,SumSPHelper,(x,y) => Add(x,y));
            int count = Vector<T>.Count;
            
            for (int i = a.Length-a.Length%count;i < a.Length;i++)
            {
                acc = Add(acc, a[i]);
            }

          
            return acc;
        }

      

    }
}
