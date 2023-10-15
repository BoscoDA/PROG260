using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DBApp
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

        public void UpdateLocation()
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                conn.Open();

                string inlineSQL = @$"UPDATE Produce Set Location = REPLACE(Location, 'F', 'Z') WHERE Produce.Location LIKE '%F'";
                using (var command = new SqlCommand(inlineSQL, conn))
                {
                    var query = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

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
    }
}
