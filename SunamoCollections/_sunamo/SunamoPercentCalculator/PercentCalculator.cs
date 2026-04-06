namespace SunamoCollections._sunamo.SunamoPercentCalculator;

/// <summary>
/// Calculator for computing percentage distributions.
/// </summary>
internal class PercentCalculator
{
    internal static Type PercentCalculatorType = typeof(PercentCalculator);
    private readonly double hundredPercent = 100d;
    private int sum;

    /// <summary>
    /// Gets or sets the value of one percent relative to the overall sum.
    /// </summary>
    internal double OnePercent { get; set; }

    internal PercentCalculator(double overallSum)
    {
        if (overallSum == 0) ThrowEx.DivideByZero();
        OnePercent = hundredPercent / overallSum;
        OverallSum = overallSum;
    }

    /// <summary>
    /// Gets or sets the last computed percentage.
    /// </summary>
    internal double Last { get; set; }

    /// <summary>
    /// Gets or sets the overall sum used as the base for percentage calculations.
    /// </summary>
    internal double OverallSum { get; set; }

    /// <summary>
    /// Resets the computed sum. Called automatically with PercentFor when isLast is true.
    /// </summary>
    internal void ResetComputedSum()
    {
        sum = 0;
    }

    /// <summary>
    /// Computes the percentage for a given value relative to the overall sum.
    /// </summary>
    /// <param name="value">The value to compute the percentage for.</param>
    /// <param name="isLast">Whether this is the last computation in the series (adjusts for rounding).</param>
    /// <returns>The computed percentage as an integer.</returns>
    internal int PercentFor(double value, bool isLast)
    {
        if (OverallSum == 0) return 0;
        var quotient = value / OverallSum;
        var result = (int)(hundredPercent * quotient);
        sum += result;
        if (isLast)
        {
            var diff = sum - 100;
            if (sum != 0) result -= diff;
            ResetComputedSum();
        }
#if DEBUG
        if (result == -2147483648) Debugger.Break();
#endif
        return result;
    }
}
