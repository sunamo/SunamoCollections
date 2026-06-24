namespace SunamoCollections;

public class CANew
{
    public static bool ContainsAnyFromArray(string text, string[] array)
    {
        foreach (var item in array)
            if (text.Contains(item))
                return true;

        return false;
    }
}
