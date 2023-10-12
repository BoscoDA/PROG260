using System.Data.SqlClient;

namespace Assignment6DBApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder mySqlConBldr = new SqlConnectionStringBuilder();
            mySqlConBldr["server"] = @"(localdb)\MSSQLLocalDB";
            mySqlConBldr["Trusted_Connection"] = true;
            mySqlConBldr["Integrated Security"] = "SSPI";
            mySqlConBldr["Initial Catalog"] = "PROG260FA23";
            string sqlConStr = mySqlConBldr.ToString();

            List<Produce> Produce = new List<Produce>();

            using(StreamReader sr = new StreamReader("./Produce.txt"))
            {
                var line = sr.ReadLine();
                if(line.StartsWith("Name,"))
                {
                    line = sr.ReadLine();
                }

                while(line != null)
                {
                    var props = line.Split('|');

                    string name = props[0];
                    string location = props[1];
                    decimal price = Convert.ToDecimal(props[2]);
                    string uom = props[3];
                    var temp = props[4].Split("-");
                    DateTime sellBy = new DateTime(Int32.Parse(temp[2]), Int32.Parse( temp[0]), Int32.Parse(temp[1]) );

                    Produce.Add(new Produce(name, location, price, uom, sellBy));

                    line = sr.ReadLine();
                }
            }

            //Insert items from Produce.txt into DB
            using (SqlConnection conn = new SqlConnection(sqlConStr))
            {
                conn.Open();


                foreach (var produce in Produce)
                {
                    string inlineSQL = @$"INSERT [dbo].[Produce] ([Name], [Location], [Price], [UoM], [Sell_by_Date]) Values('{produce.Name}', '{produce.Location}', {produce.Price}, '{produce.UoM}', '{produce.SellByDate.ToString("MM-dd-yyyy")}')";
                    using (var command = new SqlCommand(inlineSQL, conn))
                    {
                        var query = command.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}