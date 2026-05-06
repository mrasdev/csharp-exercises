// Build a square which cannot be changed after being constructed. The square can tell its area.

namespace _18_Datenkapselung;

internal class Square
{
    public double Width { get; init; }
    public double Height { get; init; }

    public double GetArea() => Width * Height;
}
