﻿using Assignment5.Entities.JSON;
using Assignment5.Entities.XML;
using Assignment5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Engines
{
    internal class XMLEngine : BaseEngine
    {
        internal override List<Error> ProcessFiles(IFile file)
        {
            List<Error> errors = new List<Error>();

            try
            {
                string outputFilePath = GenerateOutputFile(file);

                using (StreamReader sr = new StreamReader(file.Path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(GroceryList));
                    var groceryList = (GroceryList)serializer?.Deserialize(sr);

                    using (StreamWriter sw = new StreamWriter(outputFilePath))
                    {
                        var lineCount = 1;
                        foreach(var item in groceryList.GroceryItems) 
                        {
                            sw.WriteLine($"Item #{lineCount}: {item.ToString()}");
                            lineCount++;
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
