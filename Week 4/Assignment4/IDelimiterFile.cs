using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal interface IDelimiterFile
    {
        string Path { get; set; }
        char Delimiter { get; set; }
        string FileExtension { get; set; }
    }
}
