using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {
        // --------------------------  ARRAYS  --------------------------------------------
        public static double AverageP(this int[] source)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static double AverageP<T>(this T[] source, Func<T, int> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static double AverageP(this long[] source)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static double AverageP<T>(this T[] source, Func<T, long> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static float AverageP(this float[] source)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static float AverageP<T>(this T[] source, Func<T, float> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static double AverageP(this double[] source)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static double AverageP<T>(this T[] source, Func<T, double> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static decimal AverageP(this decimal[] source)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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

        public static decimal AverageP<T>(this T[] source, Func<T, decimal> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Length);
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
        public static double AverageP(this List<int> source)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static double AverageP<T>(this List<T> source, Func<T, int> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static double AverageP(this List<long> source)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static double AverageP<T>(this List<T> source, Func<T, long> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static double AverageP(this List<float> source)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static double AverageP<T>(this List<T> source, Func<T, float> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static double AverageP(this List<double> source)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static double AverageP<T>(this List<T> source, Func<T, double> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static decimal AverageP(this List<decimal> source)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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

        public static decimal AverageP<T>(this List<T> source, Func<T, decimal> selector)
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
            var rangePartitioner = Partitioner.Create(0, source.Count);
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
