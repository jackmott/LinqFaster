using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace JM.LinqFaster.Utils
{

    //Takes a comparer, and creates a reverse comparer, for Descending sorts
    public sealed class ComparerReverser<T> : IComparer<T>
    {
        private readonly IComparer<T> wrappedComparer;

        public ComparerReverser(IComparer<T> wrappedComparer)
        {
            this.wrappedComparer = wrappedComparer;
        }

#if UNITY_CONFIG
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public int Compare(T x, T y)
        {
            return wrappedComparer.Compare(y, x);
        }
    }


    public static class ComparerExtensions
    {

        // Lets us reverse a comparere with comparer.Reverse();
        public static IComparer<T> Reverse<T>(this IComparer<T> comparer)
        {
            return new ComparerReverser<T>(comparer);
        }
    }

    public sealed class LambdaComparer<T, U> : IComparer<T>
    {
        IComparer<U> comparer;
        Func<T, U> selector;

        public LambdaComparer(Func<T, U> selector, IComparer<U> comparer)
        {
            this.comparer = comparer;
            this.selector = selector;
        }
#if UNITY_CONFIG
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public int Compare(T x, T y)
        {
            return comparer.Compare(selector(x), selector(y));
        }
    }

    public sealed class ReverseLambdaComparer<T, U> : IComparer<T>
    {
        IComparer<U> comparer;
        Func<T, U> selector;

        public ReverseLambdaComparer(Func<T, U> selector, IComparer<U> comparer)
        {
            this.comparer = comparer;
            this.selector = selector;
        }

#if UNITY_CONFIG
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public int Compare(T x, T y)
        {
            return comparer.Compare(selector(y), selector(x));
        }
    }
}
