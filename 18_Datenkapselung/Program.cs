namespace _18_Datenkapselung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestePerson();
            TesteKonto();
        }

        private static void TesteKonto()
        {
            Konto konto = new Konto("0815");
            konto.SaldoAnzeigen();
            konto.Einzahlen(100);
            konto.SaldoAnzeigen();
            konto.Auszahlen(200);
            konto.Auszahlen(100);
            konto.Einzahlen(2000);
            konto.Auszahlen(1100);
            konto.SaldoAnzeigen();

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
