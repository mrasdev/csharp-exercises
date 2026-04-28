// Four short samples for how to use loops in C#. The first sample is a switch statement that asks the user for their drink choice and responds accordingly. The second sample is a for loop that calculates and displays the total savings over 12 months based on user input. The third sample is a while loop that continues to ask the user if they have arrived until they respond with "ja". The fourth sample is a do-while loop that presents a menu to the user until they choose to exit by entering "0".

using System.Globalization;   // for CultureInfo.CreateSpecificCulture("de-DE") to format currency in German style
using System.Text;   // for Console.OutputEncoding = Encoding.UTF8; to ensure proper display of characters like the Euro symbol
Console.OutputEncoding = Encoding.UTF8;


Console.WriteLine("Was möchten Sie trinken? (Kaffee, Tee, Schokolade) ");
string drink = Console.ReadLine() ?? string.Empty;
drink = drink.Trim().ToLower();
switch (drink)
{
    case "kaffee":
        Console.WriteLine("Guten Morgen! Hier ist Ihr Kaffee.");
        break;
    case "tee":
        Console.WriteLine("Hier ist Ihr Tee. Genießen Sie ihn!");
        break;
    case "schokolade":
        Console.WriteLine("Hier ist Ihre heiße Schokolade. Lecker!");
        break;
    default:
        Console.WriteLine("Entschuldigung, wir haben das nicht auf der Karte.");
        break;
}
Console.WriteLine("\n----------------------------------------");


Console.WriteLine("Wieviel Geld wollen Sie jeden Monat sparen?");
if(!double.TryParse(Console.ReadLine(), out double savings))
{
    Console.WriteLine("Ungültige Eingabe für die Ersparnisse.");
    return;
}
for (int month = 1; month <= 12; month++)
{
    string euroString = (savings * month).ToString("C", CultureInfo.CreateSpecificCulture("de-DE"));
    Console.WriteLine($"Nach {month} Monat(en) haben Sie {euroString} gespart.");
}
Console.WriteLine("\n----------------------------------------");


while (true)
{
    Console.WriteLine("Sind wir schon da?");
    string answer = Console.ReadLine() ?? string.Empty;
    if (answer.Trim().Equals("ja", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Endlich angekommen!");
        break;
    }
    else
    {
        Console.WriteLine("Noch nicht, weiterfahren...");
    }
}
Console.WriteLine("\n----------------------------------------");


string input;
do
{
    Console.WriteLine("Bitte auswählen:");
    Console.WriteLine("1: Option A");
    Console.WriteLine("2: Option B");
    Console.WriteLine("0: Programm beenden");
    input = Console.ReadLine() ?? string.Empty;
} while (input.Trim() != "0");
