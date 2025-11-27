using System;
using System.Collections.Concurrent;
using System.Numerics;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {

        /// <summary>
        /// Projects each element of a sequence into a new form with SIMD and
        /// multiple threads / tasks.
        /// </summary>        
        /// <param name="source">The sequence of primitive values to transform.</param>
        /// <param name="selectorSIMD">A transformation function that operates on Vectors.</param>
        /// <param name="selector">An optional selection function to transform the leftover values.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence of transformed values.</returns>        
        public static U[] SelectSP<T, U>(this T[] source, Func<Vector<T>, Vector<U>> selectorSIMD, Func<T, U> selector = null, int? batchSize = null)
            where T : struct
            where U : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int count = Vector<T>.Count;

            if (count != Vector<U>.Count)
            {
                throw Error.ArgumentOutOfRange("Vector widths do not match.");
            }

            U[] result = new U[source.Length];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakeSIMDPartition(source.Length, count, batchSize);
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
