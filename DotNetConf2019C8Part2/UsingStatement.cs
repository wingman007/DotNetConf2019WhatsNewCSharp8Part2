using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019C8Part2
{
    class ResourceHog : IDisposable
    {
        public ResourceHog? MyProperty { get; set; }
        public ResourceHog(string source)
        {
            Console.WriteLine(source);
        }

        internal void CopyFrom(ResourceHog source)
        {

        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
    class UsingStatement
    {
        internal static void Demo()
        {
            //using (var src = new ResourceHog("source")) 
            //{
            //    using (var dest = new ResourceHog("destination"))
            //    {
            //        dest.CopyFrom(src);
            //    }
            //    Console.WriteLine("After closing destination block");
            //}
            //Console.WriteLine("After closing the source block");

            // you can refactor to:
            using (var src = new ResourceHog("source"))
                using (var dest = new ResourceHog("destination"))
                    dest.CopyFrom(src);
                Console.WriteLine("After closing destination block");
            Console.WriteLine("After closing the source block");
        }
    }
}
