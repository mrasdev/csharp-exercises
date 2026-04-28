int[] meineZahlen = { 10, 20, 40, 30, 44, 55 };  // Definition, d.h. die Variable wird gleich mit Werten initialisiert
double[] meineZahlen2 = { 10.5, 20, 40, 30 };  // Hier haben wir einen double, dann muss das ganze Array ein double sein, die Werte werden automatisch konvertiert (10.5 ist ein double, 20, 40 und 30 sind ints, die automatisch zu doubles konvertiert werden)
int[] andereZahlen = new int[2];  // Deklaration, d.h. die Variable wird ohne Werte initialisiert, es werden automatisch Standardwerte (0) zugewiesen

string[] Gaesteliste = { "Klaus", "Hamid", "Patrick" };  // Array aus Strings
//                           0        1          2       // Index startet bei 0

string[] gaesteDieKommen = new string[3];  // Wir wissen noch nicht, wer zur Party kommt, aber wir wissen, dass drei Gäste auf der Gästeliste stehen, deshalb reservieren wir Platz für drei Strings. Mehr Personen werden nicht kommen.

Gaesteliste[1] = "Andreas";  // Mit Index 1 (der zweite Platz) wird der Name "Hamid" überschrieben, jetzt steht dort "Andreas". Beim Array-Index fängt man immer bei Null an zu zählen, deshalb ist der erste Platz 0, der zweite Platz 1, der dritte Platz 2 usw.

Console.WriteLine("Gaesteliste[0] = " + Gaesteliste[0]);
Console.WriteLine("Gaesteliste[1] = " + Gaesteliste[1]);
Console.WriteLine("Gaesteliste[2] = " + Gaesteliste[2]);
// Console.WriteLine("Gaesteliste[3] = " + Gaesteliste[3]);  // Fehler, da es nur drei Plätze gibt, der Index 3 existiert nicht, deshalb gibt es eine Unbehandelte Ausnahme (unhandled exception) "Index außerhalb des Bereichs des Arrays". Gerade auf sog. Embedded Systems, also in der Software, die in Geräten wie Waschmaschinen, Autos, Handys usw. läuft, kann so eine unhandled exception zu einem kompletten Ausfall des Geräts führen. Deshalb ist es besonders wichtig, dass wir solche Fehler vermeiden, d.h. die Ausnahme abfangen und gezielt behandeln (z.B. Ausgabe einer Fehlermeldung, Einschalten einer Warnlampe).

Console.WriteLine("meineZahlen[0] = " + meineZahlen[0]);  // 10 wird ausgegeben, da wir das Array mit diesen Werten definiert haben
Console.WriteLine("andereZahlen[0] = " + andereZahlen[0]);  // 0 wird ausgegeben, da wir das Array mit der Größe 2 definiert haben, aber keine Werte zugewiesen haben, deshalb wurden die Standardwerte (0) zugewiesen

//Console.Clear();   // löscht Konsole, damit es übersichtlicher wird. Bitte Kommentar entfernen, wenn die alte Ausgabe gelöscht werden soll.

meineZahlen[1] = 80;  // wir können in einem Array einen einzelnen Wert ändern, indem wir den Index angeben und einen neuen Wert zuweisen, hier wird der Wert 20 durch 80 ersetzt
Console.WriteLine("meineZahlen[0] = " + meineZahlen[0]);
Console.WriteLine("meineZahlen[1] = " + meineZahlen[1]);
Console.WriteLine("meineZahlen[2] = " + meineZahlen[2]);
Console.WriteLine("meineZahlen[3] = " + meineZahlen[3]);

// meineZahlen = { 100, 200, 400, 300 };  // Diese Zuweisung ist nur bei der Deklaration erlaubt. Nach der Deklaration führt sie zu einer Fehlermeldung.

int[] testZahlen = new int[2];  // Das ist die ausführliche Schreibweise, um ein Array zu erstellen, hier wird ein Array mit der Größe 2 erstellt, die Werte werden automatisch mit Standardwerten (0) initialisiert und später mit neuen Werten überschrieben (17 und 33)
testZahlen[0] = 17;
testZahlen[1] = 33;

int[] neueZahlen2 = { 17, 33 };  // Das ist die Kurzschreibweise, um ein Array zu erstellen, hier wird ein Array mit der Größe 2 erstellt, die Werte werden direkt bei der Deklaration zugewiesen (17 und 33), die Größe des Arrays wird automatisch anhand der Anzahl der Werte bestimmt

Console.WriteLine("testZahlen.Length = " + testZahlen.Length);  // Die Eigenschaft Length gibt die Anzahl der Elemente im Array zurück, hier wird 2 ausgegeben, da das Array testZahlen zwei Elemente enthält (17 und 33). Das benötigen wir später bei Schleifen.

//Console.Clear();   // löscht Konsole, damit es übersichtlicher wird. Bitte Kommentar entfernen, wenn die alte Ausgabe gelöscht werden soll.

int meineZahl;          // Deklaration eines Integers
int neueZahl;           // Deklaration eines Integers
meineZahl = 10;         // Wertzuweisung, meineZahl wird mit 10 initialisiert
neueZahl = meineZahl;   // Wert wird kopiert und in neue Variable geschrieben, es liegen zwei Objekte im Speicher (byValue)
neueZahl = 100;         // Nur der Wert von neueZahl wird geändert, meineZahl bleibt unverändert, da es sich um zwei verschiedene Objekte im Speicher handelt, deshalb wird 10 ausgegeben, wenn wir den Wert von meineZahl abfragen, nur neueZahl wird zu 100 geändert
Console.WriteLine("meineZahl = " + meineZahl);
Console.WriteLine("neueZahl = " + neueZahl);

