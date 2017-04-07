#if !(UNITY_4 || UNITY_5)

using System;
using System.Runtime.CompilerServices;

/*

    C# has no way to constrain a generic to only primitive types.
    You can only constrain them to value types via:
        where T : struct
    All primitives are value types but not all value types are
    primitives. Thus, when you try to do operations like + > < ==
    on generic value types, you get a compiler error.  These methods
    work around that by checking the type, casting, and performing the 
    operation.  The JIT elides all of the non relevant bits of the If statement
    for each generic type, so this is remarkably still fast.  Since these are
    only used for the SIMD specific operations, and the SIMD library
    works exactly this way as well, it does not add any problems that
    don't already exist when you use .NET SIMD.  Which is, if you create a 
    Vector<T> where T is a non primitive value type, you will get a runtime error.
 */
namespace JM.LinqFaster.Utils
{
    internal static class GenericOperators
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Add<T>(T a, T b)
        {
            if (typeof(T) == typeof(Byte))
            {
                return (T)(object)((Byte)(object)a + (Byte)(object)b);
            }
            else if (typeof(T) == typeof(SByte))
            {
                return (T)(object)((SByte)(object)a + (SByte)(object)b);
            }
            else if (typeof(T) == typeof(UInt16))
            {
                return (T)(object)((UInt16)(object)a + (UInt16)(object)b);
            }
            else if (typeof(T) == typeof(Int16))
            {
                return (T)(object)((Int16)(object)a + (Int16)(object)b);
            }
            else if (typeof(T) == typeof(UInt32))
            {
                return (T)(object)((UInt32)(object)a + (UInt32)(object)b);
            }
            else if (typeof(T) == typeof(Int32))
            {
                return (T)(object)((Int32)(object)a + (Int32)(object)b);
            }
            else if (typeof(T) == typeof(UInt64))
            {
                return (T)(object)((UInt64)(object)a + (UInt64)(object)b);
            }
            else if (typeof(T) == typeof(Int64))
            {
                return (T)(object)((Int64)(object)a + (Int64)(object)b);
            }
            else if (typeof(T) == typeof(Single))
            {
                return (T)(object)((Single)(object)a + (Single)(object)b);
            }
            else if (typeof(T) == typeof(Double))
            {
                return (T)(object)((Double)(object)a + (Double)(object)b);
            }
            else
            {
                throw new NotSupportedException("Nope");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterThan<T>(T a, T b)
        {
            if (typeof(T) == typeof(Byte))
            {
                return ((Byte)(object)a > (Byte)(object)b);
            }
            else if (typeof(T) == typeof(SByte))
            {
                return ((SByte)(object)a > (SByte)(object)b);
            }
            else if (typeof(T) == typeof(UInt16))
            {
                return ((UInt16)(object)a > (UInt16)(object)b);
            }
            else if (typeof(T) == typeof(Int16))
            {
                return ((Int16)(object)a > (Int16)(object)b);
            }
            else if (typeof(T) == typeof(UInt32))
            {
                return ((UInt32)(object)a > (UInt32)(object)b);
            }
            else if (typeof(T) == typeof(Int32))
            {
                return ((Int32)(object)a > (Int32)(object)b);
            }
            else if (typeof(T) == typeof(UInt64))
            {
                return ((UInt64)(object)a > (UInt64)(object)b);
            }
            else if (typeof(T) == typeof(Int64))
            {
                return ((Int64)(object)a > (Int64)(object)b);
            }
            else if (typeof(T) == typeof(Single))
            {
                return ((Single)(object)a > (Single)(object)b);
            }
            else if (typeof(T) == typeof(Double))
            {
                return ((Double)(object)a > (Double)(object)b);
            }
            else
            {
                throw new NotSupportedException("Nope");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals<T>(T a, T b)
        {
            if (typeof(T) == typeof(Byte))
            {
                return ((Byte)(object)a == (Byte)(object)b);
            }
            else if (typeof(T) == typeof(SByte))
            {
                return ((SByte)(object)a == (SByte)(object)b);
            }
            else if (typeof(T) == typeof(UInt16))
            {
                return ((UInt16)(object)a == (UInt16)(object)b);
            }
            else if (typeof(T) == typeof(Int16))
            {
                return ((Int16)(object)a == (Int16)(object)b);
            }
            else if (typeof(T) == typeof(UInt32))
            {
                return ((UInt32)(object)a == (UInt32)(object)b);
            }
            else if (typeof(T) == typeof(Int32))
            {
                return ((Int32)(object)a == (Int32)(object)b);
            }
            else if (typeof(T) == typeof(UInt64))
            {
                return ((UInt64)(object)a == (UInt64)(object)b);
            }
            else if (typeof(T) == typeof(Int64))
            {
                return ((Int64)(object)a == (Int64)(object)b);
            }
            else if (typeof(T) == typeof(Single))
            {
                return ((Single)(object)a == (Single)(object)b);
            }
            else if (typeof(T) == typeof(Double))
            {
                return ((Double)(object)a == (Double)(object)b);
            }
            else
            {
                throw new NotSupportedException("Nope");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessThan<T>(T a, T b)
        {
            if (typeof(T) == typeof(Byte))
            {
                return ((Byte)(object)a < (Byte)(object)b);
            }
            else if (typeof(T) == typeof(SByte))
            {
                return ((SByte)(object)a < (SByte)(object)b);
            }
            else if (typeof(T) == typeof(UInt16))
            {
                return ((UInt16)(object)a < (UInt16)(object)b);
            }
            else if (typeof(T) == typeof(Int16))
            {
                return ((Int16)(object)a < (Int16)(object)b);
            }
            else if (typeof(T) == typeof(UInt32))
            {
                return ((UInt32)(object)a < (UInt32)(object)b);
            }
            else if (typeof(T) == typeof(Int32))
            {
                return ((Int32)(object)a < (Int32)(object)b);
            }
            else if (typeof(T) == typeof(UInt64))
            {
                return ((UInt64)(object)a < (UInt64)(object)b);
            }
            else if (typeof(T) == typeof(Int64))
            {
                return ((Int64)(object)a < (Int64)(object)b);
            }
            else if (typeof(T) == typeof(Single))
            {
                return ((Single)(object)a < (Single)(object)b);
            }
            else if (typeof(T) == typeof(Double))
            {
                return ((Double)(object)a < (Double)(object)b);
            }
            else
            {
                throw new NotSupportedException("Nope");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Divide<T>(T a, double b)
        {
            if (typeof(T) == typeof(Byte))
            {
                return (double)(object)((Byte)(object)a /b) ;
            }
            else if (typeof(T) == typeof(SByte))
            {
                return (double)(object)((SByte)(object)a /b);
            }
            else if (typeof(T) == typeof(UInt16))
            {
                return (double)(object)((UInt16)(object)a / b);
            }
            else if (typeof(T) == typeof(Int16))
            {
                return (double)(object)((Int16)(object)a / b);
            }
            else if (typeof(T) == typeof(UInt32))
            {
                return (double)(object)((UInt32)(object)a / b);
            }
            else if (typeof(T) == typeof(Int32))
            {
                return (double)(object)((Int32)(object)a /b);
            }
            else if (typeof(T) == typeof(UInt64))
            {
                return (double)(object)((UInt64)(object)a / b);
            }
            else if (typeof(T) == typeof(Int64))
            {
                return (double)(object)((Int64)(object)a /b);
            }
            else if (typeof(T) == typeof(Single))
            {
                return (double)(object)((Single)(object)a /b);
            }
            else if (typeof(T) == typeof(Double))
            {
                return (double)(object)((Double)(object)a / b);
            }
            else
            {
                throw new NotSupportedException("Nope");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DivideFloat<T>(T a, float b)
        {
            if (typeof(T) == typeof(Byte))
            {
                return (float)(object)((Byte)(object)a / b);
            }
            else if (typeof(T) == typeof(SByte))
            {
                return (float)(object)((SByte)(object)a / b);
            }
            else if (typeof(T) == typeof(UInt16))
            {
                return (float)(object)((UInt16)(object)a / b);
            }
            else if (typeof(T) == typeof(Int16))
            {
                return (float)(object)((Int16)(object)a / b);
            }
            else if (typeof(T) == typeof(UInt32))
            {
                return (float)(object)((UInt32)(object)a / b);
            }
            else if (typeof(T) == typeof(Int32))
            {
                return (float)(object)((Int32)(object)a / b);
            }
            else if (typeof(T) == typeof(UInt64))
            {
                return (float)(object)((UInt64)(object)a / b);
            }
            else if (typeof(T) == typeof(Int64))
            {
                return (float)(object)((Int64)(object)a / b);
            }
            else if (typeof(T) == typeof(Single))
            {
                return (float)(object)((Single)(object)a / b);
            }
            else if (typeof(T) == typeof(Double))
            {
                return (float)(object)((Double)(object)a / b);
            }
            else
            {
                throw new NotSupportedException("Nope");
            }
        }
    }
}

#endif