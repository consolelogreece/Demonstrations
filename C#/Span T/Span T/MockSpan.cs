using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Span_T
{
    // In order to implement your own version of Span<T>, you'd need a reference field so you could modify the region of memory directly,
    // and not just modify a copy of it. Fields of type 'ref' are illegal in C#.
    public class MockSpan<T>
    { 
        private int _length;

        private ref T _pointer; // Does not compile.

        public MockSpan(T[] arr)
        {
            _pointer = ref arr[0];

            _length = arr.Length;
        } 

        public MockSpan(T[] arr, int length)
        {
            _pointer = ref arr[0];

            _length = length;
        }

        // Span sets pointer to the nth element, as determined by start.
        public MockSpan(T[] arr, int start, int length)
        {
            _pointer = ref arr[start];

            _length = length;
        }

        // ref T return indexer overload.
        public ref T this[int index]
        {
            get
            {
                // logic goes here.
            }
        }
    }
}
