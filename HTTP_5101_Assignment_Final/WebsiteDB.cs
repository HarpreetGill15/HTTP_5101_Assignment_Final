using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace HTTP_5101_Assignment_Final
{
    public class WebsiteDB
    {
        // Database connection data
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "websites"; } }
        private static string Server { get { return ""; } }
        private static string Port { get { return "3306"; } }

        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + ": database = " + Database
                    + "; port = " + Port
                    + ": password = " + Password;
            }
        }

        public List<Dictionary<String,String>> List_Query(string Query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);


            List<Dictionary<String,>>
        }
    }
}