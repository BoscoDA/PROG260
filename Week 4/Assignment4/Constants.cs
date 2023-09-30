using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public sealed class Constants
    {
        public sealed class FileExtensions
        {
            public static string TEXT => ".txt";
            public static string PIPE => ".txt";
            public static string CSV => ".csv";
        }

        public sealed class FileDelimieters
        {
            public static char PIPE => '|';
            public static char CSV => ',';
        }
    }
}
