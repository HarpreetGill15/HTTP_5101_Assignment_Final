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

            webpage.set_W_title(txtpage_title.Text);
            webpage.set_W_body(txtpage_body.InnerText);
            webpage.set_W_author(ddpage_author.SelectedValue);
            if(chkpublish.Checked == true)
            {
                webpage.set_W_publish_state("Published");
                webpage.set_W_publish_date(DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"));
            }
            else
            {
                webpage.set_W_publish_state("Not Published");
            }
            db.AddWebpage(webpage);

            Response.Redirect("ListWebpages.aspx");
        }

        protected void populate_authordropdown()
        {
            WebsiteDB dB = new WebsiteDB();
            string query = "select * from author";

            try
            {
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
            catch(Exception ex)
            {
                alert.Visible = true;
                output.InnerHtml = "Error. Contact Support " + ex;
            }
            

            
        }
    }
}