using System.Collections.Generic;
using System.Numerics;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements  bitwise comparison        
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>        
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualS<T>(this T[] first, T[] second) where T:struct
        {           
            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Length != second.Length) return false;
            if (first == second) return true;

            var count = Vector<T>.Count;            
            for (int i = 0; i < first.Length - count; i += count)
            {
                if (!Vector.EqualsAll(new Vector<T>(first, i), new Vector<T>(second,i)))
                {
                    return false;
                }
            }
            var comparer = EqualityComparer<T>.Default;
            for (int i = first.Length - (first.Length % count); i < first.Length; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }
            
            return true;
        }  
    }
}
