using System;
using System.Data.SqlClient;
using NewGame4.Utilities;

namespace NewGame4
{
    public class BdConnection
    {
        public SqlConnection Connection;
        public void Connect()
        {
            var data = JsonLoader.Load(@"Resources\ServerConfig.json");
            var bdConfig = data.GetNode("BD");
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = bdConfig.GetString("host"); 
            builder.UserID = bdConfig.GetString("username");            
            builder.Password =bdConfig.GetString("password");     
            builder.InitialCatalog = bdConfig.GetString("database");
            
            Connection = new SqlConnection(builder.ConnectionString);
            Connection.Open();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Connection successful\n");
        }

        public void CloseConnect()
        {
            Connection.Close();
        }
    }
}