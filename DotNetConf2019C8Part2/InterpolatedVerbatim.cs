using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019C8Part2
{
    class InterpolatedVerbatim // дословно
    {
        internal static void Demo()
        {
            // https://www.tabsoverspaces.com/233762-interpolated-verbatim-string-in-csharp-8
            // Today, if you want to use interpolated verbatim string, you have to place the $ and @ in proper order. So, this $@"test {DateTime.UnixEpoch}" works, while @$"test {DateTime.UnixEpoch}" doesn’t (Wondering about DateTime.UnixEpoch?

            // But having to type it in correct order was apparently pain in the ass and so in C# 8 the order will not matter. You can try that in i.e. preview of VS 2019 or here.
        }
    }
}
