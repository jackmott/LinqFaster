using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.SIMD.Parallel
{

    public static partial class LinqFasterSIMDParallel
    {

        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements using bitwise comparison        
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualSP<T>(this T[] first, T[] second,int? batchSize = null) where T: struct
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
            int nonEqualCount = 0;            
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakeSIMDPartition(first.Length, count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,               
                (range, loopState) =>
                {

                    int index = range.Item1 * count;
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (!Vector.EqualsAll(new Vector<T>(first, index), new Vector<T>(second, index)))
                        {
                            Interlocked.Increment(ref nonEqualCount);
                            loopState.Break();
                        }
                        index += count;
                    }

                });
            if (nonEqualCount != 0) return false;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = first.Length - (first.Length % count); i < first.Length; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }
            return true;
        }
     
    }
}
