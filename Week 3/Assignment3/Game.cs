using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Game
    {
        string asciiArt;
        AssetParser assetParser;
        Player? player;
        int stages;
        List<Room> dungeonRooms;
        Assignment3.LinkedList GameScenes;  

        public Game()
        {
            asciiArt = @"    ███        ▄█    █▄       ▄████████       ▄████████    ▄████████  ▄█    █▄     ▄████████ 
▀█████████▄   ███    ███     ███    ███      ███    ███   ███    ███ ███    ███   ███    ███ 
   ▀███▀▀██   ███    ███     ███    █▀       ███    █▀    ███    ███ ███    ███   ███    █▀  
    ███   ▀  ▄███▄▄▄▄███▄▄  ▄███▄▄▄          ███          ███    ███ ███    ███  ▄███▄▄▄     
    ███     ▀▀███▀▀▀▀███▀  ▀▀███▀▀▀          ███        ▀███████████ ███    ███ ▀▀███▀▀▀     
    ███       ███    ███     ███    █▄       ███    █▄    ███    ███ ███    ███   ███    █▄  
    ███       ███    ███     ███    ███      ███    ███   ███    ███ ███    ███   ███    ███ 
   ▄████▀     ███    █▀      ██████████      ████████▀    ███    █▀   ▀██████▀    ██████████ 
                                                                                             
";
            assetParser = new AssetParser();
            dungeonRooms = new List<Room>();
            GameScenes = new LinkedList();
        }

        public void Start()
        {
            //Display menu title
            Printer.Print($"{asciiArt}", ConsoleColor.Green);
            
            bool setupSuccess = Setup();
            if (setupSuccess)
            {
                GameLoop();
                SaveResults();
                EndGame();
            }
            else
            {
                Printer.Print($"Something went wrong during setup{Environment.NewLine}", ConsoleColor.Red);
                Printer.WaitForInput("Press any key to exit the game...");
            }
        }

        private void GameLoop()
        {
            DisplayHud();

            Printer.Print($"You venture deep into the cave until you come to a intersection where the cave splits into {dungeonRooms.Count} paths. {Environment.NewLine}", ConsoleColor.Green);

            //Select room
            Room dungeonRoom = dungeonRooms[SelectRoom() - 1];

            while (player.GetHealth() > 0 && player.GetCurrentStage() < stages)
            {
                dungeonRoom.Discovered = true;
                //present monster and riddle
                Printer.Print(dungeonRoom.DisplayRoom(), ConsoleColor.Yellow);
                //answer riddle
                Printer.Print($"{Environment.NewLine}Enter the choice that answers the riddle: ");
                string playerInput = Console.ReadLine().Trim();

                //Check answer
                bool success = dungeonRoom.Question.CheckAnswer(playerInput);

                //Update stage and/or health of player
                if (success)
                {
                    player.IncrementStage();
                    dungeonRooms.Remove(dungeonRoom);
                    DisplayHud();
                    dungeonRoom.PlayerWin = true;
                    GameScenes.AddNodeToFront(dungeonRoom);
                    if (player.GetCurrentStage() < stages)
                    {
                        dungeonRoom = dungeonRooms[SelectRoom() - 1];
                    }
                }
                else
                {
                    player.LostLife();
                    DisplayHud();
                    Printer.Print($"Incorrect answer! The {dungeonRoom.Monster.Type} attacks you and you lose a life.{Environment.NewLine}", ConsoleColor.Red);
                }
            }
            GameScenes.AddNodeToEnd(dungeonRoom);
            dungeonRooms.Remove(dungeonRoom);

            foreach(Room room in dungeonRooms)
            {
                GameScenes.AddNodeToEnd(room);
            }
        }

        private int SelectRoom()
        {
            int roomChoice = 0;
            bool validRoom = false;
            while (validRoom != true)
            {
                Printer.Print($"Enter the number of the path you will take ({1} - {dungeonRooms.Count}): ", ConsoleColor.Green);
                var playerRoomInput = Console.ReadLine().Trim();

                validRoom = (Int32.TryParse(playerRoomInput, out roomChoice)) && (roomChoice > 0) && (roomChoice <= dungeonRooms.Count);
                if (validRoom == false)
                {
                    Printer.Print($"{playerRoomInput} is not a valid room! {Environment.NewLine}", ConsoleColor.Red);
                }
            }

            return roomChoice;
        }

        private bool Setup()
        {
            
            GetPlayerName();

            Printer.Print($"{Environment.NewLine}{Environment.NewLine}{player.GetName()}, press any key to venture into the cave...{Environment.NewLine}", ConsoleColor.Blue);
            Console.ReadKey();

            List<Question> riddles = assetParser.LoadRiddles(@"./Riddles.txt");
            List<Monster> monsters = assetParser.LoadMonsters(@"./Stats.txt");

            if(riddles.Count != monsters.Count)
            {
                return false;
            }
            else
            {
                GenerateRooms(riddles, monsters);
            }

            stages = dungeonRooms.Count;

            return true;
        }

        private void EndGame()
        {
            Console.Clear();

            if ((player.GetHealth() > 0) && (player.GetCurrentStage() == 3))
            {
                Printer.Print($"Congradulations! You made it through the cave.", ConsoleColor.Green);
            }
            else
            {
                Printer.Print($"Game Over! The darkness of the cave consumes you.", ConsoleColor.Red);
            }

            Printer.Print($"{Environment.NewLine}{Environment.NewLine}Press any key to exit the game...", ConsoleColor.Blue);
            Console.ReadKey();
        }

        private void DisplayHud()
        {
            Console.Clear();

            Printer.Print("Lives: ", ConsoleColor.Magenta);
            for (int i = 1; i <= player.GetHealth(); i++)
            {
                Printer.Print("\u2665", ConsoleColor.Red);
            }
            Printer.Print($"{Environment.NewLine}Score: {player.GetCurrentStage()}{Environment.NewLine}{Environment.NewLine}", ConsoleColor.Magenta);
        }

        private void GenerateRooms(List<Question> riddles, List<Monster> monsters)
        {
            Random rand = new Random();

            while((riddles.Count > 0) && (monsters.Count > 0)) 
            {
                int riddleSelect = rand.Next(riddles.Count);
                int monsterSelect = rand.Next(monsters.Count);
                Room currentRoom = new Room(monsters[monsterSelect], riddles[riddleSelect]);
                dungeonRooms.Add(currentRoom);

                riddles.Remove(riddles[riddleSelect]);
                monsters.Remove(monsters[monsterSelect]);
            }
        }

        private void SaveResults()
        {
            FileStream fs = File.Create(@"./DungeonRoomsResults.txt");
            fs.Close();
            using(StreamWriter sw = new StreamWriter(@"./DungeonRoomsResults.txt"))
            {
                sw.WriteLine("Monster Info: Type/HP/MP/AP/DEF|Riddle Info: Riddle/Correct Answer/Wrong Answer 1/Wrong Answer 2|PlayerWin|Discovered,");
                var runner = GameScenes.GetHead();
                while(runner != null)
                {
                    string output = Regex.Replace(runner.Data.ToString(), @"[\r\n\t]", "");
                    sw.WriteLine(output);
                    runner = runner.Next;
                }
            }
        }

        private void GetPlayerName()
        {
            bool validName = false;

            while (validName == false)
            {
                //Ask for name
                Printer.Print($"{Environment.NewLine}{Environment.NewLine}Enter your name: ", ConsoleColor.Blue);

                //Player enter name
                string playerInput = Console.ReadLine().Trim();

                if (String.IsNullOrEmpty(playerInput))
                {
                    Printer.Print($"{Environment.NewLine}Invalid Name!", ConsoleColor.Red);
                }
                else
                {
                    player = new Player(playerInput, 4);
                    validName = true;
                }
            }
        }
    }
}
