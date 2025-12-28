// variables names: ok
namespace SunamoCollections._sunamo.SunamoTextOutputGenerator;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
///     In Comparing
/// </summary>
internal class TextOutputGenerator //: ITextOutputGenerator
{
    private static readonly string s_znakNadpisu = "*";

    // při převádění na nugety jsem to změnil na ITextBuilder StringBuilder = TextBuilder.Create();
    // ale asi to byla blbost, teď mám v _sunamo Create() která je ale null místo abych použil ctor
    // takže vracím nazpět.
    //internal TextBuilder StringBuilder = new TextBuilder();
    internal StringBuilder StringBuilder = new();

    //internal string prependEveryNoWhite
    //{
    //    get => StringBuilder.prependEveryNoWhite;
    //    set => StringBuilder.prependEveryNoWhite = value;
    //}

    public override string ToString()
    {
        var ts = StringBuilder.ToString();
        return ts;
    }
}