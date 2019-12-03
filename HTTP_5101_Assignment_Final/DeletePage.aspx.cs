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
            //getting the page title to paste to the page
            string pagetitle = Request.QueryString["pagetitle"];

            title.InnerText = pagetitle;
        }

        protected void yes_delete_Click(object sender, EventArgs e)
        {
            Boolean flag = true;

            //get the pageid from the request and convert the string to int
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            //if the id that requested is null or is 0 set the flag to false
            if (pageid.Equals(null) || pageid.Equals(0)) flag = false;

            //if the flag is true continue with the logic
            if (flag)
            {
                WebsiteDB db = new WebsiteDB();

                //use the websitedb class and delete the page from the table
                db.DeleteWebpage(pageid);

                //redirect the user to the listwebpages page
                Response.Redirect("ListWebPages.aspx");
            }
            
        }

        //if user does not want to delete the page they can go back to the listwebpages page
        protected void go_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListWebPages.aspx");
        }
    }
}