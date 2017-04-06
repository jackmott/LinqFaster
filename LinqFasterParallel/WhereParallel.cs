using System;
using System.Collections.Generic;
using System.Threading;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate in parallel.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static TSource[] WhereP<TSource>(this TSource[] source, Func<TSource, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Length];
            int count = 0;
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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
            var result = new TSource[count];
            int idx = 0;
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result[idx] = source[i];
                    idx++;
                }
            }
            return result;
        }

       

        /// <summary>
        /// Filters a sequence of values in parallel based on a predicate that includes the index in it's logic.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition along with the element's index.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static TSource[] WhereP<TSource>(this TSource[] source, Func<TSource,int, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Length];
            int count = 0;
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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
            var result = new TSource[count];
            int idx = 0;
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result[idx] = source[i];
                    idx++;
                }
            }
            return result;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate in parallel.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static List<TSource> WhereP<TSource>(this List<TSource> source, Func<TSource, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Count];
            int count = 0;
            var rangePartitioner = MakePartition(source.Count, batchSize);
            
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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

            List<TSource> result = new List<TSource>(count);            
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result.Add(source[i]);                    
                }
            }
            return result;
        }

        /// <summary>
        /// Filters a sequence of values in parallel based on a predicate that includes the index in it's logic.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition along with the element's index.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static List<TSource> WhereP<TSource>(this List<TSource> source, Func<TSource,int, bool> predicate, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Count];
            int count = 0;
            var rangePartitioner = MakePartition(source.Count, batchSize);

            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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

            List<TSource> result = new List<TSource>(count);            
            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                {
                    result.Add(source[i]);                    
                }
            }
            return result;
        }
    }
}

