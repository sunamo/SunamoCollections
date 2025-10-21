// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections;

public class ResultWithExceptionCollections<T>
{
    public T Data { get; set; }
    public string exc { get; set; }
    public ResultWithExceptionCollections(T data)
    {
        Data = data;
    }
    public ResultWithExceptionCollections(string exc)
    {
        this.exc = exc;
    }
    public ResultWithExceptionCollections(Exception exc)
    {
        this.exc = Exceptions.TextOfExceptions(exc);
    }
    public ResultWithExceptionCollections()
    {
    }
}