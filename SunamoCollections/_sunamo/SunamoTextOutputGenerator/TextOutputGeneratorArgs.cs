namespace SunamoCollections._sunamo.SunamoTextOutputGenerator;

/// <summary>
/// Arguments for configuring text output generation.
/// </summary>
internal class TextOutputGeneratorArgs
{
    /// <summary>
    /// Gets or sets the delimiter between entries.
    /// </summary>
    internal string Delimiter { get; set; } = Environment.NewLine;

    /// <summary>
    /// Gets or sets whether headers are wrapped with empty lines.
    /// </summary>
    internal bool IsHeaderWrappedWithEmptyLines { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to insert the count in the output.
    /// </summary>
    internal bool IsInsertingCount { get; set; }

    /// <summary>
    /// Gets or sets the text displayed when there are no entries.
    /// </summary>
    internal string WhenNoEntries { get; set; } = "No entries";

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    internal TextOutputGeneratorArgs()
    {
    }

    /// <summary>
    /// Initializes a new instance with the specified configuration.
    /// </summary>
    /// <param name="isHeaderWrappedWithEmptyLines">Whether headers are wrapped with empty lines.</param>
    /// <param name="isInsertingCount">Whether to insert the count in the output.</param>
    internal TextOutputGeneratorArgs(bool isHeaderWrappedWithEmptyLines, bool isInsertingCount)
    {
        IsHeaderWrappedWithEmptyLines = isHeaderWrappedWithEmptyLines;
        IsInsertingCount = isInsertingCount;
    }
}
