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
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int SumP(this int[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            int sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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

            return sum;
        }


        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int SumP<T>(this T[] source, Func<T, int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static long SumP(this long[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long SumP<T>(this T[] source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float SumP(this float[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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
                 acc =>
                 {
                     lock (LOCK)
                     {
                         sum += acc;
                     }
                 });

            return (float)sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static float SumP<T>(this T[] source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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
                 acc =>
                 {
                     lock (LOCK)
                     {
                         sum += acc;
                     }
                 });


            return (float)sum;
        }

        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double SumP(this double[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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
                 acc =>
                 {
                     lock (LOCK)
                     {
                         sum += acc;
                     }
                 });


            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double SumP<T>(this T[] source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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
                 acc =>
                 {
                     lock (LOCK)
                     {
                         sum += acc;
                     }
                 });


            return sum;
        }


        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal SumP(this decimal[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            decimal sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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
                 acc =>
                 {
                     lock (LOCK)
                     {
                         sum += acc;
                     }
                 });


            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal SumP<T>(this T[] source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            decimal sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Length,batchSize);
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
                 acc =>
                 {
                     lock (LOCK)
                     {
                         sum += acc;
                     }
                 });

            return sum;
        }

        // --------------------------  LISTS  --------------------------------------------

        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int SumP(this List<int> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            int sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int SumP<T>(this List<T> source, Func<T, int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
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

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The sum of the sequence.</returns>
        public static long SumP(this List<long> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
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

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long SumP<T>(this List<T> source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
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

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float SumP(this List<float> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
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

            return (float)sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static float SumP<T>(this List<T> source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
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

            return (float)sum;
        }


        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double SumP(this List<double> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
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

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double SumP<T>(this List<T> source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
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
                 acc => { lock (LOCK) { sum += acc; } });

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values using multiple Tasks / Threads.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal SumP(this List<decimal> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            decimal sum = 0;

            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
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


            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <param name="batchSize">Optional custom batch size to divide work into.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal SumP<T>(this List<T> source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            decimal sum = 0;
            object LOCK = new object();
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = MakePartition(source.Count,batchSize);
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

            return sum;
        }

    }
}
