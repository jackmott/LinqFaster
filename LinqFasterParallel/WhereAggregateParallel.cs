using System;
using System.Collections.Generic;
using System.Threading;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {
        
        public static TSource WhereAggregateP<TSource>(this TSource[] source, Func<TSource, bool> predicate, Func<TSource, TSource, TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            bool[] isChosen = new bool[source.Length];            
            var rangePartitioner = MakePartition(source.Length, batchSize);
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

            var result = default(TSource);

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

        public static TSource WhereAggregateP<TSource>(this TSource[] source, Func<TSource,int, bool> predicate, Func<TSource, TSource,TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            bool[] isChosen = new bool[source.Length];
            var rangePartitioner = MakePartition(source.Length, batchSize);
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

            var result = default(TSource);

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

        public static TAccumulate WhereAggregateP<TSource, TAccumulate>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            bool[] isChosen = new bool[source.Length];
            var rangePartitioner = MakePartition(source.Length, batchSize);
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

            var result = seed;

            for (int i = 0; i < isChosen.Length;i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return result;

        }

        public static TResult WhereAggregateP<TSource, TAccumulate,TResult>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            bool[] isChosen = new bool[source.Length];
            var rangePartitioner = MakePartition(source.Length, batchSize);
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

            var result = seed;

            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return resultSelector(result);

        }


        //----------------------- Lists
        public static TSource WhereAggregateP<TSource>(this List<TSource> source, Func<TSource, bool> predicate, Func<TSource, TSource, TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            bool[] isChosen = new bool[source.Count];
            var rangePartitioner = MakePartition(source.Count, batchSize);
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

            var result = default(TSource);

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

        public static TSource WhereAggregateP<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate, Func<TSource, TSource, TSource> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            bool[] isChosen = new bool[source.Count];
            var rangePartitioner = MakePartition(source.Count, batchSize);
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

            var result = default(TSource);

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

        public static TAccumulate WhereAggregateP<TSource, TAccumulate>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            bool[] isChosen = new bool[source.Count];
            var rangePartitioner = MakePartition(source.Count, batchSize);
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

            var result = seed;

            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return result;

        }

        public static TResult WhereAggregateP<TSource, TAccumulate, TResult>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (func == null)
            {
                throw Error.ArgumentNull(nameof(func));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull(nameof(predicate));
            }

            bool[] isChosen = new bool[source.Count];
            var rangePartitioner = MakePartition(source.Count, batchSize);
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

            var result = seed;

            for (int i = 0; i < isChosen.Length; i++)
            {
                if (isChosen[i])
                    result = func(result, source[i]);
            }
            return resultSelector(result);

        }

    }
}

