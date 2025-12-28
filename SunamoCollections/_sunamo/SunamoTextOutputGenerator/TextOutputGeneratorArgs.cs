// variables names: ok
namespace SunamoCollections._sunamo.SunamoTextOutputGenerator;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal class TextOutputGeneratorArgs
{
    internal string Delimiter { get; set; } = Environment.NewLine;
    internal bool HeaderWrappedEmptyLines { get; set; } = true;
    internal bool InsertCount { get; set; }
    internal string WhenNoEntries { get; set; } = "No entries";

    internal TextOutputGeneratorArgs()
    {
    }

    internal TextOutputGeneratorArgs(bool headerWrappedEmptyLines, bool insertCount)
    {
        this.HeaderWrappedEmptyLines = headerWrappedEmptyLines;
        this.InsertCount = insertCount;
    }
}