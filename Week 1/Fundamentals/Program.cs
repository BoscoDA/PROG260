using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameInfo gameInfo = new GameInfo();
            Dictionary<int, Info> Games = new Dictionary<int, Info>();

            foreach (Info info in gameInfo.MetaData)
            {
                Games.Add(info.Id, info);
            }

            //Display number of games
            Console.WriteLine($"Total games: {Games.Count}\n");

            //Display most frequent genre


            //Display which map names have the most number of characters excluding spaces and which game they belong to


            //Display all info as a dictionary

            //Display map names with letter z in them

            Console.ReadKey();
        }
    }
}
