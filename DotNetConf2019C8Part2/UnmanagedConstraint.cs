using System;
using System.Collections.Generic;
using System.Text;

// WhatsNewCSharp8
namespace DotNetConf2019C8Part2
{
    // This example is taken from
    // https://github.com/dotnet/csharplang/issues/1744
    public struct MyStruct<T> where T : unmanaged
    {
        public T field;
    }

    // https://github.com/dotnet/csharplang/issues/2380
    class UnmanagedConstraint
    {

        internal static void Demo()
        {
            // used by libraries for high performance
        }
    }
}
