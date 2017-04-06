using System;
using System.Collections.Generic;
using JM.LinqFaster.Utils;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// Unlike standard Linq NOT a stable sort.
        /// </summary>        
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">A Comparer to compare keys.</param>
        /// <returns>A sequence whose alements are ordered according to a key</returns>
        public static TSource[] OrderByF<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector,IComparer<TKey> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (comparer == null)
            {
                comparer = Comparer<TKey>.Default;
            }

            var keys = new TKey[source.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = keySelector(source[i]);
            }            
            var result = (TSource[])source.Clone();
            Array.Sort(keys,result,comparer);                        
            return result;
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key.
        /// Unlike standard Linq NOT a stable sort.
        /// </summary>        
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">A Comparer to compare keys.</param>
        /// <returns>A sequence whose alements are ordered according to a key</returns>
        public static TSource[] OrderByDescendingF<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer = null) {
            if (source == null) {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null) {
                throw Error.ArgumentNull("keySelector");
            }

            if (comparer == null) {
                comparer = Comparer<TKey>.Default;
            }

            var keys = new TKey[source.Length];
            for (int i = 0; i < keys.Length; i++) {
                keys[i] = keySelector(source[i]);
            }
            var result = (TSource[])source.Clone();
            Array.Sort(keys, result, comparer.Reverse());
            return result;
        }


        // ---------------------- Lists

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// Unlike standard Linq NOT a stable sort.
        /// </summary>        
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">A Comparer to compare keys.</param>
        /// <returns>A sequence whose alements are ordered according to a key</returns>
        public static List<TSource> OrderByF<TSource, TKey>(this List<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
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

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key.
        /// Unlike standard Linq NOT a stable sort.
        /// </summary>        
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">A Comparer to compare keys.</param>
        /// <returns>A sequence whose alements are ordered according to a key</returns>
        public static List<TSource> OrderByDescendingF<TSource, TKey>(this List<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer = null) {
            if (source == null) {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null) {
                throw Error.ArgumentNull("keySelector");
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






