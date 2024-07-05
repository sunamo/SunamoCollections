namespace SunamoCollections._sunamo.SunamoPercentCalculator;

using System.Diagnostics;

/// <summary>
/// Normálně se volá 100x DonePartially()
/// </summary>
internal class PercentCalculator //: IPercentCalculator
//: IPercentCalculator
{
    internal double onePercent = 0;
    internal double last { get; set; } = 0;
    internal double _overallSum { get; set; }
    private double _hundredPercent = 100d;
    int added = 0;
    internal PercentCalculator Create(double overallSum)
    {
        return new PercentCalculator(overallSum);
    }
    internal void AddOnePercent()
    {
        added++;
        last += onePercent;
    }
    /// <summary>
    /// Dont know when is AddOne more useful than AddOnePercent => private
    /// </summary>
    private void AddOne()
    {
        last += 1;
    }
    internal static Type type = typeof(PercentCalculator);
    internal PercentCalculator(double overallSum)
    {
        if (overallSum == 0)
        {
            ThrowEx.DivideByZero();
        }
        onePercent = _hundredPercent / overallSum;
        _overallSum = overallSum;
    }
    private int _sum = 0;
    /// <summary>
    /// Is automatically called with PercentFor with last 
    /// </summary>
    internal void ResetComputedSum()
    {
        _sum = 0;
        Func<string, short> d = short.Parse;
    }
    /// <summary>
    /// Was used for generating text output with inBothCount, files1Count, files2Count 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="last"></param>
    /// <returns></returns>
    internal int PercentFor(double value, bool last)
    {
        // cannot divide by zero
        if (_overallSum == 0)
        {
            return 0;
        }
        // value - 
        // 
        double quocient = value / _overallSum;
        int result = (int)(_hundredPercent * quocient);
        _sum += result;
        if (last)
        {
            int diff = _sum - 100;
            if (_sum != 0)
            {
                result -= diff;
            }
            ResetComputedSum();
        }
#if DEBUG
        if (result == -2147483648)
        {
            System.Diagnostics.Debugger.Break();
        }
#endif
        return result;
    }
}