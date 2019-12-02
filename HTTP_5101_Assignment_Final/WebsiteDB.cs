using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Globalization;

namespace HTTP_5101_Assignment_Final
{
    // Referenceing SCHOOLDB from crud_essentials 
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

        //List all pages
        public List<Dictionary<String,String>> List_Query(string Query)
        {
            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> resultList = new List<Dictionary<String, String>>();

            // check if connected to database
            try
            {
                sqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(Query, sqlCon);
                MySqlDataReader resultset = cmd.ExecuteReader();

                while (resultset.Read())
                {
                    Dictionary<String, String> row = new Dictionary<String, String>();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    resultList.Add(row);
                }
                resultset.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Check the List_Query()");
                Debug.WriteLine(ex.ToString());
            }
            sqlCon.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return resultList;
        }
        public Webpage FindWebPage(int id)
        {
            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);
            Webpage result_page = new Webpage();

            try
            {
                string query = "select * from PAGES where page_id = " + id;

                sqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                MySqlDataReader resultset = cmd.ExecuteReader();

                List<Webpage> page = new List<Webpage>();

                while (resultset.Read())
                {
                    Webpage currentpage = new Webpage();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
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
                                currentpage.set_W_publish_date(value);
                                break;
                        }

                    }
                    page.Add(currentpage);
                }

                result_page = page[0]; 

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Check the findWebpage()");
                Debug.WriteLine(ex.ToString());
            }

            sqlCon.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }
        public void AddWebpage(Webpage webpage)
        {
            string query = "insert into pages(page_title,page_body,publish_author,publish_state,publish_date) values ('{0}','{1}','{2}','{3}','{4}')";
            query = String.Format(query, webpage.get_W_title(), webpage.get_W_body(), webpage.get_W_author(), webpage.get_W_publish_state(), webpage.get_W_publish_date());

            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, sqlCon);
            try
            {
                sqlCon.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Check the AddWebpage()");
                Debug.WriteLine(ex.ToString());
            }

            sqlCon.Close();
        }
        public void UpdateWebpage(int pageid,Webpage webpage)
        {
            string query = "update pages set page_title='{0}', page_body='{1}', publish_author='{2}' where page_id = "+pageid;
            query = String.Format(query, webpage.get_W_title(), webpage.get_W_body(), webpage.get_W_author());

            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, sqlCon);
            try
            {
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Check the UpdateWebpage()");
                Debug.WriteLine(ex.ToString());
            }

            sqlCon.Close();
        }

        //publish the website by added a publish state to the publish collumn
        public void publishWebpage(int pageid,string date)
        {
            string query = "update pages set publish_state='Published', publish_date = '"+date+"' where page_id = "+pageid;
            query = String.Format(query);

            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, sqlCon);
            try
            {
                //Update with user info
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Check the publishWebpage()");
                Debug.WriteLine(ex.ToString());
            }

            sqlCon.Close();
        }
        //unpublish the website by added a not publish state to the publish collumn
        public void unPublishWebpage(int pageid)
        {
            string query = "update pages set publish_state = 'Not Published', publish_date ='' where page_id = " + pageid;
            query = String.Format(query);

            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, sqlCon);
            try
            {
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Check the unpublishWebpage()");
                Debug.WriteLine(ex.ToString());
            }

            sqlCon.Close();
        }
        //delete the webpage from the database
        public void DeleteWebpage(int pageid)
        {
            string deletePage = "delete from pages where page_id = "+pageid;
            deletePage = String.Format(deletePage, pageid);

            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);
            MySqlCommand cmd_deletepage = new MySqlCommand(deletePage, sqlCon);

            try
            {
                //delete from database
                sqlCon.Open();
                cmd_deletepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_deletepage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Check the deleteWebpage()");
                Debug.WriteLine(ex.ToString());
            }

            sqlCon.Close();
        }
    }
}