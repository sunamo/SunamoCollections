namespace SunamoCollections._sunamo;
internal class SHParts
{
    public static string RemoveAfterFirstFunc(string v, Func<char, bool> isSpecial, params char[] canBe)
    {
        v = v.Trim();
        for (var i = 0; i < v.Length; i++)
            if (isSpecial(v[i]))
            {
                if (canBe.Contains(v[i])) continue;
                return v.Substring(0, i);
            }

        return v;
    }
}
