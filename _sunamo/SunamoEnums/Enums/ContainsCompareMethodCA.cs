namespace SunamoCollections;


/// <summary>
/// Used in SunamoCollectionsGenericStore + SunamoCollections
/// </summary>
public enum ContainsCompareMethodCA
{
    WholeInput,
    SplitToWords,
    /// <summary>
    /// split to words and check for ! at [0]
    /// </summary>
    Negations
}