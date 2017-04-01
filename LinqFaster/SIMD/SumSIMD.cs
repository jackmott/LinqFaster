using System;
using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;
using static JM.LinqFaster.Utils.ParallelUtils;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
                          
        public static T SumS<T>(this T[] a) where T:struct
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            var state = Vector<T>.Zero;
            var count = Vector<T>.Count;

            for (int i = 0; i <= a.Length - count; i+=count)
            {
                state = state + new Vector<T>(a, i);
            }

            var result = default(T);
            
            for (int i = a.Length-a.Length % count; i < a.Length;i++)
            {
                result = Add(result,a[i]);
            }

            for (int i = 0; i < count; i++)
            {
                result = Add(result, state[i]);
            }

            return result;
        }

        public static U SumS<T,U>(this T[] a, Func<Vector<T>,Vector<U>> selectorSIMD, Func<T,U> selector = null)
            where T : struct
            where U : struct
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            if (selectorSIMD == null)
            {
                throw Error.ArgumentNull(nameof(selectorSIMD));
            }

            var state = Vector<U>.Zero;
            var count = Vector<U>.Count;

            for (int i = 0; i <= a.Length-count; i += count)
            {
                state = state + selectorSIMD(new Vector<T>(a, i));
            }

            var result = default(U);

            if (selector != null)
            {
                for (int i = a.Length - a.Length % count; i < a.Length; i++)
                {
                    result = Add(result, selector(a[i]));
                }
            }

            for (int i = 0; i < count; i++)
            {
                result = Add(result, state[i]);
            }

            return result;
        }

       

    }
}
