// Ask for purchased items (description, amount, price) and show a receipt on console.
// Discount is caclulated for each item.
// To keep it simple, no classes are used, only structs.

using System.Globalization;

namespace _16_Getraenkemarkt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PurchaseItem> purchasedItems = new List<PurchaseItem>();
            DoShopping(purchasedItems);
            PrintReceipt(purchasedItems);
        }

        static void DoShopping(List<PurchaseItem> purchasedItems)
        {
            PrintHeader();
            bool loopAgain = false;
            do
            {
                PurchaseItem purchasedItem = ShopAnItem();
                CalculateDiscount(ref purchasedItem);
                purchasedItems.Add(purchasedItem);
                loopAgain = ReadUserInput<string>("Einen weiteren Artikel erfassen? (j/n)").ToLower() == "j";
            } while (loopAgain);
        }

        static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("Willkommen im Getränke Garten Gelsenkirchen");
            Console.WriteLine("Bitte geben Sie Ihre Bestellung ein.");
            Console.WriteLine();
        }

        static PurchaseItem ShopAnItem()
        {
            PurchaseItem item = new();
            item.Description = ReadUserInput<string>("Bitte geben Sie die Artikelbeschreibung ein");
            item.NumItems = ReadUserInput<int>("Bitte geben Sie die Anzahl ein");
            item.SinglePrice = ReadUserInput<double>("Bitte geben Sie den Einzelpreis ein");
            return item;
        }

        static dynamic ReadUserInput<T>(string message)
        {
            while (true)
            {
                Console.Write(message + ": ");
                if (typeof(T) == typeof(double))
                {
                    if (!double.TryParse(Console.ReadLine(), out double value) || value < 0)
                    {
                        Console.WriteLine("Falsche Eingabe!");
                        continue;
                    }
                    return value;
                }
                if (typeof(T) == typeof(int))
                {
                    if (!int.TryParse(Console.ReadLine(), out int value) || value < 0)
                    {
                        Console.WriteLine("Falsche Eingabe!");
                        continue;
                    }
                    return value;
                }
                if (typeof(T) == typeof(string))
                {
                    return (Console.ReadLine() ?? "").Trim();
                }
                throw new NotImplementedException();
            }
        }

        static void CalculateDiscount(ref PurchaseItem item)
        {
            item.DiscountPercent = GetDiscount(item.NumItems);
            item.TotalPrice = item.NumItems * item.SinglePrice;
            item.DiscountEuro = item.TotalPrice * item.DiscountPercent / 100.0;  // value > 0
            item.FinalPrice = item.TotalPrice - item.DiscountEuro;
        }

        static double GetDiscount(int quantity)
        {
            if (quantity >= 100) return 10.0;
            if (quantity >= 50) return 7.0;
            if (quantity >= 10) return 5.0;
            return 0.0;
        }

        static void PrintReceipt(List<PurchaseItem> purchasedItems)
        {
            const int lineWidth = 46;
            PrintReceiptHeader(lineWidth);
            PrintReceiptItems(purchasedItems, lineWidth);
            PrintReceiptTotal(purchasedItems, lineWidth);
            printReceiptFooter(lineWidth);
        }

        static void PrintReceiptHeader(int lineWidth)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.WriteLine(new string('-', lineWidth));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("🍺  GGG - Getränke Garten Gelsenkirchen 04  🍺");
            Console.ResetColor();
            Console.WriteLine(new string('-', lineWidth));
        }

        static void PrintReceiptItems(List<PurchaseItem> purchasedItems, int lineWidth)
        {
            foreach (PurchaseItem item in purchasedItems)
            {
                Console.WriteLine(item.Description);
                Console.WriteLine($"{item.NumItems,4} Stück à {item.SinglePrice,15:c} = {item.TotalPrice,15:c}");
                Console.Write($"Rabatt {item.DiscountPercent,4:f1} % {item.DiscountEuro,14:c}");
                Console.WriteLine($"\u001b[1m{item.FinalPrice,18:c}\u001b[0m");
                Console.WriteLine(new string('-', lineWidth));
            }
        }

        static void PrintReceiptTotal(List<PurchaseItem> purchasedItems, int lineWidth)
        {
            CalculateTotals(purchasedItems, out Totals totals);
            Console.WriteLine("\u001b[1mEndpreis:          " + $"{totals.SumEuro,27:c}\u001b[0m");
            Console.WriteLine($"inkl. {totals.TaxRate * 100:f0} % MwSt.   " + $"{totals.TaxEuro,27:c}");
            Console.WriteLine(new string('-', lineWidth));
        }

        static void CalculateTotals(List<PurchaseItem> purchasedItems, out Totals totals)
        {
            Totals myTotals = new Totals();
            myTotals.SumEuro = purchasedItems.Sum(item => item.FinalPrice);
            myTotals.TaxRate = 0.19;
            myTotals.TaxEuro = myTotals.SumEuro * myTotals.TaxRate;
            totals = myTotals;
        }

        static void printReceiptFooter(int lineWidth)
        {
            var culture = new CultureInfo("de-DE");
            //var culture = new CultureInfo("ru-RU");
            //var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            DateTime dtNow = DateTime.Now;
            string dayAndDate = dtNow.ToString("dddd", culture) + $", {dtNow:d}";
            Console.WriteLine($"{dayAndDate,-36}{dtNow,10:t}");
        }

        public struct PurchaseItem
        {
            public string Description;
            public int NumItems;
            public double SinglePrice;
            public double TotalPrice;  // NumItems * SinglePrice
            public double DiscountPercent;
            public double DiscountEuro; // TotalPrice * DiscountPercent / 100
            public double FinalPrice;  // TotalPrice - DiscountEuro
        }

        public struct Totals
        {
            public double SumEuro;
            public double TaxRate;
            public double TaxEuro;
        }
    }
}