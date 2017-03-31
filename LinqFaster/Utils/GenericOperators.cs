using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JM.LinqFaster.Utils
{
    public static class GenericOperators
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





    }
}
