using CharacterDBApp.DAL;
using CharacterDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterDBApp.Engines
{
    internal abstract class BaseEngine
    {
        private CharacterDAL cDAL;

        public BaseEngine()
        {
            cDAL = new CharacterDAL();
        }
        internal virtual List<Error> ProcessFile(IFile file)
        {
            List<Error> errors = new List<Error>();

            try
            {
                List<Character> characters = GenerateCharacters(file);
                List<string> types = GenerateTypesFromCharacters(characters);
                List<string> locations = GenerateLocationsFromCharacters(characters);

                RunSQL(characters, types, locations);

                GenerateOutputFiles();
            }
            catch (IOException exception)
            {
                errors.Add(new Error(exception.Message, exception.TargetSite.ToString()));
            }
            catch (Exception exception)
            {
                errors.Add(new Error(exception.Message, exception.TargetSite.ToString()));
            }

            return errors;
        }
        private List<string> GenerateLocationsFromCharacters(List<Character> characters)
        {
            List<string> locations = new List<string>();

            foreach (var c in characters)
            {
                if ((!locations.Contains(c.Location)) && (c.Location != ""))
                {
                    locations.Add(c.Location);
                }
            }

            return locations;
        }
        private List<string> GenerateTypesFromCharacters(List<Character> characters)
        {
            List<string> types = new List<string>();

            foreach (var c in characters)
            {
                if ((!types.Contains(c.Type)) && (c.Type != ""))
                {
                    types.Add(c.Type);
                }
            }

            return types;
        }
        private List<Character> GenerateCharacters(IFile file)
        {
            List<Character> characters = new List<Character>();

            using (StreamReader sr = new StreamReader(file.Path))
            {
                var line = sr.ReadLine();
                if (line.StartsWith("Character,"))
                {
                    line = sr.ReadLine();
                }

                while (line != null)
                {
                    var props = line.Split(',');

                    string name = props[0];
                    string type = props[1];
                    string location = props[2];

                    bool? isOriginal = null;
                    if (props[3].Trim() != "")
                    {
                        isOriginal = Convert.ToBoolean(props[3]);
                    }


                    bool? ismagic = null;
                    if (props[5].Trim() != "")
                    {
                        ismagic = Convert.ToBoolean(props[5]);
                    }

                    bool? isSword = null;
                    if (props[4].Trim() != "")
                    {
                        isSword = Convert.ToBoolean(props[4]);
                    }

                    Character temp = new Character();
                    temp.Name = name.Trim();
                    temp.Type = type.Trim().ToUpper();
                    temp.Location = location.Trim().ToUpper();
                    temp.IsOriginal = isOriginal;
                    temp.IsSwordFighter = isSword;
                    temp.IsMagical = ismagic;
                    characters.Add(temp);
                    line = sr.ReadLine();
                }
            }
            return characters;
        }
        private void RunSQL(List<Character> characters, List<string> types, List<string> location)
        {
            foreach (string t in types)
            {
                cDAL.InsertType(t);
            }

            foreach (string l in location)
            {
                cDAL.InsertLocation(l);
            }

            foreach (Character c in characters)
            {
                cDAL.InsertCharacter(c);
            }
        }
        private void GenerateOutputFiles()
        {
            if (Directory.Exists("./Output") == false)
            {
                Directory.CreateDirectory("./Output");
            }

            //inner join
            using (StreamWriter sw = new StreamWriter("./Output/Full Report.txt"))
            {
                sw.WriteLine("Character,Type,Map Location,Original Character,Sword Fighter,Magic User");
                List<Character> output = cDAL.FindAllFullCharacters();

                foreach (Character c in output)
                {
                    sw.WriteLine(c.ToString());
                }
            }

            //lost
            using (StreamWriter sw = new StreamWriter("./Output/Lost.txt"))
            {
                List<string> output = cDAL.FindCharactersWithNoLocation();

                foreach (string c in output)
                {
                    sw.WriteLine(c);
                }
            }

            //not humand and sword user
            using (StreamWriter sw = new StreamWriter("./Output/SwordNonHuman.txt"))
            {
                List<string> output = cDAL.FindNotHumansThatAreSwordUsers();

                foreach (string c in output)
                {
                    sw.WriteLine(c);
                }
            }
        }
    }
}
