using System;
using System.Collections.Generic;
using System.Text;

namespace Span_T
{
    public static class Segments
    {
        // Span makes working substrings/sections/segments of arrays more efficient.
        // In this example, I will try to demonstrate this with strings and substrings.
        public static void SegmentDemo()
        {
            var text = "abc123doreme";

            // Inefficient
            SubstringWithoutSpan(text);

            // Efficient
            SubstringWithSpan(text);
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
    }
}
