using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_Assignment_Final
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void yes_delete_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            if (pageid.Equals(null)) flag = false;

            if (flag == true)
            {
                
                Debug.WriteLine(pageid);
                WebsiteDB db = new WebsiteDB();

                db.DeleteWebpage(pageid);
                Response.Redirect("ListWebPages.aspx");
            }
            else
            {

            }
        }

        protected void go_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListWebPages.aspx");
        }
    }
}