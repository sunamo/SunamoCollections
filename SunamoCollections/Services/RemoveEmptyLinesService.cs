namespace SunamoCollections.Services;

/// <summary>
/// Service for removing empty lines from the beginning and end of a list of strings.
/// </summary>
public class RemoveEmptyLinesService
{
    /// <summary>
    /// Removes empty lines from both the start and end of the list.
    /// </summary>
    /// <param name="list">The list to process.</param>
    public void RemoveEmptyLinesFromStartAndEnd(List<string> list)
    {
        RemoveEmptyLinesToFirstNonEmpty(list);
        RemoveEmptyLinesFromBack(list);
    }

    /// <summary>
    /// Removes empty lines from the start of the list until the first non-empty line is found.
    /// </summary>
    /// <param name="list">The list to process.</param>
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
    /// Removes empty lines from the end of the list.
    /// </summary>
    /// <param name="list">The list to process.</param>
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
