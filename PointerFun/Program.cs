// add <AllowUnsafeBlocks>true</AllowUnsafeBlocks> to csproj file to allow unsafe code to compile

class Program
{
    static unsafe void Main()
    {
        int ersteZahl = 5;
        int zweiteZahl = ersteZahl;
        Console.WriteLine("ersteZahl Wert: " + ersteZahl);
        Console.WriteLine("zweiteZahl Wert: " + zweiteZahl);
        Console.WriteLine("ersteZahl Adresse: " + (long)&ersteZahl);
        Console.WriteLine("zweiteZahl Adresse: " + (long)&zweiteZahl);

        zweiteZahl = 10;
        Console.WriteLine("ersteZahl nach Änderung: " + ersteZahl);
        Console.WriteLine("zweiteZahl nach Änderung: " + zweiteZahl);

        //int* pointerToErsteZahl = &ersteZahl;
        //*pointerToErsteZahl = 20;
        //Console.WriteLine("ersteZahl nach Änderung mit Zeiger: " + ersteZahl);


        //int ersteZahl = 5;
        //int* zweiteZahl = &ersteZahl;
        //Console.WriteLine("ersteZahl Wert: " + ersteZahl);
        //Console.WriteLine("zweiteZahl Wert: " + *zweiteZahl);
        //Console.WriteLine("ersteZahl Adresse: " + (long)&ersteZahl);
        //Console.WriteLine("zweiteZahl Adresse: " + (long)zweiteZahl);

        //*zweiteZahl = 10;
        //Console.WriteLine("ersteZahl nach Änderung: " + ersteZahl);
        //Console.WriteLine("zweiteZahl nach Änderung: " + *zweiteZahl);
    }
}