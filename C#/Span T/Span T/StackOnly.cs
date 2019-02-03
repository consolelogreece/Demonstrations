using System;
using System.Collections.Generic;
using System.Text;

namespace Span_T
{
    // Span<T> is a ref struct, thus can only live on the stack. 
    public class StackOnly_Class
    {
        // Fails, as class object lives on heap, being a property on a class means it, too, will be on the heap.
        private ReadOnlySpan<char> x;
    }

    public ref struct StackOnly_RefStruct
    {
        // Compiles successfully as ref struct is stack only.
        private ReadOnlySpan<char> x;
    }

    // This interface implementation is pointless as ref structs cannot be boxed as that may cause it to live on the heap.
    public ref struct StackOnly_RefStruct_Interfaced : IDisposable
    {
    }
}
