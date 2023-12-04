using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8WebAPIInterface.Options
{
    [Verb("remove", HelpText = "Removes a fruit from the database.")]
    public class RemoveOptions
    {
        [Option('f', "fruit_name", Required = true, HelpText = "Name of fruit to be removed from the database.")]
        public string Fruit_Name { get; set; }
    }
}
