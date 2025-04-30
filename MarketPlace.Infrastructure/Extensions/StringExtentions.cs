namespace System;

public static class StringExtentions
{
    public static bool HasValue(this string str)
    {
        var isEmpty = string.IsNullOrEmpty(str) && string.IsNullOrWhiteSpace(str);
        return !isEmpty;
    }
}
