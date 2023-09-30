using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    internal interface IDelimeterFile
    {
        string FileName { get; set; }
        string DelimeterValue {get; set; }
        string FileExtension { get; set; }
    }
}
