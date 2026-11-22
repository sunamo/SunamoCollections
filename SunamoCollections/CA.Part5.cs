namespace SunamoCollections;

public partial class CA
{

    /// <summary>
    /// Contains diacritic.
    /// </summary>
    /// <param name="solutionNames">The solution names.</param>
    /// <returns>The contains diacritic result.</returns>
    public static List<string> ContainsDiacritic(IList<string> solutionNames)
    {
        var vr = new List<string>(solutionNames.Count());
        foreach (var item in solutionNames)
            if (item.HasDiacritics())
                vr.Add(item);
        return vr;
    }


    /// <summary>
    /// To size.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="requiredLength">The required length.</param>
    /// <returns>The to size result.</returns>
    public static List<string> ToSize(List<string> input, int requiredLength)
    {
        List<string> returnArray = null;
        var realLength = input.Count;
        if (realLength > requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            for (var i = 0; i < requiredLength; i++) returnArray[i] = input[i];
            return returnArray;
        }

        if (realLength == requiredLength)
        {
            return input;
        }

        if (realLength < requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            var i = 0;
            for (; i < realLength; i++) returnArray[i] = input[i];
            for (; i < requiredLength; i++) returnArray[i] = null;
        }

        return returnArray;
    }

    /// <summary>
    /// Format.
    /// </summary>
    /// <param name="uninstallNpmPackageGlobal">The uninstall npm package global.</param>
    /// <param name="globallyInstalledTsDefinitions">The globally installed ts definitions.</param>
    /// <returns>The format result.</returns>
    public static List<string> Format(string uninstallNpmPackageGlobal, List<string> globallyInstalledTsDefinitions)
    {
        for (var i = 0; i < globallyInstalledTsDefinitions.Count(); i++)
            globallyInstalledTsDefinitions[i] = /*string.Format*/
                string.Format(uninstallNpmPackageGlobal, globallyInstalledTsDefinitions[i]);
        return globallyInstalledTsDefinitions;
    }






    #region For easy copy from CAShared64.cs






    /// <summary>
    /// Trim start char.
    /// </summary>
    /// <param name="backslash">The backslash.</param>
    /// <param name="s">The s.</param>
    /// <returns>The trim start char result.</returns>
    public static List<string> TrimStartChar(char backslash, List<string> s)
    {
        for (var i = 0; i < s.Count; i++) s[i] = s[i].TrimStart(backslash);
        return s;
    }

    #endregion
}