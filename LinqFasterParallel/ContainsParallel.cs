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
        /// Determines whether an array contains a specified element by using the 
        /// provided IEqualityComparer or the default comparer if none is provided,
        /// in parallel. If using a default comparer, use the non parallel version, it is faster.
        /// </summary>        
        /// <param name="source">An array in which to locate a value.</param>
        /// <param name="value">The value to locate.</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
        public static bool ContainsP<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource> comparer, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (comparer == null)
            {
                throw Error.ArgumentNull("comparer");
            }


            int total = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (comparer.Equals(source[i], value))
                        {
                            Interlocked.Increment(ref total);
                            loopState.Stop();
                        }
                    }

                });


            return total > 0;
        }

        /// <summary>
        /// Determines whether an array contains a specified element by using the 
        /// provided IEqualityComparer or the default comparer if none is provided,
        /// in parallel. If using a default comparer, use the non parallel version, it is faster.
        /// </summary>        
        /// <param name="source">An array in which to locate a value.</param>
        /// <param name="value">The value to locate.</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
        public static bool ContainsP<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource> comparer, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (comparer == null)
            {
                throw Error.ArgumentNull("comparer");
            }


            int total = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (comparer.Equals(source[i], value))
                        {
                            Interlocked.Increment(ref total);
                            loopState.Stop();
                        }
                    }

                });


            return total > 0;
        }


    }
}
