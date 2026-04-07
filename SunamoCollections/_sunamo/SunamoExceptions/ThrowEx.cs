namespace SunamoCollections._sunamo.SunamoExceptions;

/// <summary>
/// Utility class for throwing formatted exceptions with caller context information.
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws if the two collections have different element counts.
    /// </summary>
    /// <param name="firstCollectionName">The name of the first collection.</param>
    /// <param name="firstCollectionCount">The count of the first collection.</param>
    /// <param name="secondCollectionName">The name of the second collection.</param>
    /// <param name="secondCollectionCount">The count of the second collection.</param>
    /// <returns>True if an exception was thrown.</returns>
    internal static bool DifferentCountInLists(string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), firstCollectionName, firstCollectionCount, secondCollectionName, secondCollectionCount));
    }

    /// <summary>
    /// Throws a divide-by-zero exception.
    /// </summary>
    /// <returns>True if an exception was thrown.</returns>
    internal static bool DivideByZero() { return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode())); }

    /// <summary>
    /// Throws if the specified variable is null.
    /// </summary>
    /// <param name="variableName">The name of the variable.</param>
    /// <param name="variable">The variable to check.</param>
    /// <returns>True if an exception was thrown.</returns>
    internal static bool IsNull(string variableName, object? variable = null)
    { return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable)); }

    /// <summary>
    /// Throws a not-implemented-case exception for the specified value.
    /// </summary>
    /// <param name="notImplementedName">The value of the unimplemented case.</param>
    /// <returns>True if an exception was thrown.</returns>
    internal static bool NotImplementedCase(object notImplementedName)
    { return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName); }

    /// <summary>
    /// Throws a not-implemented-method exception.
    /// </summary>
    /// <returns>True if an exception was thrown.</returns>
    internal static bool NotImplementedMethod() { return ThrowIsNotNull(Exceptions.NotImplementedMethod); }

    /// <summary>
    /// Gets the full name of the currently executed code (type and method).
    /// </summary>
    /// <returns>The fully qualified type and method name.</returns>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Gets the full name of the executed code from a type object and method name.
    /// </summary>
    /// <param name="typeObject">The type object (Type, MethodBase, string, or any object).</param>
    /// <param name="methodName">The method name.</param>
    /// <param name="isFromThrowEx">Whether this call originates from ThrowEx (adjusts stack depth).</param>
    /// <returns>The fully qualified type and method name.</returns>
    static string FullNameOfExecutedCode(object typeObject, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (typeObject is Type typeAsType)
        {
            typeFullName = typeAsType.FullName ?? "Type cannot be get via Type is Type";
        }
        else if (typeObject is MethodBase methodBase)
        {
            typeFullName = methodBase.ReflectedType?.FullName ?? "Type cannot be get via Type is MethodBase";
            methodName = methodBase.Name;
        }
        else if (typeObject is string)
        {
            typeFullName = typeObject.ToString() ?? "Type cannot be get via Type is string";
        }
        else
        {
            Type objectType = typeObject.GetType();
            typeFullName = objectType.FullName ?? "Type cannot be get via Type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws an exception if the message is not null.
    /// </summary>
    /// <param name="exceptionMessage">The exception message to check.</param>
    /// <param name="isReallyThrowing">Whether to actually throw or just return true.</param>
    /// <returns>True if the exception message was not null.</returns>
    internal static bool ThrowIsNotNull(string? exceptionMessage, bool isReallyThrowing = true)
    {
        if (exceptionMessage != null)
        {
            Debugger.Break();
            if (isReallyThrowing)
            {
                throw new Exception(exceptionMessage);
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Throws an exception produced by the factory function if the result is not null.
    /// </summary>
    /// <typeparam name="TArgument">The type of the argument passed to the factory.</typeparam>
    /// <param name="exceptionFactory">The factory function that creates the exception message.</param>
    /// <param name="argument">The argument to pass to the factory.</param>
    /// <returns>True if an exception was thrown.</returns>
    internal static bool ThrowIsNotNull<TArgument>(Func<string, TArgument, string?> exceptionFactory, TArgument argument)
    {
        string? exceptionMessage = exceptionFactory(FullNameOfExecutedCode(), argument);
        return ThrowIsNotNull(exceptionMessage);
    }

    /// <summary>
    /// Throws an exception produced by the factory function if the result is not null.
    /// </summary>
    /// <param name="exceptionFactory">The factory function that creates the exception message.</param>
    /// <returns>True if an exception was thrown.</returns>
    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFactory)
    {
        string? exceptionMessage = exceptionFactory(FullNameOfExecutedCode());
        return ThrowIsNotNull(exceptionMessage);
    }
}
