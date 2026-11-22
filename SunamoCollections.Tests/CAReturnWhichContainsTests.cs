using SunamoCollections._public.SunamoEnums.Enums;

namespace SunamoCollections.Tests;

/// <summary>
/// Tests for CA.ReturnWhichContains.
/// </summary>
public class CAReturnWhichContainsTests
{
    /// <summary>
    /// Tests that a word with '!' excludes lines, a null line never matches and the comparison is respected.
    /// </summary>
    [Fact]
    public void ReturnWhichContains_NegationsNullAndComparison()
    {
        var lines = new List<string> { "Red car", "red bike", null!, "blue car" };

        var result = CA.ReturnWhichContains(lines, "red !bike", ContainsCompareMethodCA.Negations, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(["Red car"], result);

        var ordinal = CA.ReturnWhichContains(lines, "red", ContainsCompareMethodCA.SplitToWords);
        Assert.Equal(["red bike"], ordinal);

        var whole = CA.ReturnWhichContains(lines, "car");
        Assert.Equal(["Red car", "blue car"], whole);
    }
}
