using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {
       
        public static T SumSP<T>(this T[] source, int? batchSize = null) where T : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            var count = Vector<T>.Count;
            var sum = Vector<T>.Zero;
            object LOCK = new object();

            var rangePartitioner = MakeSIMDPartition(source.Length, count, batchSize);
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
                     lock(LOCK)
                     {
                         sum = sum + acc;
                     }
                 });

            T result = default(T);
            for (int i = 0; i < count;i++)
            {
                result = Add(result, sum[i]);
            }
            return result;
        }

      


    }
}
