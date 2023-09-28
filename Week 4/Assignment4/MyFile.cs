using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class MyFile : IDelimiterFile
    {
        public string Path { get; set; }
        public char Delimiter { get; set; }
        public string FileExtension { get; set; }

        public MyFile(string path, char delimiter, string fileExtension)
        {
            Path = path;
            Delimiter = delimiter;
            FileExtension = fileExtension;
        }
    }
}
