// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections.Services;

public class RemoveEmptyLinesService
{
    public void RemoveEmptyLinesFromStartAndEnd(List<string> c)
    {
        RemoveEmptyLinesToFirstNonEmpty(c);
        RemoveEmptyLinesFromBack(c);
    }
    public void RemoveEmptyLinesToFirstNonEmpty(List<string> content)
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
    public void RemoveEmptyLinesFromBack(List<string> c)
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
}