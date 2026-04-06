namespace SunamoCollections._sunamo;

/// <summary>
/// Service providing predefined lists of special characters.
/// </summary>
internal class SpecialCharsService
{
    internal readonly List<char> SpecialChars = new(new[]
        { excl, commat, num, dollar, percnt, hat, amp, ast, quest, lowbar, tilda });
    internal readonly List<char> SpecialCharsExtended = new(new[]
    {
        leftQuote, rightQuote, dash, leftApostrophe, rightApostrophe,
        comma, period, colon, apos, rightParen, sol, lt, gt, leftCurly, rightCurly, leftSquare, verbar, semi, plus, rightSquare,
        ndash, slash
    });
    /// <summary>
    /// Used in enigma.
    /// </summary>
    internal readonly List<char>? SpecialCharsAll = null;
    internal readonly List<char> SpecialCharsWhite = new(new[] { space });
    internal readonly List<char> SpecialCharsNotEnigma = new(new[] { space160, copy });
    private const char leftApostrophe = '\u2018';
    private const char rightApostrophe = '\u2019';
    private const char comma = ',';
    private const char space = ' ';
    private static char space160 = (char)160;
    private const char dollar = '$';
    private const char hat = '^';
    private const char ast = '*';
    private const char quest = '?';
    private const char tilda = '~';
    private const char period = '.';
    private const char colon = ':';
    private const char excl = '!';
    private const char apos = '\'';
    private const char rightParen = ')';
    private const char sol = '/';
    private const char lowbar = '_';
    private const char lt = '<';
    private const char gt = '>';
    private const char amp = '&';
    private const char leftCurly = '{';
    private const char rightCurly = '}';
    private const char leftSquare = '[';
    private const char verbar = '|';
    private const char semi = ';';
    private const char commat = '@';
    private const char plus = '+';
    private const char rightSquare = ']';
    private const char num = '#';
    private const char percnt = '%';
    private const char ndash = '\u2013';
    private const char copy = '\u00A9';
    private const char leftQuote = '\u201C';
    private const char rightQuote = '\u201D';
    private const char dash = '-';
    private const char slash = '/';
}
