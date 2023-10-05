using Assignment5.Entities.JSON;
using Assignment5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Engines
{
    internal class JSONEngine : BaseEngine
    {
        internal override List<Error> ProcessFiles(IFile file)
        {
            List<Error> errors = new List<Error>();

            try
            {
                string outputFilePath = file.Path.Replace(file.FileExtension, $"_out{Constants.FileExtensions.TEXT}");

                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }

                using (StreamReader sr = new StreamReader(file.Path))
                {
                    Student myStudent = JsonConvert.DeserializeObject<Student>(sr.ReadToEnd());

                    using (StreamWriter sw = new StreamWriter(outputFilePath))
                    {
                        sw.WriteLine($"Line #1: {myStudent.ToString()}");
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
