
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections._sunamo.SunamoPercentCalculator;

/// <summary>
///     Normálně se volá 100x DonePartially()
/// </summary>
internal class PercentCalculator //: IPercentCalculator
//: IPercentCalculator
{
    internal static Type Type = typeof(PercentCalculator);
    private readonly double _hundredPercent = 100d;
    private int _sum;
    private int _added;
    internal double OnePercent { get; set; }

    internal PercentCalculator(double overallSum)
    {
        if (overallSum == 0) ThrowEx.DivideByZero();
        OnePercent = _hundredPercent / overallSum;
        OverallSum = overallSum;
    }

    internal double Last { get; set; }
    internal double OverallSum { get; set; }



    
    /// <summary>
    ///     Is automatically called with PercentFor with last
    /// </summary>
    internal void ResetComputedSum()
    {
        _sum = 0;
        Func<string, short> d = short.Parse;
    }

    /// <summary>
    ///     Was used for generating text output with inBothCount, files1Count, files2Count
    /// </summary>
    /// <param name="value"></param>
    /// <param name="last"></param>
    /// <returns></returns>
    internal int PercentFor(double value, bool last)
    {
        // cannot divide by zero
        if (OverallSum == 0) return 0;
        // value -
        //
        var quocient = value / OverallSum;
        var result = (int)(_hundredPercent * quocient);
        _sum += result;
        if (last)
        {
            var diff = _sum - 100;
            if (_sum != 0) result -= diff;
            ResetComputedSum();
        }
#if DEBUG
        if (result == -2147483648) Debugger.Break();
#endif
        return result;
    }
}
