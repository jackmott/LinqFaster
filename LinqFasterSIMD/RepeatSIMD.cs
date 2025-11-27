using System.Numerics;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
        /// <summary>
        /// Generates a sequence that contains one repeated value using SIMD.
        /// </summary>        
        /// <param name="e">The value to be repeated.</param>
        /// <param name="count">The number of times to repeat the value in the generated sequence.</param>
        /// <returns>A sequence that contains a repeated value</returns>
        public static T[] RepeatS<T>(T e, int count)
            where T : struct
        {
            if (count < 0)
            {
                throw Error.ArgumentOutOfRange("count");
            }

            T[] result = new T[count];
            Vector<T> v = new Vector<T>(e);
            int vCount = Vector<T>.Count;

            int i = 0;
            for (; i <= result.Length-vCount; i += vCount)
            {
                v.CopyTo(result, i);
            }

            for (i = count-count%vCount;i < result.Length;i++)
            {
                result[i] = e;
            }

            return result;

        }       
    }
}
