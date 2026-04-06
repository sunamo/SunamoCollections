namespace SunamoCollections._sunamo.SunamoExceptions;

/// <summary>
/// Utility class for throwing formatted exceptions with caller context information.
/// </summary>
internal partial class ThrowEx
{
    internal static bool DifferentCountInLists(string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), firstCollectionName, firstCollectionCount, secondCollectionName, secondCollectionCount));
    }

    internal static bool DivideByZero() { return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode())); }

    internal static bool IsNull(string variableName, object? variable = null)
    { return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable)); }

    internal static bool NotImplementedCase(object notImplementedName)
    { return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName); }

    internal static bool NotImplementedMethod() { return ThrowIsNotNull(Exceptions.NotImplementedMethod); }

    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

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

    internal static bool ThrowIsNotNull<TArgument>(Func<string, TArgument, string?> exceptionFactory, TArgument argument)
    {
        string? exceptionMessage = exceptionFactory(FullNameOfExecutedCode(), argument);
        return ThrowIsNotNull(exceptionMessage);
    }

    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFactory)
    {
        string? exceptionMessage = exceptionFactory(FullNameOfExecutedCode());
        return ThrowIsNotNull(exceptionMessage);
    }
}
