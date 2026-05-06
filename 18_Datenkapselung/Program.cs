namespace _18_Datenkapselung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestePerson();
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
