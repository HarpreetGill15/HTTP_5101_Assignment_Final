using System;
using System.Collections.Generic;
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
            WebsiteDB dB = new WebsiteDB();

            string pageid = Request.QueryString["pageid"];

            showpageinfo();

        }

        protected void publish_button_Click(object sender, EventArgs e)
        {
            WebsiteDB dB = new WebsiteDB();
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            dB.publishWebpage(pageid);

        }
        protected void showpageinfo()
        {
            Webpage webpage = new Webpage();
            string pageid = Request.QueryString["pageid"];

            
            txtpage_title.Text = webpage.get_W_title();
            txtpage_body.InnerText = webpage.get_W_body();
        }
    }
}