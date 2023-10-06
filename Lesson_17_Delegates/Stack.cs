public class Stack<T>
{
    private T[] _array;
    private int _header;

    public event EventHandler<T> ItemAdded;

    public event EventHandler<T> ItemRemoved;

    public Stack()
    {
        _array = new T[100];
        _header = 0;
    }

    public T Peek() => _array[_header];

    public T Pop()
    {
        T value = _array[--_header];
        ItemRemoved?.Invoke(this, value);
        return value;
    }

    public void Push(T value)
    {
        _array[_header++] = value;
        ItemAdded?.Invoke(this, value);
    }
}