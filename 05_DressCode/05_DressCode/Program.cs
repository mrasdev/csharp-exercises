// Ask for weather and temperature, then give clothing advice based on the input. Example how to use enums and to throw exceptions for unimplemented cases.

Console.WriteLine("Wie ist das Wetter heute?");
for (int i = 0; i < Enum.GetNames<Weather>().Length; i++)
{
    Console.WriteLine($"{i}: {(Weather)i}");
}
if (!int.TryParse(Console.ReadLine(), out int weatherInput) || weatherInput < 0 || weatherInput >= Enum.GetNames<Weather>().Length)
{
    Console.WriteLine("Ungültige Eingabe für das Wetter.");
    return;
}

Console.Write("Wie warm ist es heute? ");
if (!double.TryParse(Console.ReadLine(), out double temperature))
{
    Console.WriteLine("Ungültige Eingabe für die Temperatur.");
    return;
}
Console.WriteLine();

if (temperature < 20)
{
    Console.WriteLine("Ziehe eine Jacke an.");
}
else
{
    Console.WriteLine("Ziehe ein T-Shirt an.");
}

switch ((Weather)weatherInput)
{
    case Weather.Sonnig:
        break;
    case Weather.Regnerisch:
        Console.WriteLine("Nehme einen Regenschirm mit.");
        break;
    default:
        throw new NotImplementedException("invalid weather type");
}

public enum Weather
{
    Sonnig,
    Regnerisch,
    Windig   // needs to be implemented
}