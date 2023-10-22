using CharacterDBApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterDBApp.DAL
{
    public class CharacterDAL
    {
        DatabaseConnectionSingleton connectionSingleton { get; set; }
        string sqlConnectString { get; set; } = string.Empty;

        public CharacterDAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        public void InsertType(string type)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"INSERT [dbo].[Type] ([Type_Name]) VALUES ('{type}')";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void InsertLocation(string location)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                if (location.Contains("'"))
                {
                    location = location.Replace("'", "''");
                }
                string inlineSQL = @$"INSERT [dbo].[Location] ([Location_Name]) VALUES ('{location}')";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void InsertCharacter(Character character)
        {
            string typeID = GetTypeIDFromTypeName(character.Type);
            string locationID = GetLocationIDFromLocationName(character.Location);
            string isMagic = "NULL";
            string isSword = "NULL";
            string isOriginal = "NULL";

            if (character.IsMagical != null)
            {
                isMagic = $@"'{character.IsMagical}'";
            }

            if (character.IsSwordFighter != null)
            {
                isSword = $@"'{character.IsSwordFighter}'";
            }

            if (character.IsOriginal != null)
            {
                isOriginal = $@"'{character.IsOriginal}'";
            }

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQLInsertCharacter = $@"INSERT INTO [dbo].[Character] ([Name], [Type_Id], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) 
            VALUES('{character.Name}', {typeID}, {isOriginal}, {isSword}, {isMagic}, {locationID})";
                using (var command = new SqlCommand(inlineSQLInsertCharacter, conn))
                {
                    var query = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public string GetTypeIDFromTypeName(string typeName)
        {
            string typeID = string.Empty;

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQLGetTypeID = $@"SELECT TOP 1 ID FROM [dbo].[Type] WHERE [dbo].[Type].[Type_Name] = '{typeName}'";
                using (var command = new SqlCommand(inlineSQLGetTypeID, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        typeID = reader.GetValue(0).ToString();
                    }

                    reader.Close();
                }

                conn.Close();
            }

            if (typeID == string.Empty)
            {
                typeID = "NULL";
            }

            return typeID;
        }

        public string GetLocationIDFromLocationName(string locationName)
        {
            string locationID = string.Empty;

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                if (locationName.Contains("'"))
                {
                    locationName = locationName.Replace("'", "''");
                }
                string inlineSQLGetLocationID = $@"SELECT TOP 1 ID FROM [dbo].[Location] WHERE [dbo].[Location].[Location_Name] = '{locationName}'";

                using (var command = new SqlCommand(inlineSQLGetLocationID, conn))
                {

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        locationID = reader.GetValue(0).ToString();
                    }

                    reader.Close();
                }

                conn.Close();
            }

            if (locationID == string.Empty)
            {
                locationID = "NULL";
            }

            return locationID;
        }

        public List<string> FindNotHumansThatAreSwordUsers()
        {
            List<string> results = new List<string>();

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"SELECT c.Name FROM Character as c LEFT OUTER JOIN Type as t ON c.Type_ID = t.ID WHERE c.Sword_Fighter = 'TRUE' AND t.Type_Name != 'Human'";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        results.Add(reader.GetValue(0).ToString());
                    }
                }

                conn.Close();
            }

            return results;
        }

        public List<string> FindCharactersWithNoLocation()
        {
            List<string> results = new List<string>();

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"SELECT c.Name FROM Character as c LEFT OUTER JOIN Location as l ON c.Map_ID = l.ID WHERE c.Map_ID is NULL";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        results.Add(reader.GetValue(0).ToString());
                    }
                }

                conn.Close();
            }

            return results;
        }

        public List<Character> FindAllFullCharacters()
        {
            List<Character> results = new List<Character>();

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"SELECT c.Name, t.Type_Name as Type, l.Location_Name as Location ,c.Original_Character, c.Sword_Fighter, c.Magic_User FROM Character as c INNER JOIN Type as t ON c.Type_ID = t.ID INNER JOIN Location as l ON c.Map_ID = l.ID ORDER BY c.ID ASC";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Character character = new Character();
                        character.Name = reader.GetString(0);
                        character.Type = reader.GetString(1);
                        character.Location = reader.GetString(2);
                        character.IsOriginal = reader.GetBoolean(3);
                        character.IsSwordFighter = reader.GetBoolean(4);
                        character.IsMagical = reader.GetBoolean(5);
                        results.Add(character);
                    }
                }

                conn.Close();
            }

            return results;
        }
    }
}
