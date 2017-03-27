using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFaster
{
    public static class AverageFuncs
    {
        public static double Average(this int[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            long sum = 0;            
            for (long i = 0; i < source.LongLength;i++)
            {
                sum += source[i];                
            }
            return 1.0;

        }
    }
}
