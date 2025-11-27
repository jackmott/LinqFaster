using System.Numerics;
using JM.LinqFaster.Utils;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        /// <summary>
        /// Determines whether an array contains a specified element 
        /// using SIMD.        
        /// </summary>        
        /// <param name="source">An array in which to locate a value.</param>
        /// <param name="value">The value to locate.</param>        
        /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
        public static bool ContainsS<T>(this T[] source, T value)
            where T : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int count = Vector<T>.Count;
            Vector<T> vectorValue = new Vector<T>(value);
            for (int i = 0; i < source.Length-count;i+=count)
            {
                if (Vector.EqualsAny(new Vector<T>(source,i),vectorValue))
                {
                    return true;
                }
            }
            for (int i = source.Length-(source.Length%count); i < source.Length;i++)
            {                
                if (GenericOperators.Equals(source[i],value)) return true;
            }
            return false;
        }
    }
}
