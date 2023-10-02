// NDC Conf

// See https://aka.ms/new-console-template for more information
using System.Text;

Vector2 vec = default;
Console.WriteLine(vec);

Vector2? vec_nullable_1 = null;
Nullable<Vector2> vec_nullable_2 = null;
Console.WriteLine(vec_nullable_1);
Console.WriteLine(vec_nullable_2);


Collection<Vector2> vectors = new Collection<Vector2>();
for (int i = 0; i < 50; ++i)
{
    vectors.Add(new Vector2 { X = Random.Shared.NextSingle(), Y = Random.Shared.NextSingle() });
}

Console.WriteLine(vectors);


public struct Vector2 // non-nullable type
{
    public float X;
    public float Y;

    public override string ToString()
        => $"({X:F3}, {Y:F3})";
}

public class Collection<T>
{
    private T[] _array; // Field
    private int _lastElement;

    public T this[int index] => Get(index); // Indexer

    public Collection()
    {
        _array = new T[10];
        _lastElement = 0;
    }

    public T Get(int index) => _array[index];

    public void Add(T item)
    {
        _array[_lastElement] = item;
        _lastElement++;

        if (_lastElement >= _array.Length)
        {
            Array.Resize(ref _array, 2 * _array.Length);
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < _lastElement; ++i)
        {
            builder.AppendLine($"{i}: {_array[i].ToString()}");
        }

        return builder.ToString();
    }
}
