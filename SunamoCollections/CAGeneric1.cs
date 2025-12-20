
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections;
/// <summary>
/// V samostatném souboru kvůli <T>
/// Do CAG to nejde, musel bych upravovat i ty v _sunamo všude
/// </summary>
partial class CA
{
    /// <summary>
    ///     element can be null, then will be added as default(T)
    ///     Must be private - to use only public in CA
    ///     bcoz Cast() not working
    ///     Dont make any Type checking - could be done before
    /// </summary>
    private static List<T> ToListT2<T>(IList enumerable) //where T : IList<char>
    {
        if (typeof(T) == Types.TString)
        {
            var stringResults = new List<T>();
            foreach (var item in enumerable)
                if (item is IList)
                {
                    var itemList = (IList)item;
                    var stringBuilder = new StringBuilder();
                    foreach (var item2 in itemList)
                        stringBuilder.Append(item2);
                    object convertedString = stringBuilder.ToString();
                    stringResults.Add((T)convertedString);
                }
                else if (item is char)
                {
                    var stringBuilder = new StringBuilder();
                    foreach (var item2 in enumerable)
                        stringBuilder.Append(item2);
                    object convertedString = stringBuilder.ToString();
                    stringResults.Add((T)convertedString);
                    break;
                }
                else
                {
                    stringResults.Add((T)(IEnumerable<char>)item.ToString());
                }

            return stringResults;
        }

        var result = new List<T>(enumerable.Count());
        foreach (var item in enumerable)
            if (item == null)
                result.Add(default);
            else
                // cant join from IList elements because there must be T2 for element's Type of collection. Use CA.TwoDimensionParamsIntoOne instead
                //var t1 = item.GetType();
                //var t2 = typeof(IList);
                //if (RH.IsOrIsDeriveFromBaseClass(t1 , t2, false) && t1 != Types.TString)
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

    public static T[] JumbleUp<T>(T[] array)
    {
        var length = array.Length;
        var random = new Random();
        for (var i = 0; i < length; ++i)
        {
            var index1 = random.Next() % length;
            var index2 = random.Next() % length;
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        return array;
    }
}