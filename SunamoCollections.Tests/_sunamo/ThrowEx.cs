using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoCollections.Tests._sunamo;
internal class ThrowEx
{
    internal static void Custom(string v)
    {
        throw new Exception(v);
    }
}
