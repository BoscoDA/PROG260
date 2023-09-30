using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment4
{
    internal class Parser
    {
        List<IDelimiterFile> filesToProcess { get; set; }
        List<Error> errors { get; set; }
        Engine engine { get; set; }

        public Parser()
        {
            filesToProcess = new List<IDelimiterFile>();
            errors = new List<Error>();
            engine = new Engine();
        }

        public void ParseFiles(string directoryPath)
        {
            List<string> files = GetFilesToProcess(directoryPath);
            GenerateFiles(files);
            engine.ProcessFiles(filesToProcess);
        }

        private List<string> GetFilesToProcess(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath).Where(x => !x.Contains("_out")).ToList();
            return files;
        }

        private void GenerateFiles(List<string> files)
        {
            foreach (var file in files)
            {
                if (file.EndsWith(".txt"))
                {
                    MyFile tempFile = new MyFile(file, '|', ".txt");
                    filesToProcess.Add(tempFile);
                }
                else if (file.EndsWith(".csv"))
                {
                    MyFile tempFile = new MyFile(file, ',', ".csv");
                    filesToProcess.Add(tempFile);
                }
            }
        }
    }
}
