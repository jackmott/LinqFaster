using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        public static T MinS<T> (this T[] a)
            where T : struct
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (a.Length == 0)
            {
                throw Error.NoElements();
            }

            T min = a[0];
            int count = Vector<T>.Count;
            if (count <= a.Length)
            {
                var vMin = new Vector<T>(a, 0);
                for (int i = count; i < a.Length; i+=count)
                {
                    var v = new Vector<T>(a, i);
                    vMin = Vector.Min(v, vMin);
                }

                min = vMin[0];
                for (int i = 1; i < count; i++)
                {
                    if (LessThan(vMin[i], min)) min = vMin[i];
                }
            }

            for (int i = a.Length-a.Length%count; i < a.Length;i++)
            {
                if (LessThan(a[i],min)) min = a[i];
            }
            return min;
        }
    }
}
