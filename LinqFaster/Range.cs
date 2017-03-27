using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFaster
{
    public static partial class LinqFasterArray
    {
        public static int[] Range(int start, int count)
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
            for (int i = 0; i < result.Length;i++)
            {
                result[i] = i + start;
            }
            return result;

        }        
    }

    public static partial class LinqFasterList
    {
        public static List<int> Range(int start, int count)
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
            for (int i = 0; i < count;i++)
            {
                result.Add(i + count);
            }
            return result;
        }
    }
}
