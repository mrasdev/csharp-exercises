using _20_Rechner_OOP.Modules;

namespace _20_Rechner_OOP;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;  // for \inf output on console

        CalcManager calcman = new();

        do
        {
            calcman.SetOperation();
            calcman.Operate();
        } while (calcman.Enabled);
    }
}
