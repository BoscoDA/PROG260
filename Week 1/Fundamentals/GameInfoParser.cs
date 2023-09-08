using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public class GameInfoParser
    {
        public GameInfoParser() 
        {

        }

        /// <summary>
        /// Returns the total number of games present in the GameInfo object.
        /// </summary>
        /// <returns></returns>
        public int TotalNumberOfGames(GameInfo games)
        {
            return games.MetaData.Count;
        }

        /// <summary>
        /// Determines and returns the most frequent game genre in the GameInfo.
        /// </summary>
        /// <returns></returns>
        public string MostFrequentGenre(GameInfo games)
        {
            Dictionary<string, int> genres = new Dictionary<string, int>();
            foreach (var game in games.MetaData)
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

            string MostFreqGenre = genres.OrderByDescending(x => x.Value).ToList().FirstOrDefault().Key;

            return MostFreqGenre;
        }

        /// <summary>
        /// Determines the maps with the longest names excluding whitespace with the game that they belong to.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> MapsWithLongestNames(GameInfo games)
        {
            List<string> mapNames = new List<string>();
            Dictionary<string, string> LongestMapsWithGame = new Dictionary<string, string>();

            foreach (var game in games.MetaData)
            {
                mapNames.AddRange(game.MapNames.ToList());
            }

            //sort by length
            mapNames = mapNames.OrderByDescending(x => Utility.RemoveWhiteSpace(x).Length).ToList();

            //find all maps that match the largest element length and print them with the game name
            foreach (var map in mapNames)
            {
                if (Utility.RemoveWhiteSpace(map).Length == Utility.RemoveWhiteSpace(mapNames.First()).Length)
                {
                    var gameMapIsFrom = games.MetaData.Where(x => x.MapNames.Contains(map)).ToList().First().Name;

                    LongestMapsWithGame.Add(map, gameMapIsFrom);
                }
            }

            return LongestMapsWithGame;
        }

        /// <summary>
        /// Outputs to the screen all game info to the user.
        /// </summary>
        public void DisplayAllInfo(GameInfo games)
        {
            Dictionary<int, Info> Games = new Dictionary<int, Info>();

            foreach (Info info in games.MetaData)
            {
                Games.Add(info.Id, info);
            }

            //simply loop through each element of the dictionary and print
            foreach (var game in Games)
            {
                Console.WriteLine($"ID: {game.Value.Id}");
                Console.WriteLine($"    - Name: {game.Value.Name}");
                Console.WriteLine($"    - Genre: {game.Value.Genre}");
                Console.Write("    - Maps: ");
                foreach (var map in game.Value.MapNames)
                {
                    Console.Write($"{map}, ");

                    if (map != game.Value.MapNames.LastOrDefault())
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.Write("\n");
                    }
                }
            }
        }

        /// <summary>
        /// Method that returns a list of all maps that have the contain the inputted sequence.
        /// </summary>
        /// <param name="gameInfo">GameInfo object to be parsed.</param>
        /// <param name="sequence">String sequence the method is looking for.</param>
        /// <returns></returns>
        public List<string> GetAllContainingSequence(GameInfo gameInfo, string sequence)
        {
            List<string> maps = new List<string>();

            foreach (var game in gameInfo.MetaData)
            {
                foreach (var map in game.MapNames)
                {
                    //turn map name to upper and check for uppercase "Z", so you can check for z once and get both caes of uppercase and lowercase
                    if (map.ToUpper().Contains("Z"))
                    {
                        maps.Add(map);
                    }
                }
            }

            return maps;
        }
    }
}
