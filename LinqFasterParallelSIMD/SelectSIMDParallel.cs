using System;
using System.Numerics;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {


        public static U[] SelectSP<T, U>(this T[] source, Func<Vector<T>, Vector<U>> selectorSIMD, Func<T, U> selector = null, int? batchSize = null)
            where T : struct
            where U : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            int count = Vector<T>.Count;

            if (count != Vector<U>.Count)
            {
                throw Error.ArgumentOutOfRange("Vector widths do not match.");
            }

            var result = new U[source.Length];
            var rangePartitioner = MakeSIMDPartition(source.Length, count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) =>
                {
                    int index = range.Item1 * count;
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        selectorSIMD(new Vector<T>(source, index)).CopyTo(result, index);
                        index += count;
                    }

                });

            if (selector != null)
            {
                for (int i = source.Length - source.Length % count; i < source.Length; i++)
                {
                    result[i] = selector(source[i]);
                }
            }


            return result;
        }

    }
}
