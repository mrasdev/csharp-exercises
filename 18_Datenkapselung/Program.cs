namespace _18_Datenkapselung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestePerson();
            //TesteKonto();
            TesteRechteck();
        }

        private static void TesteRechteck()
        {
            Square square = new Square { Width = 120, Height = 2 };
            Console.WriteLine($"Die Fläche beträgt {square.GetArea()}.");
        }

        private static void TesteKonto()
        {
            Konto konto1 = new Konto("0815");
            konto1.SaldoAnzeigen();
            konto1.Einzahlen(100);
            konto1.SaldoAnzeigen();
            konto1.Auszahlen(200);
            konto1.Auszahlen(100);
            konto1.Einzahlen(2000);
            konto1.Auszahlen(1100);
            konto1.SaldoAnzeigen();
            Konto konto2 = new Konto("2222");
            konto1.ZinssatzAnzeigen();
            konto2.ZinssatzAnzeigen();
            Console.WriteLine("Ändere Zinssatz von Konto 0815");
            konto1.ZinssatzSetzen(0.03);
            konto1.ZinssatzAnzeigen();
            konto2.ZinssatzAnzeigen();

        }

        private static void TestePerson()
        {
            Person person = new Person();  // Rufe Default Konstruktor ohne Inhalt auf
            person.SetzeVorname();  // Frage Name vom Anwender ab und speichere ihn im Objekt
            person.SetzeNachname();  // Frage Name vom Anwender ab und speichere ihn im Objekt
            person.SagHallo();
            person = new Person(vorname: "Michael", nachname: "Meier");  // Neues Objekt mit definierten Werten
            person.SagHallo();
            person.LoescheNamen();
            person.SagHallo();
            person.SetzeVorname("Martin");
            person.SetzeNachname("Müller");
            person.SagHallo();
        }
    }
}
