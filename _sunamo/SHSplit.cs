
namespace SunamoCollections._sunamo;
using System;
using System.Collections.Generic;
using System.Linq;

internal class SHSplit
{
    internal static List<string> SplitNone(string p, params string[] newLine)
    {
        return p.Split(newLine, StringSplitOptions.None).ToList();
    }

    internal static List<string> SplitMore(string p, params string[] newLine)
    {
        return p.Split(newLine, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}