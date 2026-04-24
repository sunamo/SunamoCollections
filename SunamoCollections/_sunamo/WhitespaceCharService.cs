namespace SunamoCollections._sunamo;

/// <summary>
/// Service providing predefined whitespace character codes.
/// </summary>
internal class WhitespaceCharService
{
    /// <summary>List of whitespace characters derived from <see cref="WhiteSpacesCodes"/>.</summary>
    internal List<char> WhiteSpaceChars { get; set; }
    /// <summary>Unicode code points representing whitespace characters.</summary>
    internal List<int> WhiteSpacesCodes { get; } = new(new[]
    {
        9, 10, 11, 12, 13, 32, 133, 160, 5760, 6158, 8192, 8193, 8194, 8195, 8196, 8197, 8198, 8199, 8200, 8201, 8202,
        8232, 8233, 8239, 8287, 12288
    });

    /// <summary>
    /// Initializes a new instance and populates <see cref="WhiteSpaceChars"/> from <see cref="WhiteSpacesCodes"/>.
    /// </summary>
    internal WhitespaceCharService()
    {
        WhiteSpaceChars = WhiteSpacesCodes.ConvertAll(code => (char)code);
    }
}
