using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019C8Part2
{
    class NullCoalescingAssignment // Coalescing = unite = сливане
    {
        // Will help us start to addopt nullable reference type
        internal static void Demo()
        {
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>(); // numbers will remain what it was but if it is null a new List<int>() will be created and assigned to numbers
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20); // So instead of adding if assignments we use ??

            Console.WriteLine(String.Join(' ', numbers)); // 17 17 i already is not null after the first i ??= 17
            Console.WriteLine(i);
        }
    }
}
