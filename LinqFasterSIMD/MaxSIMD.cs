using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
        /// <summary>
        /// Finds the maximum value the sequence using SIMD
        /// </summary>        
        /// <param name="source">A sequence of primitive values</param>
        /// <returns>The maximum value in the sequence</returns>
        public static T MaxS<T> (this T[] source)
            where T : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            T max = source[0];
            int count = Vector<T>.Count;
            if (count <= source.Length)
            {
                Vector<T> vMax = new Vector<T>(source, 0);
                for (int i = count; i <= source.Length-count; i+=count)
                {
                    Vector<T> v = new Vector<T>(source, i);
                    vMax = Vector.Max(v, vMax);                         
                }

                max = vMax[0];
                for (int i = 1; i < count; i++)
                {
                    if (GreaterThan(vMax[i], max)) max = vMax[i];
                }
            }

            for (int i = source.Length-source.Length%count; i < source.Length;i++)
            {
                if (GreaterThan(source[i],max)) max = source[i];
            }
            return max;
        }
    }
}
