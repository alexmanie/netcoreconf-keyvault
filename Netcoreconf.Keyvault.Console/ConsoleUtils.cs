using System;
using System.Collections.Generic;
using System.Text;

namespace Netcoreconf.Keyvault
{
    internal static class ConsoleUtils
    {
        internal static void WriteInfo(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
