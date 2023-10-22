using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterDBApp.Models
{
    public class Error
    {
        public string message { get; set; }
        public string source { get; set; }

        public Error(string message, string source)
        {
            this.message = message;
            this.source = source;
        }
    }
}
