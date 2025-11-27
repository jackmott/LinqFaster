using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static JM.LinqFaster.Utils.CustomPartition;

namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel {

        // --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        ///  Projects each element of a sequence into a new form in place using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>       
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        public static void SelectInPlaceP<T>(this T[] source, Func<T, T> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        source[i] = selector(source[i]);
                    }
                });
            
        }

        /// <summary>
        ///  Projects each element of a sequence into a new form, in place, by incorporating the element's index using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>        
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        public static void SelectInPlaceP<T>(this T[] source, Func<T,int, T> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }


            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        source[i] = selector(source[i],i);
                    }
                });

        }

        /// <summary>
        ///  Projects each element of a sequence into a new form using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element.</param>        
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        public static TResult[] SelectP<T, TResult>(this T[] source, Func<T, TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            TResult[] r = new TResult[source.Length];

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++) {
                        r[i] = selector(source[i]);
                    }
                });
            
            return r;
        }

        /// <summary>
        ///  Projects each element of a sequence into a new form by incorporating the element's index using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element of source.</returns>
        public static TResult[] SelectP<T, TResult>(this T[] source, Func<T, int, TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            TResult[] r = new TResult[source.Length];
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++) {
                        r[i] = selector(source[i],i);
                    }
                });

            return r;
        }

        // --------------------------  LISTS --------------------------------------------

        /// <summary>
        ///  Projects each element of a sequence into a new form in place using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>        
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        public static void SelectInPlaceP<T>(this List<T> source, Func<T, T> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }


            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        source[i] = selector(source[i]);
                    }
                });

        }

        /// <summary>
        ///  Projects each element of a sequence into a new form, in place, by incorporating the element's index using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>        
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        public static void SelectInPlaceP<T>(this List<T> source, Func<T, int, T> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }


            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        source[i] = selector(source[i], i);
                    }
                });

        }

        /// <summary>
        ///  Projects each element of a sequence into a new form, in place, by incorporating the element's index using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>        
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        public static List<TResult> SelectP<T, TResult>(this List<T> source, Func<T, TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            TResult[] r = new TResult[source.Count];

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        r[i] = selector(source[i]);
                    }
                });


            return new List<TResult>(r);
        }

        /// <summary>
        ///  Projects each element of a sequence into a new form by incorporating the element's index using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element of source.</returns>
        public static List<TResult> SelectP<T, TResult>(this List<T> source, Func<T, int, TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            TResult[] r = new TResult[source.Count];

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++) {
                        r[i] = selector(source[i], i);
                    }
                });


            return new List<TResult>(r);
        }

        /// <summary>
        ///  Projects each element of a sequence into a new form by incorporating the element's index using multiple Tasks / Threads.
        ///  !!Order of the collection is not preserved!! for more speed and less memory use.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element of source.</returns>
        public static List<TResult> SelectUnorderedP<T, TResult>(this List<T> source, Func<T, int, TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            List<TResult> r = new List<TResult>(source.Count);

            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        r.Add(selector(source[i], i));
                    }
                });


            return r;
        }

    }
}
