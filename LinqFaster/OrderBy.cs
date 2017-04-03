using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JM.LinqFaster.Utils;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        
        public static TSource[] OrderByF<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector,IComparer<TKey> comparer = null)
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

        public static TSource[] OrderByDescendingF<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer = null) {
            if (source == null) {
                throw Error.ArgumentNull(nameof(source));
            }

            if (keySelector == null) {
                throw Error.ArgumentNull(nameof(keySelector));
            }

            if (comparer == null) {
                comparer = Comparer<TKey>.Default;
            }

            var keys = new TKey[source.Length];
            for (long i = 0; i < keys.LongLength; i++) {
                keys[i] = keySelector(source[i]);
            }
            var result = (TSource[])source.Clone();
            Array.Sort(keys, result, comparer.Reverse());
            return result;
        }


        // ---------------------- Lists

        public static List<TSource> OrderByF<TSource, TKey>(this List<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer = null)
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

        public static List<TSource> OrderByDescendingF<TSource, TKey>(this List<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer = null) {
            if (source == null) {
                throw Error.ArgumentNull(nameof(source));
            }

            if (keySelector == null) {
                throw Error.ArgumentNull(nameof(keySelector));
            }

            if (comparer == null) {
                comparer = Comparer<TKey>.Default;
            }

            var result = new List<TSource>(source);
            var lambdaComparer = new ReverseLambdaComparer<TSource, TKey>(keySelector, comparer);
            result.Sort(lambdaComparer);
            return result;
        }



    }
}






