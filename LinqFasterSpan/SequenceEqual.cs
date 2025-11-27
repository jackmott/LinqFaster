using System.Collections.Generic;
using System;

namespace JM.LinqFasterSpan
{

    public static partial class LinqFasterSpan
    {

        /*---- Spans ----*/
        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="comparer">An optional Comparer to use for the comparison.</param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>     
        public static bool SequenceEqualF<T>(this Span<T> first, Span<T> second, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Length != second.Length) return false;
            if (first == second) return true;

            for (int i = 0; i < first.Length; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }

            return true;
        }



        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="comparer">An optional Comparer to use for the comparison.</param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualF<T>(this Span<T> first, List<T> second, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Length != second.Count) return false;

            for (int i = 0; i < first.Length; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using the 
        /// provided comparer or the default equality comparer for their type if none is provided.
        /// </summary>        
        /// <param name="first">A sequence to compare to second.</param>
        /// <param name="second">A sequence to compare to first.</param>
        /// <param name="comparer">An optional Comparer to use for the comparison.</param>
        /// <returns>true of the two sources are of equal length and their corresponding 
        /// elements are equal according to the equality comparer. Otherwise, false.</returns>
        public static bool SequenceEqualF<T>(this List<T> first, Span<T> second, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull("first");
            }

            if (second == null)
            {
                throw Error.ArgumentNull("second");
            }

            if (first.Count != second.Length) return false;

            for (int i = 0; i < first.Count; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }

            return true;
        }

    }
}
