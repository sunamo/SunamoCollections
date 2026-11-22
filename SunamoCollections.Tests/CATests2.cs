using SunamoTestValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoCollections.Tests;
public class CATests2
{
    [Fact]
    public void DivideByPercentTest()
    {
        var numbers = Enumerable.Range(0, 96).ToList();
        var actual = CA.DivideByPercent<int>(numbers, 10);

        Assert.Equal(11, actual.Count);
        Assert.Equal(Enumerable.Range(0, 9).ToList(), actual[0]);
        Assert.Equal(Enumerable.Range(81, 9).ToList(), actual[9]);
        Assert.Equal(Enumerable.Range(90, 6).ToList(), actual[10]);
    }

    [Fact]
    public void DivideByTest()
    {
        List<string> abcd = ["a", "b", "c", "d"];
        var actual = CA.DivideBy(abcd, 2);
        var actual3 = CA.DivideBy(abcd, 3);
    }
}
