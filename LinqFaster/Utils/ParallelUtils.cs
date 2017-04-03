using System;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;

namespace JM.LinqFaster.Utils
{
    public static class ParallelUtils
    {
        public static int GetElementsPerRangeVector(int len, int stride)
        {
            int numStrides = len / stride;
            int numRanges = Math.Min(Environment.ProcessorCount, numStrides);
            int stridesPerTask = numStrides / numRanges;
            return stridesPerTask * stride;
        }
        public static T ForVectorAggregate<T>(T[] a,T acc, Func<T[], int, int, T> f, Func<T,T,T> combiner)
         where T : struct
        {
            int stride = Vector<T>.Count;
            int vectorLen = a.Length - a.Length % stride;
            if (vectorLen/stride <= 0) return acc;

            object LOCK = new object();
            int x = GetElementsPerRangeVector(vectorLen, stride);
            var rangePartitioner = Partitioner.Create(0, vectorLen, GetElementsPerRangeVector(vectorLen, stride));
            
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => acc,
                (range, s, accum) => f(a, range.Item1, range.Item2),
                accum =>
                {
                    lock (LOCK)
                    { 
                        acc = combiner(acc, accum);
                    }
                });
            
            return acc;

        }

        public static void ForVector<T,U>(T[] a,U[] result,Func<Vector<T>,Vector<U>> selector,Action<T[],U[],Func<Vector<T>,Vector<U>>,int,int> f)
            where T : struct
            where U : struct
        {
            int stride = Vector<T>.Count;
            int vectorLen = a.Length - a.Length % stride;
            if (vectorLen / stride <= 0) return;

            var rangePartitioner = Partitioner.Create(0,vectorLen, GetElementsPerRangeVector(vectorLen, stride));
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                (range) => f(a,result,selector,range.Item1, range.Item2));

        }
    }
}
