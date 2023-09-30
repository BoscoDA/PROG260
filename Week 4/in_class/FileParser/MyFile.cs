using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    internal class MyFile : IDelimeterFile
    {
        public string FileName { get; set; }
        public string DelimeterValue { get; set; }
        public string FileExtension { get; set; }


    }
}
