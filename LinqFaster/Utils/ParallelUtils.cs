using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.LinqFaster.Utils
{
    public static class ParallelUtils
    {
        public static T ApplyTaskAggregate<T>(int from, int to, int stride, T acc, Func<int,T,T> f)
        {
            for (int i = from; i < to; i+=stride)
            {
                acc = f(i, acc);
            }
            return acc;
        }

        public static T ForStrideAggregate<T>(int from, int to, int stride, T acc, Func<int,T,T> f, Func<T,T,T> combiner )
        {
            int numStrides = (to - from) / stride;
            if (numStrides <= 0) return acc;

            int numTasks = Math.Min(Environment.ProcessorCount, numStrides);
            int stridesPerTask = numStrides / numTasks;
            int elementsPerTask = stridesPerTask * stride;
            int remainderStrides = numStrides - (stridesPerTask * numTasks);

            var tasks = new Task<T>[numTasks];
            int index = 0;
            for (int i =0; i < tasks.Length;i++)
            {
                int toExc;
                if (remainderStrides == 0)
                {
                    toExc = index + elementsPerTask;
                } else
                {
                    remainderStrides--;
                    toExc = index + elementsPerTask + stride;
                }
                tasks[i] = Task<T>.Factory.StartNew(() => ApplyTaskAggregate(index, toExc, stride, acc, f));
                index = toExc;
            }
            for (int i = 0; i < tasks.Length;i++)
            {
                acc = combiner(acc, tasks[i].Result);
            }
            return acc;

        }
    }
}
