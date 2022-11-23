using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class TextColor
    {
        public static void PressEnter()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void RedMessageColor(string output, int attempts)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(output);
            Console.ResetColor();
        }
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
        public static void YellowMessageColor(string output)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(output);
            Console.ResetColor();
        }
        public static void BankLogo()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" _   _   _____   _____     ");
            Console.WriteLine("| \\ | | /  __ \\ |  _  |    ");
            Console.WriteLine("|  \\| | | /  \\/ | | | |    ");
            Console.WriteLine("| . ` | | |     | | | |     ");
            Console.WriteLine("| |\\  | | \\__/\\ \\ \\_/ /    ");
            Console.WriteLine("\\_| \\_/  \\____/  \\___/     ");
            Console.WriteLine(" ");
            Console.WriteLine("______                _    ");
            Console.WriteLine("| ___ \\              | |   ");
            Console.WriteLine("| |_/ /  __ _  _ __  | | __");
            Console.WriteLine("| ___ \\ / _` || '_ \\ | |/ /");
            Console.WriteLine("| |_/ /| (_| || | | ||   < ");
            Console.WriteLine("\\____/  \\__,_||_| |_||_|\\_\\");
            Console.WriteLine(" ");

            Console.ResetColor();
        }
    }
}
