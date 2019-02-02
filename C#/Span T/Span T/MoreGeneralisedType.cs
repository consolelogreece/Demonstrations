using System;
using System.Collections.Generic;
using System.Text;

namespace Span_T
{
    public static class MoreGeneralisedType
    {
        public static void MoreGeneralisedTypeDemo()
        {
            // Span is also more general, accepting any contiguous memory:
            var str2 = "abc123doreme";

            // Only accepts strings, which may be a problem when say, using a Stream Reader which returns an array of characters.
            MatchesFirstLetterWithoutSpan(str2, 'a');
            MatchesFirstLetterWithoutSpan(str2.ToCharArray(), 'a'); // Fails, as without span accepts only strings.

            // As span accepts any contiguous memory, it will work with both string and char[].
            MatchesFirstLetterWithSpan(str2, 'a');
            MatchesFirstLetterWithSpan(str2.ToCharArray(), 'a'); //Succeeds.
        }

        static bool MatchesFirstLetterWithoutSpan(string str, char n)
        {
            return str[0] == n;
        }

        static bool MatchesFirstLetterWithSpan(ReadOnlySpan<char> str, char n)
        {
            return str[0] == n;
        }
    }
}
