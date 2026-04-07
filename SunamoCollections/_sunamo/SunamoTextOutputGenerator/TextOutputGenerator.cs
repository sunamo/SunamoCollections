namespace SunamoCollections._sunamo.SunamoTextOutputGenerator;

/// <summary>
/// Text output generator used for formatting comparison results.
/// </summary>
internal class TextOutputGenerator
{
    /// <summary>The underlying StringBuilder used for text generation.</summary>
    internal StringBuilder StringBuilder = new();

    /// <summary>
    /// Returns the generated text output.
    /// </summary>
    /// <returns>The text content.</returns>
    public override string ToString()
    {
        var result = StringBuilder.ToString();
        return result;
    }
}
