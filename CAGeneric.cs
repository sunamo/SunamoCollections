
namespace SunamoCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// V samostatném souboru kvůli <T>
/// Do CAG to nejde, musel bych upravovat i ty v _sunamo všude
/// </summary>
partial class CA
{
    /// <summary>
    ///     better is use first or default, because here I also have to use default(T)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static T FirstOrNull<T>(List<T> list)
    {
        if (list.Count > 0) return list[0];
        return default;
    }

    public static List<List<T>> DivideBy<T>(List<T> divs, int countOfColumn)
    {
        if (divs.Count % countOfColumn != 0)
        {
            throw new Exception($"Elements in {nameof(divs)} is not dividable by {nameof(countOfColumn)}");
        }

        List<List<T>> result = new List<List<T>>();

        List<T> t = new List<T>();

        foreach (var item in divs)
        {
            t.Add(item);
            if (t.Count == countOfColumn)
            {
                result.Add(t);
                t = new List<T>();
            }
        }

        return result;
    }

    public static List<List<T>> DivideByPercent<T>(List<T> ls, int v)
    {
        var parts = 100 / v;
        var ds = ls.Count / parts;

        var from = 0;
        var result = new List<List<T>>();
        for (var i = 0; i < parts; i++)
        {
            result.Add(GetIndexesFromTo(ls, from, ds));
            from += ds;
        }

        var anotherEls = from != ls.Count;
        if (anotherEls) result.Add(GetIndexesFromTo(ls, from, ls.Count - result[0].Count * parts));

        return result;
    }

    private static List<T> GetIndexesFromTo<T>(List<T> ls, int from, int countOfElements)
    {
        var t = new T[countOfElements];
        ls.CopyTo(from, t, 0, countOfElements);

        return new List<T>(t);
    }

    public static void InitFillWith<T>(List<T> arr, int columns)
    {
        for (var i = 0; i < columns; i++) arr.Add(default);
    }

    public static void RemoveNull<T>(List<T> result)
    {
        var def = default(T);
        for (var i = result.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(def, result[i]))
                result.RemoveAt(i);
    }

    public static List<T> ReplaceNullFor<T>(List<T> l, T empty) where T : class
    {
        for (var i = 0; i < l.Count; i++)
            if (l[i] == null)
                l[i] = empty;
        return l;
    }

    public static List<T> ToArrayTCheckNull<T>(params T[] where)
    {
        var vr = where.ToList();
        RemoveDefaultT(vr);
        return vr;
    }

    public static T IndexOrNull<T>(T[] where, int v)
    {
        if (where.Length > v) return where[v];
        return default;
    }

    /// <summary>
    ///     Index A2 a další bude již v poli A4
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="before"></param>
    /// <param name="after"></param>
    public static void Split<T>(T[] p1, int p2, out T[] before, out T[] after)
    {
        before = new T[p2];
        var p1l = p1.Length;
        after = new T[p1l - p2];
        var b = true;
        for (var i = 0; i < p1l; i++)
        {
            if (i == p2) b = false;
            if (b)
                before[i] = p1[i];
            else
                after[i] = p1[i - p2];
        }
    }

    public static List<List<T>> SplitList<T>(IList<T> locations, int nSize = 30)
    {
        var result = new List<List<T>>();

        for (var i = 0; i < locations.Count; i += nSize)
            result.Add(locations.ToList().GetRange(i, Math.Min(nSize, locations.Count - i)));

        return result;
    }

    public static void RemovePadding<T>(List<T> decrypted, T v)
    {
        for (var i = decrypted.Count - 1; i >= 0; i--)
        {
            if (!EqualityComparer<T>.Default.Equals(decrypted[i], v)) break;
            decrypted.RemoveAt(i);
        }
    }

    #region 4) ContainsElement

    /// <summary>
    ///     ContainsAnyFromElement - Contains string elements of list. Return List
    ///     <string>
    ///         IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///         IsEqualToAllElement - takes two generic list. return bool
    ///         ContainsElement - at least one element must be equaled. generic. bool
    ///         IsSomethingTheSame - only for string. as List.Contains. bool
    ///         IsAllTheSame() - takes element and list.generic. bool
    ///         IndexesWithValue() - element and list.generic. return list
    ///         <int>
    ///             ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="t"></param>
    public static bool ContainsElement<T>(IList<T> list, T t)
    {
        if (list.Count() == 0) return false;
        foreach (var item in list)
            if (Equals(item, t))
                return true;

        return false;
    }

    #endregion

