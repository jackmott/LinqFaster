using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {

        /// <summary>
        /// Returns a number that represents how many elements in the specified in parallel.
        /// array satisfy a condition.
        /// </summary>        
        /// <param name="source">An array that contains elements to be tested and counted.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>A number that represents how many elements in the array satisfy the condition
        /// in the predicate function.</returns>
        public static int CountP<T>(this T[] source, Func<T, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            int total = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
                (range, loopState, acc) =>
                {                    
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            if (predicate(source[i]))
                            {
                                acc++;
                            }
                        }
                    }

                    return acc;
                },
                 acc => Interlocked.Add(ref total, acc));


            return total;
        }


        // ------------------------------ Lists ---------------------

        /// <summary>
        /// Returns a number that represents how many elements in the specified in parallel.
        /// list satisfy a condition.
        /// </summary>        
        /// <param name="source">A list that contains elements to be tested and counted.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>A number that represents how many elements in the list satisfy the condition
        /// in the predicate function.</returns>
        public static int CountP<T>(this List<T> source, Func<T, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            int total = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
                (range, loopState, acc) =>
                {                    
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            if (predicate(source[i]))
                            {
                                acc++;
                            }
                        }
                    }

                    return acc;
                },
                 acc => Interlocked.Add(ref total, acc));


            return total;
        }




    }
}
