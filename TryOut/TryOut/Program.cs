// See https://aka.ms/new-console-template for more information

double d = 5.5;
int e = (int)d;   // This is an explicit cast, which truncates the decimal part and assigns the integer value 5 to e.

string s = "5";
int f = Convert.ToInt32(s);

int a = Convert.ToInt32(null);   // Convert converts a null value to 0, so no exception is thrown and a will be assigned the value 0.
Console.WriteLine($"a = {a}");

try
{
    int b = Int32.Parse(null);   // Int32.Parse throws an ArgumentNullException when it receives a null value.
catch (ArgumentNullException)
{
    Console.WriteLine("Ausnahme abgefangen!");
}
int age1 = 3;
int age2 = 4;
Console.WriteLine($"Durschnittsalter = {(age1 + age2) / 2.0}");   // Because of the presence of the double literal 2.0, the division will be performed as floating-point division, resulting in a double value of 3.5.
