using System;

internal static class Error
{
    internal static Exception ArgumentNull(string s) => new ArgumentNullException(s);

    internal static Exception ArgumentOutOfRange(string s) => new ArgumentOutOfRangeException(s);

    internal static Exception MoreThanOneElement() => new InvalidOperationException("Sequence contains more than one element");

    internal static Exception MoreThanOneMatch() => new InvalidOperationException("Sequence contains more than one matching element");

    internal static Exception NoElements() => new InvalidOperationException("Sequence contains no elements");

    internal static Exception NoMatch() => new InvalidOperationException("Sequence contains no matching element");

    internal static Exception NotSupported() => new NotSupportedException();
}