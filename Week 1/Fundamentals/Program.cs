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
            Dictionary<int, Info> Games = new Dictionary<int, Info>();

            foreach (Info info in gameInfo.MetaData)
            {
                Games.Add(info.Id, info);
            }

            //Display number of games
            Console.WriteLine($"Total games: {Games.Count}\n");

            //Display most frequent genre
            Dictionary<string, int> genres = new Dictionary<string, int>();
            foreach (var game in gameInfo.MetaData)
            {
                if (genres.ContainsKey(game.Genre))
                {
                    genres[game.Genre]++;
                }
                else
                {
                    genres.Add(game.Genre, 0);
                }
            }

            var MostFreqGenre = genres.OrderByDescending(x => x.Value).ToList();
            Console.WriteLine($"The most frequent genre is: {MostFreqGenre[0].Key}\n");

            //Display which map names have the most number of characters excluding spaces and which game they belong to
            Console.WriteLine("The maps with the most characters are:\n");

            List<string> mapNames = new List<string>();

            foreach(var game in gameInfo.MetaData)
            {
                mapNames.AddRange(game.MapNames.ToList());
            }

            //sort by length
            mapNames = mapNames.OrderByDescending(x => removeWhiteSpace(x).Length).ToList();
            //find all maps that match the largest element length and print them with the game name
            foreach (var map in mapNames)
            {
                if (removeWhiteSpace(map).Length == removeWhiteSpace(mapNames.First()).Length)
                {
                    var gameMapIsFrom = gameInfo.MetaData.Where(x => x.MapNames.Contains(map)).ToList().First().Name;
                    Console.WriteLine($"{gameMapIsFrom}: {map}\n");
                }
            }
            
            foreach(var game in Games)
            {
                for(int i = 0; i < game.Value.MapNames.Length; i++)
                {
                    var noWhiteSpace = new string(game.Value.MapNames[i].Where(x => !Char.IsWhiteSpace(x)).ToArray());
                    game.Value.MapNames[i] = noWhiteSpace;
                }

                game.Value.MapNames.OrderBy(x => x.Length);
            }



            //Display all info as a dictionary

            //simply loop through each element of the dictionary and print
            foreach (var game in Games)
            {
                Console.WriteLine($"ID: {game.Value.Id}");
                Console.WriteLine($"Name: {game.Value.Name}");
                Console.WriteLine($"Genre: {game.Value.Genre}");
                Console.Write("Maps: ");
                foreach (var map in game.Value.MapNames)
                {
                    Console.Write($"{map}, ");
                }
                Console.WriteLine("\n");
            }

            //Display map names with letter z in them
            foreach(var game in Games)
            {
                foreach(var map in game.Value.MapNames)
                {
                    //turn map name to upper and check for uppercase "Z", so you can check for z once and get both caes of uppercase and lowercase
                    if (map.ToUpper().Contains("Z"))
                    {
                        Console.WriteLine(map);
                    }
                }
            }

            Console.ReadKey();
        }

        static string removeWhiteSpace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    }
}
