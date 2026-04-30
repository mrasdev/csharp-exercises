// Guess a random number between 1 and 100 (optionally 1000) within a loop until cancelled. A hint is shown after the second try if you get better (wärmer) or worse (kälter). You will be informed if or if not you've beaten the highscore.

namespace _15_WarmKaltSpiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            int numGuessed, numPrevious, count, highscore = 0;
            Console.Write("Wollen Sie es auf die harte Tour? (j/n) ");
            int rndMax = (Console.ReadLine() ?? "").Trim().Equals("j", StringComparison.OrdinalIgnoreCase) ? 1000 : 100;
            do
            {
                int numToGuess = rnd.Next(rndMax) + 1;  // random number 1..100
                Console.WriteLine("Zu erraten: " + numToGuess);  // only for internal use
                numPrevious = 0;
                count = 0;
                do
                {
                    while (true)
                    {
                        count++;
                        Console.Write($"{count}. Versuch - Erraten Sie die Zahl: ");
                        if (!int.TryParse(Console.ReadLine(), out numGuessed) || numGuessed <= 0)
                        {
                            Console.WriteLine("Falsche Eingabe!");
                            continue;
                        }
                        break;
                    }
                    if (numPrevious != 0 && numGuessed != numToGuess)
                    {
                        if (Math.Abs(numGuessed - numToGuess) < Math.Abs(numPrevious - numToGuess))
                        {
                            Console.WriteLine("Es wird wärmer.");
                        }
                        else
                        {
                            Console.WriteLine("Es wird kälter.");
                        }
                    }
                    numPrevious = numGuessed;
                } while (numGuessed != numToGuess);
                Console.WriteLine($"Sie haben die Zahl in {count} Versuchen erraten.");
                if (count == 1) Console.WriteLine("Hallo Chuck Norris...");
                else if (count < 10) Console.WriteLine("Das ist Spitzenklasse!");
                else if (count < 20) Console.WriteLine("Das haben Sie sehr gut gemacht.");
                else Console.WriteLine("Wir üben besser noch etwas...");
                if (highscore == 0)
                {
                    highscore = count;
                }
                else if (count < highscore)
                {
                    highscore = count;
                    Console.WriteLine("Sie haben einen neuen Highscore erreicht :)");
                }
                else
                {
                    Console.WriteLine($"Den Rekord von {highscore} Versuchen haben Sie nicht gebrochen.");
                }
                Console.WriteLine();
                Console.Write("Noch ein Versuch? (j/n) ");
            }
            while ((Console.ReadLine() ?? "").Trim().Equals("j", StringComparison.OrdinalIgnoreCase));
        }

    }
}
