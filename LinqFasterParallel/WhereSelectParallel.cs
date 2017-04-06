using System;
using System.Collections.Generic;
using System.Threading;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {
        /// <summary>
        /// Combined Where and Select for optimal performance.
        /// </summary>        
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        
            /*
        public static TResult[] WhereSelectP<T, TResult>(this T[] source, Func<T, bool> predicate, Func<T, TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            object LOCK = new object();
            var results = new TResult[source.Length];
            int idx = 0;
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,                
                (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (predicate(source[i]))
                        {
                            var result = selector(source[i]);
                            do {
                                var localCopy = idx;
                                results[idx] = result;
                            }
                            idx++;
                            
                        }
                    }                    
                });

            Array.Resize(ref results, idx);
            return results;
        }*/
    }
}

