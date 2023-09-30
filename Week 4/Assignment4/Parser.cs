using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assignment4.Models;

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

        /// <summary>
        /// Process all pipe and csv files in the inputted directory
        /// </summary>
        /// <param name="directoryPath">Path to the file directory to be parsed</param>
        public void ParseFiles(string directoryPath)
        {
            Console.WriteLine($"Processing files...{Environment.NewLine}");

            List<string> files = GetFilesToProcess(directoryPath);

            if(errors.Count == 0)
            {
                GenerateFiles(files);
            }

            if(errors.Count == 0)
            {
                errors = engine.ProcessFiles(filesToProcess);
            }

            if (errors.Count > 0)
            {
                Console.WriteLine("File process unsuccessful!");
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error Message: {error.message}. Error Source: {error.source}");
                }
            }
            else
            {
                Console.WriteLine("Files processed successfully!");
            }
        }

        /// <summary>
        /// Makes a list of all files in the inputted directory.
        /// </summary>
        /// <param name="directoryPath">Target directory path.</param>
        /// <returns>A list of type string with all file paths in the input directory.</returns>
        private List<string> GetFilesToProcess(string directoryPath)
        {
            List<string> files = new List<string>();

            try
            {
                files = Directory.GetFiles(directoryPath).Where(x => !x.Contains("_out")).ToList();
            }
            catch(IOException ex)
            {
                errors.Add(new Error(ex.Message, "Parser.GetFilesToProcess()"));
            }
            catch (UnauthorizedAccessException ex)
            {
                errors.Add(new Error(ex.Message, "Parser.GetFilesToProcess()"));
            }
            catch (ArgumentException ex)
            {
                errors.Add(new Error(ex.Message, "Parser.GetFilesToProcess()"));
            }
            catch(Exception ex)
            {
                errors.Add(new Error(ex.Message, "Parser.GetFilesToProcess()"));
            }
            
            return files;
        }

        /// <summary>
        /// From a list of file paths, generates objects of type MyFile and adds them to the FileeToProcess list.
        /// </summary>
        /// <param name="files">List of files paths to be turned into MyFile Objects</param>
        private void GenerateFiles(List<string> files)
        {
            foreach (var file in files)
            {
                if (file.EndsWith(Constants.FileExtensions.PIPE))
                {
                    MyFile tempFile = new MyFile(file, Constants.FileDelimieters.PIPE, Constants.FileExtensions.PIPE);
                    filesToProcess.Add(tempFile);
                }
                else if (file.EndsWith(Constants.FileExtensions.CSV))
                {
                    MyFile tempFile = new MyFile(file, Constants.FileDelimieters.CSV, Constants.FileExtensions.CSV);
                    filesToProcess.Add(tempFile);
                }
                else
                {
                    errors.Add(new Error($"Invalid file extenstion processed: {file.Substring(file.LastIndexOf('.'))}", "Parser.GenerateFiles()"));
                    break;
                }
            }
        }
    }
}
