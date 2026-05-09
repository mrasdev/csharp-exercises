// Provide an enum with basic mathematical operations and helper functions to get their sign and description.
namespace _20_Rechner_OOP.Modules;

public enum Operation
{
    Quit,
    Add,
    Subtract,
    Multiply,
    Divide,
    Modulo,
    History,
}

public static class EnumExtensions
{
    public static string GetDescription(this Operation value) => value switch
    {
        Operation.Quit => "Programm verlassen",
        Operation.Add => "Addieren (+)",
        Operation.Subtract => "Subtrahieren (-)",
        Operation.Multiply => "Multiplizieren (*)",
        Operation.Divide => "Dividieren (/)",
        Operation.Modulo => "Modulo (%)",
        Operation.History => "Verlauf anzeigen",
        _ => throw new NotImplementedException()
    };

    public static string GetSign(this Operation value) => value switch
    {
        Operation.Add => "+",
        Operation.Subtract => "-",
        Operation.Multiply => "*",
        Operation.Divide => "/",
        Operation.Modulo => "%",
        _ => "?"
    };

    public static bool IsMathOp(this Operation value)
        => value != Operation.Quit && value != Operation.History;
}