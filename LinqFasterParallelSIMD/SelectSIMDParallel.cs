using System;
using System.Numerics;
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
             
        public static U[] SelectSP<T,U>(this T[] source, Func<Vector<T>,Vector<U>> selectorSIMD, Func<T,U> selector = null) 
            where T : struct
            where U : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            var result = new U[source.Length];
            ForVector(source,result,selectorSIMD,SelectSPHelper);

            if (selector != null)
            {
                int count = Vector<T>.Count;
                for (int i = source.Length - source.Length % count; i < source.Length; i++)
                {
                    result[i] = selector(source[i]);
                }
            }


            return result;
        }

    }
}
