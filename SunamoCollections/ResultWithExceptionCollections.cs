namespace SunamoCollections;

public class ResultWithExceptionCollections<T>
{
    public T Data { get; set; }
    public string ExceptionMessage { get; set; }
    public ResultWithExceptionCollections(T data)
    {
        Data = data;
    }
    public ResultWithExceptionCollections(string exceptionMessage)
    {
        this.ExceptionMessage = exceptionMessage;
    }
    public ResultWithExceptionCollections(Exception exception)
    {
        this.ExceptionMessage = Exceptions.TextOfExceptions(exception);
    }
    public ResultWithExceptionCollections()
    {
    }
}