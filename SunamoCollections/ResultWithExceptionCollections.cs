namespace SunamoCollections;

/// <summary>
/// Represents the result with exception collections t type.
/// </summary>
public class ResultWithExceptionCollections<T>
{
    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets the exception message.
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// Result with exception collections.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>The result with exception collections result.</returns>
    public ResultWithExceptionCollections(T data)
    {
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the result with exception collections class.
    /// </summary>
    /// <param name="data">The data.</param>
    public ResultWithExceptionCollections(string exceptionMessage)
    {
        ExceptionMessage = exceptionMessage;
    }

    /// <summary>
    /// Initializes a new instance of the result with exception collections class.
    /// </summary>
    /// <param name="exceptionMessage">The exception message.</param>
    public ResultWithExceptionCollections(Exception exception)
    {
        ExceptionMessage = Exceptions.TextOfExceptions(exception);
    }

    /// <summary>
    /// Initializes a new instance of the result with exception collections class.
    /// </summary>
    /// <param name="exception">The exception.</param>
    public ResultWithExceptionCollections()
    {
    }
}
