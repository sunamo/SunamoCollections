namespace SunamoCollections.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RemoveEmptyLinesService
{
    public static void RemoveEmptyLinesFromStartAndEnd(List<string> c)
    {
        RemoveEmptyLinesToFirstNonEmpty(c);
        RemoveEmptyLinesFromBack(c);
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
}