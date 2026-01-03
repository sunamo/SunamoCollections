namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
///     Do doby než bude refactoring
///     Mám celkem dost velký bordel v metodách v CA
///     Takže bude třeba udělat fasádu jako jsem dříve udělal v DTHelper
/// </summary>
public class CANew
{
    public static bool ContainsAnyFromArray(string input, string[] array)
    {
        foreach (var item in array)
            if (input.Contains(item))
                return true;

        return false;
    }
}