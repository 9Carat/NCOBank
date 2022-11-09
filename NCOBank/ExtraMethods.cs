using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public static class ExtraMethods
    {
        public static void MessageColor(string output, bool ok = true)
        {
            if (ok)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(output);
            Console.ResetColor();
        }
    }
}
