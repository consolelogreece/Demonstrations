using System;
using System.Security.Cryptography;

namespace Span_T
{
    class Program
    {
        /*
         * Span is useful for safely representing and using contiguous memory. Without the span class you'd need to use unsafe code.
         * Note: Span is a JIT construct, and can't be written in C#.
         */

        /*
         *Span can be thought of as having 3 fields:
         *  1) Pointer to position in memory.
         *  2) Offset. I.e. if the pointer is to an array of integers, and the offset is 3, we will look at the third item.
         *  3) Length. How much of this array we want to be able to access from the span.
         */

        /*
         * Extra Notes:
         * Due to span being implemented as a ref struct, it is stack only. Compilation will fail if attempting to use this as, say, a field in a class.
         * It can only be a field member of another ref struct.
         */

        // Fails, as class object lives on heap.
        private ReadOnlySpan<char> x;

        static void Main(string[] args)
        {
            // Span makes working substrings/sections of arrays more efficient:
            var str1 = "abc123doreme";

            // Inefficient
            SubstringWithoutSpan(str1);

            // Efficient
            SubstringWithSpan(str1);



            // Span is also more general, accepting any contiguous memory:
            var str2 = "abc123doreme";

            // Only accepts strings, which may be a problem when say, using a Stream Reader which returns an array of characters.
            MatchesFirstLetterWithoutSpan(str2, 'a');

            // As span accepts any contiguous memory, it will work with both string and char[].
            MatchesFirstLetterWithSpan(str2, 'a');
            MatchesFirstLetterWithSpan(str2.ToCharArray(), 'a');
        }

        static void SubstringWithoutSpan(string text)
        {
            // Typically to get part of a string, you would need to use the substring extension method.
            // This expensive as not only are you using cpu cycles to copy,
            // you are allocating more space on the heap for this substring.
            string subString = text.Substring(0, 5);
        }

        static void SubstringWithSpan(ReadOnlySpan<char> text)
        {
            // The object you are calling Slice on will be the pointer, the first parameter is the offset and the second parameter is the length.
            // No copying is done and no heap allocation is done. When calling slice, all we are doing is changing the offset and length.
            // The original string is still being used.
            ReadOnlySpan<char> textSlice = text.Slice(0, 3);

            // Out of bounds, thanks to the length property not allowing us to access the rest of the original string.
            var outOfBoundsChar = textSlice[4]; 
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
