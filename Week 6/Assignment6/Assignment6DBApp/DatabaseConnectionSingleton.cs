using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DBApp
{
    internal class DatabaseConnectionSingleton
    {
        private static DatabaseConnectionSingleton? instance;

        //use this to reference the DB connection
        private static SqlConnectionStringBuilder? connectionBuilder;

        //make sure there is only one instance of the reference to the database
        public static DatabaseConnectionSingleton Instance()
        {
            if (instance == null)
            {
                instance = new DatabaseConnectionSingleton();
                connectionBuilder = new SqlConnectionStringBuilder();
            }
            return instance;
        }

        private DatabaseConnectionSingleton() { }

        //Create the reference that will be used to connect to the db
        public string PrepareDBConnection()
        {
            connectionBuilder["server"] = @"(localdb)\MSSQLLocalDB";
            connectionBuilder["Trusted_Connection"] = true;
            connectionBuilder["Integrated Security"] = "SSPI";
            connectionBuilder["Initial Catalog"] = "PROG260FA23";

            //The string that is associated and will be used to reference/represent the DB connection
            return connectionBuilder.ToString();
        }
    }
}
