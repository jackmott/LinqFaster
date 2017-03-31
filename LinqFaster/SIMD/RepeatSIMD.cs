using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
        public static T[] RepeatS<T>(T e, int count)
            where T : struct
        {
            if (count < 0)
            {
                throw Error.ArgumentOutOfRange(nameof(count));
            }

            var result = new T[count];
            var v = new Vector<T>(e);
            var vCount = Vector<T>.Count;

            int i = 0;
            for (; i < result.Length; i += vCount)
            {
                v.CopyTo(result, i);
            }

            for (i = count-count%vCount;i < result.Length;i++)
            {
                result[i] = e;
            }

            return result;

        }       
    }
}
