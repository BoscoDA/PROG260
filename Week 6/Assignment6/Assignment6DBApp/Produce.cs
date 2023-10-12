using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DBApp
{
    public class Produce
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string UoM { get; set; }
        public DateTime SellByDate { get; set; }

        public Produce(string name, string location, decimal price, string uoM, DateTime sellByDate)
        {
            Name = name;
            Location = location;
            Price = price;
            UoM = uoM;
            SellByDate = sellByDate;
        }
    }
}
