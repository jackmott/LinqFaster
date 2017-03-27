using System;

internal static class Error
{
    internal static Exception ArgumentNull(string s) => new ArgumentNullException(s);

    internal static Exception ArgumentOutOfRange(string s) => new ArgumentOutOfRangeException(s);

    internal static Exception MoreThanOneElement() => new InvalidOperationException(SR.MoreThanOneElement);

    internal static Exception MoreThanOneMatch() => new InvalidOperationException(SR.MoreThanOneMatch);

    internal static Exception NoElements() => new InvalidOperationException(SR.NoElements);

    internal static Exception NoMatch() => new InvalidOperationException(SR.NoMatch);

    internal static Exception NotSupported() => new NotSupportedException();
}