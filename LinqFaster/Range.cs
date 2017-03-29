using System.Collections.Generic;

namespace JM.LinqFaster
{
    public static partial class LinqFaster
    {
        public static int[] RangeArray(int start, int count)
        {
            long max = ((long)start) + count - 1;
            if (count < 0 || max > int.MaxValue)
            {
                throw Error.ArgumentOutOfRange(nameof(count));
            }

            if (count == 0)
            {
                return new int[0];
            }

            int[] result = new int[count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i + start;
            }
            return result;

        }
    }

    public static partial class LinqFaster
    {
        public static List<int> RangeList(int start, int count)
        {
            long max = ((long)start) + count - 1;
            if (count < 0 || max > int.MaxValue)
            {
                throw Error.ArgumentOutOfRange(nameof(count));
            }

            if (count == 0)
            {
                return new List<int>();
            }

            var result = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                result.Add(i + count);
            }
            return result;
        }
    }
}
