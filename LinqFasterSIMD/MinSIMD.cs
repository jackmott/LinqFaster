using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        /// <summary>
        /// Finds the minimum value in a sequence using SIMD.
        /// </summary>        
        /// <param name="source">A sequence of primitive values</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinS<T> (this T[] source)
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

            T min = source[0];
            int count = Vector<T>.Count;
            if (count <= source.Length)
            {
                Vector<T> vMin = new Vector<T>(source, 0);
                for (int i = count; i <= source.Length-count; i+=count)
                {
                    Vector<T> v = new Vector<T>(source, i);
                    vMin = Vector.Min(v, vMin);
                }

                min = vMin[0];
                for (int i = 1; i < count; i++)
                {
                    if (LessThan(vMin[i], min)) min = vMin[i];
                }
            }

            for (int i = source.Length-source.Length%count; i < source.Length;i++)
            {
                if (LessThan(source[i],min)) min = source[i];
            }
            return min;
        }
    }
}
