// Ask the user for the amount of beer consumed and their body weight, then calculate and display the estimated blood alcohol content (BAC) in permil (‰). Provide feedback based on the BAC level.

Console.Write("Wieviel Liter Bier haben Sie getrunken? ");
if (!double.TryParse(Console.ReadLine(), out double litersBeer))
{
    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein.");
    return;
}
double gramsAlcohol = litersBeer * 1000 * 0.05 * 0.8;   // 0.05 = 5% alcohol, 0.8 = density of alcohol

Console.Write("\nGeben Sie Ihr Körpergewicht in kg ein: ");
if (!double.TryParse(Console.ReadLine(), out double kgramsWeight) || kgramsWeight == 0)
{
    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl größer Null ein.");
    return;
}
double permilAlcohol = gramsAlcohol / (kgramsWeight * 0.65); // 0.65 = average body water content

Console.WriteLine($"\nIhr geschätzter Blutalkoholgehalt beträgt: {permilAlcohol:F2} promille\n");

switch (permilAlcohol)
{
    case <= 0.3:
        Console.WriteLine("Noch akzeptabel. Dennoch vorsichtig sein!");
        break;
    case <= 0.5:
        Console.WriteLine("Achtung! Hände weg vom Steuer!");
        break;
    case <= 0.8:
        Console.WriteLine("Das ist jetzt schon ganz schön ordentlich.");
        break;
    default:
        Console.WriteLine("Kein Kommentar...");
        break;
}
