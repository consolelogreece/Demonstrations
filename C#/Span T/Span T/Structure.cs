using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Span_T
{
    public static class Structure
    {
        public static void StructureDemo()
        {
            // Pointer = the first number, as no offset is provided on construction.
            // length = 9.
            int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Span<int> NumberSpan = Numbers;


            // Offset of 3 provided, meaning the pointer points to the third element.
            // Length = 2, so holds positions 3 & 4;
            Span<int> NumberSegment = NumberSpan.Slice(3, 2);

        }
    }
}
