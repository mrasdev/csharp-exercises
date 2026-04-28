Random rnd = new Random();
int[] randomNumbers = new int[6];
int count = 0;
do
{
    int randomNumber = rnd.Next(1, 50); // Generates a random number between 1 and 49
    if (!randomNumbers.Contains(randomNumber))
    {
        randomNumbers[count] = randomNumber;
        count++;
    }
} while (count < 6);
Console.WriteLine("randomNumbers (for debug):    " + randomNumbers.Aggregate(string.Empty, (s, i) => s + $"{i:d2} "));

int[] userNumbers = new int[6];
count = 0;
do
{
    Console.Write($"Bitte {count + 1}. Zahl eingeben: ");
    if (!int.TryParse(Console.ReadLine(), out int userInput) || userInput < 1 || userInput > 49)
    {
        Console.WriteLine("Bitte eine Zahl zwischen 1 und 49 eingeben!\n");
        continue;
    }
    if (userNumbers.Contains(userInput))
    {
        Console.WriteLine("Diese Zahl haben Sie bereits eingegeben!\n");
        continue;
    }
    userNumbers[count] = userInput;
    count++;
} while (count < 6);

Console.WriteLine("Die gezogenen Zahlen sind:    " + randomNumbers.Aggregate(string.Empty, (s, i) => s + $"{i:d2} "));
Console.WriteLine("Ihre gewählten Zahlen sind:   " + userNumbers.Aggregate(string.Empty, (s, i) => s + $"{i:d2} "));
int numberOfMatches = userNumbers.Count(item => randomNumbers.Contains(item));
Console.WriteLine("Anzahl der Übereinstimmungen: " + numberOfMatches);
