// Console calculator with basic mathematical functions
using System.Diagnostics.CodeAnalysis;

namespace _20_Rechner_OOP.Modules;

internal class Calculator
{
    // Properties
    public double Operand1 { get; set; }  
    public double Operand2 { get; set; } 
    public Operation Operator { get; set; } 
    public double Result { get; private set; }

    // Public methods
    public static double QueryDoubleValue(string message)
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

    public void QueryOperands()
    {
        Operand1 = QueryDoubleValue("Bitte geben Sie den ersten Operanden ein");
        Operand2 = QueryDoubleValue("Bitte geben Sie den zweiten Operanden ein");
    }

    public bool Operate()  // returns true if operation was successful
    {
        if (Operator.IsMathOp())
        {
            return MathOperate();
        }
        Console.WriteLine($"\nFEHLER: Unbekannter Operator: {Operator}");
        return false;
    }

    public string GetSummary()
    {
        string summary = $"{Operand1} {Operator.GetSign()} {Operand2} = {Result}";
        return summary;
    }

    // Private methods

    private bool MathOperate()  // returns true if operation was successful
    {
        switch (Operator)
        {
            case Operation.Add:
                Result = Operand1 + Operand2;
                return true;
            case Operation.Subtract:
                Result = Operand1 - Operand2;
                return true;
            case Operation.Multiply:
                Result = Operand1 * Operand2;
                return true;
            case Operation.Divide:
                Result = Operand1 / Operand2;
                if (Operand2 == 0)
                {
                    Console.WriteLine("\nWARNUNG: Division durch Null!");
                    return false;
                }
                return true;
            case Operation.Modulo:
                Result = Operand1 % Operand2;
                if (Operand2 == 0)
                {
                    Console.WriteLine("\nWARNUNG: Modulo durch Null!");
                    return false;
                }
                return true;
            default:
                throw new NotImplementedException();
        }
    }
}