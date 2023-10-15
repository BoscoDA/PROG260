using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DBApp.Models
{
    internal interface IFile
    {
        string Path { get; set; }
        string? Delimiter { get; set; }
        string FileExtension { get; set; }
    }
}
