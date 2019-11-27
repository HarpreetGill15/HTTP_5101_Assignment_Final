using System;
using System.Collections.Generic;
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
            var db = new WebsiteDB();
            string search_text = webpage_search.Text.ToString();
            string query = "select * from pages";



            List<Dictionary<String, String>> rs = db.List_Query(query + " where page_title like '%" + search_text + "%'");
            list_pages.InnerHtml += "<table class=\"table\"><thead><tr>" +
                    "<th>Page Title</th>" +
                    "<th>Author</th>" +
                    "<th>State</th>" +
                    "<th>Published Date</th>" +
                    "</tr></thead><tbody>";

            //<a href=\"ss.aspx?pageid=" + pageid + "\"></a>
            foreach (Dictionary<String, String> row in rs)
            {
                string pageid = row["page_id"];
                list_pages.InnerHtml += "<tr>";

                string pagetitle = row["page_title"];
                list_pages.InnerHtml += "<td><a href=\"SinglePage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></td>";

                string pageauthor = row["publish_author"];
                list_pages.InnerHtml += "<td>" + pageauthor + "</td>";

                string pagestate = row["publish_state"];
                list_pages.InnerHtml += "<td>" + pagestate + "</td>";

                string publishdate = row["publish_date"];
                list_pages.InnerHtml += "<td>" + publishdate + "</td>";

                list_pages.InnerHtml += "</tr>";
            }
            list_pages.InnerHtml += "</tbody></table>";
            if (Page.IsPostBack)
            {
                

                string query2 = "select * from pages";

                

                List<Dictionary<String, String>> ros = db.List_Query(query2 );
                list_pages.InnerHtml = "";
                list_pages.InnerHtml += "<table class=\"table\"><thead><tr>" +
                        "<th>Page Title</th>" +
                        "<th>Author</th>" +
                        "<th>State</th>" +
                        "<th>Published Date</th>" +
                        "</tr></thead><tbody>";

                //<a href=\"ss.aspx?pageid=" + pageid + "\"></a>
                foreach (Dictionary<String, String> row in rs)
                {
                    string pageid = row["page_id"];
                    list_pages.InnerHtml += "<tr>";

                    string pagetitle = row["page_title"];
                    list_pages.InnerHtml += "<td><a href=\"SinglePage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></td>";

                    string pageauthor = row["publish_author"];
                    list_pages.InnerHtml += "<td>" + pageauthor + "</td>";

                    string pagestate = row["publish_state"];
                    list_pages.InnerHtml += "<td>" + pagestate + "</td>";

                    string publishdate = row["publish_date"];
                    list_pages.InnerHtml += "<td>" + publishdate + "</td>";

                    list_pages.InnerHtml += "</tr>";
                }
                list_pages.InnerHtml += "</tbody></table>";
            }
           
        }
    }
}