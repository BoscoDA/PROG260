using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDesignWebAPIClient.Options
{
    [Verb("delete", HelpText = "Deletes the inputted fruit from the database.")]
    public class DeleteOptions
    {
        [Option('f', "fruit_name", Required = true, HelpText = "Name of fruit to be removed from the database.")]
        public string Fruit_Name { get; set; }
    }
}