    /// <summary>
    ///     element can be null, then will be added as default(T)
    ///     If item is null, add instead it default(T)
    ///     cant join from IList elements because there must be T2 for element's type of collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    public static List<T> ToList<T>(IList enumerable)
    {
        // system array etc cant be casted
        //var ien = enumerable as IList<object>;
        var ien = enumerable as List<object>;
        var ienf = ien.FirstOrNull() as IList;
        List<T> result = null;
        //if (enumerable is IList<char>)
        //{
        //    result = new List<T>(1);
        //    result.Add(SHJoin.JoinIList(string.Empty, enumerable));
        //}

        var b1 = ien != null;
        var b2 = typeof(T) == Types.tString;
        var b3 = ienf.Count > 1;
        var b4 = false;
        var b5 = false;

        if (ienf != null)
        {
            var f = ienf.FirstOrNull();
            if (f != null) b4 = f.GetType() == Types.tChar;
        }

        if (ien != null)
        {
            var l = ien.Last();
            if (l != null) b5 = l.GetType() == Types.tChar;
        }

        if (enumerable.Count == 1 && enumerable.FirstOrNull() is IList<object>)
            result = ToListT2<T>((IList)enumerable.FirstOrNull());
        else if (b1 && b2 && b3 && b4 && b5)
            result.Add((T)(dynamic)string.Join(string.Empty, enumerable));
        else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList)
            result = ToListT2<T>((IList)enumerable.FirstOrNull());
        else
            return ToListT2<T>(enumerable);
        return result;
    }

    public static bool IsListStringWrappedInArray<T>(List<T> v2)
    {
        var first = v2.First().ToString();
        if (v2.Count == 1 && (first == "System.Collections.Generic.List`1[System.String]" ||
                              first == "System.Collections.Generic.List`1[System.Object]")) return true;
        return false;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vr"></param>
    public static void RemoveDefaultT<T>(List<T> vr)
    {
        for (var i = vr.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(vr[i], default))
                vr.RemoveAt(i);
    }

    public static void InitFillWith<T>(List<T> datas, int pocet, T initWith)
    {
        for (var i = 0; i < pocet; i++) datas.Add(initWith);
    }

    /// <summary>
    ///     Only for structs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="times"></param>
    public static List<int> IndexesWithNull<T>(List<T?> times) where T : struct
    {
        var nulled = new List<int>();
        for (var i = 0; i < times.Count; i++)
        {
            if (!times[i].HasValue) nulled.Add(i);


        }

        return nulled;
    }

    public static List<T> JoinIList<T>(params IList<T>[] enumerable)
    {
        var t = new List<T>();
        foreach (var item in enumerable)
            foreach (var item2 in item)
                t.Add(item2);
        return t;
    }

    /// <summary>
    ///     Simply calling SequenceEqual
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sloupce"></param>
    /// <param name="sloupce2"></param>
    /// <returns></returns>
    public static bool IsTheSame<T>(IList<T> sloupce, IList<T> sloupce2)
    {
        return sloupce.SequenceEqual(sloupce2);
    }

    public static List<T> JumbleUp<T>(List<T> b)
    {
        var bl = b.Count;
        var r = new Random();
        for (var i = 0; i < bl; ++i)
        {
            var index1 = r.Next() % bl;
            var index2 = r.Next() % bl;

            var temp = b[index1];
            b[index1] = b[index2];
            b[index2] = temp;
        }

        return b;
    }

    /// <summary>
    ///     element can be null, then will be added as default(T)
    ///     Must be private - to use only public in CA
    ///     bcoz Cast() not working
    ///     Dont make any type checking - could be done before
    /// </summary>
    private static List<T> ToListT2<T>(IList enumerable) //where T : IList<char>
    {
        if (typeof(T) == Types.tString)
        {
            var t = new List<T>();


            foreach (var item in enumerable)
                if (item is IList)
                {
                    var ie = (IList)item;
                    var sb = new StringBuilder();
                    foreach (var item2 in ie) sb.Append(item2);
                    object t2 = sb.ToString();
                    t.Add((T)t2);
                }
                else if (item is char)
                {
                    var sb = new StringBuilder();
                    foreach (var item2 in enumerable) sb.Append(item2);
                    object t2 = sb.ToString();
                    t.Add((T)t2);
                    break;
                }
                else
                {
                    t.Add((T)(IEnumerable<char>)item.ToString());
                }

            return t;
        }

        var result = new List<T>(enumerable.Count());
        foreach (var item in enumerable)
            if (item == null)
                result.Add(default);
            else
                // cant join from IList elements because there must be T2 for element's type of collection. Use CA.TwoDimensionParamsIntoOne instead
                //var t1 = item.GetType();
                //var t2 = typeof(IList);
                //if (RH.IsOrIsDeriveFromBaseClass(t1 , t2, false) && t1 != Types.tString)
                //{
                //    //result.AddRange(item as IList);
                //    var item3 = (IList)item;
                //    foreach (var item2 in item3)
                //    {
                //        result.Add(item2);
                //    }
                //}
                //else
                //{
                //try
                //{
                result.Add((T)item);
        //}
        //catch (Exception ex)
        //{
        //    // Insert Here ThrowEx
        //}
        //}
        return result;
    }

    public static T[] JumbleUp<T>(T[] b)
    {
        var bl = b.Length;

        var random = new Random();

        for (var i = 0; i < bl; ++i)
        {
            var index1 = random.Next() % bl;
            var index2 = random.Next() % bl;

            var temp = b[index1];
            b[index1] = b[index2];
            b[index2] = temp;
        }

        return b;
    }


}