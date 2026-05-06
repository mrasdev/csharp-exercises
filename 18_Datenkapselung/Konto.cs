namespace _18_Datenkapselung;

internal class Konto
{
    string _kontonummer;
    double _saldo;
    const double _maxAuszahlen = 1000.0;

    public Konto()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;  // for currency output on console
    }

    public Konto(string kontonummer):this() 
    {
        _kontonummer = kontonummer;
        Console.WriteLine($"Ein Konto mit der Nummer {_kontonummer} wurde erstellt.");
    }

    public void Einzahlen(double betrag)
    {
        _saldo += betrag;
        Console.WriteLine($"Es wurden {betrag:c} einbezahlt. Der Kontostand ist jetzt {_saldo:c}.");
    }

    public void Auszahlen(double betrag)
    {
        if ( betrag > _maxAuszahlen)
        {
            Console.WriteLine($"Der maximale Auszahlungsbetrag von {_maxAuszahlen:c} wurde überschritten.");
            return;
        }
        if ( betrag > _saldo)
        {
            Console.WriteLine($"Eine Auszahlung von {betrag:c} ist nicht möglich, der Kontostand ist {_saldo:c}.");
            return;
        }
        _saldo -= betrag;
        Console.WriteLine($"Es wurden {betrag:c} ausbezahlt. Der Kontostand ist jetzt {_saldo:c}.");
    }
    public void SaldoAnzeigen()
    {
        Console.WriteLine($"Ihr Konto hat den aktuellen Stand {_saldo:c}.");
    }
}
