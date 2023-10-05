using System.Collections;
using System.Text;

public class Collection<T> : IEnumerable<T>
{
    private class CollectionEnumerator : IEnumerator<T>
    {
        private int _index;

        private readonly Collection<T> _collection;

        public T Current => _collection[_index];

        object IEnumerator.Current => (object)Current;

        public CollectionEnumerator(Collection<T> collection)
        {
            _collection = collection;
            _index = 0;
        }

        public bool MoveNext() => ++_index > _collection._lastElement;

        public void Reset() => _index = 0;

        public void Dispose()
        {
        }
    }

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

    public IEnumerator<T> GetEnumerator() => new CollectionEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

