using CharacterDBApp.DAL;
using CharacterDBApp.Models;
using System.Data.SqlClient;

namespace CharacterDBApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Console.WriteLine("Hello, World!");

            //            //Create Character Objects 
            //            List<Character> characters = new List<Character>();

            //            using (StreamReader sr = new StreamReader("./Files/Chars.csv"))
            //            {
            //                var line = sr.ReadLine();
            //                if (line.StartsWith("Character,"))
            //                {
            //                    line = sr.ReadLine();
            //                }

            //                while (line != null)
            //                {
            //                    var props = line.Split(',');

            //                    string name = props[0];
            //                    string type = props[1];
            //                    string location = props[2];

            //                    bool? isOriginal = null;
            //                    if (props[3].Trim() != "")
            //                    {
            //                        isOriginal = Convert.ToBoolean(props[3]);
            //                    }


            //                    bool? ismagic = null;
            //                    if (props[5].Trim() != "")
            //                    {
            //                        ismagic = Convert.ToBoolean(props[5]);
            //                    }

            //                    bool? isSword = null;
            //                    if (props[4].Trim() != "")
            //                    {
            //                        isSword = Convert.ToBoolean(props[4]);
            //                    }

            //                    Character temp = new Character();
            //                    temp.Name = name.Trim();
            //                    temp.Type = type.Trim().ToUpper();
            //                    temp.Location = location.Trim().ToUpper();
            //                    temp.IsOriginal = isOriginal;
            //                    temp.IsSwordFighter = isSword;
            //                    temp.IsMagical = ismagic;
            //                    characters.Add(temp);
            //                    line = sr.ReadLine();
            //                }
            //            }

            //            //Generate list of types
            //            List<string> types = new List<string>();

            //            foreach (var c in characters)
            //            {
            //                if ((!types.Contains(c.Type)) && (c.Type != ""))
            //                {
            //                    types.Add(c.Type);
            //                }
            //            }
            //            //Generate list of locations
            //            List<string> locations = new List<string>();

            //            foreach (var c in characters)
            //            {
            //                if ((!locations.Contains(c.Location)) && (c.Location != ""))
            //                {
            //                    locations.Add(c.Location);
            //                }
            //            }
            var connectionSingleton = DatabaseConnectionSingleton.Instance();
            string sqlConnectString = connectionSingleton.PrepareDBConnection();

            //            //Insert types
            //            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            //            {
            //                conn.Open();
            //                foreach (var type in types)
            //                {
            //                    string inlineSQL = @$"INSERT [dbo].[Type] ([Type_Name]) VALUES ('{type}')";
            //                    using (var command = new SqlCommand(inlineSQL, conn))
            //                    {
            //                        var query = command.ExecuteNonQuery();
            //                    }
            //                }

            //                conn.Close();
            //            }
            //            //Insert locations
            //            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            //            {
            //                conn.Open();
            //                for (int i = 0; i < locations.Count; i++)
            //                {
            //                    if (locations[i].Contains("'"))
            //                    {
            //                        locations[i] = locations[i].Replace("'", "''");
            //                    }
            //                    string inlineSQL = @$"INSERT [dbo].[Location] ([Location_Name]) VALUES ('{locations[i]}')";
            //                    using (var command = new SqlCommand(inlineSQL, conn))
            //                    {
            //                        var query = command.ExecuteNonQuery();
            //                    }
            //                }

            //                conn.Close();
            //            }
            //            //Insert characters
            //            //Get type and location ids from other tables
            //            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            //            {
            //                conn.Open();
            //                foreach (var c in characters)
            //                {
            //                    string typeID = "";
            //                    string locationID = "";

            //                    string inlineSQLGetTypeID = $@"SELECT TOP 1 ID FROM [dbo].[Type] WHERE [dbo].[Type].[Type_Name] = '{c.Type}'";
            //                    if (c.Location.Contains("'"))
            //                    {
            //                        c.Location = c.Location.Replace("'", "''");
            //                    }
            //                    string inlineSQLGetLocationID = $@"SELECT TOP 1 ID FROM [dbo].[Location] WHERE [dbo].[Location].[Location_Name] = '{c.Location}'";

            //                    using (var command = new SqlCommand(inlineSQLGetTypeID, conn))
            //                    {
            //                        var reader = command.ExecuteReader();

            //                        while (reader.Read())
            //                        {
            //                            typeID = reader.GetValue(0).ToString();
            //                        }

            //                        reader.Close();
            //                    }

            //                    if (typeID == "")
            //                    {
            //                        typeID = "NULL";
            //                    }

            //                    using (var command = new SqlCommand(inlineSQLGetLocationID, conn))
            //                    {

            //                        var reader = command.ExecuteReader();

            //                        while (reader.Read())
            //                        {
            //                            locationID = reader.GetValue(0).ToString();
            //                        }

            //                        reader.Close();
            //                    }

            //                    if (locationID == "")
            //                    {
            //                        locationID = "NULL";
            //                    }

            //                    string isMagic = "NULL";
            //                    string isSword = "NULL";
            //                    string isOriginal = "NULL";

            //                    if (c.IsMagical != null)
            //                    {
            //                        isMagic = $@"'{c.IsMagical}'";
            //                    }

            //                    if (c.IsSwordFighter != null)
            //                    {
            //                        isSword = $@"'{c.IsSwordFighter}'";
            //                    }

            //                    if (c.IsOriginal != null)
            //                    {
            //                        isOriginal = $@"'{c.IsOriginal}'";
            //                    }
            //                    string inlineSQLInsertCharacter = $@"INSERT INTO [dbo].[Character] ([Name], [Type_Id], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) 
            //VALUES('{c.Name}', {typeID}, {isOriginal}, {isSword}, {isMagic}, {locationID})";
            //                    using (var command = new SqlCommand(inlineSQLInsertCharacter, conn))
            //                    {
            //                        var query = command.ExecuteNonQuery();
            //                    }
            //                }
            //                conn.Close();
            //            }

            //inner join
            using (StreamWriter sw = new StreamWriter("./Full Report.txt"))
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectString))
                {
                    conn.Open();
                    string inlineSQL = @$"SELECT c.Name, t.Type_Name as Type, l.Location_Name as Location ,c.Original_Character, c.Sword_Fighter, c.Magic_User FROM Character as c INNER JOIN Type as t ON c.Type_ID = t.ID INNER JOIN Location as l ON c.Map_ID = l.ID ORDER BY c.ID ASC";
                    using (var command = new SqlCommand(inlineSQL, conn))
                    {
                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            sw.WriteLine($"{reader.GetValue(0)}, {reader.GetValue(1)}, {reader.GetValue(2)}, {reader.GetValue(3)}, {reader.GetValue(4)}, {reader.GetValue(5)}");
                        }
                    }

                    conn.Close();
                }
            }
            
            //lost
            

            using (StreamWriter sw = new StreamWriter("./Lost.txt"))
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectString))
                {
                    conn.Open();
                    string inlineSQL = @$"SELECT c.Name FROM Character as c LEFT OUTER JOIN Location as l ON c.Map_ID = l.ID WHERE c.Map_ID is NULL";
                    using (var command = new SqlCommand(inlineSQL, conn))
                    {
                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            sw.WriteLine($"{reader.GetValue(0)}");
                        }
                    }

                    conn.Close();
                }
            }

            //not humand and sword user
            

            using (StreamWriter sw = new StreamWriter("./SwordNonHuman.txt"))
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectString))
                {
                    conn.Open();
                    string inlineSQL = @$"SELECT c.Name FROM Character as c LEFT OUTER JOIN Type as t ON c.Type_ID = t.ID WHERE c.Sword_Fighter = 'TRUE' AND t.Type_Name != 'Human'";
                    using (var command = new SqlCommand(inlineSQL, conn))
                    {
                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            sw.WriteLine($"{reader.GetValue(0)}");
                        }
                    }

                    conn.Close();
                }
            }
            Console.ReadKey();
        }
    }
}