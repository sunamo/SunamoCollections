
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections.Services;

public class RemoveEmptyLinesService
{
    public void RemoveEmptyLinesFromStartAndEnd(List<string> lines)
    {
        RemoveEmptyLinesToFirstNonEmpty(lines);
        RemoveEmptyLinesFromBack(lines);
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
    public void RemoveEmptyLinesFromBack(List<string> lines)
    {
        for (var i = lines.Count - 1; i >= 0; i--)
        {
            var line = lines[i];
            if (line.Trim() == string.Empty)
                lines.RemoveAt(i);
            else
                break;
        }
    }
}