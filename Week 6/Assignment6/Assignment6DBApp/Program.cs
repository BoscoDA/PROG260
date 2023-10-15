using System.Data.SqlClient;
using Assignment6DBApp.DAL;

namespace Assignment6DBApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read Produce file and create produce object list

            //DATABASE STUFF

            //Read DATABASE to txt file
            string dir = @".\Files\";
            Parser parser = new Parser();

            parser.ParseFiles(dir);

            Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey();
        }
    }
}