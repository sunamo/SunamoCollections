namespace SunamoCollections._sunamo;

/// <summary>
/// Service providing predefined lists of letter and digit characters.
/// </summary>
internal class LetterAndDigitCharService
{
    /// <summary>All characters excluding special characters.</summary>
    internal List<char>? AllCharsWithoutSpecial = null;
    /// <summary>All characters including special characters.</summary>
    internal List<char>? AllChars = null;
    /// <summary>List of numeric digit characters (0-9).</summary>
    internal readonly List<char> NumericChars =
        new(new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
    /// <summary>List of lowercase letter characters (a-z).</summary>
    internal readonly List<char> LowerChars = new(new[]
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
        'w', 'x', 'y', 'z'
    });
    /// <summary>List of uppercase letter characters (A-Z).</summary>
    internal readonly List<char> UpperChars = new(new[]
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
        'W', 'X', 'Y', 'Z'
    });
}
