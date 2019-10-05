using System;
using System.Collections.Generic;
using System.Text;

// namespace WhatsNewCSharp8
namespace DotNetConf2019C8Part2
{
    class StaticLocalFunc
    {
        internal static void Demo()
        {
            foreach (var i in Counter(1, 10)) Console.WriteLine(i);
        }

        public static IEnumerable<int> Counter(int start, int end)
        {
            if (start >= end) throw new ArgumentOutOfRangeException(nameof(start), "start must be less than end");

            // return localCounter();

            // this works
            //IEnumerable<int> localCounter()
            //{
            //    for (int i = start; i < end; i++)
            //        yield return i;
            //}


            // if you don't need closure make the nested function static
            return localCounter(start, end);

            // if it is static we have to pass the free variable in this closure
            static IEnumerable<int> localCounter(int start, int end) // !!! We have to pass the variables as parameters
            {
                for (int i = start; i < end; i++)
                    yield return i;
            }
        }
    }
}
