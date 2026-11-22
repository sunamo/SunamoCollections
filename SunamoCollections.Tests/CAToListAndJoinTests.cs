namespace SunamoCollections.Tests;

/// <summary>
/// Tests for CA.ToList, CA.JoinIEnumerable and CA.ToListString over objects.
/// </summary>
public class CAToListAndJoinTests
{
    /// <summary>
    /// Tests that ToList with params creates a list with the items in the passed order.
    /// </summary>
    [Fact]
    public void ToList_Params()
    {
        var actual = CA.ToList<object>("a", 1, string.Empty);

        Assert.Equal(new List<object> { "a", 1, string.Empty }, actual);
    }

    /// <summary>
    /// Tests that JoinIEnumerable joins lists of different item types into one list.
    /// </summary>
    [Fact]
    public void JoinIEnumerable_JoinsInOrder()
    {
        var objects = new List<object> { "a", 1 };
        var strings = new List<string> { "b", "c" };

        var actual = CA.JoinIEnumerable<object>(objects, strings, new List<string>());

        Assert.Equal(new List<object> { "a", 1, "b", "c" }, actual);
        Assert.Equal(new List<string> { "b", "c", "b", "c" }, CA.JoinIEnumerable<string>(strings, strings));
    }

    /// <summary>
    /// Tests that ToListString over objects converts items with ToString and null to an empty string.
    /// </summary>
    [Fact]
    public void ToListString_Objects()
    {
        var actual = CA.ToListString(new List<object?> { "a", 1, null });

        Assert.Equal(new List<string> { "a", "1", string.Empty }, actual);
        Assert.Equal(new List<string> { "a", "b" }, CA.ToListString("a", "b"));
    }
}
