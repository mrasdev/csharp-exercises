// Simple Calculator in C#. Reads two operands and an operator from the user, performs the calculation, and displays the result.

List<string> validOperators = ["+", "-", "*", "/", "%"];

while (true)
{
    Console.Write("Bitte geben Sie den linken Operanden ein: ");
    if (!double.TryParse(Console.ReadLine(), out double leftOperand))
    {
        Console.WriteLine("Ungültige Eingabe für den linken Operanden.");
        return;
    }
    Console.Write("\nBitte geben Sie den rechten Operanden ein: ");
    if (!double.TryParse(Console.ReadLine(), out double rightOperand))
    {
        Console.WriteLine("Ungültige Eingabe für den rechten Operanden.");
        return;
    }
    Console.Write("\nBitte geben Sie den Operator ein ({0}): ", string.Join(", ", validOperators));
    string myOperator = (Console.ReadLine() ?? String.Empty).Trim();   // avoid null reference exception and trim whitespace
    if (!validOperators.Contains(myOperator))
    {
        Console.WriteLine("Ungültiger Operator");
        return;
    }

    switch (myOperator)
    {
        case "+":
            Console.WriteLine($"{leftOperand} + {rightOperand} = {leftOperand + rightOperand}");
            break;
        case "-":
            Console.WriteLine($"{leftOperand} - {rightOperand} = {leftOperand - rightOperand}");
            break;
        case "*":
            Console.WriteLine($"{leftOperand} * {rightOperand} = {leftOperand * rightOperand}");
            break;
        case "/":
            if (rightOperand == 0)
            {
                Console.WriteLine("Division durch Null ist nicht erlaubt.");
                return;
            }
            Console.WriteLine($"{leftOperand} / {rightOperand} = {leftOperand / rightOperand}");
            break;
        case "%":
            if (rightOperand == 0)
            {
                Console.WriteLine("Modulo Null ist nicht definiert.");
                return;
            }
            Console.WriteLine($"{leftOperand} % {rightOperand} = {leftOperand % rightOperand}");
            break;
    }

    Console.Write("\nMöchten Sie eine weitere Berechnung durchführen? (j/n): ");
    string continueLoop = Console.ReadLine() ?? String.Empty;
    if (continueLoop.Equals("n", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Auf Wiedersehen!");
        return;
    }
    Console.WriteLine(); // add an empty line for better readability before the next calculation
}