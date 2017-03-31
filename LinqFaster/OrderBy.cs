using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        
        public static TSource[] OrderByF<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector,Comparer<TKey> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull(nameof(keySelector));
            }

            if (comparer == null)
            {
                comparer = Comparer<TKey>.Default;
            }

            var keys = new TKey[source.Length];
            for (long i = 0; i < keys.LongLength; i++)
            {
                keys[i] = keySelector(source[i]);
            }            
            var result = (TSource[])source.Clone();
            Array.Sort(keys,result,comparer);
            return result;
        }
     

        // ---------------------- Lists

        public static List<TSource> OrderByF<TSource, TKey>(this List<TSource> source, Func<TSource, TKey> keySelector, Comparer<TKey> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull(nameof(keySelector));
            }

            if (comparer == null)
            {
                comparer = Comparer<TKey>.Default;
            }

            var result = new List<TSource>(source);
            var lambdaComparer = new LambdaComparer<TSource, TKey>(keySelector, comparer);          
            result.Sort(lambdaComparer);
            return result;
        }

     
        private class LambdaComparer<T, U> : IComparer<T>
        {
            Comparer<U> comparer;
            Func<T, U> selector;

            public LambdaComparer(Func<T, U> selector, Comparer<U> comparer)
            {               
                this.comparer = comparer;               
                this.selector = selector;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Compare(T x, T y)
            {                
                return comparer.Compare(selector(x), selector(y));
            }
        }
    }
}






