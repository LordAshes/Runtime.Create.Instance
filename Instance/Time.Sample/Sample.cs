using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class Sample
    {
        private static ITime clock = null;

        static void Main(string[] args)
        {
            //
            // For this simple example the external DLL libray to be used is provided as the first command line argument.
            //
            // Time.Sample.exe Time.ClockType1.dll
            // 
            // Time.Sample.exe Time.ClockType2.dll
            //
            // In an actual application implementation the choice of external library could be configured in a configuration file. 
            //

            //
            // Style 1 With No Construction Parameters
            //
            clock = Runtime.Create<ITime>.Instance(args[0]);

            //
            // Style 1 With Construction Parameters
            //
            // clock = Runtime.Create<ITime>.Instance(args[0], new object[] { "Toronto", -5 } );

            //
            // Style 2 With No Construction Parameters
            //
            // clock = Runtime.Create.Instance("Time.ITime", args[0]);

            //
            // Style 2 With Construction Parameters
            //
            // clock = Runtime.Create.Instance("Time.ITime", args[0], new object[] { "Toronto", -5 } );

            if (clock!=null)
            {
                // Example of instance use
                Console.WriteLine(clock.GetCurrentDateTime());
                Console.ReadLine();
            }
        }
    }
}
