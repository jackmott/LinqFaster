using System;

namespace JM.LinqFasterSpan
{
    public static partial class LinqFasterSpan
    {

        
        // --------------------------  this Spans --------------------------------------------

        /// <summary>
        /// Returns a number that represents how many elements in the specified
        /// array satisfy a condition.
        /// </summary>        
        /// <param name="source">An array that contains elements to be tested and counted.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A number that represents how many elements in the array satisfy the condition
        /// in the predicate function.</returns>
        public static int CountF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            int count = 0;
            for (int i = 0; i < source.Length; i++)
            {
                checked
                {
                    if (predicate(source[i]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }


    }
}
