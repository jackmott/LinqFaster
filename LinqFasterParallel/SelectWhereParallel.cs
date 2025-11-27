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
        /// Combines Select and Where into a single call in parallel.
        /// </summary>        
        /// <param name="source">The input sequence to filter and select</param>
        /// <param name="selector">The transformation to apply before filtering.</param>
        /// <param name="predicate">The predicate with which to filter result.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence transformed and then filtered by selector and predicate.</returns>
        public static TResult[] SelectWhereP<T, TResult>(this T[] source, Func<T, TResult> selector, Func<TResult, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }
            
            bool[] isChosen = new bool[source.Length];
            TResult[] tempResults = new TResult[source.Length];
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,               
                (range, loopState,acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        TResult s = selector(source[i]);
                        if (predicate(s))
                        {
                            isChosen[i] = true;
                            tempResults[i] = s;
                            acc++;
                        }                        
                    }
                    return acc;
                },
                 acc =>
                 {
                     Interlocked.Add(ref count, acc);
                 });

            TResult[] result = new TResult[count];
            int idx = 0;
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result[idx] = tempResults[i];
                    idx++;
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Select and Where into a single call in parallel with indexes
        /// </summary>        
        /// <param name="source">The input sequence to filter and select</param>
        /// <param name="selector">The transformation to apply before filtering.</param>
        /// <param name="predicate">The predicate with which to filter result.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence transformed and then filtered by selector and predicate.</returns>
        public static TResult[] SelectWhereP<T, TResult>(this T[] source, Func<T, int,TResult> selector, Func<TResult,int, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Length];
            TResult[] tempResults = new TResult[source.Length];
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,
                (range, loopState, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        TResult s = selector(source[i],i);
                        if (predicate(s,i))
                        {
                            isChosen[i] = true;
                            tempResults[i] = s;
                            acc++;
                        }
                    }
                    return acc;
                },
                 acc =>
                 {
                     Interlocked.Add(ref count, acc);
                 });

            TResult[] result = new TResult[count];
            int idx = 0;
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result[idx] = tempResults[i];
                    idx++;
                }
            }
            return result;
        }


        //------------------------------------ Lists --------------------------------------
        /// <summary>
        /// Combines Select and Where into a single call in parallel.
        /// </summary>        
        /// <param name="source">The input sequence to filter and select</param>
        /// <param name="selector">The transformation to apply before filtering.</param>
        /// <param name="predicate">The predicate with which to filter result.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence transformed and then filtered by selector and predicate.</returns>
        public static List<TResult> SelectWhereP<T, TResult>(this List<T> source, Func<T, TResult> selector, Func<TResult, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Count];
            TResult[] tempResults = new TResult[source.Count];
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,
                (range, loopState, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        TResult s = selector(source[i]);
                        if (predicate(s))
                        {
                            isChosen[i] = true;
                            tempResults[i] = s;
                            acc++;
                        }
                    }
                    return acc;
                },
                 acc =>
                 {
                     Interlocked.Add(ref count, acc);
                 });

            List<TResult> result = new List<TResult>(count);            
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result.Add(tempResults[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Select and Where into a single call in parallel with indexes
        /// </summary>        
        /// <param name="source">The input sequence to filter and select</param>
        /// <param name="selector">The transformation to apply before filtering.</param>
        /// <param name="predicate">The predicate with which to filter result.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence transformed and then filtered by selector and predicate.</returns>
        public static List<TResult> SelectWhereP<T, TResult>(this List<T> source, Func<T, int, TResult> selector, Func<TResult, int, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Count];
            TResult[] tempResults = new TResult[source.Count];
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,
                (range, loopState, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        TResult s = selector(source[i], i);
                        if (predicate(s, i))
                        {
                            isChosen[i] = true;
                            tempResults[i] = s;
                            acc++;
                        }
                    }
                    return acc;
                },
                 acc =>
                 {
                     Interlocked.Add(ref count, acc);
                 });

            List<TResult> result = new List<TResult>(count);            
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result.Add(tempResults[i]);                    
                }
            }
            return result;
        }

    }
}

