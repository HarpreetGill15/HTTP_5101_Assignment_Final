using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Globalization;

namespace HTTP_5101_Assignment_Final
{
    public class WebsiteDB
    {
        // Database connection data
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "websites"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        // connection string to connect to database
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        public List<Dictionary<String,String>> List_Query(string Query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            // check if connected to database
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + Query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(Query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }//end row
                resultset.Close();

            }//end try
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());
            }//end catch
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }
        public Webpage FindWebPage(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a "blank" student so that our method can return something if we're not successful catching student data
            Webpage result_page = new Webpage();

            //we will try to grab student data from the database, if we fail, a message will appear in Debug>Windows>Output dialogue
            try
            {
                //Build a custom query with the id information provided
                string query = "select * from PAGES where page_id = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of students (although we're only trying to get 1)
                List<Webpage> page = new List<Webpage>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single student
                    Webpage currentpage = new Webpage();

                    //Look at each column in the result set row, add both the column name and the column value to our Student dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        //can't just generically put data into a dictionary anymore
                        //must go through each column one by one to insert data into the right property
                        switch (key)
                        {
                            case "page_title":
                                currentpage.set_W_title(value);
                                break;
                            case "page_body":
                                currentpage.set_W_body(value);
                                break;
                            case "publish_author":
                                currentpage.set_W_author(value);
                                break;
                            case "publish_state":
                                currentpage.set_W_publish_state(value);
                                break;
                            case "publish_date":
                                //how to convert a string to a date?
                                //http://net-informations.com/q/faq/stringdate.html
                                //https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
                                currentpage.set_W_publish_date(DateTime.ParseExact(value, "ddd dd MMM yyyy", new CultureInfo("en-US")));
                                break;
                        }

                    }
                    //Add the student to the list of students
                    page.Add(currentpage);
                }

                result_page = page[0]; //get the first student

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in the find Webpage method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }
        public void AddWebpage(Webpage webpage)
        {
            string query = "insert into pages(page_title,page_body,publish_author,publish_state,publish_date) values ('{0}','{1}','{2}','{3}','{4}')";
            query = String.Format(query, webpage.get_W_title(), webpage.get_W_body(), webpage.get_W_author(), webpage.get_W_publish_state(), webpage.get_W_publish_date().ToString("MM-dd-yyyy hh:mm"));

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddWebPage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        public void UpdateWebpage(int pageid,Webpage webpage)
        {
            string query = "update pages set page_title='{0}', page_body='{1}', publish_author='{2}',publish_state='{3}',publish_date='{4}'";
            query = String.Format(query, webpage.get_W_title(), webpage.get_W_body(), webpage.get_W_author(), webpage.get_W_publish_state(), webpage.get_W_publish_date().ToString("MM-dd-yyyy hh:mm"));

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Try to update a student with the information provided to us.
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                //If that doesn't seem to work, check Debug>Windows>Output for the below message
                Debug.WriteLine("Something went wrong in the UpdateWebpage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        public void DeleteWebpage(int pageid)
        {
            string deletePage = "delete from pages where page_id = {0}";
            deletePage = String.Format(deletePage, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //This command removes all the target student's classes from the studentsxclasses table
            MySqlCommand cmd_deletepage = new MySqlCommand(deletePage, Connect);

            try
            {
                //try to execute both commands!
                Connect.Open();
                //remember to remove the relational element first
                cmd_deletepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_deletepage);
            }
            catch (Exception ex)
            {
                //if this isn't working as intended, you can check debug>windows>output for the error message.
                Debug.WriteLine("Something went wrong in the delete page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
    }
}