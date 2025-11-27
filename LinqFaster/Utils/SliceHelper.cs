using System;
using System.Runtime.CompilerServices;

namespace JM.LinqFaster
{
    public static class SliceHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> Slice<T>(this T[] array, int start, int len)
        {
            return array.AsSpan().Slice(start, len);
        }
    }
}
