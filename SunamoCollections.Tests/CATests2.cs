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
        List<int> a = TestData._0To95;
        var actual = CA.DivideByPercent<int>(a, 10);

        Assert.Equal(TestData._0To95By10, actual);
    }

    [Fact]
    public void DivideByTest()
    {
        List<string> abcd = ["a", "b", "c", "d"];
        var actual = CA.DivideBy(abcd, 2);
        var actual3 = CA.DivideBy(abcd, 3);
    }
}
