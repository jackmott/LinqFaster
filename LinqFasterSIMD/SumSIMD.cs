using System;
using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;


namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
                          
        public static T SumS<T>(this T[] source) where T:struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            var state = Vector<T>.Zero;
            var count = Vector<T>.Count;

            for (int i = 0; i <= source.Length - count; i+=count)
            {
                state = state + new Vector<T>(source, i);
            }

            var result = default(T);
            
            for (int i = source.Length-source.Length % count; i < source.Length;i++)
            {
                result = Add(result,source[i]);
            }

            for (int i = 0; i < count; i++)
            {
                result = Add(result, state[i]);
            }

            return result;
        }

        public static U SumS<T,U>(this T[] source, Func<Vector<T>,Vector<U>> selectorSIMD, Func<T,U> selector = null)
            where T : struct
            where U : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (selectorSIMD == null)
            {
                throw Error.ArgumentNull("selectorSIMD");
            }

            var state = Vector<U>.Zero;
            var count = Vector<U>.Count;

            for (int i = 0; i <= source.Length-count; i += count)
            {
                state = state + selectorSIMD(new Vector<T>(source, i));
            }

            var result = default(U);

            if (selector != null)
            {
                for (int i = source.Length - source.Length % count; i < source.Length; i++)
                {
                    result = Add(result, selector(source[i]));
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
