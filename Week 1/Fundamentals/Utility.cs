using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fundamentals
{
    internal static class Utility
    {
        internal static string RemoveWhiteSpace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    }
}
