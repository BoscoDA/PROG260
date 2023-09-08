using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fundamentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameInfo gameInfo = new GameInfo();
            GameInfoParser gameParser = new GameInfoParser();

            //Total number of games
            Console.WriteLine($"Total games: {gameParser.TotalNumberOfGames(gameInfo)}\n");

            //Display most frequent genre
            Console.WriteLine($"The most frequent genre is: {gameParser.MostFrequentGenre(gameInfo)}\n");

            //Display which map names have the most number of characters excluding spaces and which game they belong to
            Console.WriteLine("The maps with the most characters are:");
            Dictionary<string, string> longestMapNames = gameParser.MapsWithLongestNames(gameInfo);
            foreach (var map in longestMapNames)
            {
                Console.WriteLine($"- {map.Value}: {map.Key}");
            }

            //Display all info as a dictionary
            Console.WriteLine("\nAll game info: ");
            gameParser.DisplayAllInfo(gameInfo);

            //Display map names with letter z in them
            Console.Write("\n\nMaps with the letter z: ");

            List<string> mapsWithZ = gameParser.GetAllContainingSequence(gameInfo, "Z");

            for(int i = 0; i < mapsWithZ.Count; i++ ) 
            {
                Console.Write(mapsWithZ[i]);

                if(i < mapsWithZ.Count - 1) 
                {
                    Console.Write(", ");
                }
            }

            Console.ReadKey();
        }

        
    }
}
