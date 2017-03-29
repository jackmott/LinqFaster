using System.Collections.Generic;


namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {

        // --------------------------  ARRAYS  --------------------------------------------
        public static TSource[] DistinctF<TSource>(this TSource[] source, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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

        public static TSource[] DistinctF<TSource>(this TSource[] source)
        {
            return DistinctF(source, EqualityComparer<TSource>.Default);
        }


        // --------------------------  LISTS --------------------------------------------
        public static List<TSource> DistinctF<TSource>(this List<TSource> source, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
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

        public static List<TSource> DistinctF<TSource>(this List<TSource> source)
        {
            return DistinctF(source, EqualityComparer<TSource>.Default);
        }


    }
}
