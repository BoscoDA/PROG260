using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Engine
    {
        public void ProcessFiles(List<IDelimiterFile> filesToProcess)
        {
            try
            {
                foreach (var file in filesToProcess)
                {
                    string outputFilePath = file.Path.Replace(file.FileExtension, $"_out.txt");

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

            }
            catch(Exception exception)
            {

            }
        }
    }
}
