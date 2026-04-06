namespace SunamoCollections;

/// <summary>
/// Wraps a result value along with an optional exception message.
/// </summary>
/// <typeparam name="T">The type of the result data.</typeparam>
public class ResultWithExceptionCollections<T>
{
    /// <summary>
    /// Gets or sets the result data.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets the exception message if an error occurred.
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// Initializes a new instance with result data.
    /// </summary>
    /// <param name="data">The result data.</param>
    public ResultWithExceptionCollections(T data)
    {
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance with an exception message.
    /// </summary>
    /// <param name="exceptionMessage">The exception message.</param>
    public ResultWithExceptionCollections(string exceptionMessage)
    {
        ExceptionMessage = exceptionMessage;
    }

    /// <summary>
    /// Initializes a new instance from an exception.
    /// </summary>
    /// <param name="exception">The exception to extract the message from.</param>
    public ResultWithExceptionCollections(Exception exception)
    {
        ExceptionMessage = Exceptions.TextOfExceptions(exception);
    }

    /// <summary>
    /// Initializes a new empty instance.
    /// </summary>
    public ResultWithExceptionCollections()
    {
    }
}
