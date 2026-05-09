namespace _20_Rechner_OOP.Modules;

internal class CalcManager
{
    // Nested types
    public record CalculationRecord(
        DateTime Timestamp,
        bool Success,
        string Summary
        );

    // Properties
    public List<CalculationRecord> Calculations { get; private set; } = [];
    public Operation Operator { get; set; }
    public bool Enabled { get; private set; } = true;  // to stop an external loop

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
            Console.WriteLine($"{rec.Timestamp:T}  {(rec.Success ? "✓" : "✕")}   {rec.Summary}");
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
                MathOperate();
                return;
        }
    }

    // Private methods
    private static void QueryOperands(Calculator calc)
    {
        calc.Operand1 = Calculator.QueryDoubleValue("Bitte geben Sie den ersten Operanden ein");
        calc.Operand2 = Calculator.QueryDoubleValue("Bitte geben Sie den zweiten Operanden ein");
    }

    private void MathOperate()
    {
        Calculator calc = new() { Operator = Operator };
        QueryOperands(calc);
        bool success = calc.Operate();
        string summary = calc.GetSummary();
        CalculationRecord rec = new(DateTime.Now, success, summary);
        Calculations.Add(rec); 
        Console.WriteLine();
        if (success) Console.WriteLine($"Das Ergebnis ist {calc.Result:f2}");
        Console.WriteLine($"Die Operation war {(success ? "" : "nicht ")}erfolgreich");
        Console.WriteLine();
    }
}
