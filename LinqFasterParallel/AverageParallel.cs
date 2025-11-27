using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using static JM.LinqFaster.Utils.CustomPartition;


namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {
        // --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP(this int[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += source[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP<T>(this T[] source, Func<T, int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(source[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP(this long[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += source[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP<T>(this T[] source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(source[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageP(this float[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += source[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageP<T>(this T[] source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(source[i]);
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP(this double[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += source[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP<T>(this T[] source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(source[i]);
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageP(this decimal[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            decimal sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += source[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });


            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageP<T>(this T[] source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }


            decimal sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(source[i]);
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });


            return sum / source.Length;
        }

        // --------------------------  Lists  --------------------------------------------

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP(this List<int> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;            
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += source[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>        
        /// <returns>The average of the array.</returns>
        public static double AverageP<T>(this List<T> source, Func<T, int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(source[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP(this List<long> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += source[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP<T>(this List<T> source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(source[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP(this List<float> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += source[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });
            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP<T>(this List<T> source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(source[i]);
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP(this List<double> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            double sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += source[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageP<T>(this List<T> source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(source[i]);
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a sequence in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the average of.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageP(this List<decimal> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            decimal sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += source[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array in parallel.
        /// </summary>
        /// <param name="source">The array to calculate the transformed average of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageP<T>(this List<T> source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }


            decimal sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(source[i]);
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum / source.Count;


        }
    }
}
