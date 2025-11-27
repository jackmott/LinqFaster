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
        /// Combined Where and Select with the Where phase in parallel.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence of filtered and transformed elements.</returns>     
        public static TResult[] WhereSelectP<T, TResult>(this T[] source, Func<T, bool> predicate, Func<T, TResult> selector, int? batchSize = null)
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
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,               
                (range, loopState,acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
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
                    result[idx] = selector(source[i]);
                    idx++;
                }
            }
            return result;
        }


        /// <summary>
        /// Combined Where and Select with the Where phase in parallel using the
        /// index in the predicate and selector.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence of filtered and transformed elements.</returns>     
        public static TResult[] WhereSelectP<T, TResult>(this T[] source, Func<T,int, bool> predicate, Func<T,int, TResult> selector, int? batchSize = null)
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
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,
                (range, loopState, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i],i))
                        {
                            isChosen[i] = true;
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
                    result[idx] = selector(source[i],idx);
                    idx++;
                }
            }
            return result;
        }

        // -------------------------------- Lists ------------------------------------------

        /// <summary>
        /// Combined Where and Select with the Where phase in parallel.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence of filtered and transformed elements.</returns>     
        public static List<TResult> WhereSelectP<T, TResult>(this List<T> source, Func<T, bool> predicate, Func<T, TResult> selector, int? batchSize = null)
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
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,
                (range, loopState, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
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
                    result.Add(selector(source[i]));                    
                }
            }
            return result;
        }


        /// <summary>
        /// Combined Where and Select with the Where phase in parallel using the
        /// index in the predicate and selector.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>A sequence of filtered and transformed elements.</returns>     
        public static List<TResult> WhereSelectP<T, TResult>(this List<T> source, Func<T, int, bool> predicate, Func<T, int, TResult> selector, int? batchSize = null)
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
            int count = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner, () => 0,
                (range, loopState, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i], i))
                        {
                            isChosen[i] = true;
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
            int idx = 0;
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result.Add(selector(source[i], idx));
                    idx++;
                }
            }
            return result;
        }



    }
}
