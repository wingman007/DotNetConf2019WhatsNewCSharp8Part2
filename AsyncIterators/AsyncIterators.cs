using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncIterators
{
    public class AsyncIterators
    {
        public static async Task Demo()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine($"The time is {DateTime.Now:hh:mm:ss}. Retrieved {number}");
            }
        }

        internal static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 50; i++)
            {
                // every 10 elements wait 2 seconds
                if (i % 10 == 0)
                    await Task.Delay(2000);
                yield return i;

            }
        }
    }
}
