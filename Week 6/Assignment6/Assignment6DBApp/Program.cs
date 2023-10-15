using System.Data.SqlClient;

namespace Assignment6DBApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProduceDAL produceDAL = new ProduceDAL();

            List<Produce> Produce = new List<Produce>();

            using (StreamReader sr = new StreamReader("./Produce.txt"))
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

            //Insert items from Produce.txt into DB
            foreach(var produce in Produce)
            {
                produceDAL.InsertProduce(produce);
            }

            //Update all location that end with F to Z
            produceDAL.UpdateLocation();

            //Delete all items passed sell by date
            produceDAL.DeleteProduceSellByDatePassed();

            //Increase all prices by $1
            produceDAL.IncrementAllPrices();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}