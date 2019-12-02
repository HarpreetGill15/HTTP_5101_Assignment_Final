using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_Assignment_Final
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide the alert on page load
            alert.Visible = false;
            
            if (!IsPostBack)
            {
                populate_authordropdown();
            }
            
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            WebsiteDB db = new WebsiteDB();

            Webpage webpage = new Webpage();

            //set the title, body and author from the textbox to the webpage class
            webpage.set_W_title(txtpage_title.Text);
            webpage.set_W_body(txtpage_body.InnerText);
            webpage.set_W_author(ddpage_author.SelectedValue);
            //if user checks the publish checkbox set the state to published and publish date to the current date and time
            if(chkpublish.Checked == true)
            {
                webpage.set_W_publish_state("Published");
                //convert date and time to ex.(Saturday, 15 July 2019 5:00 AM)
                webpage.set_W_publish_date(DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"));
            }
            //if user doesnt check the checkbox set the state to not published
            else
            {
                webpage.set_W_publish_state("Not Published");
            }
            //use the webpage class to pass the variables to the addwebpage method in the database class
            db.AddWebpage(webpage);

            Response.Redirect("ListWebpages.aspx");
        }

        //Fill the authors dropdown with the authors names from the authors table
        protected void populate_authordropdown()
        {
            WebsiteDB dB = new WebsiteDB();
            string query = "select * from author";

            // try to send the query to the database to select all the authors
            try
            {
                List<Dictionary<string, string>> page = dB.List_Query(query);

                if (page.Count > 0)
                {
                    //for each author add the author and authorid to the list items of the dropdown list
                    foreach (Dictionary<String, String> pagedata in page)
                    {
                        string authorName = pagedata["author_name"];
                        string authorid = pagedata["author_id"];
                        ListItem authors = new ListItem(authorName, authorid);
                        ddpage_author.Items.Add(authors);
                    }
                }
            }
            catch(Exception ex)
            {
                //Show the error alert if the query does not work
                alert.Visible = true;
                output.InnerHtml = "Error. Contact Support " + ex;
            }
        }
    }
}