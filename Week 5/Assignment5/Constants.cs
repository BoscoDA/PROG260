using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public static class Constants
    {
        public sealed class FileExtensions
        {
            public static string TEXT => ".txt";
            public static string PIPE => ".txt";
            public static string CSV => ".csv";
            public static string JSON => ".json";
            public static string XML => ".xml";
        }

        public sealed class FileDelimieters
        {
            public static string PIPE => "|";
            public static string CSV => ",";
        }
    }
}
