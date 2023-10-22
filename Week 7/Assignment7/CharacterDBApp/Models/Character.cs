using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterDBApp.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public bool? IsOriginal { get; set; }
        public bool? IsMagical { get; set; }
        public bool? IsSwordFighter { get; set; }

        public Character()
        {

        }

        public override string ToString()
        {
            return $"{Name},{Type},{Location},{IsOriginal.ToString()},{IsSwordFighter.ToString()},{IsMagical.ToString()}";
        }
    }
}
