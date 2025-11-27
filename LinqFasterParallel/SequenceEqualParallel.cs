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
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="comparer">An optional Comparer to use for the comparison.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualP<T>(this T[] first, T[] second, IEqualityComparer<T> comparer = null, int? batchSize = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

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
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(first.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,               
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (!comparer.Equals(first[i], second[i]))
                        {
                            Interlocked.Increment(ref count);
                            loopState.Break();
                        }
                    }
                    
                });

            return count == 0;
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="comparer">An optional Comparer to use for the comparison.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualP<T>(this List<T> first, List<T> second, IEqualityComparer<T> comparer = null, int? batchSize = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Count != second.Count) return false;
            if (first == second) return true;

            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(first.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (!comparer.Equals(first[i], second[i]))
                        {
                            Interlocked.Increment(ref count);
                            loopState.Break();
                        }
                    }

                });

            return count == 0;            
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="comparer">An optional Comparer to use for the comparison.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualP<T>(this T[] first, List<T> second, IEqualityComparer<T> comparer = null, int? batchSize = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Length != second.Count) return false;

            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(first.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (!comparer.Equals(first[i], second[i]))
                        {
                            Interlocked.Increment(ref count);
                            loopState.Break();
                        }
                    }

                });

            return count == 0;
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="comparer">An optional Comparer to use for the comparison.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualP<T>(this List<T> first, T[] second, IEqualityComparer<T> comparer = null, int? batchSize = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Count != second.Length) return false;

            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(first.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (!comparer.Equals(first[i], second[i]))
                        {
                            Interlocked.Increment(ref count);
                            loopState.Break();
                        }
                    }

                });

            return count == 0;            
        }
    }
}
