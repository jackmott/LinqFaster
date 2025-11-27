using System;
using System.Runtime.CompilerServices;

internal static class Error
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Exception ArgumentNull(string s) { return new ArgumentNullException(s); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Exception ArgumentOutOfRange(string s) { return new ArgumentOutOfRangeException(s); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Exception MoreThanOneElement() { return new InvalidOperationException("Sequence contains more than one element"); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Exception MoreThanOneMatch() { return new InvalidOperationException("Sequence contains more than one matching element"); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Exception NoElements() { return new InvalidOperationException("Sequence contains no elements"); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Exception NoMatch() { return new InvalidOperationException("Sequence contains no matching element"); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Exception NotSupported() { return new NotSupportedException(); }
}