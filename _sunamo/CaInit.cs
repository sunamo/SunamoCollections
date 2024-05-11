namespace SunamoCollections;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FS2 = SunamoCollections._sunamo.FS;
//using SH2 = SunamoCollections._sunamo.SH;

//namespace SunamoCollections._sunamo
//{
//    internal class CaInit
//    {
//        internal static void Fs(Func<string, string> GetDirectoryName, Func<string, string, Task> WriteAllTextWithExc, Func<string, bool> TryDeleteFile, Func<string, bool> ExistsFile, Action<string> CreateFileIfDoesntExists, Func<string, string> WithEndSlash, Func<string, string> WithoutEndSlash)
//        {
//            FS2.GetDirectoryName = GetDirectoryName;
//            FS2.WriteAllTextWithExc = WriteAllTextWithExc;
//            FS2.ExistsFile = ExistsFile;
//            FS2.TryDeleteFile = TryDeleteFile;
//            FS2.CreateFileIfDoesntExists = CreateFileIfDoesntExists;
//            FS2.WithEndSlash = WithEndSlash;
//            FS2.WithoutEndSlash = WithoutEndSlash;
//        }

//        internal static void Sh(Func<string, string, bool> MatchWildcard, Func<string, List<string>> GetLines, Func<string, bool, string> GetFirstWord, Func<string, Object[], string> Format2, Func<string, Func<char, bool>, Char[], string> RemoveAfterFirstFunc, Func<string, string> TextWithoutDiacritic, Func<char, IList, string> JoinChar, Func<string, List<string>, ContainsCompareMethod, bool> ContainsAll, Func<string, string, bool, bool> StartingWith, Func<string, (bool, string)> IsNegationTuple, Func<string, string, string, string> Replace, Func<string, string, string> PostfixIfNotEmpty, Func<List<string>, string> JoinNL, Func<string, bool> ContainsDiacritic, Func<string, string> FirstCharUpper, Func<string, string> ReplaceWhiteSpacesWithoutSpaces, Func<string, string> ReplaceAllDoubleSpaceToSingle, Func<string, string, SearchStrategy, bool> Contains)
//        {
//            SH2.MatchWildcard = MatchWildcard;
//            SH2.GetLines = GetLines;
//            SH2.GetFirstWord = GetFirstWord;
//            SH2.Format2 = Format2;
//            SH2.RemoveAfterFirstFunc = RemoveAfterFirstFunc;
//            SH2.TextWithoutDiacritic = TextWithoutDiacritic;
//            SH2.JoinChar = JoinChar;
//            SH2.ContainsAll = ContainsAll;
//            SH2.Replace = Replace;
//            SH2.StartingWith = StartingWith;
//            SH2.IsNegationTuple = IsNegationTuple;
//            SH2.PostfixIfNotEmpty = PostfixIfNotEmpty;
//            SH2.JoinNL = JoinNL;
//            SH2.ContainsDiacritic = ContainsDiacritic;
//            SH2.FirstCharUpper = FirstCharUpper;
//            SH2.ReplaceWhiteSpacesWithoutSpaces = ReplaceWhiteSpacesWithoutSpaces;
//            SH2.ReplaceAllDoubleSpaceToSingle = ReplaceAllDoubleSpaceToSingle;
//            SH2.Contains = Contains;
//        }

//        internal static void Wildcard(Func<string, string, bool> IsMatch)
//        {
//            SunamoCollections._sunamo.Wildcard.IsMatch = IsMatch;
//        }
//    }
//}
