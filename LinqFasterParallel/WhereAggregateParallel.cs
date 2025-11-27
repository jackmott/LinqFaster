using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {

        /// <summary>
        /// Combines Where and Aggregate and performs the Where phase in parallel.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>        
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TSource WhereAggregateP<TSource>(this TSource[] source, Func<TSource, bool> predicate, Func<TSource, TSource, TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            bool[] isChosen = new bool[source.Length];            
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TSource result = default(TSource);

            int idx = 0;
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = source[idx];
                    idx++;
                    break;
                }
            }
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = func(result, source[idx]);
                }
            }            
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate with index, run the where phase in parallel.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence and it's index with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TSource WhereAggregateP<TSource>(this TSource[] source, Func<TSource,int, bool> predicate, Func<TSource, TSource,TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            bool[] isChosen = new bool[source.Length];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i],i))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TSource result = default(TSource);

            int idx = 0;            
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = source[idx];                    
                    idx++;
                    break;
                }
            }
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = func(result, source[idx]);                    
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed, 
        /// perform the Where phase in parallel.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TAccumulate WhereAggregateP<TSource, TAccumulate>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Length];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TAccumulate result = seed;

            for (int i = 0; i < isChosen.Length;i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return result;

        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed and a result transformation.
        /// Perform the where phase in parallel.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="resultSelector">A function to transform the final result.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated then transformed sequence.</returns>
        public static TResult WhereAggregateP<TSource, TAccumulate,TResult>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Length];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TAccumulate result = seed;

            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return resultSelector(result);

        }


        //----------------------- Lists ----------------------------------

        /// <summary>
        /// Combines Where and Aggregate and performs the Where phase in parallel.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TSource WhereAggregateP<TSource>(this List<TSource> source, Func<TSource, bool> predicate, Func<TSource, TSource, TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            bool[] isChosen = new bool[source.Count];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TSource result = default(TSource);

            int idx = 0;
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = source[idx];
                    idx++;
                    break;
                }
            }
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = func(result, source[idx]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate with index for optimal performance
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence and it's index with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TSource WhereAggregateP<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate, Func<TSource, TSource, TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            bool[] isChosen = new bool[source.Count];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i], i))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TSource result = default(TSource);

            int idx = 0;
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = source[idx];
                    idx++;
                    break;
                }
            }
            for (; idx < isChosen.Length; idx++)
            {
                if (isChosen[idx])
                {
                    result = func(result, source[idx]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TAccumulate WhereAggregateP<TSource, TAccumulate>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Count];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TAccumulate result = seed;

            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return result;

        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed and a result transformation.
        /// Perform the where phase in parallel.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="resultSelector">A function to transform the final result.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The filtered then aggregated then transformed sequence.</returns>
        public static TResult WhereAggregateP<TSource, TAccumulate, TResult>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            bool[] isChosen = new bool[source.Count];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            isChosen[i] = true;
                        }
                    }
                });

            TAccumulate result = seed;

            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return resultSelector(result);

        }

    }
}

