public interface IInterfaceRegular<T>
{
    T GetSomeValue();
    void SetSomeValue(T arg);
}


// Covariant
interface IInterfaceCovariant<out T>
{
    T GetValue();
}

// Contrvariant
interface IInterfaceContrvariant<in T>
{
    void SetValue(T arg);
}