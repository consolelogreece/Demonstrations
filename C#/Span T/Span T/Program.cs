using System;
using System.Security.Cryptography;

namespace Span_T
{
    class Program
    {
        static void Main(string[] args)
        {
            UnsafeStackData();

            Console.Read();
        }



        static unsafe void UnsafeStackData()
        {
            int* numbers = stackalloc int[5];
            numbers[1] = 5;
            numbers[2] = 50;
            numbers[6] = 44; // No Exception Thrown.  

            var x = numbers[7];
        }
    }
}
