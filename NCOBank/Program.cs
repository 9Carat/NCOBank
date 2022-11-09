namespace NCOBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankMenu start = new BankMenu();
            start.chooseOption();

            Console.ReadKey();
        }
    }
}