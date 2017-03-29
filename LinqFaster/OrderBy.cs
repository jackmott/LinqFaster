using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        public static TSource[] OrderByF<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector)
        { 
            return OrderByF(source, keySelector, Comparer<TKey>.Default);
        }

        public static TSource[] OrderByF<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector,Comparer<TKey> comparer)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull(nameof(keySelector));
            }

            var lambdaComparer = new LambdaComparer<TSource, TKey>(keySelector,comparer);
            var result = (TSource[])source.Clone();
            Array.Sort(result, lambdaComparer);
            return result;
        }



        private class LambdaComparer<T, U> : IComparer<T>
        {
            Comparer<U> comparer;
            Func<T, U> selector;

            public LambdaComparer(Func<T, U> selector, Comparer<U> comparer = null)
            {
                if (comparer == null)
                {
                    this.comparer = Comparer<U>.Default;
                }
                else
                {
                    this.comparer = comparer;
                }
                this.selector = selector;
            }

            public int Compare(T x, T y)
            {
                return comparer.Compare(selector(x), selector(y));
            }
        }
    }
}






