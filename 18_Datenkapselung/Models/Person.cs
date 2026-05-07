namespace _18_Datenkapselung.Models;

internal class Person
{
    string _vorname;
    string _nachname;

    public Person()
    {
    }

    public Person(string vorname, string nachname)
    {
        SetzeVorname(vorname);
        SetzeNachname(nachname);
    }

    public void SetzeNachname(string nachname = "")
    {
        if (nachname.Length > 0)
        {
            _nachname = nachname;
            return;
        }
        Console.Write("Bitte Nachnamen eingeben: ");
        _nachname = Console.ReadLine() ?? string.Empty;
    }

    public void SetzeVorname(string vorname = "")
    {
        if (vorname.Length > 0)
        {
            _vorname = vorname;
            return;
        }
        Console.Write("Bitte Vornamen eingeben: ");
        _vorname = Console.ReadLine() ?? string.Empty;
    }

    public void SagHallo()
    {
        if (_vorname.Length == 0 || _nachname.Length == 0)
        {
            Console.WriteLine("FEHLER: Vor- bzw. Nachname ist nicht definiert.");
            return;
        }
        Console.WriteLine($"Hallo, ich heiße {_vorname} {_nachname}.");
    }

    public void LoescheNamen()
    {
        _vorname = "";
        _nachname = "";
    }
}
