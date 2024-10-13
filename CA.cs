namespace SunamoCollections;

public partial class CA
{
    public static Func<IList, object> dFirstOrNull = null;

    //dFirstOrNull
    private static Type type = typeof(CA);

    public static Dictionary<string, int> OccurenceOfEveryLine(List<string> l)
    {
        throw new NotImplementedException();
    }

    public static string LastItem(string version, string v)
    {
        throw new NotImplementedException();
    }






    public static void InitFillWith(List<string> datas, int pocet, string initWith = Consts.stringEmpty)
    {
        InitFillWith<string>(datas, pocet, initWith);
    }






    public static int Count(IEnumerable e)
    {
        if (e == null) return 0;
        var t = e.GetType();
        var tName = t.Name;


        if (e is IList) return (e as IList).Count;
        if (e is Array) return (e as Array).Length;
        var count = 0;
        foreach (var item in e) count++;
        return count;
    }


    public static List<string> Trim(List<string> l)
    {
        for (var i = 0; i < l.Count; i++) l[i] = l[i].Trim();
        return l;
    }

    [Obsolete("Do the same as Trim")]
    public static void TrimWhereIsOnlyWhitespace(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var l = list[i];
            if (string.IsNullOrWhiteSpace(l)) list[i] = list[i].Trim();
        }
    }

    public static string First(IEnumerable v2)
    {
        foreach (var item in v2) return item.ToString();
        return null;
    }

    public static bool IsListStringWrappedInArray(IEnumerable v2)
    {
        var first = First(v2);
        if (Count(v2) == 1 && (first == "System.Collections.Generic.List`1[System.String]" ||
                               first == "System.Collections.Generic.List`1[System.Object]")) return true;
        return false;
    }


    public static List<string> WrapWithIfFunc(Func<string, string, bool, bool> f, bool invert, string mustContains,
        string wrapWith, params string[] whereIsUsed2)
    {
        for (var i = 0; i < whereIsUsed2.Length; i++)
            if (f.Invoke(whereIsUsed2[i], mustContains, invert))
                whereIsUsed2[i] = wrapWith + whereIsUsed2[i] + wrapWith;
        return whereIsUsed2.ToList();
    }

    /// <summary>
    ///     Return null if A1 will be null
    /// </summary>
    /// <param name="captions"></param>
    /// <param name="i"></param>
    public static object GetIndex(List<string> captions, int i)
    {
        if (captions == null) return null;
        if (!HasIndex(i, captions)) return null;
        return captions[i];
    }

    /// <summary>
    ///     ToListString2 - simply for all items call ToString()
    ///     ToListString - working with type of every element
    ///     Just 3 cases of working:
    ///     IList
    ///     <char>
    ///         => string
    ///         IList
    ///         <string>
    ///             => List
    ///             <string>
    ///                 IList => List<string>
    /// </summary>
    /// <param name="enumerable"></param>
    [ObjectParamsObsoleteAttribute]
    public static List<string> ToListStringIList(IList enumerable2)
    {
        return null;
        //List<string> result = new List<string>();
        //if (enumerable2.GetType() != typeof(string))
        //{
        //    foreach (object item in enumerable2)
        //    {
        //        Type t = item.GetType();
        //        // !(item is string)  - not working
        //        if (RH.IsOrIsDeriveFromBaseClass(t, Types.tIEnumerable))
        //        {
        //            // zde to musí být IEnumerable protože spousta věcí z .netu může takhle přijít (např. string)
        //            var enumerable = (System.Collections.IEnumerable)item;
        //            Type type = enumerable.GetType();
        //            bool isEnumerableChar = RH.IsOrIsDeriveFromBaseClass(type, typeof(IList<char>));
        //            bool isEnumerableString = RH.IsOrIsDeriveFromBaseClass(type, typeof(IList<string>));
        //            if (type == typeof(string))
        //            {
        //                result.Add(string.Join(string.Empty, enumerable));
        //            }
        //            else if (isEnumerableChar)
        //            {
        //                // IList<char> => string
        //                //enumerable2 is not string, then I can add all to list
        //                result.AddRange(ToListStringIEnumerable2(enumerable));
        //            }
        //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList<string>)
        //            {
        //                // IList<string> => List<string>
        //                result.AddRange(((IList<string>)enumerable.FirstOrNull()).ToList());
        //            }
        //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList &&
        //                     !isEnumerableChar && !isEnumerableString)
        //            {
        //                result.AddRange(ToListStringIEnumerable2((IList)enumerable.FirstOrNull()));
        //            }
        //            else
        //            {
        //                // IList => List<string>
        //                result.AddRange(ToListStringIEnumerable2(enumerable));
        //            }
        //        }
        //        else
        //        {
        //            result.Add(item.ToString());
        //        }
        //    }
        //}
        //else
        //{
        //    result.Add(enumerable2.ToString());
        //}
        //return result;
    }

    public static bool HasIndex(int dex, Array col)
    {
        return col.Length > dex;
    }

    public static bool HasIndex(int p, IList nahledy)
    {
        if (p < 0) throw new Exception("Chybn\u00FD parametr p");
        if (nahledy.Count > p) return true;
        return false;
    }

    public static bool RemoveAndLeading(List<string> tokens, string v)
    {
        var dx = tokens.IndexOf(v);
        if (dx != -1)
        {
            tokens.RemoveAt(dx);
            tokens.Insert(0, v);
            return true;
        }

        return false;
    }



    public static string DoubleOrMoreMultiLinesToSingle(string list)
    {
        DoubleOrMoreMultiLinesToSingle(ref list);
        return list;
    }

    public static void RemoveNullEmptyWs(List<string> l)
    {
        for (var i = l.Count - 1; i >= 0; i--)
            if (string.IsNullOrWhiteSpace(l[i]))
                l.RemoveAt(i);
    }

    /// <summary>
    ///     Return true if A1 is null or have zero elements
    /// </summary>
    /// <param name="mustBe"></param>
    public static bool IsEmptyOrNull(IList mustBe)
    {
        if (mustBe == null)
            return true;
        if (mustBe.Count == 0) return true;
        return false;
    }

    /// <summary>
    ///     Pro vyssi vykon uklada primo do zdrojoveho pole, pokud neni A2
    /// </summary>
    /// <param name="ss"></param>
    public static List<string> ToLower(List<string> ss, bool createNewArray = false)
    {
        var outArr = ss;
        if (createNewArray)
        {
            outArr = new List<string>(ss.Count);
            InitFillWith(outArr, ss.Count);
        }

        for (var i = 0; i < ss.Count; i++) outArr[i] = ss[i].ToLower();
        return outArr;
    }

    public static void DoubleOrMoreMultiLinesToSingle(ref string list)
    {
        var n = Environment.NewLine;
        list = Regex.Replace(list, @"(\r?\n\s*){2,}", Environment.NewLine + Environment.NewLine);
        list = list.Trim();
        //list = list.Replace(n, n + n);
        // 27-10-23 dříve to bylo takhle
        //return list.Trim();
    }

    /// <summary>
    ///     A1 musí být string[], kdyby byl string[] nemůžu vložit List<string>, tj. object ale ne string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="innerMain"></param>
    /// <returns></returns>
    [ObjectParamsObsoleteAttribute]
    public static object[] ConvertListStringWrappedInArray(object[] innerMain)
    {
        if (IsListStringWrappedInArray(innerMain))
        {
            List<object> result = null;
            var first = (IEnumerable)innerMain[0];
            if (first is List<object>)
            {
                result = (List<object>)first;
            }
            else
            {
                result = new List<object>();
                foreach (var item in first) result.Add(item);
            }

            return result.ToArray();
        }

        return innerMain;
    }

    public static (bool, string) IsNegationTuple(string contains)
    {
        if (contains[0] == '!')
        {
            contains = contains.Substring(1);
            return (true, contains);
        }

        return (false, contains);
    }

    /// <summary>
    ///     Remove elements starting with A1
    ///     Direct edit
    /// </summary>
    /// <param name="start"></param>
    /// <param name="mySites"></param>
    public static void RemoveStartingWith(string start, List<string> mySites, RemoveStartingWithArgsCA a = null)
    {
        if (a == null) a = new RemoveStartingWithArgsCA();
        var (negate, start2) = IsNegationTuple(start);
        start = start2;
        for (var i = mySites.Count - 1; i >= 0; i--)
        {
            var val = mySites[i];
            if (a._trimBeforeFinding) val = val.Trim();
            if (negate)
            {
                if (!StartingWith(val, start, a.caseSensitive)) mySites.RemoveAt(i);
            }
            else
            {
                if (StartingWith(val, start, a.caseSensitive)) mySites.RemoveAt(i);
            }
        }
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="v"></param>
    /// <param name="l"></param>
    /// <returns></returns>
    public static List<string> StartingWith(string v, List<string> l)
    {
        for (var i = l.Count - 1; i >= 0; i--)
            if (!l[i].StartsWith(v))
                l.RemoveAt(i);
        return l;
    }

    public static bool StartingWith(string val, string start, bool caseSensitive)
    {
        if (caseSensitive)
            return val.StartsWith(start);
        return val.ToLower().StartsWith(start.ToLower());
    }

    public static List<string> RemoveStringsEmptyTrimBefore(List<string> mySites)
    {
        for (var i = mySites.Count - 1; i >= 0; i--)
            if (mySites[i].Trim() == string.Empty)
                mySites.RemoveAt(i);
        return mySites;
    }

    private static string Replace(string s, string from, string to)
    {
        return s.Replace(from, to);
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="files_in"></param>
    /// <param name="what"></param>
    /// <param name="forWhat"></param>
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        for (var i = 0; i < files_in.Count; i++) files_in[i] = Replace(files_in[i], what, forWhat);
        //CAChangeContent.ChangeContent2(null, files_in, Replace, what, forWhat);
    }

    /// <summary>
    ///     ToListString2 - simply for all items call ToString()
    ///     ToListString - working with type of every element
    ///     <string>
    ///         Nothing more, nothing less
    ///         Must be private - to use only public in CA
    ///         bcoz Cast() not working
    ///         Dont make any type checking - could be done before
    /// </summary>
    public static List<string> ToListStringIEnumerable2(IEnumerable enumerable)
    {
        var result = new List<string>( /*enumerable.Count()*/);
        foreach (var item in enumerable)
            if (item == null)
                result.Add(Consts.nulled);
            else
                result.Add(item.ToString());
        return result;
    }


    public static bool PartialContains(List<string> dirs, string pathWithoutNameBs)
    {
        throw new NotImplementedException();
    }

    public static void RemoveEmptyLinesFromBack(List<string> c)
    {
        for (var i = c.Count - 1; i >= 0; i--)
        {
            var line = c[i];
            if (line.Trim() == string.Empty)
                c.RemoveAt(i);
            else
                break;
        }
    }

    public static int AllNonWhitespaceLines(List<string> lines)
    {
        var nonEmptyLines = 0;

        for (var i = 0; i < lines.Count; i++)
            if (lines[i].Trim() != string.Empty)
                nonEmptyLines++;

        return nonEmptyLines;
    }

    public static List<string> RemoveStringsEmptyFromBeginStart(List<string> sourceList)
    {
        //textLines1.SkipWhile(e => !HasContent(e))
        //            .Reverse()
        //            .SkipWhile(e => !HasContent(e))
        //            .Reverse()
        //            .ToList();

        int start = 0, end = sourceList.Count - 1;

        while (start < end && string.IsNullOrWhiteSpace(sourceList[start])) start++;
        while (end >= start && string.IsNullOrWhiteSpace(sourceList[end])) end--;

        var result = sourceList.Skip(start).Take(end - start + 1).ToList();

        return result;
    }

    public static void RemoveLines(List<string> lines, List<int> removeLines)
    {
        removeLines.Sort();
        for (var i = removeLines.Count - 1; i >= 0; i--)
        {
            var dx = removeLines[i];
            lines.RemoveAt(dx);
        }
    }


    public static void Remove(List<string> from, List<string> what)
    {
        foreach (var item in what) from.Remove(item);
    }


    public static void AddSuffix(List<string> headers, string v)
    {
        for (var i = 0; i < headers.Count; i++) headers[i] = headers[i] + v;
    }

    public static List<string> CreateListStringWithReverse(int reverse, IList<string> v)
    {
        var vs = new List<string>(reverse + v.Count());
        vs.AddRange(v);
        return vs;
    }


    public static List<char> ToListChar(ICollection<string> values)
    {
        var v = new List<char>(values.Count);
        foreach (var item in values) v.Add(item[0]);
        return v;
    }


    public static bool HasDuplicates(List<string> list)
    {
        var list2 = list.ToList();
        //CAG.RemoveDuplicitiesList(list);
        list2 = list2.Distinct().ToList();
        if (list2.Count != list.Count)
            //Console.WriteLine( Exceptions.DifferentCountInLists(string.Empty, "list2", list2.Count, "list", list.Count));
            return true;
        return false;
    }


    public static void Unindent(List<string> l, int v)
    {
        for (var i = 0; i < l.Count; i++)
        {
            var line = l[i];
            if (line.StartsWith(AllStrings.tab))
                l[i] = l[i].Substring(AllStrings.tab.Length);
            else if (line.StartsWith(Consts.spaces4)) l[i] = l[i].Substring(Consts.spaces4.Length);
        }
    }






    public static bool AnyElementEndsWith(string t, IList<string> v)
    {
        string item2 = null;
        return AnyElementEndsWith(t, v, out item2);
    }

    public static bool AnyElementEndsWith(string t, IList<string> v, out string element)
    {
        element = null;

        foreach (var item in v)
            if (item.EndsWith(t))
            {
                element = item;
                return true;
            }

        return false;
    }

    /// <summary>
    ///     Overrides working only with string, not list
    ///     AnyElementEndsWith - string[]
    ///     EndsWith - IList<string>
    /// </summary>
    /// <param name="t"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static bool EndsWithAnyElement(string t, params string[] v)
    {
        return EndsWithAnyElement(t, v.ToList());
    }

    /// <summary>
    ///     Overrides working only with string, not list
    ///     Return whether A1 contains with any of A2
    /// </summary>
    /// <param name="t"></param>
    /// <param name="v"></param>
    public static bool EndsWithAnyElement(string t, IList<string> v)
    {
        foreach (var item in v)
            if (t.EndsWith(item))
                return true;
        return false;
    }

    /// <summary>
    ///     AnyElementEndsWith - string[]
    ///     EndsWith - IList<string>
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="allowedExtension"></param>
    /// <returns></returns>
    public static bool EndsWith(string fn, List<string> allowedExtension)
    {
        foreach (var item in allowedExtension)
            if (fn.EndsWith(item))
                return true;
        return false;
    }

    public static List<string> Join(IEnumerable<object> o)
    {
        var result = new List<string>();
        foreach (var item in o)
        {
            result.AddRange(new List<string>([item.ToString()]));
        }

        return result;
    }

    public static string ReplaceAll(string r, List<string> what, string forWhat)
    {
        foreach (var item in what) r = r.Replace(item, forWhat);

        return r;
    }


    /// <summary>
    ///     Remove from A1 which exists in A2
    /// </summary>
    /// <param name="s"></param>
    /// <param name="manuallyNo"></param>
    public static void RemoveWhichExists(IList<string> s, List<string> manuallyNo)
    {
        var dex = -1;
        foreach (var item in manuallyNo)
        {
            dex = s.IndexOf(item);
            if (dex != -1) s.RemoveAt(dex);
        }
    }





    /// <summary>
    ///     Return first of A2 which starts with  A1. Otherwise null
    ///     So, isnt finding occurences but find out something in A2 have right format.
    ///     Method with shifted parameters working for searching occurences
    /// </summary>
    /// <param name="item2"></param>
    /// <param name="v1"></param>
    public static string StartWith(string item2, params string[] v1)
    {
        return StartWith(item2, v1.ToList());
    }

    public static string StartWith(string item2, IList<string> v1)
    {
        int i;
        return StartWith(item2, v1, out i);
    }

    /// <summary>
    ///     Return first of A2 which starts with  A1. Otherwise null
    ///     So, isnt finding occurences but find out something in A2 have right format.
    ///     Method with shifted parameters working for searching occurences
    ///     Cant be use if A1 is shorter than A2 (text vs textarea)
    /// </summary>
    /// <param name="item2"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    public static string StartWith(string item2, IList<string> v1, out int i)
    {
        i = -1;
        foreach (var item in v1)
        {
            i++;
            if (item.StartsWith(item2)) return item;
        }

        return null;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="backslash"></param>
    /// <param name="s"></param>
    public static List<string> TrimStart(string backslash, List<string> s)
    {
        var methodName = "TrimStart";

        ThrowEx.IsNull("backslash", backslash);
        ThrowEx.IsNull("s", s);

        for (var i = 0; i < s.Count; i++)
            if (s[i].StartsWith(backslash))
                s[i] = s[i].Substring(backslash.Length);
        return s;
    }




    public static void AppendToLastElement(List<string> list, string s)
    {
        if (list.Count > 0)
            list[list.Count - 1] += s;
        else
            list.Add(s);
    }





    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="whereIsUsed2"></param>
    /// <param name="v"></param>
    public static List<string> WrapWith(List<string> whereIsUsed2, string v)
    {
        return WrapWith(whereIsUsed2, v, v);
    }

    /// <summary>
    ///     direct edit
    /// </summary>
    /// <param name="whereIsUsed2"></param>
    /// <param name="v"></param>
    public static List<string> WrapWith(List<string> whereIsUsed2, string before, string after)
    {
        for (var i = 0; i < whereIsUsed2.Count; i++) whereIsUsed2[i] = before + whereIsUsed2[i] + after;
        return whereIsUsed2;
    }


    public static List<long> ToLong(IList enumerable)
    {
        var result = new List<long>();
        foreach (var item in enumerable) result.Add(long.Parse(item.ToString()));
        return result;
    }




    public static List<short> ToShort(IList enumerable)
    {
        var result = new List<short>();
        foreach (var item in enumerable) result.Add(short.Parse(item.ToString()));
        return result;
    }


    public static List<byte> JoinBytesArray(byte[] pass, byte[] salt)
    {
        var lb = new List<byte>(pass.Length + salt.Length);
        lb.AddRange(pass);
        lb.AddRange(salt);
        return lb;
    }






    public static int GetLength(IList where)
    {
        if (where == null) return 0;
        return where.Count;
    }

    public static string[] JoinVariableAndArray(object p, IList sloupce)
    {
        var o = new List<string>();
        o.Add(p.ToString());
        foreach (var item in sloupce) o.Add(item.ToString());

        return o.ToArray();
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="sf"></param>
    /// <param name="toTrim"></param>
    public static List<string> TrimEnd(List<string> sf, params char[] toTrim)
    {
        for (var i = 0; i < sf.Count; i++) sf[i] = sf[i].TrimEnd(toTrim);
        return sf;
    }





    public static List<int> StartWithAnyInElement(string s, List<string> list, bool _trimBefore)
    {
        var result = new List<int>();

        var i = 0;
        foreach (var item in list)
        {
            var item2 = item;
            if (_trimBefore) item2 = item2.Trim();

            if (s.StartsWith(item2)) result.Add(i);

            i++;
        }

        return result;
    }


    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="nazev"></param>
    public static List<string> WithoutDiacritic(List<string> nazev)
    {
        for (var i = 0; i < nazev.Count; i++) nazev[i] = nazev[i].RemoveDiacritics();
        return nazev;
    }

    public static bool HasIndexWithValueWithoutException(int p, List<string> nahledy, string item)
    {
        if (p < 0) return false;
        if (nahledy.Count > p && nahledy[p] == item) return true;
        return false;
    }

    public static bool HasIndexWithoutException(int p, IList nahledy)
    {
        if (p < 0) return false;
        if (nahledy.Count > p) return true;
        return false;
    }


    /// <summary>
    ///     Return A2 if start something in A1
    ///     A2 can be null
    /// </summary>
    /// <param name="suMethods"></param>
    /// <param name="line"></param>
    /// <returns></returns>
    public static string StartWith(List<string> suMethods, string line)
    {
        string element = null;
        return StartWith(suMethods, line, out element);
    }

    /// <summary>
    ///     Return A2 if start something in A1
    ///     Really different method than string, List
    ///     <string>
    ///         A1 can be null
    /// </summary>
    /// <param name="suMethods"></param>
    /// <param name="line"></param>
    public static string StartWith(List<string> suMethods, string line, out string element)
    {
        element = null;

        if (suMethods != null)
            foreach (var method in suMethods)
                if (line.StartsWith(method))
                {
                    element = method;
                    return line;
                }

        return null;
    }

    /// <summary>
    ///     Return A1 which contains A2
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="term"></param>
    public static List<string> ReturnWhichContains(List<string> lines, string term,
        ContainsCompareMethodCA parseNegations = ContainsCompareMethodCA.WholeInput)
    {
        List<int> founded;
        return ReturnWhichContains(lines, term, out founded, parseNegations);
    }

    /// <summary>
    ///     Return A1 which contains A2
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="term"></param>
    /// <param name="founded"></param>
    public static List<string> ReturnWhichContains(List<string> lines, string term, out List<int> founded,
        ContainsCompareMethodCA parseNegations = ContainsCompareMethodCA.WholeInput)
    {
        founded = new List<int>();
        var result = new List<string>();
        var i = 0;

        List<string> w = null;
        if (parseNegations == ContainsCompareMethodCA.SplitToWords ||
            parseNegations == ContainsCompareMethodCA.Negations)
            w = SHSplit.SplitNone(term, AllStrings.whiteSpacesChars.ToArray());

        if (parseNegations == ContainsCompareMethodCA.WholeInput)
            foreach (var item in lines)
            {
                if (item.Contains(term))
                {
                    founded.Add(i);
                    result.Add(item);
                }

                i++;
            }
        else if (parseNegations == ContainsCompareMethodCA.SplitToWords ||
                 parseNegations == ContainsCompareMethodCA.Negations)
            foreach (var item in lines)
            {
                if (w.All(d => item.Contains(d))) //SH.ContainsAll(item, w, parseNegations))
                {
                    founded.Add(i);
                    result.Add(item);
                }

                i++;
            }
        else
            ThrowEx.NotImplementedCase(parseNegations);

        return result;
    }

    public static void Remove(List<string> input, Func<string, string, bool> pred, string arg)
    {
        for (var i = input.Count - 1; i >= 0; i--)
            if (pred.Invoke(input[i], arg))
                input.RemoveAt(i);
    }


    public static bool HasNullValue(List<string> idPhotos)
    {
        for (var i = 0; i < idPhotos.Count; i++)
            if (idPhotos[i] == null)
                return true;
        return false;
    }

    /// <summary>
    ///     Create array with A2 elements, otherwise return null. If any of element has not int value, return also null.
    /// </summary>
    /// <param name="altitudes"></param>
    /// <param name="requiredLength"></param>
    public static List<int> ToIntMinRequiredLength(IList enumerable, int requiredLength)
    {
        if (enumerable.Count() < requiredLength) return null;

        var result = new List<int>();
        var y = 0;
        foreach (var item in enumerable)
            if (int.TryParse(item.ToString(), out y))
                result.Add(y);
            else
                return null;
        return result;
    }




    public static List<string> EnsureBackslash(List<string> eb)
    {
        for (var i = 0; i < eb.Count; i++)
        {
            var r = eb[i];
            if (r[r.Length - 1] != AllChars.bs) eb[i] = r + Consts.bs;
        }

        return eb;
    }

    /// <summary>
    ///     Delete which fullfil A2 wildcard
    /// </summary>
    /// <param name="d"></param>
    /// <param name="mask"></param>
    public static void RemoveWildcard(List<string> d, string mask)
    {
        //https://stackoverflow.com/a/15275806

        for (var i = d.Count - 1; i >= 0; i--)
            if (SH.MatchWildcard(d[i], mask))
                d.RemoveAt(i);
    }



    public static List<object> ToObject(IList enumerable)
    {
        var result = new List<object>();
        foreach (var item in enumerable) result.Add(item);
        return result;
    }

    public static List<bool> ToBool(List<int> numbers)
    {
        var b = new List<bool>(numbers.Count);
        foreach (var item in numbers) b.Add(item == 1 ? true : false);
        return b;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="files"></param>
    /// <param name="list"></param>
    /// <param name="wildcard"></param>
    public static void RemoveWhichContainsList(List<string> files, List<string> list, bool wildcard,
        Func<string, string, bool> WildcardIsMatch = null)
    {
        foreach (var item in list) RemoveWhichContains(files, item, wildcard, WildcardIsMatch);
    }


    public static string RemovePadding(List<byte> decrypted, byte v, bool returnStringInUtf8)
    {
        RemovePadding(decrypted, v);

        if (returnStringInUtf8) return Encoding.UTF8.GetString(decrypted.ToArray());
        return string.Empty;
    }



    public static bool HasAtLeastOneElementInArray(List<string> d)
    {
        if (d != null)
            if (d.Count != 0)
                return true;
        return false;
    }





    public static bool HasPostfix(string key, params string[] v1)
    {
        foreach (var item in v1)
            if (key.EndsWith(item))
                return true;
        return false;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="numbered"></param>
    /// <param name="input"></param>
    private static void Prepend(List<string> numbered, List<string> input)
    {
        ThrowEx.DifferentCountInLists("numbered", numbered.Count(), "input", input.Count);
        for (var i = 0; i < input.Count; i++) input[i] = numbered[i] + input[i];
    }

    /// <summary>
    ///     Direct edit input collection
    /// </summary>
    /// <param name="v"></param>
    /// <param name="toReplace"></param>
    public static List<string> Prepend(string v, List<string> toReplace)
    {
        for (var i = 0; i < toReplace.Count; i++)
            if (!toReplace[i].StartsWith(v))
                toReplace[i] = v + toReplace[i];
        return toReplace;
    }

    /// <summary>
    ///     Direct edit input collection
    /// </summary>
    /// <param name="v"></param>
    /// <param name="toReplace"></param>
    public static List<string> Prepend(string v, string[] toReplace)
    {
        return Prepend(v, toReplace.ToList());
    }


    public static string FindOutLongestItem(List<string> list, params string[] delimiters)
    {
        var delkaNejdelsiho = 0;
        var nejdelsi = "";
        foreach (var item in list)
        {
            var tem = item;
            if (delimiters.Length != 0) tem = SHSplit.SplitMore(item, delimiters)[0].Trim();
            if (delkaNejdelsiho < tem.Length)
            {
                nejdelsi = tem;
                delkaNejdelsiho = tem.Length;
            }
        }

        return nejdelsi;
    }

    public static bool IsOdd(params List<int>[] bold)
    {
        foreach (var item in bold)
            if (item.Count % 2 == 1)
                return true;
        return false;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="slova"></param>
    public static List<string> ToLower(List<string> slova)
    {
        for (var i = 0; i < slova.Count; i++) slova[i] = slova[i].ToLower();
        return slova;
    }





    /// <summary>
    ///     Direct editr
    /// </summary>
    /// <param name="files1"></param>
    /// <param name="item"></param>
    /// <param name="wildcard"></param>
    public static void RemoveWhichContains(List<string> files1, string item, bool wildcard,
        Func<string, string, bool> WildcardIsMatch)
    {
        if (wildcard)
        {
            //item = SH.WrapWith(item, AllChars.asterisk);
            for (var i = files1.Count - 1; i >= 0; i--)
                if (WildcardIsMatch(files1[i], item))
                    files1.RemoveAt(i);
        }
        else
        {
            for (var i = files1.Count - 1; i >= 0; i--)
                if (files1[i].Contains(item))
                    files1.RemoveAt(i);
        }
    }






    ///// <summary>
    ///// Convert IList to List<string> Nothing more, nothing less
    ///// Must be private - to use only public in CA
    ///// bcoz Cast() not working
    ///// Dont make any type checking - could be done before
    ///// </summary>
    //private static List<string> ToListString2(IList enumerable)
    //{
    //    return se.new List<string>2(enumerable);
    //}

    ///// <summary>
    ///// Just 3 cases of working:
    ///// IList<char> => string
    ///// IList<string> => List<string>
    ///// IList => List<string>
    ///// </summary>
    ///// <param name="enumerable"></param>
    //public static List<string> ToListString(IList enumerable2)
    //{
    //    return se.new List<string>(enumerable2);
    //}

    public static IList<object> OneElementCollectionToMulti(IList deli2)
    {
        if (deli2.Count() == 1)
        {
            var first = deli2.FirstOrNull();
            var ien = first as IList<object>;

            if (ien != null) return ien;
            return ToListMoreObject(first);
        }

        return deli2 as IList<object>;
    }


    /// <summary>
    ///     Direct edit collection
    ///     Na rozdíl od metody RemoveStringsEmpty2 NEtrimuje před porovnáním
    /// </summary>
    /// <param name="mySites"></param>
    public static List<string> RemoveStringsEmpty(List<string> mySites)
    {
        for (var i = mySites.Count - 1; i >= 0; i--)
            if (mySites[i] == string.Empty)
                mySites.RemoveAt(i);
        return mySites;
    }

    public static List<string> PostfixIfNotEnding(string pre, List<string> l)
    {
        for (var i = 0; i < l.Count; i++) l[i] = pre + l[i];
        return l;
    }

    public static List<int> ParseInt(string v, string comma)
    {
        var s = SHSplit.SplitMore(v, comma);
        var n = new List<int>(s.Count);
        foreach (var item in s) n.Add(int.Parse(item));

        //return BTS.CastCollectionStringToInt(s);
        return n;
    }

    public static List<List<string>> Split(List<string> s, string determining)
    {
        var ls = new List<List<string>>();
        var actual = new List<string>();
        foreach (var item in s)
            if (item == determining)
            {
                ls.Add(actual);
                actual.Clear();
            }

        return ls;
    }

    public static string GetFirstWordOfList(string t2)

    {
        var sb = new StringBuilder();

        var text = t2.Split(new[] { t2.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.None)
            .ToList(); //SHGetLines.GetLines(t2);
        foreach (var item in text)
        {
            var t = item.Trim();

            if (t.EndsWith(AllStrings.colon))
                sb.AppendLine(item);
            else if (t == "")
                sb.AppendLine(t);
            else
                sb.AppendLine(t.Split(AllChars.whiteSpacesChars.ToArray())[0]);
        }

        return sb.ToString();
    }

    public static void RemoveEmptyLinesToFirstNonEmpty(List<string> content)
    {
        for (var i = 0; i < content.Count; i++)
        {
            var line = content[i];
            if (line.Trim() == string.Empty)
            {
                content.RemoveAt(i);
                i--;
            }
            else
            {
                break;
            }
        }
    }

    //public static object FirstOrNull(IList e)
    //{
    //    if (e == null)
    //    {
    //        return null;
    //    }

    //    //var tName = e.GetType().Name;
    //    //if (ThreadHelper.NeedDispatcher(tName))
    //    //{
    //    //    var result = CA.dFirstOrNull(e);
    //    //    return result;
    //    //}

    //    return e.FirstOrNull();
    //}
    public static void KeepOnlyWordsToFirstSpecialChars(List<string> l)
    {
        ThrowEx.NotImplementedMethod();
        //for (int i = 0; i < l.Count; i++)
        //{
        //    l[i] = SHParts.RemoveAfterFirstFunc(l[i], CharHelper.IsSpecial, EmptyArrays.Chars);
        //}
    }


    public static List<string> LinesIndexes(List<string> cOnlyNamesBy10, int from, int to, bool indexedFrom1)
    {
        if (indexedFrom1)
        {
            from--;
            to--;
        }

        var s = new List<string>();

        for (var i = from; i < to + 1; i++) s.Add(cOnlyNamesBy10[i]);

        return s;
    }

    // In order to convert any 2d array to jagged one
    // let's use a generic implementation
    public static List<List<int>> ToJagged(bool[,] value)
    {
        var result = new List<List<int>>();
        for (var i = 0; i < value.GetLength(0); i++)
        {
            var ca = new List<int>();
            for (var y = 0; y < value.GetLength(1); y++) ca.Add(value[i, y] ? 1 : 0);
            result.Add(ca);
        }

        return result;
    }


    ///// <summary>
    ///// Direct edit
    ///// </summary>
    ///// <param name="input"></param>
    //public static string GetNumberedList(List<string> input, int startFrom)
    //{
    //    input = input.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();
    //    CA.PrependWithNumbered(input, startFrom);
    //    return SH.JoinNL(input);
    //}
    ///// <summary>
    ///// Direct edit
    ///// </summary>
    ///// <param name="input"></param>
    //private static void PrependWithNumbered(List<string> input, int startFrom)
    //{
    //    var numbered = SunamoBts.BTS.GetNumberedListFromTo(startFrom, input.Count - 1, ") ");
    //    Prepend(numbered, input);
    //}
    public static ABLCA<string, string> CompareListDifferent(List<string> c1, List<string> c2)
    {
        var existsIn1 = new List<string>();
        var existsIn2 = new List<string>();
        var dex = -1;
        for (var i = c2.Count - 1; i >= 0; i--)
        {
            var item = c2[i];
            dex = c1.IndexOf(item);
            if (dex == -1) existsIn2.Add(item);
        }

        for (var i = c1.Count - 1; i >= 0; i--)
        {
            var item = c1[i];
            dex = c2.IndexOf(item);
            if (dex == -1) existsIn1.Add(item);
        }

        var abl = new ABLCA<string, string>();
        abl.a = existsIn1;
        abl.b = existsIn2;
        return abl;
    }


    /// <summary>
    ///     A2,3 can be null, then no header will be append
    ///     A4 nameOfSolution - main header, also can be null
    /// </summary>
    /// <param name="alsoFileNames"></param>
    /// <param name="nameForFirstFolder"></param>
    /// <param name="nameForSecondFolder"></param>
    /// <param name="nameOfSolution"></param>
    /// <param name="files1"></param>
    /// <param name="files2"></param>
    /// <param name="inBoth"></param>
    public static string CompareListResult(bool alsoFileNames, string nameForFirstFolder, string nameForSecondFolder,
        string nameOfSolution, List<string> files1, List<string> files2, List<string> inBoth)
    {
        var files1Count = files1.Count;
        var files2Count = files2.Count;
        string result;

        dynamic textOutput = null; //new TextOutputGenerator();
        var inBothCount = inBoth.Count;
        double sumBothPlusManaged = inBothCount + files2Count;
        var percentCalculator = new PercentCalculator(sumBothPlusManaged);
        if (nameOfSolution != null) textOutput.sb.AppendLine(nameOfSolution);
        textOutput.sb.AppendLine("Both (" + inBothCount + AllStrings.swda +
                                 percentCalculator.PercentFor(inBothCount, false) + "%):");
        if (alsoFileNames) textOutput.List(inBoth);
        if (nameForFirstFolder != null)
            textOutput.sb.AppendLine(nameForFirstFolder + AllStrings.lb + files1Count + AllStrings.swda +
                                     percentCalculator.PercentFor(files1Count, true) + "%):");
        if (alsoFileNames) textOutput.List(files1);
        if (nameForSecondFolder != null)
            textOutput.sb.AppendLine(nameForSecondFolder + AllStrings.lb + files2Count + AllStrings.swda +
                                     percentCalculator.PercentFor(files2Count, true) + "%):");
        if (alsoFileNames) textOutput.List(files2);
        textOutput.SingleCharLine(AllChars.asterisk, 10);
        result = textOutput.ToString();
        return result;
    }


    public static List<string> PaddingByEmptyString(List<string> list, int columns)
    {
        for (var i = list.Count - 1; i < columns - 1; i++) list.Add(string.Empty);
        return list;
    }

    public static int CountOfEnding(List<string> winrarFiles, string v)
    {
        var count = 0;
        for (var i = 0; i < winrarFiles.Count; i++)
            if (winrarFiles[i].EndsWith(v))
                count++;
        return count;
    }

    public static bool IsInRange(int od, int to, int index)
    {
        return od >= index && to <= index;
    }

    public static List<string> DummyElementsCollection(int count)
    {
        return Enumerable.Repeat(string.Empty, count).ToList();
    }


    /// <summary>
    ///     Is useful when want to wrap and also join with string. Also last element will have delimiter
    /// </summary>
    /// <param name="list"></param>
    /// <param name="wrapWith"></param>
    /// <param name="delimiter"></param>
    public static List<string> WrapWithAndJoin(IList<string> list, string wrapWith, string delimiter)
    {
        return list.Select(i => wrapWith + i + wrapWith + delimiter).ToList();
    }

    public static int PartsCount(int count, int inPart)
    {
        var celkove = count / inPart;
        if (count % inPart != 0) celkove++;
        return celkove;
    }

    public static bool HasFirstItemLength(List<string> notContains)
    {
        var t = "";
        if (notContains.Count > 0) t = notContains[0].Trim();
        return t.Length > 0;
    }

    public static List<string> TrimList(List<string> c)
    {
        for (var i = 0; i < c.Count; i++) c[i] = c[i].Trim();
        return c;
    }

    public static string GetTextAfterIfContainsPattern(string input, string ifNotFound, List<string> uriPatterns)
    {
        foreach (var item in uriPatterns)
        {
            var nt = input.IndexOf(item);
            if (nt != -1)
                if (input.Length > item.Length + nt)
                    return input.Substring(nt + item.Length);
        }

        return ifNotFound;
    }

    /// <summary>
    ///     Direct edit
    ///     WithEndSlash - trims backslash and append new
    ///     WithoutEndSlash - ony trims backslash
    /// </summary>
    /// <param name="folders"></param>
    public static List<string> WithEndSlash(List<string> folders)
    {
        var list = folders;
        if (list == null) list = folders.ToList();
        for (var i = 0; i < list.Count; i++) list[i] = list[i].TrimEnd('\\') + "\\";
        return folders;
    }

    public static List<string> WithoutEndSlash(List<string> folders)
    {
        for (var i = 0; i < folders.Count; i++) folders[i] = folders[i].TrimEnd('\\');
        return folders;
    }


    public static List<string> JoinArrayAndArrayString(IList<string> a, IList<string> p)
    {
        if (a != null)
        {
            var d = new List<string>(a.Count + p.Count);
            d.AddRange(a);
            d.AddRange(p);
            return d;
        }

        return new List<string>(p);
    }

    public static List<string> JoinArrayAndArrayString(IList<string> a, params string[] p)
    {
        return JoinArrayAndArrayString(a, p.ToList());
    }

    public static void CheckExists(List<bool> photoFiles, List<string> allFilesRelative, List<string> value)
    {
        foreach (var item in allFilesRelative) photoFiles.Add(value.Contains(item));
    }

    public static bool HasOtherValueThanNull(List<string> idPhotos)
    {
        foreach (var item in idPhotos)
            if (item != null)
                return true;
        return false;
    }

    public static List<string> GetRowOfTable(List<List<string>> _dataBinding, int i2)
    {
        var vr = new List<string>();
        for (var i = 0; i < _dataBinding.Count; i++) vr.Add(_dataBinding[i][i2]);
        return vr;
    }

    /// <summary>
    ///     Na rozdíl od metody RemoveStringsEmpty2 NEtrimuje před porovnáním
    /// </summary>
    public static List<string> RemoveStringsByScopeKeepAtLeastOne(List<string> mySites, FromToCollections fromTo,
        int keepLines)
    {
        mySites.RemoveRange((int)fromTo.FromL, (int)fromTo.ToL - (int)fromTo.FromL + 1);
        for (var i = fromTo.FromL; i < fromTo.FromL - 1 + keepLines; i++) mySites.Insert((int)i, "");
        return mySites;
    }

    /// <summary>
    ///     Return first A2 elements of A1 or A1 if A2 is bigger
    /// </summary>
    /// <param name="proj"></param>
    /// <param name="p"></param>
    public static List<string> ShortCircuit(List<string> proj, int p)
    {
        var vratit = new List<string>();
        if (p > proj.Count) p = proj.Count;
        for (var i = 0; i < p; i++) vratit.Add(proj[i]);
        return vratit;
    }

    public static List<string> ContainsDiacritic(IList<string> nazvyReseni)
    {
        var vr = new List<string>(nazvyReseni.Count());
        foreach (var item in nazvyReseni)
            if (item.HasDiacritics())
                vr.Add(item);
        return vr;
    }


    /// <summary>
    ///     Change elements count in collection to A2
    /// </summary>
    /// <param name="input"></param>
    /// <param name="requiredLength"></param>
    public static List<string> ToSize(List<string> input, int requiredLength)
    {
        List<string> returnArray = null;
        var realLength = input.Count;
        if (realLength > requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            for (var i = 0; i < requiredLength; i++) returnArray[i] = input[i];
            return returnArray;
        }

        if (realLength == requiredLength)
        {
            return input;
        }

        if (realLength < requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            var i = 0;
            for (; i < realLength; i++) returnArray[i] = input[i];
            for (; i < requiredLength; i++) returnArray[i] = null;
        }

        return returnArray;
    }

    public static List<string> Format(string uninstallNpmPackageGlobal, List<string> globallyInstalledTsDefinitions)
    {
        for (var i = 0; i < globallyInstalledTsDefinitions.Count(); i++)
            globallyInstalledTsDefinitions[i] = /*string.Format*/
                string.Format(uninstallNpmPackageGlobal, globallyInstalledTsDefinitions[i]);
        return globallyInstalledTsDefinitions;
    }

    public static void RemoveEmptyLinesFromStartAndEnd(List<string> c)
    {
        RemoveEmptyLinesToFirstNonEmpty(c);
        RemoveEmptyLinesFromBack(c);
    }




    #region For easy copy from CAShared64.cs



    //public static int Count(IList e)
    //{
    //    return se.CA.Count(e);

    //}


    /// <summary>
    ///     Direct edit
    ///     Must return because is used with params string[]
    /// </summary>
    /// <param name="backslash"></param>
    /// <param name="s"></param>
    public static List<string> TrimStartChar(char backslash, List<string> s)
    {
        for (var i = 0; i < s.Count; i++) s[i] = s[i].TrimStart(backslash);
        return s;
    }

    #endregion
}