// Request melon price and quantity; generate a formatted console receipt. Supports locale testing.

using System.Globalization;

namespace _14_Melonen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var culture = new CultureInfo("de-DE");
            //var culture = new CultureInfo("ru-RU");
            //var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            double costPerMelon;
            int numberMelons;
            const DayOfWeek discountDay = DayOfWeek.Monday;
            const double taxRate = 0.19;
            while (true)
            {
                Console.Write("Preis pro Melone: ");
                if (!double.TryParse(Console.ReadLine(), out costPerMelon) || costPerMelon < 0)
                {
                    Console.WriteLine("Falsche Eingabe!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Anzahl der Melonen: ");
                if (!int.TryParse(Console.ReadLine(), out numberMelons) || numberMelons < 0)
                {
                    Console.WriteLine("Falsche Eingabe!");
                    continue;
                }
                break;
            }
            double totalCost = costPerMelon * numberMelons;
            double discountInPercent = 0;
            if (numberMelons >= 10)
            {
                discountInPercent = (discountDay == DateTime.Now.DayOfWeek) ? 12 : 10;
            }
            else if (numberMelons >= 5)
            {
                discountInPercent = (discountDay == DateTime.Now.DayOfWeek) ? 7 : 5;
            }
            double changeInCurrency = totalCost * (discountInPercent / -100.0);
            double finalCost = totalCost + changeInCurrency;
            double taxInCurrency = finalCost * taxRate;
            Console.WriteLine(new string('-', 39));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🍉    MMM - Melonen Markt München    🍉");
            Console.ResetColor();
            Console.WriteLine(new string('-', 39));
            Console.WriteLine("Anzahl Melonen:        " + $"{numberMelons,10} Stück");
            Console.WriteLine("Einzelpreis:       " + $"{costPerMelon,20:c}");
            Console.WriteLine(new string('-', 39));
            Console.WriteLine("Zwischensumme:     " + $"{totalCost,20:c}");
            Console.WriteLine(new string('-', 39));
            Console.WriteLine("Rabattstufe:     " + $"{discountInPercent,20:f1} %");
            Console.WriteLine("Preisänderung:     " + $"{changeInCurrency,20:c}");
            Console.WriteLine(new string('-', 39));
            Console.WriteLine("\u001b[1mEndpreis:          " + $"{finalCost,20:c}\u001b[0m");
            Console.WriteLine($"inkl. {taxRate * 100:f0} % MwSt.   " + $"{taxInCurrency,20:c}");
            Console.WriteLine(new string('-', 39));
            DateTime dtNow = DateTime.Now;
            string dayAndDate = dtNow.ToString("dddd", culture) + $", {dtNow:d}";
            Console.WriteLine($"{dayAndDate,-29}{dtNow,10:t}");
        }
    }
}