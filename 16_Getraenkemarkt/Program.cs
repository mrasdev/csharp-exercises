// Prompt for purchased items (description, quantity, price), calculate item-wise discounts
// and print a receipt to the console. Uses structs, not classes

using System.Globalization;

namespace _16_Getraenkemarkt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PurchaseItem> purchasedItems = [];
            DoShopping(purchasedItems);
            PrintReceipt(purchasedItems);
        }

        static void DoShopping(List<PurchaseItem> purchasedItems)
        {
            PrintHeader();
            bool loopAgain;
            do
            {
                PurchaseItem purchasedItem = ShopAnItem();
                CalculateDiscount(ref purchasedItem);
                purchasedItems.Add(purchasedItem);
                string userInput = ReadUserInput<string>("Einen weiteren Artikel erfassen? (j/n)");
                loopAgain = userInput.Equals("j", StringComparison.OrdinalIgnoreCase);
            } while (loopAgain);
        }

        static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("Willkommen im Kühlen Kasten Karlsruhe");
            Console.WriteLine("Bitte geben Sie Ihre Bestellung ein.");
        }

        static PurchaseItem ShopAnItem()
        {
            PurchaseItem item = new();
            Console.WriteLine();
            // ReadUserInput<bool>("Will throw an exception");  // for testing
            item.Description = ReadUserInput<string>("Bitte geben Sie die Artikelbeschreibung ein");
            item.NumItems = ReadUserInput<int>("Bitte geben Sie die Anzahl ein");
            item.SinglePrice = ReadUserInput<double>("Bitte geben Sie den Einzelpreis ein");
            return item;
        }

        static T ReadUserInput<T>(string message)
        {
            while (true)
            {
                Console.Write(message + ": ");
                if (!TryParseGeneric<T>(Console.ReadLine(), out T? value))
                {
                    Console.WriteLine("Falsche Eingabe!");
                    continue;
                }
                return value!;
            }
        }

        static bool TryParseGeneric<T>(string? userInput, out T? convertedValue)
        {
            // numbers must be >= 0 for returning success
            userInput = (userInput ?? String.Empty).Trim();
            if (typeof(T) == typeof(int))
            {
                bool success = int.TryParse(userInput, out int value) && value >= 0;
                convertedValue = success ? (T)(object)value : default;
                return success;
            }
            if (typeof(T) == typeof(double))
            {
                bool success = double.TryParse(userInput, out double value) && value >= 0;
                convertedValue = success ? (T)(object)value : default;
                return success;
            }
            if (typeof(T) == typeof(string))
            {
                convertedValue = (T)(object)userInput;
                return true;
            }
            throw new NotImplementedException();
        }

        static void CalculateDiscount(ref PurchaseItem item)
        {
            item.DiscountPercent = GetDiscount(item.NumItems);
            item.Update();
            static double GetDiscount(int quantity) =>
                quantity >= 100 ? 10.0 :
                quantity >= 50 ? 7.0 :
                quantity >= 10 ? 5.0 : 0.0;
        }

        static void PrintReceipt(List<PurchaseItem> purchasedItems)
        {
            const int lineWidth = 45;
            PrintReceiptHeader(lineWidth);
            PrintReceiptItems(purchasedItems, lineWidth);
            PrintReceiptTotal(purchasedItems, lineWidth);
            PrintReceiptFooter();
        }

        static void PrintReceiptHeader(int lineWidth)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.WriteLine(new string('-', lineWidth));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("🍺🍺    KKK - Kühler Kasten Karlsruhe    🍺🍺");
            Console.ResetColor();
            Console.WriteLine(new string('-', lineWidth));
        }

        static void PrintReceiptItems(List<PurchaseItem> purchasedItems, int lineWidth)
        {
            foreach (PurchaseItem item in purchasedItems)
            {
                Console.WriteLine(item.Description);
                Console.WriteLine($"{item.NumItems,4} Stück à {item.SinglePrice,14:c} = {item.TotalPrice,15:c}");
                Console.Write($"Rabatt {item.DiscountPercent,4:f1} % {item.DiscountEuro,13:c}");
                Console.WriteLine($"\u001b[1m{item.FinalPrice,18:c}\u001b[0m");
                Console.WriteLine(new string('-', lineWidth));
            }
        }

        static void PrintReceiptTotal(List<PurchaseItem> purchasedItems, int lineWidth)
        {
            Totals totals = CalculateTotals(purchasedItems);
            Console.WriteLine("\u001b[1mEndpreis:          " + $"{totals.SumEuro,26:c}\u001b[0m");
            Console.WriteLine($"inkl. {totals.TaxRate * 100:f0} % MwSt.   " + $"{totals.TaxEuro,26:c}");
            Console.WriteLine(new string('-', lineWidth));
        }

        static Totals CalculateTotals(List<PurchaseItem> purchasedItems)
        {
            Totals totals = new Totals();
            totals.SumEuro = purchasedItems.Sum(item => item.FinalPrice);
            totals.CalcTax(/*taxRate*/0.19);
            return totals;
        }

        static void PrintReceiptFooter()
        {
            var culture = new CultureInfo("de-DE");
            //var culture = new CultureInfo("ru-RU");
            //var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            DateTime dtNow = DateTime.Now;
            string dayAndDate = dtNow.ToString("dddd", culture) + $", {dtNow:d}";
            Console.WriteLine($"{dayAndDate,-35}{dtNow,10:t}");
        }

        public struct PurchaseItem
        {
            public string Description;
            public int NumItems;
            public double SinglePrice;
            public double TotalPrice;
            public double DiscountPercent;
            public double DiscountEuro;
            public double FinalPrice;
            public void Update()
            {
                TotalPrice = NumItems * SinglePrice;
                DiscountEuro = TotalPrice * DiscountPercent / 100.0;  // value > 0
                FinalPrice = TotalPrice - DiscountEuro;
            }
        }

        public struct Totals
        {
            public double SumEuro;
            public double TaxRate;
            public double TaxEuro;
            public void CalcTax(double taxRate)
            {
                TaxRate = taxRate;
                TaxEuro = SumEuro * TaxRate;
            }
        }
    }
}