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
        public static TSource[] OrderBy<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector)
        {
            return null;
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
                var xS = selector(x);
                var yS = selector(y);

                return comparer.Compare(xS, yS);
            }
        }
    }
}






