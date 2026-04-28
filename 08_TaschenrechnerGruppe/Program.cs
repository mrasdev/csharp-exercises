/* Aufgabenstellung:
Erstellen Sie ein Konsolenprogramm, das die vier Grundrechenarten (Addition, Subtraktion, Multiplikation, Division) unterstützt.
- Verwenden Sie eine do-while-Schleife, damit das Programm wiederholt ausgeführt wird, bis der Benutzer es beenden möchte.
- Gestalten Sie eine einfache Konsolenoberfläche, die den Benutzer nach der gewünschten Rechenoperation und den beiden Operanden fragt.
- Nutzen Sie eine switch-Anweisung, um die gewählte Operation auszuführen und das Ergebnis anzuzeigen.
- Validieren Sie die Benutzereingaben. Behandeln Sie auch den Fall, dass eine ungültige Operation gewählt oder durch Null geteilt wird.
- Zeigen Sie das Ergebnis auf der Konsole an und fragen Sie, ob eine weitere Berechnung durchgeführt werden soll.
 */

/* Brainstorming:
 * Variable außerhalb Schleife: string weitereBerechnung
 * do
 * Reihenfolge egal:
 * - Frage Operator (+,-,*, /)
 * - Frage Operanden
 * Variabeln in der Schleife: double linkerOperand, double rechterOperand, string operatorEingabe
 * Prüfe alle Eingaben auf Gültigkeit (Operator und Operanden)
 * Fange div durch null ab
 * while (Benutzer hat nach der Rechnung die Frage "weiter?" nicht bestätigt)
 */

using System.Text;  // für Console.OutputEncoding

Console.OutputEncoding = Encoding.Default;   // wird benötigt, um unendlich Symbol darzustellen

string weitereBerechnung = "";  // muss hier initialisiert werden, damit die while Bedingung am Ende der Schleife überprüft werden kann

do
{
    Console.WriteLine("Bitte geben Sie den linken Operanden ein:");
    if (!double.TryParse(Console.ReadLine(), out double linkerOperand))
    {
        Console.WriteLine("Ungültige Eingabe für den linken Operanden");
        continue;
    }
    Console.WriteLine("Bitte geben Sie den rechten Operanden ein:");
    if (!double.TryParse(Console.ReadLine(), out double rechterOperand))
    {
        Console.WriteLine("Ungültige Eingabe für den rechten Operanden");
        continue;
    }
    Console.WriteLine("Bitte geben Sie den Operator (+, -, *, /) ein:");
    string operatorEingabe = Console.ReadLine() ?? "";   // vermeidet null
    operatorEingabe = operatorEingabe.Trim();
    switch (operatorEingabe)
    {
        case "+":
            Console.WriteLine($"{linkerOperand} + {rechterOperand} = {linkerOperand + rechterOperand}");
            break;
        case "-":
            Console.WriteLine($"{linkerOperand} - {rechterOperand} = {linkerOperand - rechterOperand}");
            break;
        case "*":
            Console.WriteLine($"{linkerOperand} * {rechterOperand} = {linkerOperand * rechterOperand}");
            break;
        case "/":
            if (rechterOperand == 0)
            {
                // Berechnung wird auch hier durchgeführt, da C# tatsächlich mit \inf umgehen kann, aber wir wollen trotzdem eine Fehlermeldung ausgeben, damit der Benutzer weiß, dass er etwas falsch gemacht hat
                Console.WriteLine($"{linkerOperand} / {rechterOperand} = {linkerOperand / rechterOperand}");
                Console.WriteLine("Division durch Null ist nicht erlaubt");
                break;
            }
            Console.WriteLine($"{linkerOperand} / {rechterOperand} = {linkerOperand / rechterOperand}");
            break;
        default:
            Console.WriteLine("Ungültiger Operator");
            continue;
    }

    Console.WriteLine("Noch eine Berechnung durchführen? (ja/nein)");
    weitereBerechnung = Console.ReadLine() ?? string.Empty;
// } while (weitereBerechnung.Trim().Equals("ja", StringComparison.CurrentCultureIgnoreCase));
} while (weitereBerechnung.Trim().ToLower() == "ja");
