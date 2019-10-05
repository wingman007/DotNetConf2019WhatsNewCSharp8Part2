using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019C8Part2
{
    struct Point // readOnly struct we can guarantee it will never change. Look down the readonly keyword
    {
        public double X { get; set; }
        public double Y { get; set; }
        //public double Distance => Math.Sqrt(X * X + Y * Y);
        readonly public double Distance => Math.Sqrt(X * X + Y * Y);

        //public override string ToString() => $"{X} {Y} is {Distance} from the origin";
        readonly public override string ToString() => $"{X} {Y} is {Distance} from the origin";

        public void Translate(int xOffset, int yOffset)
        {
            X += xOffset;
            Y += yOffset;
        }
    }
    class ReadOnlyMembers
    {
        internal static void Demo()
        {
            var p = new Point { X = 30, Y = 40 };
            Console.WriteLine(p);
        }
    }
}
