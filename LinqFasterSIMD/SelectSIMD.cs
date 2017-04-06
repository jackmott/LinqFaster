using System;
using System.Numerics;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
                          
        public static U[] SelectS<T,U>(this T[] source, Func<Vector<T>,Vector<U>> slectorSIMD, Func<T,U> selector = null) 
            where T : struct 
            where U : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }            
            if (slectorSIMD == null)
            {
                throw Error.ArgumentNull("selectorSIMD");
            }
        
            var count = Vector<T>.Count;

            if (count != Vector<U>.Count)
            {
                throw Error.ArgumentOutOfRange("selectorSIMD");
            }

            var result = new U[source.Length];

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
        
    }
}
