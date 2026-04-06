namespace SunamoCollections._sunamo.SunamoExceptions;

/// <summary>
/// Exception message formatting utilities.
/// </summary>
internal sealed partial class Exceptions
{
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

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

    internal static void TypeAndMethodName(string stackTraceLine, out string typeName, out string methodName)
    {
        var afterAt = stackTraceLine.Split("at ")[1].Trim();
        var fullQualifiedName = afterAt.Split("(")[0];
        var parts = fullQualifiedName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        typeName = string.Join(".", parts);
    }

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

    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();

    internal static string? DivideByZero(string before)
    {
        return CheckBefore(before) + " is dividing by zero.";
    }

    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }

    internal static string? IsNull(string before, string variableName, object? variable)
    {
        return variable == null ? CheckBefore(before) + variableName + " " + "is null" + "." : null;
    }

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

    internal static string? DifferentCountInLists(string before, string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        if (firstCollectionCount != secondCollectionCount)
            return CheckBefore(before) + " different count elements in collection" + " " +
            string.Concat(firstCollectionName + "-" + firstCollectionCount) + " vs. " +
            string.Concat(secondCollectionName + "-" + secondCollectionCount);
        return null;
    }
}
