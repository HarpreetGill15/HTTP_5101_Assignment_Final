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
            populate_authordropdown();
            if (!IsPostBack)
            {
                showpageinfo();
                
            }

            
        }

        protected void publish_button_Click(object sender, EventArgs e)
        {
            WebsiteDB dB = new WebsiteDB();
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);
            string date = DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt");

            dB.publishWebpage(pageid,date);
            Response.Redirect("UpdatePage.aspx?pageid=" + pageid);
        }
        protected void showpageinfo()
        {
            WebsiteDB dB = new WebsiteDB();
            
            string pageid = Request.QueryString["pageid"];
            Webpage webpage = dB.FindWebPage(Int32.Parse(pageid));

            txtpage_title.Text = webpage.get_W_title();
            txtpage_body.InnerText = webpage.get_W_body();
            ddpage_author.SelectedValue = webpage.get_W_author();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            WebsiteDB dB = new WebsiteDB();
            Webpage webpage = new Webpage();
            string pageid = Request.QueryString["pageid"];
            Debug.Write(txtpage_title.Text+" "+ txtpage_body.InnerText+ " "+ ddpage_author.SelectedValue);
            webpage.set_W_title(txtpage_title.Text);
            webpage.set_W_body(txtpage_body.InnerText);
            webpage.set_W_author(ddpage_author.SelectedValue);
            try
            {
                dB.UpdateWebpage(Int32.Parse(pageid), webpage);
                Response.Redirect("SinglePage.aspx?pageid=" + pageid);
            }
            catch(Exception ex)
            {
                Debug.Write("What happened");
                Debug.Write(ex);
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
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            dB.unPublishWebpage(pageid);

            Response.Redirect("UpdatePage.aspx?pageid="+pageid);
        }
    }
}