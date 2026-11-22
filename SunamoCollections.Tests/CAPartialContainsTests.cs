namespace SunamoCollections.Tests;

/// <summary>
/// Tests for CA.PartialContains.
/// </summary>
public class CAPartialContainsTests
{
    /// <summary>
    /// Tests that a directory containing the path as a substring is found.
    /// </summary>
    [Fact]
    public void PartialContains_FindsSubstring()
    {
        Assert.True(CA.PartialContains(new List<string> { "a/b/c", "x/y" }, "b/c"));
    }

    /// <summary>
    /// Tests that no match and an empty list give false.
    /// </summary>
    [Fact]
    public void PartialContains_NoMatchOrEmpty_False()
    {
        Assert.False(CA.PartialContains(new List<string> { "a/b" }, "z"));
        Assert.False(CA.PartialContains(new List<string>(), "z"));
    }
}
