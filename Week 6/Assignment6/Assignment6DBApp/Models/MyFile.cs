using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DBApp.Models
{
    internal class MyFile : IFile
    {
        public string Path { get; set; }
        public string? Delimiter { get; set; } = null;
        public string FileExtension { get; set; }

        public MyFile(string path, string fileExtension, string delimiter = null)
        {
            Path = path;
            Delimiter = delimiter;
            FileExtension = fileExtension;
        }
    }
}
