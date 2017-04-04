using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JM.LinqFaster.Parallel {
    public static partial class LinqFasterParallel {

        // --------------------------  ARRAYS  --------------------------------------------

        public static TResult[] SelectP<T, TResult>(this T[] a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            var r = new TResult[a.Length];

            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++) {
                        r[i] = selector(a[i]);
                    }
                });
            
            return r;
        }

        public static TResult[] SelectP<T, TResult>(this T[] a, Func<T, int, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }
            var r = new TResult[a.Length];
            var rangePartitioner = Partitioner.Create(0, a.Length);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++) {
                        r[i] = selector(a[i],i);
                    }
                });

            return r;
        }

        // --------------------------  LISTS --------------------------------------------

        public static List<TResult> SelectP<T, TResult>(this List<T> a, Func<T, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            var r = new List<TResult>(a.Count);

            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++) {
                        r[i] = selector(a[i]);
                    }
                });


            return r;
        }


        public static List<TResult> SelectP<T, TResult>(this List<T> a, Func<T, int, TResult> selector)
        {
            if (a == null)
            {
                throw Error.ArgumentNull(nameof(a));
            }

            if (selector == null)
            {
                throw Error.ArgumentNull(nameof(selector));
            }

            var r = new List<TResult>(a.Count);

            var rangePartitioner = Partitioner.Create(0, a.Count);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range, s) => {
                    for (int i = range.Item1; i < range.Item2; i++) {
                        r[i] = selector(a[i],i);
                    }
                });


            return r;
        }

    }
}
