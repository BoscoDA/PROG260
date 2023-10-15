using System.Data.SqlClient;

namespace in_class_db_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder mySqlConBldr = new SqlConnectionStringBuilder();
            mySqlConBldr["server"] = @"(localdb)\MSSQLLocalDB";
            mySqlConBldr["Trusted_Connection"] = true;
            mySqlConBldr["Integrated Security"] = "SSPI";
            mySqlConBldr["Initial Catalog"] = "PROG260FA23";
            string sqlConStr = mySqlConBldr.ToString();

            Console.WriteLine($"Original Data{Environment.NewLine}============={Environment.NewLine}");

            using (SqlConnection conn = new SqlConnection(sqlConStr))
            {
                conn.Open();
                string inlineSQL = @"SELECT * from Game";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var value = $"{reader.GetValue(0)},{reader.GetValue(1)},{reader.GetValue(2)},{reader.GetValue(3)},{reader.GetValue(4)},{reader.GetValue(5)}";

                        Console.WriteLine(value);
                    }
                    reader.Close();
                }
                conn.Close();
            }

            using (SqlConnection conn = new SqlConnection(sqlConStr))
            {
                conn.Open();
                string inlineSQL = @"INSERT [dbo].[Game] ([Name], [Publisher], [Release_Date], [Sold], [Rating]) Values('Another Game', 'My Studio', '10-12-2023', 0, 0)";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}