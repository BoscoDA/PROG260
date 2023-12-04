using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8WebAPIInterface
{
    [Verb("add", HelpText = "Adds a fruit to the database.")]
    public class AddOptions
    {
        [Option('f', "fruit_name", Required = true, HelpText ="Name of fruit to be added to database.")]
        public string Fruit_Name { get; set; }
    }
}
