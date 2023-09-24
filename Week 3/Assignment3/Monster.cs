using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Monster
    {
        public string Type { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int AP { get; set; }
        public int DEF { get; set; }

        public Monster() { }

        public override string ToString()
        {
            return $"{Type}/{HP}/{MP}/{AP}/{DEF}";
        }
    }
}
