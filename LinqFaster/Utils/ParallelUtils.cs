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
     
        public static T ForVectorAggregate<T>(T[] a,T acc, Func<T[], int, int, T> f, Func<T,T,T> combiner)
         where T : struct
        {
            int stride = Vector<T>.Count;

            int vectorLen = a.Length - a.Length % stride;

            int numStrides = vectorLen / stride;
            if (numStrides <= 0)
                return acc;

            int numTasks = Math.Min(Environment.ProcessorCount, numStrides);
            int stridesPerTask = numStrides / numTasks;
            int elementsPerTask = stridesPerTask * stride;
            int remainderStrides = numStrides - (stridesPerTask * numTasks);

            var tasks = new Task<T>[numTasks];
            int index = 0;
            for (int i = 0; i < tasks.Length; i++) {
                int toExc;
                if (remainderStrides == 0) {
                    toExc = index + elementsPerTask;
                }
                else {
                    remainderStrides--;
                    toExc = index + elementsPerTask + stride;
                }
                int fromClosure = index;
                tasks[i] = Task<T>.Factory.StartNew(() => f(a, fromClosure, toExc));
                index = toExc;
            }
            var result = acc;
            for (int i = 0; i < tasks.Length; i++) {
                result = combiner(result, tasks[i].Result);
            }
            return result;


        }

        public static void ForVector<T,U>(T[] a,U[] result,Func<Vector<T>,Vector<U>> selector,Action<T[],U[],Func<Vector<T>,Vector<U>>,int,int> f)
            where T : struct
            where U : struct
        {
            int stride = Vector<T>.Count;

            int vectorLen = a.Length - a.Length % stride;

            int numStrides = vectorLen / stride;

            int numTasks = Math.Min(Environment.ProcessorCount, numStrides);
            int stridesPerTask = numStrides / numTasks;
            int elementsPerTask = stridesPerTask * stride;
            int remainderStrides = numStrides - (stridesPerTask * numTasks);

            var tasks = new Task[numTasks];
            int index = 0;
            for (int i = 0; i < tasks.Length; i++) {
                int toExc;
                if (remainderStrides == 0) {
                    toExc = index + elementsPerTask;
                }
                else {
                    remainderStrides--;
                    toExc = index + elementsPerTask + stride;
                }
                int fromClosure = index;
                tasks[i] = Task.Factory.StartNew(() => f(a, result, selector, fromClosure, toExc));
                index = toExc;
            }

            for (int i = 0; i < tasks.Length; i++) {
                tasks[i].Wait();
            }

        }
    }
}
