using System.Collections.Generic;


namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        // --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        /// Returns distinct elements from an array using the provided equality comparer
        /// or the default comparer if none is provided.
        /// </summary>        
        /// <param name="source">The array to remove duplicate elements from.</param>
        /// <param name="comparer">An IEqualityComparer to compare values.</param>
        /// <returns>An array that contains distinct elements from the source array.</returns>
        public static TSource[] DistinctF<TSource>(this TSource[] source, IEqualityComparer<TSource> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (comparer == null) {
                comparer = EqualityComparer<TSource>.Default;
            }


            var dict = new Dictionary<TSource, byte>(comparer);
            for (int i = 0; i < source.Length; i++)
            {
                if (!dict.ContainsKey(source[i]))
                    dict.Add(source[i], 0);
            }
            var result = new TSource[dict.Count];
            dict.Keys.CopyTo(result, 0);
            return result;
        }



        // --------------------------  LISTS --------------------------------------------

        /// <summary>
        /// Returns distinct elements from a list using the provided equality comparer
        /// or the default comparer if none is provided.
        /// </summary>        
        /// <param name="source">The list to remove duplicate elements from.</param>
        /// <param name="comparer">An IEqualityComparer to compare values.</param>
        /// <returns>A list that contains distinct elements from the source list.</returns>
        public static List<TSource> DistinctF<TSource>(this List<TSource> source, IEqualityComparer<TSource> comparer = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (comparer == null) {
                comparer = EqualityComparer<TSource>.Default;
            }

            var dict = new Dictionary<TSource, byte>(comparer);

            for (int i = 0; i < source.Count; i++)
            {
                if (!dict.ContainsKey(source[i]))
                {
                    dict.Add(source[i], 0);
                    //result.Add(source[i]);
                }
            }
            var result = new List<TSource>(dict.Count);
            foreach (var v in dict.Keys)
            {
                result.Add(v);
            }
            return result;
        }
     
    }
}
