using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Span_T
{
    // Span can refer to any arbitrary block of contiguous memory. 
    // Consider this memory from the native heap
    public static class ArbitraryPointers
    {
        public static void ArbitraryPointersDemo()
        {
            IntPtr pointer = Marshal.AllocHGlobal(5);

            Span<int> numbers;
            unsafe
            {
                // This is the magic. 
                // This unmanaged block of contiguous memory, usually unsafe, is now wrapped by the Span class and can be used in a safe context.
               numbers = new Span<int>((int*)pointer, 5);
            }

            // Can access memory outside of unsafe block.
            numbers[6] = 12; // Exception thrown, as if managed array.
        }

    }
}
