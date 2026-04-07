namespace SunamoCollections._sunamo.SunamoExceptions;

/// <summary>
/// Exception message formatting utilities.
/// </summary>
internal sealed partial class Exceptions
{
    /// <summary>
    /// Formats a prefix string for exception messages.
    /// </summary>
    /// <param name="before">The prefix text.</param>
    /// <returns>The formatted prefix with colon separator, or empty string if blank.</returns>
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Extracts text from an exception and its inner exceptions.
    /// </summary>
    /// <param name="exception">The exception to extract text from.</param>
    /// <param name="isIncludingInner">Whether to include inner exception messages.</param>
    /// <returns>A formatted string containing all exception messages.</returns>
    internal static string TextOfExceptions(Exception exception, bool isIncludingInner = true)
    {
        if (exception == null) return string.Empty;
        StringBuilder stringBuilder = new();
        stringBuilder.Append("Exception:");
        stringBuilder.AppendLine(exception.Message);
        if (isIncludingInner)
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                stringBuilder.AppendLine(exception.Message);
            }
        var result = stringBuilder.ToString();
        return result;
    }

    /// <summary>
    /// Gets the calling type name, method name, and full stack trace from the current call stack.
    /// </summary>
    /// <param name="isFillingFirstTwo">Whether to populate the type and method name from the first non-ThrowEx frame.</param>
    /// <returns>A tuple of (typeName, methodName, stackTraceText).</returns>
    internal static Tuple<string, string, string> PlaceOfException(bool isFillingFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceText = stackTrace.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var currentIndex = 0;
        string typeName = string.Empty;
        string methodName = string.Empty;
        for (; currentIndex < lines.Count; currentIndex++)
        {
            var currentLine = lines[currentIndex];
            if (isFillingFirstTwo)
                if (!currentLine.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(currentLine, out typeName, out methodName);
                    isFillingFirstTwo = false;
                }
            if (currentLine.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(typeName, methodName, string.Join(Environment.NewLine, lines));
    }

    /// <summary>
    /// Extracts the type name and method name from a stack trace line.
    /// </summary>
    /// <param name="stackTraceLine">The stack trace line to parse.</param>
    /// <param name="typeName">The extracted type name.</param>
    /// <param name="methodName">The extracted method name.</param>
    internal static void TypeAndMethodName(string stackTraceLine, out string typeName, out string methodName)
    {
        var afterAt = stackTraceLine.Split("at ")[1].Trim();
        var fullQualifiedName = afterAt.Split("(")[0];
        var parts = fullQualifiedName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        typeName = string.Join(".", parts);
    }

    /// <summary>
    /// Gets the name of the calling method at the specified stack depth.
    /// </summary>
    /// <param name="depth">The stack frame depth.</param>
    /// <returns>The method name, or an error message if not available.</returns>
    internal static string CallingMethod(int depth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(depth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }

    /// <summary>StringBuilder for collecting additional inner info during exception handling.</summary>
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();
    /// <summary>StringBuilder for collecting additional info during exception handling.</summary>
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();

    /// <summary>
    /// Creates a divide-by-zero exception message.
    /// </summary>
    /// <param name="before">The calling context prefix.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? DivideByZero(string before)
    {
        return CheckBefore(before) + " is dividing by zero.";
    }

    /// <summary>
    /// Creates a not-implemented-method exception message.
    /// </summary>
    /// <param name="before">The calling context prefix.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }

    /// <summary>
    /// Creates an is-null exception message if the variable is null.
    /// </summary>
    /// <param name="before">The calling context prefix.</param>
    /// <param name="variableName">The name of the variable.</param>
    /// <param name="variable">The variable to check.</param>
    /// <returns>The formatted exception message, or null if the variable is not null.</returns>
    internal static string? IsNull(string before, string variableName, object? variable)
    {
        return variable == null ? CheckBefore(before) + variableName + " " + "is null" + "." : null;
    }

    /// <summary>
    /// Creates a not-implemented-case exception message.
    /// </summary>
    /// <param name="before">The calling context prefix.</param>
    /// <param name="notImplementedName">The name or value of the unimplemented case.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? NotImplementedCase(string before, object notImplementedName)
    {
        var forText = string.Empty;
        if (notImplementedName != null)
        {
            forText = " for ";
            if (notImplementedName.GetType() == typeof(Type))
                forText += ((Type)notImplementedName).FullName;
            else
                forText += notImplementedName.ToString();
        }
        return CheckBefore(before) + "Not implemented case" + forText + " . internal program error. Please contact developer" +
        ".";
    }

    /// <summary>
    /// Creates a different-count-in-lists exception message if the counts differ.
    /// </summary>
    /// <param name="before">The calling context prefix.</param>
    /// <param name="firstCollectionName">The name of the first collection.</param>
    /// <param name="firstCollectionCount">The count of the first collection.</param>
    /// <param name="secondCollectionName">The name of the second collection.</param>
    /// <param name="secondCollectionCount">The count of the second collection.</param>
    /// <returns>The formatted exception message, or null if counts are equal.</returns>
    internal static string? DifferentCountInLists(string before, string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        if (firstCollectionCount != secondCollectionCount)
            return CheckBefore(before) + " different count elements in collection" + " " +
            string.Concat(firstCollectionName + "-" + firstCollectionCount) + " vs. " +
            string.Concat(secondCollectionName + "-" + secondCollectionCount);
        return null;
    }
}
