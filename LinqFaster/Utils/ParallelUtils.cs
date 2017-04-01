using System;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace JM.LinqFaster.Utils
{
    public static class ParallelUtils
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> AddVectors<T>(Vector<T> a, Vector<T> b)
          where T : struct
        {
            return a + b;
        }


        public static Vector<T> ApplyTaskAggregate<T>(T[] a,int from, int to, int stride, Vector<T> acc, Func<Vector<T>, Vector<T>, Vector<T>> combiner)
            where T : struct
        {
            for (int i = from; i < to; i += stride)
            {
                acc = combiner(acc, new Vector<T>(a, i));
            }
            return acc;
        }

        public static T ForVectorAggregate<T>(T[] a, T acc, Func<T[],int,int,T> f, Func<T,T,T> combiner)
            where T : struct
        {
            int stride = Vector<T>.Count;

            int vectorLen = a.Length - a.Length % stride;

            int numStrides = vectorLen / stride;
            if (numStrides <= 0) return acc;

            int numTasks = Math.Min(Environment.ProcessorCount, numStrides);
            int stridesPerTask = numStrides / numTasks;
            int elementsPerTask = stridesPerTask * stride;
            int remainderStrides = numStrides - (stridesPerTask * numTasks);

            var tasks = new Task<T>[numTasks];
            int index = 0;
            for (int i = 0; i < tasks.Length; i++)
            {
                int toExc;
                if (remainderStrides == 0)
                {
                    toExc = index + elementsPerTask;
                }
                else
                {
                    remainderStrides--;
                    toExc = index + elementsPerTask + stride;
                }
                int fromClosure = index;
                tasks[i] = Task<T>.Factory.StartNew(() => f(a,fromClosure, toExc));
                index = toExc;
            }
            var result = acc;
            for (int i = 0; i < tasks.Length; i++)
            {
                result = combiner(result, tasks[i].Result);
            }
            return result;

        }
    }
}
