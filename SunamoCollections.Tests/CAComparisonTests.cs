namespace SunamoCollections.Tests;

/// <summary>
/// Tests for CA.AddIfNotContains and the StringComparison overloads of EndsWith and StartWithAnyInElement.
/// </summary>
public class CAComparisonTests
{
    /// <summary>
    /// Tests that AddIfNotContains adds a new item once.
    /// </summary>
    [Fact]
    public void AddIfNotContains_AddsOnlyOnce()
    {
        var list = new List<string> { "a" };
        CA.AddIfNotContains(list, "b");
        CA.AddIfNotContains(list, "b");
        Assert.Equal(new List<string> { "a", "b" }, list);
    }

    /// <summary>
    /// Tests that EndsWith with OrdinalIgnoreCase ignores the case.
    /// </summary>
    [Fact]
    public void EndsWith_IgnoreCase_Matches()
    {
        Assert.True(CA.EndsWith("File.CS", new List<string> { ".cs" }, StringComparison.OrdinalIgnoreCase));
        Assert.False(CA.EndsWith("File.CS", new List<string> { ".cs" }, StringComparison.Ordinal));
    }

    /// <summary>
    /// Tests that StartWithAnyInElement with OrdinalIgnoreCase returns the matching indexes.
    /// </summary>
    [Fact]
    public void StartWithAnyInElement_IgnoreCase_ReturnsIndexes()
    {
        var result = CA.StartWithAnyInElement("E:\\vs\\x", new List<string> { "d:\\", "e:\\vs" }, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(new List<int> { 1 }, result);
    }
}
