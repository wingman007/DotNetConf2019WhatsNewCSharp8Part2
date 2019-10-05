using System;
using System.Threading.Tasks;
using AsyncIterators;

// https://www.youtube.com/watch?v=fhf8N4004u0
// namespace WhatsNewCSharp8
// https://stackoverflow.com/questions/53272962/system-io-filenotfoundexception-for-microsoft-entityframeworkcore
namespace DotNetConf2019C8Part2
{
    class Program
    {
        //static async Task Main(string[] args)
        //{
        //    // async method laks await operator ...
        //    await AsyncIterators.AsyncIterators.Demo();
        //}

            // the resat of the demos are not async
        static void Main(string[] args)
        {
            // await AsyncIterators.AsyncIterators.Demo();

            Patterns.Demo();
            
            DefaultInterfaceMembers.Demo();

            IndicesAndRanges.Demo1();
            IndicesAndRanges.Demo2();
            IndicesAndRanges.Demo3();
            IndicesAndRanges.Demo4();
            IndicesAndRanges.Demo5();
            IndicesAndRanges.Demo6();

            UsingStatement.Demo();
            
            StaticLocalFunc.Demo();

            ReadOnlyMembers.Demo();

            NullCoalescingAssignment.Demo();

            UnmanagedConstraint.Demo();

            InterpolatedVerbatim.Demo();
        }
    }
}
