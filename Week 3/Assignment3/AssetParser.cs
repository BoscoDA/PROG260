using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class AssetParser
    {
        public AssetParser() { }

        public List<Question> LoadRiddles(string filePath)
        {
            List<Question> riddles = new List<Question>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string currentLine = sr.ReadLine();

                if (currentLine[0] == ',')
                {
                    currentLine = sr.ReadLine();
                }

                while (currentLine != null)
                {
                    var elements = currentLine.Split("/");
                    riddles.Add(new Question(elements[0], elements[1], elements[2], elements[3]));

                    currentLine = sr.ReadLine();
                }
            }

            return riddles;
        }

        public List<Monster> LoadMonsters(string filePath)
        {
            List<Monster> monsters = new List<Monster>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string currentLine = sr.ReadLine();

                if (currentLine[0] == ',')
                {
                    currentLine = sr.ReadLine();
                }

                while (currentLine != null)
                {
                    var stats = currentLine.Split(',');

                    Monster currentMonster = new Monster();
                    currentMonster.Type = stats[0];
                    int hp;
                    bool parseResult = Int32.TryParse(stats[1], out hp);
                    if (parseResult)
                    {
                        currentMonster.HP = hp;
                    }
                    int mp;
                    parseResult = Int32.TryParse(stats[2], out mp);
                    if (parseResult)
                    {
                        currentMonster.MP = mp;
                    }
                    int ap;
                    parseResult = Int32.TryParse(stats[3], out ap);
                    if (parseResult)
                    {
                        currentMonster.AP = ap;
                    }
                    int def;
                    parseResult = Int32.TryParse(stats[4], out def);
                    if (parseResult)
                    {
                        currentMonster.DEF = def;
                    }

                    monsters.Add(currentMonster);
                    currentLine = sr.ReadLine();
                }
            }

            return monsters;
        }
    }
}
