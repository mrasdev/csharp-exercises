namespace _20_Rechner_OOP.Modules;

internal class CalcManager
{
    // Nested types
    public record CalculationRecord(
        DateTime Timestamp,
        Calculator Calculation
        );

    // Properties
    public List<CalculationRecord> Calculations { get; private set; } = [];
    public Operation Operator { get; set; }
    public bool Enabled { get; private set; } = true;
    public DateTime Timestamp { get; private set; }

    // Public methods
    public void SetOperation()
    {
        Console.WriteLine("Verfügbare Operationen:");
        var ops = Enum.GetValues<Operation>();
        for (int i = 0; i < ops.Length; i++)
        {
            Console.WriteLine($"{i} - {ops[i].GetDescription()}");
        }
        while (true)
        {
            Console.Write("\nIhre Auswahl: ");
            if (!Enum.TryParse(Console.ReadLine(), out Operation selection) ||
                !Enum.IsDefined(typeof(Operation), selection))
            {
                Console.WriteLine("FEHLER: Falsche Eingabe!");
                continue;
            }
            Operator = selection;
            return;
        }
    }

    public void ShowCalculations()
    {
        Console.WriteLine();
        if (Calculations.Count == 0)
        {
            Console.WriteLine("FEHLER: Keine Berechnungen vorhanden\n");
            return;
        }
        foreach (CalculationRecord rec in Calculations)
        {
            Console.WriteLine($"{rec.Timestamp:T}  {rec.Calculation.GetSummary()}");
        }
        Console.WriteLine();
    }

    public void Operate()
    {
        switch (Operator)
        {
            case Operation.Quit:
                Console.WriteLine("\nDie Anwendung wird beendet.\n");
                Enabled = false;
                return;
            case Operation.History:
                ShowCalculations();
                return;
            default:
                Calculator calc = new() { Operator = Operator };
                calc.Operate();
                calc.ShowResult();
                CalculationRecord rec = new(DateTime.Now, calc);
                Calculations.Add(rec);
                return;
        }
    }
}
