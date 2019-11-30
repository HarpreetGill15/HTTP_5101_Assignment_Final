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
            alert.Visible = false;

            if (!IsPostBack)
            {
                
                showpageinfo();   
            }     
        }

        protected void publish_button_Click(object sender, EventArgs e)
        {
            Boolean flag = true;
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            if (flag)
            {
                WebsiteDB dB = new WebsiteDB();

                string date = DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt");

                dB.publishWebpage(pageid, date);

                alert.Visible = true;
                output.InnerHtml = "Publish Success!"; 
            }
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
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            if (flag)
            {
                Webpage webpage = dB.FindWebPage(pageid);

                pagename.InnerText = webpage.get_W_title();
                txtpage_title.Text = webpage.get_W_title();
                txtpage_body.InnerText = webpage.get_W_body();
                ddpage_author.SelectedValue = webpage.get_W_author();
                
            }
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
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            if (flag)
            {
                webpage.set_W_title(txtpage_title.Text);
                webpage.set_W_body(txtpage_body.InnerText);
                webpage.set_W_author(ddpage_author.SelectedValue);

                dB.UpdateWebpage(pageid, webpage);
                Response.Redirect("SinglePage.aspx?pageid=" + pageid);
            }
            else
            {
                alert.Visible = true;
                alert.Attributes.Add("class", "alert alert-danger");
                output.InnerHtml = "Error cannot add";
            }
            
        }
        protected void populate_authordropdown()
        {
            WebsiteDB dB = new WebsiteDB();
            string query = "select * from author";

            List<Dictionary<string, string>> page = dB.List_Query(query);

            if (page.Count > 0)
            {
                foreach (Dictionary<String, String> pagedata in page)
                {
                    string authorName = pagedata["author_name"];
                    string authorid = pagedata["author_id"];
                    ListItem authors = new ListItem(authorName, authorid);
                    ddpage_author.Items.Add(authors);
                }
            }
        }
        protected void unpublish_button_Click(object sender, EventArgs e)
        {
            WebsiteDB dB = new WebsiteDB();
            Boolean flag = true;
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            if (flag)
            {
                dB.unPublishWebpage(pageid);

                alert.Visible = true;
                output.InnerHtml = "Un Published Success!";
            }
            else
            {
                alert.Visible = true;
                alert.Attributes.Add("class", "alert alert-danger");
                output.InnerHtml = "Error please go back home";
            }
        }
    }
}