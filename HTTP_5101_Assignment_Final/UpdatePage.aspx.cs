using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_Assignment_Final
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populate the author dropdown when the page loads with authors
            populate_authordropdown();

            //hide the alert when page loads
            alert.Visible = false;

            if (!IsPostBack)
            {
                showpageinfo();   
            }     
        }
        //if the user clicks the unpublish button change the webpage to not published
        protected void unpublish_button_Click(object sender, EventArgs e)
        {
            WebsiteDB dB = new WebsiteDB();
            Boolean flag = true;

            //get the pageid from the request and convert the string to int
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            //if the id that requested is null or is 0 set the flag to false
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            //if the flag is true continue with the logic
            if (flag)
            {
                //send the pageid to unpublish the page
                dB.unPublishWebpage(pageid);

                //show the alert the un publish was success
                alert.Visible = true;
                output.InnerHtml = "Un Published Success!";
            }
            //if flase show an alert for the error
            else
            {
                alert.Visible = true;
                alert.Attributes.Add("class", "alert alert-danger");
                output.InnerHtml = "Error please go back home";
            }
        }
        //publish the page if the user clicks the publish button
        protected void publish_button_Click(object sender, EventArgs e)
        {
            WebsiteDB dB = new WebsiteDB();

            Boolean flag = true;
            //get the pageid from the request and convert the string to int
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            //if the id that requested is null or is 0 set the flag to false
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            //if the flag is true continue with the logic
            if (flag)
            {
                //convert date and time to ex.(Saturday, 15 July 2019 5:00 AM)
                string date = DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt");

                //send the pageid and todays date to the publish webpage method in the websitedb class
                dB.publishWebpage(pageid, date);

                //show an alert for the publish success
                alert.Visible = true;
                output.InnerHtml = "Publish Success!"; 
            }
            //if pageid is not valid show the alert and the error
            else
            {
                alert.Visible = true;
                output.InnerHtml = "Error occured. Please try again";
            }
            
        }
        protected void showpageinfo()
        {
            
            WebsiteDB dB = new WebsiteDB();
            Boolean flag = true;

            //get the pageid from the request and convert the string to int
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            //if the id that requested is null or is 0 set the flag to false
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            //if the flag is true continue with the logic
            if (flag)
            {
                //find the webpage and set its values to the variables in the webpage class
                Webpage webpage = dB.FindWebPage(pageid);

                //get the data from the webpage class of the webpage requested
                //set the text boxes and the dropdown to the variables from the webpage class
                pagename.InnerText = webpage.get_W_title();
                txtpage_title.Text = webpage.get_W_title();
                txtpage_body.InnerText = webpage.get_W_body();
                ddpage_author.SelectedValue = webpage.get_W_author();
                
            }
            //if false show the alert of the error
            else
            {
                alert.Visible = true;
                alert.Attributes.Add("class","alert alert-danger");
                output.InnerHtml = "Error please go back home";
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            WebsiteDB dB = new WebsiteDB();
            Webpage webpage = new Webpage();

            Boolean flag = true;

            //get the pageid from the request and convert the string to int
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            //if the id that requested is null or is 0 set the flag to false
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            //if the flag is true continue with the logic
            if (flag)
            {
                //save the changes to the webpage in the webpage class
                webpage.set_W_title(txtpage_title.Text);
                webpage.set_W_body(txtpage_body.InnerText);
                webpage.set_W_author(ddpage_author.SelectedValue);

                //pass the new changes to the updatewebpages method in the websitedb class
                dB.UpdateWebpage(pageid, webpage);

                //once updated show the newly updated page
                Response.Redirect("SinglePage.aspx?pageid=" + pageid);
            }
            //if false show the alert of the error
            else
            {
                alert.Visible = true;
                alert.Attributes.Add("class", "alert alert-danger");
                output.InnerHtml = "Error cannot add";
            }
            
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

                        //set the listitems of the dropdown with the author name and author id
                        ListItem authors = new ListItem(authorName, authorid);
                        ddpage_author.Items.Add(authors);
                    }
                }
            }
            catch (Exception ex)
            {
                //Show the error alert if the query does not work
                alert.Visible = true;
                output.InnerHtml = "Error. Contact Support " + ex;
            }
        }
        
    }
}