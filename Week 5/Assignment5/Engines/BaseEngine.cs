using Assignment5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Engines
{
    internal class Engine
    {

        /// <summary>
        /// Takes in a list of type IDelimiterFile and sequentially processes them to a output file 
        /// </summary>
        /// <param name="filesToProcess">List of IDelimiterFile objects to be processed</param>
        /// <returns></returns>
        public List<Error> ProcessFiles(List<IFile> filesToProcess)
        {
            List<Error> errors = new List<Error>();
            try
            {
                foreach (var file in filesToProcess)
                {
                    string outputFilePath = file.Path.Replace(file.FileExtension, $"_out{Constants.FileExtensions.TEXT}");

                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                    }

                    using (StreamReader sr = new StreamReader(file.Path))
                    {
                        using (StreamWriter sw = new StreamWriter(outputFilePath))
                        {
                            var line = sr.ReadLine();
                            var lineCount = 0;
                            while (line != null)
                            {
                                lineCount++;
                                sw.Write($"Line #{lineCount} :");
                                var fields = line.Split(file.Delimiter);
                                var fieldCount = 0;
                                foreach (var field in fields)
                                {
                                    fieldCount++;
                                    sw.Write($"Field #{fieldCount} = {field}");
                                    if (fieldCount - 1 < fields.Count() - 1)
                                    {

                                        sw.Write(" ==> ");
                                    }
                                    else
                                    {
                                        sw.Write($"{Environment.NewLine}");
                                    }
                                }

                                sw.Write($"{Environment.NewLine}");
                                line = sr.ReadLine();

                            }
                        }
                    }
                }
            }
            catch (IOException exception)
            {
                errors.Add(new Error(exception.Message, "Engine.ProcessFiles()"));
            }
            catch (Exception exception)
            {
                errors.Add(new Error(exception.Message, "Engine.ProcessFiles()"));
            }

            return errors;
        }
    }
}
