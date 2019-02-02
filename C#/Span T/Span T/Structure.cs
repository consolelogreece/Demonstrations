using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Span_T
{
    public static class Structure
    {
        // TODO : LOOK DEEPER INTO WHETHER SPAN EVEN HAS OFFSETS. https://adamsitnik.com/Span/
        public static void StructureDemo()
        {
            // Pointer = Numbers.
            // Offset = 0.
            // length = 9.
            int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Span<int> NumberSpan = Numbers;


            // Pointer = Numbers,
            // Offset = 3.
            // Length = 2.
            Span<int> NumberSegment = NumberSpan.Slice(3, 2);

        }
    }
}
