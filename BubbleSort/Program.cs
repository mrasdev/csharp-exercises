/*
 * Bubble Sort Algorithm (Algorithmus = Schritt-für-Schritt-Anleitung zur Lösung eines Problems)
 * Vergleich von benachbarten Elementen und Vertauschen, wenn die linke Zahl größer als die rechte Zahl ist
 * Erster Durchgang:
 * { 5, 6, 1, 3 }  // erste Zahl mit zweiter Zahl vergleichen, keine Änderung
 * { 5, 6, 1, 3 }  // zweite Zahl mit dritter Zahl vergleichen, tauschen
 * { 5, 1, 6, 3 }  // dritte Zahl mit vierter Zahl vergleichen, tauschen    
 * { 5, 1, 3, 6 }  // erster Durchgang fertig, die größte Zahl ist jetzt an der letzten Stelle
 * Zweiter Durchgang:
 * { 5, 1, 3, 6 }  // erste Zahl mit zweiter Zahl vergleichen, tauschen
 * { 1, 5, 3, 6 }  // zweite Zahl mit dritter Zahl vergleichen, tauschen
 * { 1, 3, 5, 6 }  // dritte Zahl mit vierter Zahl vergleichen, keine Änderung
 * { 1, 3, 5, 6 }  // zweiter Durchgang fertig, die zweitgrößte Zahl ist jetzt an der vorletzten Stelle
 * Dritter Durchgang:
 * { 1, 3, 5, 6 }  // erste Zahl mit zweiter Zahl vergleichen, keine Änderung
 * { 1, 3, 5, 6 }  // zweite Zahl mit dritter Zahl vergleichen, keine Änderung
 * { 1, 3, 5, 6 }  // dritte Zahl mit vierter Zahl vergleichen, keine Änderung
 * { 1, 3, 5, 6 }  // dritter Durchgang fertig, die drittgrößte Zahl ist jetzt an der dritten Stelle
 * Damit steht die kleinste Zahl automatisch an der ersten Stelle, da alle größeren Zahlen nach rechts sortiert wurden. Wir benötigen also bei vier Zahlen nur drei Durchgänge, damit alle Zahlen an der richtigen Stelle stehen. Bei n Zahlen benötigen wir also n-1 Durchgänge, damit alle Zahlen an der richtigen Stelle stehen.
 * */

int[] zahlen = { 64, 34, 25, 12, 22, 11, 90 };

for (int i = 0; i < zahlen.Length - 1; i++)  // wir müssen einen Durchlauf weniger machen als die Anzahl der Zahlen, da die letzte Zahl nach dem vorletzten Durchlauf bereits an der richtigen Stelle ist
{
    bool wurdeGetauscht = false;  // wenn false, dann vorzeitiges Beenden der äußeren Schleife, da das Array bereits sortiert ist
    for (int j = 0; j < zahlen.Length - 1 - i; j++)  // da wir den Index in der Schleife um 1 erhöhen, darf die Schleife nur bis zur vorletzten Zahl laufen, damit wir nicht über die Array-Grenze hinauslaufen; die ersten i größten Zahlen sind bereits nach rechts sortiert, deshalb können wir die Schleife um i verkürzen
    {
        if (zahlen[j] > zahlen[j + 1])  // linke Zahl ist größer als rechte Zahl, also tauschen
        {
            int temp = zahlen[j];  // Puffervariable zum Zwischenspeichern
            zahlen[j] = zahlen[j + 1];
            zahlen[j + 1] = temp;
            wurdeGetauscht = true;
        }
    }
    if (!wurdeGetauscht)  // wenn in der inneren Schleife kein Tausch stattgefunden hat, dann ist das Array bereits sortiert und wir können die äußere Schleife vorzeitig beenden
    {
        break;
    }
}

foreach (int zahl in zahlen)
{
    Console.WriteLine("Zahl = " + zahl);
}