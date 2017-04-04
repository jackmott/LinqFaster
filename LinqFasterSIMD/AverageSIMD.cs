using System;
using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        public static double AverageS<T>(this T[] a) where T : struct
        {

            return Divide(SumS(a),a.Length);
        }

        public static double AverageS<T,U>(this T[] a, Func<Vector<T>, Vector<U>> selectorSIMD, Func<T, U> selector) 
            where T : struct
            where U : struct
        {

            return Divide(SumS(a,selectorSIMD,selector), a.Length);
        }

    }
}
