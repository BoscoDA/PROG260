using Assignment6DBApp.DAL;
using Assignment6DBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DBApp.Engines
{
    internal abstract class BaseEngine
    {
        public ProduceDAL produceDAL { get; set; }

        public BaseEngine()
        {
            produceDAL = new ProduceDAL();
        }

        /// <summary>
        /// Reads in given file then preforms need database manipulations and then writes database to output file
        /// </summary>
        /// <param name="file">Input file</param>
        /// <returns>List of type Error</returns>
        internal virtual List<Error> ProcessFile(IFile file)
        {
            List<Error> errors = new List<Error>();
            string outputFile = GenerateOutputFile(file);

            try
            {
                List<Produce> produce = GenerateProduce(file);

                List<Produce> output = RunSQL(produce);

                using (StreamWriter sw = new StreamWriter(outputFile))
                {
                    sw.WriteLine("Name,Location,Price,UoM,Sell_by_Date");
                    foreach (var item in output)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }

            }
            catch (IOException exception)
            {
                errors.Add(new Error(exception.Message, exception.TargetSite.ToString()));
            }
            catch (Exception exception)
            {
                errors.Add(new Error(exception.Message, exception.TargetSite.ToString()));
            }

            return errors;
        }

        /// <summary>
        /// Generates output file path
        /// </summary>
        /// <param name="file">Input file</param>
        /// <returns>Output file path</returns>
        internal string GenerateOutputFile(IFile file)
        {
            string outputFilePath = file.Path.Replace(file.FileExtension, $"_out{Constants.FileExtensions.TEXT}");

            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }

            return outputFilePath;
        }

        /// <summary>
        /// Reads file and generates produce objects from that data
        /// </summary>
        /// <param name="file">File with produce objects to be parsed</param>
        /// <returns>List of type Produce</returns>
        internal virtual List<Produce> GenerateProduce(IFile file)
        {
            List<Produce> Produce = new List<Produce>();

            using (StreamReader sr = new StreamReader(file.Path))
            {
                var line = sr.ReadLine();
                if (line.StartsWith("Name,"))
                {
                    line = sr.ReadLine();
                }

                while (line != null)
                {
                    var props = line.Split('|');

                    string name = props[0];
                    string location = props[1];
                    decimal price = Convert.ToDecimal(props[2]);
                    string uom = props[3];
                    var temp = props[4].Split("-");
                    DateTime sellBy = new DateTime(Int32.Parse(temp[2]), Int32.Parse(temp[0]), Int32.Parse(temp[1]));

                    Produce.Add(new Produce(name, location, price, uom, sellBy));

                    line = sr.ReadLine();
                }
            }
            return Produce;
        }

        /// <summary>
        /// Runs all SQL commands need to maintain Produce table
        /// </summary>
        /// <param name="produce">List of Produce objects</param>
        /// <returnsList all records from the table remaining after the commands run></returns>
        internal List<Produce> RunSQL(List<Produce> produce)
        {
            //Insert items from Produce.txt into DB
            foreach (Produce product in produce)
            {
                produceDAL.InsertProduce(product);
            }

            //Update all location that end with F to Z
            produceDAL.UpdateLocation();

            //Delete all items passed sell by date
            produceDAL.DeleteProduceSellByDatePassed();

            //Increase all prices by $1
            produceDAL.IncrementAllPrices();

            return produceDAL.SelectAllProduce();
        }
    }
}
