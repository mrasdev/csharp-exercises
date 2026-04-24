string newCalculation = "j";
do
{
    Console.WriteLine("Geben Sie den ersten Operanden ein:");
    if (!double.TryParse(Console.ReadLine(), out double ersterOperand))
    {
        Console.WriteLine("Ungültige Eingabe für den ersten Operanden.");
        continue;
    }
    Console.WriteLine("Geben Sie den zweiten Operanden ein:");
    if (!double.TryParse(Console.ReadLine(), out double zweiterOperand))
    {
        Console.WriteLine("Ungültige Eingabe für den zweiten Operanden.");
        continue;
    }
    Console.WriteLine("Geben Sie den Operator (+, -, *, /) ein:");
    string operatorInput = Console.ReadLine() ?? string.Empty;
    if (operatorInput == "/" && zweiterOperand == 0)
    {
        Console.WriteLine("Division durch Null ist nicht erlaubt.");
        continue;
    }
    switch(operatorInput)
    {
        case "+":
            Console.WriteLine($"{ersterOperand} + {zweiterOperand} = {ersterOperand + zweiterOperand}");
            break;
        case "-":
            Console.WriteLine($"{ersterOperand} - {zweiterOperand} = {ersterOperand - zweiterOperand}");
            break;
        case "*":
            Console.WriteLine($"{ersterOperand} * {zweiterOperand} = {ersterOperand * zweiterOperand}");
            break;
        case "/":
            Console.WriteLine($"{ersterOperand} / {zweiterOperand} = {ersterOperand / zweiterOperand}");
            break;
        default:
            Console.WriteLine("Ungültiger Operator.");
            continue;
    }
    Console.WriteLine("Nochmals eingeben? (j/n)");
    newCalculation = Console.ReadLine() ?? string.Empty;
} while (newCalculation.Trim().Equals("j", StringComparison.OrdinalIgnoreCase));