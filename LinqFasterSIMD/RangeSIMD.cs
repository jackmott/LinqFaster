using System.Numerics;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range
        /// using SIMD
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence.</param>
        /// <param name="len">The number of sequential integers to generate.</param>
        /// <returns>A sequence that contains a range of sequential integral numbers.</returns>
        public static int[] RangeS(int start, int len)            
        {
            long max = ((long)start) + len - 1;
            if (len < 0 || max > int.MaxValue) {
                throw Error.ArgumentOutOfRange("len");
            }

            int count = Vector<int>.Count;
            int[] result = new int[len];
            if (len >= count) {
                //use result array for double duty to save memory
                
                for (int i = 0; i < count; i++) {
                    result[i] = i + start;
                }

                Vector<int> V = new Vector<int>(result);
                Vector<int> Increment = new Vector<int>(count);
                V = V + Increment;
                for (int i = count; i <= len - count; i += count) {
                    V.CopyTo(result, i);
                    V = V + Increment;
                }
            }

            for (int i = len - len % count; i < len; i++) {
                result[i] = i + start;
            }

            return result;

        }
    }
}
