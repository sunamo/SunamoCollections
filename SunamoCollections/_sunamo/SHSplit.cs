// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections._sunamo;

internal class SHSplit
{
    internal static List<string> SplitNone(string p, params string[] newLine)
    {
        return p.Split(newLine, StringSplitOptions.None).ToList();
    }

    internal static List<string> Split(string p, params string[] newLine)
    {
        return p.Split(newLine, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}