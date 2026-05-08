using System.Data;

namespace _19_TemperaturStatistik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TemperaturStatistik temperaturStatistik = new TemperaturStatistik();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                temperaturStatistik.NeueMessungErfassen(rnd.NextDouble() * 100.0);
            }
            //temperaturStatistik.NeueMessungErfassen(5);
            //temperaturStatistik.NeueMessungErfassen(6);
            //temperaturStatistik.NeueMessungErfassen(7);
            // ConsoleWriteLineAusprobiererle(temperaturStatistik);
            Console.WriteLine($"Durschnitt = {temperaturStatistik.Durchschnitt():f2} °C");  // = 6
            Console.WriteLine($"Maximum = {temperaturStatistik.Maximalwert():f2} °C");  // = 7
        }

        private static void ConsoleWriteLineAusprobiererle(TemperaturStatistik temperaturStatistik)
        {
            Console.WriteLine("Durchschnitt = " + temperaturStatistik.Durchschnitt() + " und das Maximum ");
            string vorname = "Pierre";
            string nachname = "Anders";
            double zahl = 23.6546786654687654654;
            Console.WriteLine("Ich heiße {0} und mein kompletter Name ist {0} {1} und bin AE.", vorname, nachname);
            Console.WriteLine($"Ich heiße {vorname} und mein kompletter Name ist {vorname} {nachname} und bin AE.");
            Console.WriteLine($"Zahl = {zahl:f3}");
            double durchschnitt = temperaturStatistik.Durchschnitt();
            Console.WriteLine($"Durschnitt = {durchschnitt:f3}");
        }
    }
}
