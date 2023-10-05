// NDC Conf

// See https://aka.ms/new-console-template for more information
public struct Vector2 // non-nullable type
{
    public float X;
    public float Y;

    public override string ToString()
        => $"({X:F3}, {Y:F3})";
}
