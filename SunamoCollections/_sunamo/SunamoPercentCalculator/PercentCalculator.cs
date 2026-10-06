namespace SunamoCollections._sunamo.SunamoPercentCalculator;

internal class PercentCalculator
{
    private readonly double hundredPercent = 100d;
    private int sum;

    internal double OnePercent { get; set; }

    internal PercentCalculator(double overallSum)
    {
        if (overallSum == 0) ThrowEx.DivideByZero();
        OnePercent = hundredPercent / overallSum;
        OverallSum = overallSum;
    }

    internal double Last { get; set; }

    internal double OverallSum { get; set; }

    internal void ResetComputedSum()
    {
        sum = 0;
    }

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
        return result;
    }
}
