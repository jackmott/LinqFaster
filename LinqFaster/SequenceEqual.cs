using System.Collections.Generic;

namespace JM.LinqFaster
{

    public static partial class LinqFaster
    {
        public static bool SequenceEqualF<T>(T[] first, T[] second, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull(nameof(first));
            }

            if (second == null)
            {
                throw Error.ArgumentNull(nameof(second));
            }

            if (first.Length != second.Length) return false;

            for (int i = 0; i < first.Length; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }

            return true;
        }


        public static bool SequenceEqualF<T>(List<T> first, List<T> second, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull(nameof(first));
            }

            if (second == null)
            {
                throw Error.ArgumentNull(nameof(second));
            }

            if (first.Count != second.Count) return false;

            for (int i = 0; i < first.Count; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }

            return true;
        }

        public static bool SequenceEqualF<T>(T[] first, List<T> second, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull(nameof(first));
            }

            if (second == null)
            {
                throw Error.ArgumentNull(nameof(second));
            }

            if (first.Length != second.Count) return false;

            for (int i = 0; i < first.Length; i++)
            {
                if (!comparer.Equals(first[i], second[i])) return false;
            }

            return true;
        }

        public static bool SequenceEqualF<T>(List<T> first, T[] second, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            if (first == null)
            {
                throw Error.ArgumentNull(nameof(first));
            }

            if (second == null)
            {
                throw Error.ArgumentNull(nameof(second));
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
