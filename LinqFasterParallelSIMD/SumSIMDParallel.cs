using System;
using System.Collections.Concurrent;
using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {

        /// <summary>
        /// Sums the values in source using SIMD and multiple Tasks/Threads.
        /// </summary>        
        /// <param name="source">A sequence to sum.</param>
        /// <param name ="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns></returns>
        public static T SumSP<T>(this T[] source, int? batchSize = null) where T : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            int count = Vector<T>.Count;
            Vector<T> sum = Vector<T>.Zero;
            object LOCK = new object();

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakeSIMDPartition(source.Length, count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Vector<T>.Zero,
                (range, s, acc) =>
                {
                    int index = range.Item1 * count;
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += new Vector<T>(source, index);
                        index += count;
                    }

                    return acc;
                },
                 acc =>
                 {
                     lock (LOCK)
                     {
                         sum = sum + acc;
                     }
                 });

            T result = default(T);
            for (int i = 0; i < count; i++)
            {
                result = Add(result, sum[i]);
            }
            return result;
        }




    }
}
