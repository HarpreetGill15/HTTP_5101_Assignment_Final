using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_Assignment_Final
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new WebsiteDB();
            string query = "select page_id, page_title from pages where publish_state = 'Published'";
            List<Dictionary<string, string>> page = db.List_Query(query);
            
                        
                    
            nav.InnerHtml = "<ul class=\"nav navbar-nav\"><li><a runat=\"server\" href=\"~/ \">Home</a></li>" +
                        "<li><a runat = \"server\" href = \"~/About\"> Authors </a></li>";

            if (page.Count > 0)
            {
                foreach (Dictionary<String, String> pagedata in page)
                {
                    string pagetitle = pagedata["page_title"];
                    string pageid = pagedata["page_id"];

                    nav.InnerHtml += "<li><a runat = \"server\" href = \"SinglePage.aspx?pageid=" + pageid + "\">" + pagetitle+"</a></li>";
                }
            }
        }
    }
}