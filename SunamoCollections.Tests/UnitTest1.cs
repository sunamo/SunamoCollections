// variables names: ok

namespace SunamoCollections.Tests;

public class UnitTest1
{
    [Fact]
    public void InitFillWith_AddsCorrectNumberOfElements()
    {
        var list = new List<string>();
        CA.InitFillWith(list, 5, "test");
        Assert.Equal(5, list.Count);
        Assert.All(list, element => Assert.Equal("test", element));
    }

    [Fact]
    public void Count_ReturnsZeroForNull()
    {
        var result = CA.Count(null!);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Count_ReturnsCorrectCountForList()
    {
        var list = new List<string> { "a", "b", "c" };
        var result = CA.Count(list);
        Assert.Equal(3, result);
    }

    [Fact]
    public void Trim_TrimsAllElements()
    {
        var list = new List<string> { "  hello  ", " world ", "test" };
        var result = CA.Trim(list);
        Assert.Equal("hello", result[0]);
        Assert.Equal("world", result[1]);
        Assert.Equal("test", result[2]);
    }

    [Fact]
    public void IsEmptyOrNull_ReturnsTrueForNull()
    {
        Assert.True(CA.IsEmptyOrNull(null!));
    }

    [Fact]
    public void IsEmptyOrNull_ReturnsTrueForEmptyList()
    {
        Assert.True(CA.IsEmptyOrNull(new List<string>()));
    }

    [Fact]
    public void IsEmptyOrNull_ReturnsFalseForNonEmptyList()
    {
        Assert.False(CA.IsEmptyOrNull(new List<string> { "test" }));
    }

    [Fact]
    public void HasDuplicates_ReturnsTrueWhenDuplicatesExist()
    {
        var list = new List<string> { "a", "b", "a" };
        Assert.True(CA.HasDuplicates(list));
    }

    [Fact]
    public void HasDuplicates_ReturnsFalseWhenNoDuplicates()
    {
        var list = new List<string> { "a", "b", "c" };
        Assert.False(CA.HasDuplicates(list));
    }

    [Fact]
    public void RemoveNullEmptyWs_RemovesWhitespaceEntries()
    {
        var list = new List<string> { "hello", "", " ", "world", null! };
        CA.RemoveNullEmptyWs(list);
        Assert.Equal(2, list.Count);
        Assert.Equal("hello", list[0]);
        Assert.Equal("world", list[1]);
    }

    [Fact]
    public void ToLower_ConvertsAllElementsToLowerCase()
    {
        var list = new List<string> { "HELLO", "World", "TEST" };
        var result = CA.ToLower(list);
        Assert.Equal("hello", result[0]);
        Assert.Equal("world", result[1]);
        Assert.Equal("test", result[2]);
    }

    [Fact]
    public void EndsWithAnyElement_ReturnsTrueWhenMatching()
    {
        Assert.True(CA.EndsWithAnyElement("test.txt", ".txt", ".cs"));
    }

    [Fact]
    public void EndsWithAnyElement_ReturnsFalseWhenNoMatch()
    {
        Assert.False(CA.EndsWithAnyElement("test.txt", ".cs", ".xml"));
    }

    [Fact]
    public void JoinBytesArray_CombinesTwoArrays()
    {
        var first = new byte[] { 1, 2, 3 };
        var second = new byte[] { 4, 5 };
        var result = CA.JoinBytesArray(first, second);
        Assert.Equal(5, result.Count);
        Assert.Equal(new List<byte> { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void ContainsAnyFromElementBool_ReturnsTrueWhenContained()
    {
        var candidates = new List<string> { "hello", "world" };
        Assert.True(CA.ContainsAnyFromElementBool("hello there", candidates));
    }

    [Fact]
    public void ContainsAnyFromElementBool_ReturnsFalseWhenNotContained()
    {
        var candidates = new List<string> { "foo", "bar" };
        Assert.False(CA.ContainsAnyFromElementBool("hello world", candidates));
    }

    [Fact]
    public void DivideBy_DividesEvenly()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6 };
        var result = CA.DivideBy(list, 2);
        Assert.NotNull(result.Data);
        Assert.Equal(3, result.Data.Count);
        Assert.Equal(new List<int> { 1, 2 }, result.Data[0]);
        Assert.Equal(new List<int> { 3, 4 }, result.Data[1]);
        Assert.Equal(new List<int> { 5, 6 }, result.Data[2]);
    }

    [Fact]
    public void DivideBy_ReturnsExceptionWhenNotDivisible()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var result = CA.DivideBy(list, 2);
        Assert.NotNull(result.ExceptionMessage);
    }

    [Fact]
    public void ContainsAnyFromArray_ReturnsTrueWhenFound()
    {
        Assert.True(CANew.ContainsAnyFromArray("hello world", new[] { "world", "foo" }));
    }

    [Fact]
    public void ContainsAnyFromArray_ReturnsFalseWhenNotFound()
    {
        Assert.False(CANew.ContainsAnyFromArray("hello world", new[] { "foo", "bar" }));
    }
}
