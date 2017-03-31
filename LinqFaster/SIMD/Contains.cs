using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
        public static bool Contains<T>(T[] source, T value)
            where T : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            var count = Vector<T>.Count;
            var vectorValue = new Vector<T>(value);
            for (int i = 0; i < source.Length;i+=count)
            {
                if (Vector.EqualsAny(new Vector<T>(source,i),vectorValue))
                {
                    return true;
                }
            }
            for (int i = source.Length-source.Length%count; i < source.Length;i++)
            {
                if (Equals(source[i],value)) return true;
            }
            return false;
        }
    }
}
