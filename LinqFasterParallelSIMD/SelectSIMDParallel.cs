using System;
using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;
using static JM.LinqFaster.Utils.ParallelUtils;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {
        
        //assumes evenly divisible by vector Width             
        private static void SelectSPHelper<T,U>(T[] a,U[] result, Func<Vector<T>,Vector<U>> selector, int start, int end)
            where T : struct
            where U : struct
        {
         
            var count = Vector<T>.Count;

            for (int i = start; i < end; i += count)
            {
                selector(new Vector<T>(a, i)).CopyTo(result, i);
            }

        
        }   
             
        public static U[] SelectSP<T,U>(this T[] a, Func<Vector<T>,Vector<U>> selectorSIMD, Func<T,U> selector = null) 
            where T : struct
            where U : struct
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            var result = new U[a.Length];
            ForVector(a,result,selectorSIMD,SelectSPHelper);

            if (selector != null)
            {
                int count = Vector<T>.Count;
                for (int i = a.Length - a.Length % count; i < a.Length; i++)
                {
                    result[i] = selector(a[i]);
                }
            }


            return result;
        }

    }
}
