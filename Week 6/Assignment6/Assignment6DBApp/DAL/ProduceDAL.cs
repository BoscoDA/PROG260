using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DBApp.DAL
{
    public class ProduceDAL
    {
        private string sqlConnectString = string.Empty;
        private DatabaseConnectionSingleton connectionSingleton;

        public ProduceDAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        /// <summary>
        /// Inserts provided produce obejct into the database.
        /// </summary>
        /// <param name="produce">Produce object to be added to database</param>
        public void InsertProduce(Produce produce)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"INSERT [dbo].[Produce] ([Name], [Location], [Price], [UoM], [Sell_by_Date]) Values('{produce.Name}', '{produce.Location}', {produce.Price}, '{produce.UoM}', '{produce.SellByDate.ToString("MM-dd-yyyy")}')";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        /// <summary>
        /// Updates all records with locations ending with "F" to end with "Z"
        /// </summary>
        public void UpdateLocation()
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"UPDATE Produce Set Location = REPLACE(Location, 'F', 'Z')";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        /// <summary>
        /// Deletes all records from database that are passed their sell by date
        /// </summary>
        public void DeleteProduceSellByDatePassed()
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();
                // Learned about GETDATE() from https://www.geeksforgeeks.org/how-to-get-the-current-date-without-time-in-t-sql/
                string inlineSQL = @$"DELETE FROM PROG260FA23.dbo.Produce WHERE Sell_by_Date < cast(GETDATE() as date)";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        /// <summary>
        /// Increments all records price by $1
        /// </summary>
        public void IncrementAllPrices()
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"UPDATE [PROG260FA23].[dbo].[Produce] SET Price = Price + 1";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        /// <summary>
        /// Gets all produce records from database
        /// </summary>
        /// <returns>List of Produce objects</returns>
        public List<Produce> SelectAllProduce()
        {
            List<Produce> output = new List<Produce>();

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();
                string inlineSQL = @"SELECT * FROM Produce";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Produce value = new Produce((string)reader.GetValue(1), (string)reader.GetValue(2), (decimal)reader.GetValue(3), (string)reader.GetValue(4), (DateTime)reader.GetValue(5));
                        output.Add(value);
                    }
                    reader.Close();
                }
                conn.Close();
            }

            return output;
        }
    }
}
