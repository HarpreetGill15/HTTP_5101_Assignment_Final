using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_Assignment_Final
{
    public partial class ListWebPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebsiteDB db = new WebsiteDB();

            list_pages.InnerHtml = "";
            //set the user input of the search to a variable
            string search_text = webpage_search.Text.ToString();
            
            //create a query with the user input in the query
            string query = "select * from pages join author on publish_author = author_id ";

            //where page_title like '%" + search_text + "%' join author on publish_author = author_id


            if (search_text != "")
            {
                query += "where page_title like '%" + search_text + "%'";
            }
                try
                {
                    List<Dictionary<String, String>> rs = db.List_Query(query);
                    list_pages.InnerHtml += "<table class=\"table\"><thead><tr>" +
                        "<th>Page Title</th>" +
                        "<th>Author</th>" +
                        "<th>State</th>" +
                        "<th>Update/Delete</th>" +
                        "</tr></thead><tbody>";

                    foreach (Dictionary<String, String> row in rs)
                    {
                        string pageid = row["page_id"];
                        list_pages.InnerHtml += "<tr>";

                        string pagetitle = row["page_title"];
                        list_pages.InnerHtml += "<td><a href=\"SinglePage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></td>";

                        string pageauthor = row["author_name"];
                        list_pages.InnerHtml += "<td>" + pageauthor + "</td>";

                        string pagestate = row["publish_state"];
                        list_pages.InnerHtml += "<td>" + pagestate + "</td>";

                        //was supposed to be icons but due to bootstrap 4 dropping glyphicon in v4.4 had to stick to badges
                        list_pages.InnerHtml += "<td><a href=\"UpdatePage.aspx?pageid=" + pageid + "\">" +
                            "<span class=\"badge badge-pill badge-info\">Edit</span></a>" +
                            "<a href=\"DeletePage.aspx?pageid=" + pageid + "\"><span class=\"badge badge-pill badge-danger\">Delete</span></a></td>";

                        list_pages.InnerHtml += "</tr>";
                    }
                    list_pages.InnerHtml += "</tbody></table>";
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            
           
    /*if (Page.IsPostBack)
                {
                    string query2 = "select * from pages";

                    List<Dictionary<String, String>> ros = db.List_Query(query2);
                    list_pages.InnerHtml = "";
                    list_pages.InnerHtml += "<table class=\"table\"><thead><tr>" +
                            "<th>Page Title</th>" +
                            "<th>Author</th>" +
                            "<th>State</th>" +
                            "<th></th>" +
                            "</tr></thead><tbody>";

                    //<a href=\"ss.aspx?pageid=" + pageid + "\"></a>
                    foreach (Dictionary<String, String> row in rs)
                    {
                        string pageid = row["page_id"];
                        list_pages.InnerHtml += "<tr>";

                        string pagetitle = row["page_title"];
                        list_pages.InnerHtml += "<td><a href=\"SinglePage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></td>";

                        string pageauthor = row["author_name"];
                        list_pages.InnerHtml += "<td>" + pageauthor + "</td>";

                        string pagestate = row["publish_state"];
                        list_pages.InnerHtml += "<td>" + pagestate + "</td>";

                        list_pages.InnerHtml += "<td><a href=\"UpdatePage.aspx?pageid=" + pageid + "\">" +
                        "<span class=\"glyphicon glyphicon-upload\"></span><span class=\"glyphicon glyphicon-cog\"></span></a>" +
                        "<a href=\"DeletePage.aspx?pageid="+ pageid +"\"><span class=\"glyphicon glyphicon-trash\"></span></a></td>";

                        list_pages.InnerHtml += "</tr>";
                    }
                    list_pages.InnerHtml += "</tbody></table>";*/
        }

        protected void addPage(object sender, EventArgs e)
        {
            //if the user clicks add page redirect them to the addpage page
            Response.Redirect("AddPage.aspx");
        }
    }
}