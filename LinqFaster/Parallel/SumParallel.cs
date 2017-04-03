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

        public static int SumP(this int[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            int sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += a[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }

        public static int SumPB(this int[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            int sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Length,a.Length/4);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += a[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }


        public static int SumP<T>(this T[] a, Func<T, int> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(a[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }

        public static long SumP(this long[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            long sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += a[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }

        public static long SumP<T>(this T[] a, Func<T, long> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(a[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }


        public static float SumP(this float[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {

                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += a[i];
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

        public static float SumP<T>(this T[] a, Func<T, float> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(a[i]);
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


        public static double SumP(this double[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += a[i];
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

        public static double SumP<T>(this T[] a, Func<T, double> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(a[i]);
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


        public static decimal SumP(this decimal[] a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            decimal sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += a[i];
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

        public static decimal SumP<T>(this T[] a, Func<T, decimal> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            decimal sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(a[i]);
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

        public static int SumP(this List<int> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            int sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += a[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }

        public static int SumP<T>(this List<T> a, Func<T, int> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            int sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(a[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }

        public static long SumP(this List<long> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            long sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += a[i];
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }

        public static long SumP<T>(this List<T> a, Func<T, long> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            long sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0L,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(a[i]);
                        }
                    }
                    return acc;
                },
                 acc => Interlocked.Add(ref sum, acc));

            return sum;
        }


        public static float SumP(this List<float> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += a[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return (float)sum;
        }

        public static float SumP<T>(this List<T> a, Func<T, float> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(a[i]);
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return (float)sum;
        }


        public static double SumP(this List<double> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += a[i];
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum;
        }

        public static double SumP<T>(this List<T> a, Func<T, double> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            double sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => 0.0,
                (range, s, acc) =>
                {
                    checked
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            acc += selector(a[i]);
                        }
                    }
                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum;
        }

        public static decimal SumP(this List<decimal> a)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }
            decimal sum = 0;

            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {

                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += a[i];
                    }

                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });


            return sum;
        }

        public static decimal SumP<T>(this List<T> a, Func<T, decimal> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            decimal sum = 0;
            object LOCK = new object();
            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => (decimal)0.0,
                (range, s, acc) =>
                {

                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        acc += selector(a[i]);
                    }

                    return acc;
                },
                 acc => { lock (LOCK) { sum += acc; } });

            return sum;
        }

    }
}
