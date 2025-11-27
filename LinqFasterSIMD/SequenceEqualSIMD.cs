using System.Collections.Generic;
using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

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
        public static bool SequenceEqualS<T>(this T[] first, T[] second) where T : struct
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

            int count = Vector<T>.Count;
            for (int i = 0; i <= first.Length - count; i += count)
            {
                if (!Vector.EqualsAll(new Vector<T>(first, i), new Vector<T>(second, i)))
                {
                    return false;
                }
            }
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = first.Length - (first.Length % count); i < first.Length; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }

            return true;
        }
              
        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>        
        /// <returns>An array of integers, where the value corresponds to IComparer.Compare indicating less than, greater than, or equals</returns>     
        public static int[] SequenceCompareS<T>(this T[] first, T[] second) where T : struct
        {
            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Length != second.Length) throw Error.NotSupported();

            Vector<int> minusone = new Vector<int>(-1);
            int count = Vector<T>.Count;
            int[] result = new int[first.Length];
            for (int i = 0; i <= first.Length - count; i += count)
            {
                Vector<T> a = new Vector<T>(first, i);
                Vector<T> b = new Vector<T>(second, i);
                if (!Vector.EqualsAll(a, b))
                {
                    Vector<int> gt = Vector.BitwiseAnd(Vector.AsVectorInt32(Vector.GreaterThan(a, b)), Vector<int>.One);
                    Vector<int> lt = Vector.BitwiseAnd(Vector.AsVectorInt32(Vector.LessThan(a, b)), minusone);
                    Vector.BitwiseOr(gt, lt).CopyTo(result, i);
                }
            }
            for (int i = first.Length - (first.Length % count); i < first.Length; i++)
            {
                if (GreaterThan(first[i], second[i]))
                {
                    result[i] = 1;
                }
                else if (LessThan(first[i], second[i]))
                {
                    result[i] = -1;
                }
            }
            return result;
        }
      
    }
}
