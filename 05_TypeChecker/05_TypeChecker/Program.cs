// Enter a string and the program will try to convert it to all possible types. Then you can choose which type you want to see the value of.

using System.Numerics;   // for BigInteger

var convertedValue = new Dictionary<string, object>();

Console.Write("Bitte geben Sie etwas ein: ");
string? input = Console.ReadLine();
Console.WriteLine();

// input = null;   // test of null input; a white space input is an empty string and treated as a valid string input
if (input == null)
{
    Console.WriteLine("Es wurde keine Eingabe erkannt.");
    return;
}

// types see https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/built-in-types

if (bool.TryParse(input, out bool boolValue))
{
    Console.WriteLine($"Die Eingabe ist ein boolescher Wert: {boolValue}");
    convertedValue["bool"] = boolValue;
}
if (byte.TryParse(input, out byte byteValue))
{
    Console.WriteLine($"Die Eingabe ist ein Byte: {byteValue}");
    convertedValue["byte"] = byteValue;
}
if (sbyte.TryParse(input, out sbyte sbyteValue))
{
    Console.WriteLine($"Die Eingabe ist ein sByte: {sbyteValue}");
    convertedValue["sbyte"] = sbyteValue;
}
if (char.TryParse(input, out char charValue))
{
    Console.WriteLine($"Die Eingabe ist ein Zeichen: {charValue}");
    convertedValue["char"] = charValue;
}
if (decimal.TryParse(input, out decimal decimalValue))
{
    Console.WriteLine($"Die Eingabe ist eine Dezimalzahl: {decimalValue}");
    convertedValue["decimal"] = decimalValue;
}
if (double.TryParse(input, out double doubleValue))
{
    Console.WriteLine($"Die Eingabe ist eine double Gleitkommazahl: {doubleValue}");
    convertedValue["double"] = doubleValue;
}
if (float.TryParse(input, out float floatValue))
{
    Console.WriteLine($"Die Eingabe ist eine float Gleitkommazahl: {floatValue}");
    convertedValue["float"] = floatValue;
}
if (int.TryParse(input, out int intValue))
{
    Console.WriteLine($"Die Eingabe ist ein Integer: {intValue}");
    convertedValue["int"] = intValue;
}
if (uint.TryParse(input, out uint uintValue))
{
    Console.WriteLine($"Die Eingabe ist ein unsigned Integer: {uintValue}");
    convertedValue["uint"] = uintValue;
}
if (nint.TryParse(input, out nint nintValue))
{
    Console.WriteLine($"Die Eingabe ist ein native Integer: {nintValue}");
    convertedValue["nint"] = nintValue;
}
if (nuint.TryParse(input, out nuint nuintValue))
{
    Console.WriteLine($"Die Eingabe ist ein native unsigned Integer: {nuintValue}");
    convertedValue["nuint"] = nuintValue;
}
if (long.TryParse(input, out long longValue))
{
    Console.WriteLine($"Die Eingabe ist ein long Integer: {longValue}");
    convertedValue["long"] = longValue;
}
if (ulong.TryParse(input, out ulong ulongValue))
{
    Console.WriteLine($"Die Eingabe ist ein unsigned long Integer: {ulongValue}");
    convertedValue["ulong"] = ulongValue;
}
if (short.TryParse(input, out short shortValue))
{
    Console.WriteLine($"Die Eingabe ist ein short Integer: {shortValue}");
    convertedValue["short"] = shortValue;
}
if (ushort.TryParse(input, out ushort ushortValue))
{
    Console.WriteLine($"Die Eingabe ist ein unsigned short Integer: {ushortValue}");
    convertedValue["ushort"] = ushortValue;
}
if (BigInteger.TryParse(input, out BigInteger bigIntegerValue))
{
    Console.WriteLine($"Die Eingabe ist eine BigInteger-Zahl: {bigIntegerValue}");
    convertedValue["bigint"] = bigIntegerValue;
}
Console.WriteLine($"Die Eingabe ist ein String: {input}");
convertedValue.Add("string", input);

while (true)   // loop until a valid key is chosen
{
    string key;
    if (convertedValue.Count == 1)
    {
        key = convertedValue.Keys.First();
    }
    else
    {
        Console.Write("\nMögliche Eingaben sind: ");
        foreach (var item in convertedValue)
        {
            Console.Write($"{item.Key} ");
        }
        Console.Write("\nBitte wählen Sie aus: ");
        key = Console.ReadLine() ?? string.Empty;   // avoid null reference exception
    }
    if (convertedValue.TryGetValue(key, out var value))
    {
        Console.WriteLine($"\nSie haben '{key}' mit dem Wert '{value}' gewählt.");
        Console.WriteLine($"Dieser Wert hat tatsächlich den Typ '{value.GetType()}'.");
        break;
    }
}