// int[] meineZahlen = { 10, 20, 40, 30, 44, 55 };  // So haben wir das Array weiter oben definiert
int[] neueZahlen;          // Deklaration eines Arrays of Integers
neueZahlen = meineZahlen;  // In die neue Variable wird ein Verweis (Pointer) auf das alte Array geschrieben, das Array liegt nur einmal im Speicher (byRef)
neueZahlen[0] = 100;       // Der Wert an Index 0 im Array wird geändert, da beide Variablen (meineZahlen und neueZahlen) auf dasselbe Array im Speicher zeigen, wird die Änderung in beiden Variablen sichtbar, deshalb wird 100 ausgegeben, wenn wir den Wert an Index 0 abfragen
Console.WriteLine("meineZahlen[0] = " + meineZahlen[0]);
Console.WriteLine("neueZahlen[0] = " + neueZahlen[0]);

//Console.Clear();   // löscht Konsole, damit es übersichtlicher wird. Bitte Kommentar entfernen, wenn die alte Ausgabe gelöscht werden soll.

for (int i = 0; i < meineZahlen.Length; i++)  // Schleife, die von 0 bis zur Länge des Arrays (exklusiv, d.h. bis 5, da das Array 6 Elemente hat) läuft, hier wird i als Index verwendet, um auf die Elemente des Arrays zuzugreifen. Der Wert von i wird in jedem Durchlauf um 1 erhöht (i++). Die Schleife wird 6 Mal durchlaufen mit den Indizes 0, 1, 2, 3, 4 und 5.
{
    //Console.WriteLine("meineZahlen[" + i + "] = " + meineZahlen[i]);  // einfacher zu verstehen, aber etwas schwierig zu lesen
    Console.WriteLine($"meineZahlen[{i}] = {meineZahlen[i]}");  // gleiche Ausgabe wie die Zeile darüber, hier wird die String Interpolation verwendet, um den Index und den Wert des Arrays in einer lesbaren Form auszugeben. 
}
Console.WriteLine();
for (int i = 0; i < meineZahlen.Length - 1; i++)  // Schleife nur bis zur Länge des Arrays - 1, damit wir nicht über das Ende des Arrays hinausgehen, wenn wir auf das Element rechts daneben zugreifen wollen (siehe unten, [i + 1])
{
    Console.WriteLine($"meineZahlen[{i}] = {meineZahlen[i]}, Rechts daneben = {meineZahlen[i + 1]}");  // Der Wert von i wird hier nicht geändert
}
Console.WriteLine();
for (int i = 0; i < meineZahlen.Length - 1; i++)
{
    Console.WriteLine($"meineZahlen[{i}] = {meineZahlen[i]}, NICHT Rechts daneben = {meineZahlen[i++]}");  // Die for Schleife erhöht i um 1, und in der Schleife selbst wird i auch um 1 erhöht, deshalb wird hier jedes zweite Element des Arrays ausgegeben. Es wird nicht das Element rechts daneben ausgegeben, sondern das aktuelle Element, da i erst nach dem Zugriff auf das Array erhöht wird. Das ist ein häufiger Fehler.
}
Console.WriteLine();
for (int i = 1; i < meineZahlen.Length; i++)  // Auch hier müssen wir auf die Grenzen aufpassen. Die Schleife fängt bei 1 an, damit wir nicht über den Anfang des Arrays hinausgehen, wenn wir auf das Element links daneben zugreifen wollen
{
    Console.WriteLine($"meineZahlen[{i}] = {meineZahlen[i]}, Links daneben = {meineZahlen[i - 1]}");  
}

Console.WriteLine();  
foreach (int zahl in meineZahlen)  // Die foreach Schleife ist eine "Abkürzung" für die for Schleife, sie ist einfacher zu lesen und zu schreiben, aber sie bietet weniger Kontrolle über den Index und die Reihenfolge der Elemente. Sie wird verwendet, wenn wir alle Elemente eines Arrays oder einer Sammlung durchlaufen wollen, ohne uns um die Indizes kümmern zu müssen. In der foreach Schleife wird automatisch jedes Element des Arrays nacheinander durchlaufen, bis alle Elemente verarbeitet wurden. Achtung, wir verwenden hier die Variable "zahl", denn es handelt sich um den Wert des aktuellen Elements, nicht um den Index. Wenn wir den Index benötigen, müssen wir die for Schleife verwenden.
{ 
    Console.WriteLine($"zahl = {zahl}"); 
}
Console.WriteLine();
foreach (string gast in Gaesteliste)  // Hier erkennt man gut, dass die foreach Schleife fast schon der Formulierung in natürlicher Sprache entspricht. "Für jeden Gast in der Gästeliste, mache folgendes: ...". 
{
    Console.WriteLine($"gast = {gast}");
}

//Console.Clear();   // löscht Konsole, damit es übersichtlicher wird. Bitte Kommentar entfernen, wenn die alte Ausgabe gelöscht werden soll.

Console.WriteLine("Min = " + meineZahlen.Min());
Console.WriteLine("Max = " + meineZahlen.Max());
Console.WriteLine("Sum = " + meineZahlen.Sum());
Console.WriteLine("Average = " + meineZahlen.Average());
Console.WriteLine("Average = " + (double)(meineZahlen.Sum() / meineZahlen.Length));  // double cast auf int = Ganzzahl
Console.WriteLine("Average = " + meineZahlen.Sum() / (double)meineZahlen.Length);  // double cast auf ein Argument = der "/" Operator erkennt dass ein Operand ein double ist und gibt als Ergebnis deshalb eine Kommazahl aus
