namespace _20_Rechner_OOP.Modules;

internal class Calculator
{
    // Properties
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }
    public Operation Operator { get; set; }
    public double Result { get; private set; }
    public bool Success { get; private set; } = true;

    // Public methods
    public void QueryOperands()
    {
        Operand1 = QueryDoubleValue("Bitte geben Sie den ersten Operanden ein");
        Operand2 = QueryDoubleValue("Bitte geben Sie den zweiten Operanden ein");
    }


    public void Operate()
    {
        Success = true;
        switch (Operator)
        {
            case Operation.Add:
                QueryOperands();
                Result = Operand1 + Operand2;
                return;
            case Operation.Subtract:
                QueryOperands();
                Result = Operand1 - Operand2;
                return;
            case Operation.Multiply:
                QueryOperands();
                Result = Operand1 * Operand2;
                return;
            case Operation.Divide:
                QueryOperands();
                Result = Operand1 / Operand2;
                if (Operand2 == 0)
                {
                    Console.WriteLine("\nWARNUNG: Division durch Null!");
                    Success = false;
                }
                return;
            case Operation.Modulo:
                QueryOperands();
                Result = Operand1 % Operand2;
                if (Operand2 == 0)
                {
                    Console.WriteLine("\nWARNUNG: Modulo durch Null!");
                    Success = false;
                }
                return;
            default:
                Console.WriteLine($"\nFEHLER: Unbekannter Operator: {Operator}");
                Success = false;
                return;
        }
    }

    public void ShowResult()
    {
        if (Operator == Operation.Quit || Operator == Operation.History) return;
        Console.WriteLine();
        if (Success) Console.WriteLine($"Das Ergebnis ist {Result:f2}");
        Console.WriteLine($"Die Operation war {(Success ? "" : "nicht ")}erfolgreich");
        Console.WriteLine();
    }

    public string GetSummary()
    {
        string summary = $"{(Success ? "✓" : "✕")}   {Operand1} {Operator.GetSign()} {Operand2} = {Result}";
        return summary;
    }

    // Helper Methods
    static double QueryDoubleValue(string message)
    {
        while (true)
        {
            Console.Write($"{message}: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("FEHLER: Falsche Eingabe!");
                continue;
            }
            return value;
        }
    }
}
