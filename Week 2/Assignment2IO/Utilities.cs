using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment2IO
{
    internal static class Utilities
    {
        internal static string RemoveWhiteSpace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }

        internal static string RemoveEscapeChars(string input)
        {
            return Regex.Replace(input, @"[\r\n\t]", "");
        }
    }
}
