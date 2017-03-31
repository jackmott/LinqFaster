using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        public static T MaxS<T> (this T[] a)
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

            T max = a[0];
            int count = Vector<T>.Count;
            if (count <= a.Length)
            {
                var vMax = new Vector<T>(a, 0);
                for (int i = count; i < a.Length; i+=count)
                {
                    var v = new Vector<T>(a, i);
                    vMax = Vector.Max(v, vMax);
                }

                max = vMax[0];
                for (int i = 1; i < count; i++)
                {
                    if (GreaterThan(vMax[i], max)) max = vMax[i];
                }
            }

            for (int i = a.Length-a.Length%count; i < a.Length;i++)
            {
                if (GreaterThan(a[i],max)) max = a[i];
            }
            return max;
        }
    }
}
