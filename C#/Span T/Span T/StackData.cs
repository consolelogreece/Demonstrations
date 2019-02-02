using System;

namespace Span_T
{
    public static class StackData
    {
        public static void StackDataDemo()
        {
            UnsafeStackData();
            SafeStackData();
        }

        static unsafe void UnsafeStackData()
        {
            int* numbers = stackalloc int[2];
            numbers[1] = 5;
            numbers[2] = 50;
            numbers[6] = 44; // No Exception Thrown.        
        }

        // No need for unsafe keyword.
        static void SafeStackData()
        {
            Span<int> numbers = stackalloc int[5];
            numbers[1] = 5;
            numbers[2] = 50;
            numbers[6] = 44; // throws IndexOutOfRangeException
        }
    }
}
