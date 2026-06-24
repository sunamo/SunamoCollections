//namespace SunamoCollections.Tests._sunamo;

//internal class CA
//{
//    public static string CompareListResult(bool alsoFileNames, string nameForFirstFolder, string nameForSecondFolder, string nameOfSolution, List<string> files1, List<string> files2, List<string> inBoth)
//    {
//        int files1Count = files1.Count;
//        int files2Count = files2.Count;
//        string result;
//        var textOutput = new TextOutputGenerator();
//        int inBothCount = inBoth.Count;
//        double sumBothPlusManaged = inBothCount + files2Count;
//        PercentCalculator percentCalculator = new PercentCalculator(sumBothPlusManaged);
//        if (nameOfSolution != null)
//        {
//            textOutput.sb.AppendLine(nameOfSolution);
//        }
//        textOutput.sb.AppendLine("Both (" + inBothCount + AllStrings.swda + percentCalculator.PercentFor(inBothCount, false) + "%):");
//        if (alsoFileNames)
//        {
//            textOutput.List(inBoth);
//        }
//        if (nameForFirstFolder != null)
//        {
//            textOutput.sb.AppendLine(nameForFirstFolder + AllStrings.lb + files1Count + AllStrings.swda + percentCalculator.PercentFor(files1Count, true) + "%):");
//        }
//        if (alsoFileNames)
//        {
//            textOutput.List(files1);
//        }
//        if (nameForSecondFolder != null)
//        {
//            textOutput.sb.AppendLine(nameForSecondFolder + AllStrings.lb + files2Count + AllStrings.swda + percentCalculator.PercentFor(files2Count, true) + "%):");
//        }
//        if (alsoFileNames)
//        {
//            textOutput.List(files2);
//        }
//        textOutput.SingleCharLine(AllChars.asterisk, 10);
//        result = textOutput.ToString();
//        return result;
//    }

//    internal static void RemoveStartingWith(string start, List<string> mySites)
//    {
//        mySites.RemoveAll(d => d.StartsWith(start));
//    }
//}
