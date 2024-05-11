using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoCollections._sunamo;
internal class SHSE
{
    public static List<string> Split(string s, params string[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
