using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _13_Zahlensysteme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selection;
            do
            {
                Console.WriteLine("\nMenü:");
                Console.WriteLine("1 - Überprüfung Primzahl");
                Console.WriteLine("2 - Quersumme bilden");
                Console.WriteLine("3 - Potenzieren");
                Console.WriteLine("4 - Zahlen spiegeln");
                Console.WriteLine("5 - Zahlen-Palindrom");
                Console.WriteLine("6 - Programmende");
                Console.Write("Bitte wählen: ");
                if (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
                {
                    Console.WriteLine("Falsche Eingabe!");
                    continue;
                }
                int num1, num2;
                switch (selection)
                {
                    case 1:
                        Console.Write("Geben Sie ein Ganzzahl ein: ");
                        if (!int.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.WriteLine("Falsche Eingabe!");
                            break;
                        }
                        bool isPrime = (num1 == 0 || num1 == 1) ? false : true;
                        for (int a = 2; a <= num1 / 2; a++)
                        {
                            if (num1 % a == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        Console.WriteLine($"{num1} ist {(isPrime ? "" : "k")}eine Primzahl");
                        break;
                    case 2:
                        Console.Write("Geben Sie ein Ganzzahl ein: ");
                        if (!int.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.WriteLine("Falsche Eingabe!");
                            break;
                        }
                        int crosssum = 0;
                        num1 = Math.Abs(num1); // Umgang mit negativen Zahlen
                        while (num1 > 0)
                        {
                            crosssum += num1 % 10; // Letzte Ziffer addieren
                            num1 /= 10;            // Letzte Ziffer entfernen
                        }
                        Console.WriteLine("Die Quersumme ist " + crosssum);
                        break;
                    case 3:
                        Console.Write("Geben Sie die Basis als Ganzzahl ein: ");
                        if (!int.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.WriteLine("Falsche Eingabe!");
                            break;
                        }
                        Console.Write("Geben Sie den Exponenten als Ganzzahl ein: ");
                        if (!int.TryParse(Console.ReadLine(), out num2))
                        {
                            Console.WriteLine("Falsche Eingabe!");
                            break;
                        }
                        Console.WriteLine($"{num1} hoch {num2} ergibt {Math.Pow(num1, num2)}");
                        break;
                    case 4:
                        Console.Write("Geben Sie ein Ganzzahl ein: ");
                        if (!int.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.WriteLine("Falsche Eingabe!");
                            break;
                        }
                        int reversedNumber = 0;
                        while (num1 != 0)
                        {
                            int remainder = num1 % 10; // Letzte Ziffer holen
                            reversedNumber = (reversedNumber * 10) + remainder; // Ziffer anhängen
                            num1 /= 10; // Letzte Ziffer entfernen
                        }
                        Console.WriteLine($"Umgedreht = {reversedNumber}");
                        break;
                    case 5:
                        Console.Write("Geben Sie eine Ganzzahl ein: ");
                        if (!int.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.WriteLine("Falsche Eingabe!");
                            break;
                        }
                        string numAsString = num1.ToString() ?? "";
                        string numReversed = new string(numAsString.Reverse().ToArray());
                        Console.WriteLine($"{num1} ist {(numAsString == numReversed ? "" : "k")}ein Palindrom");
                        break;
                }
            } while (selection != 6);
        }
    }
}
