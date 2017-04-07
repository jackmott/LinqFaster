using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace JM.LinqFaster.Utils {

    //Takes a comparer, and creates a reverse comparer, for Descending sorts
    internal sealed class ComparerReverser<T> : IComparer<T> {
        private readonly IComparer<T> wrappedComparer;

        public ComparerReverser(IComparer<T> wrappedComparer) {
            this.wrappedComparer = wrappedComparer;
        }
#if !(UNITY_4 || UNITY_5)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public int Compare(T x, T y) {
            return wrappedComparer.Compare(y, x);
        }
    }

    
    internal static class ComparerExtensions {

        // Lets us reverse a comparere with comparer.Reverse();
        public static IComparer<T> Reverse<T>(this IComparer<T> comparer) {
            return new ComparerReverser<T>(comparer);
        }
    }

    internal sealed class LambdaComparer<T, U> : IComparer<T> {
        IComparer<U> comparer;
        Func<T, U> selector;

        public LambdaComparer(Func<T, U> selector, IComparer<U> comparer) {
            this.comparer = comparer;
            this.selector = selector;
        }
#if !(UNITY_4 || UNITY_5)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif      
        public int Compare(T x, T y) {
            return comparer.Compare(selector(x), selector(y));
        }
    }

    internal sealed class ReverseLambdaComparer<T, U> : IComparer<T> {
        IComparer<U> comparer;
        Func<T, U> selector;

        public ReverseLambdaComparer(Func<T, U> selector, IComparer<U> comparer) {
            this.comparer = comparer;
            this.selector = selector;
        }
#if !(UNITY_4 || UNITY_5)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif      
        public int Compare(T x, T y) {
            return comparer.Compare(selector(y), selector(x));
        }
    }
}
