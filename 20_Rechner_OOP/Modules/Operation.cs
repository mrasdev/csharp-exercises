using System.ComponentModel;
using System.Reflection;

namespace _20_Rechner_OOP.Modules;

public enum Operation
{
    [Description("Programm verlassen")]
    Quit,

    [Description("Addition (+)")]
    Add,

    [Description("Subtraktion (-)")]
    Subtract,

    [Description("Multiplikation (*)")]
    Multiply,

    [Description("Division (/)")]
    Divide,

    [Description("Modulo (%)")]
    Modulo,

    [Description("Historie anzeigen")]
    History,
}

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        if (fi == null) return "";
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    }

    public static string GetSign(this Enum value) => value switch
    {
        Operation.Add => "+",
        Operation.Subtract => "-",
        Operation.Multiply => "*",
        Operation.Divide => "/",
        Operation.Modulo => "%",
        _ => "?"
    };

}