namespace SunamoCollections.Services;

/// <summary>
/// Represents the remove empty lines service type.
/// </summary>
public class RemoveEmptyLinesService
{
    /// <summary>
    /// Remove empty lines from start and end.
    /// </summary>
    /// <param name="list">The list.</param>
    public void RemoveEmptyLinesFromStartAndEnd(List<string> list)
    {
        RemoveEmptyLinesToFirstNonEmpty(list);
        RemoveEmptyLinesFromBack(list);
    }

    /// <summary>
    /// Remove empty lines to first non empty.
    /// </summary>
    /// <param name="list">The list.</param>
    public void RemoveEmptyLinesToFirstNonEmpty(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            var line = list[i];
            if (line.Trim() == string.Empty)
            {
                list.RemoveAt(i);
                i--;
            }
            else
            {
                break;
            }
        }
    }

    /// <summary>
    /// Remove empty lines from back.
    /// </summary>
    /// <param name="list">The list.</param>
    public void RemoveEmptyLinesFromBack(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var line = list[i];
            if (line.Trim() == string.Empty)
                list.RemoveAt(i);
            else
                break;
        }
    }
}
