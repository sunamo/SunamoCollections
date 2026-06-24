namespace SunamoCollections.Services;

public class RemoveEmptyLinesService
{
    public void RemoveEmptyLinesFromStartAndEnd(List<string> list)
    {
        RemoveEmptyLinesToFirstNonEmpty(list);
        RemoveEmptyLinesFromBack(list);
    }

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
