using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{
    
    public static partial class LinqFasterSIMD
    {
                          
        public static U[] SelectS<T,U>(this T[] a, Func<Vector<T>,Vector<U>> simdSelector, Func<T,U> selector) 
            where T : struct 
            where U : struct
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }            
        
            var count = Vector<T>.Count;

            if (count != Vector<U>.Count)
            {
                throw Error.ArgumentOutOfRange(nameof(simdSelector));
            }

            var result = new U[a.Length];

            int i = 0;
            for (; i < a.Length;i+=count)
            {
                simdSelector(new Vector<T>(a, i)).CopyTo(result, i);
            }

            i = a.Length - a.Length % count;
            for (;i<result.Length;i++)
            {
                result[i] = selector(a[i]);
            }
            return result;
        }
        
    }
}
