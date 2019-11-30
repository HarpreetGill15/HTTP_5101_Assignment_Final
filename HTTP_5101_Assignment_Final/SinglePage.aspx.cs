using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HTTP_5101_Assignment_Final
{
    public partial class SinglePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool flag = true;
            int pageid = Convert.ToInt32(Request.QueryString["pageid"]);

            if (pageid.Equals(null)) flag = false;

            if (flag == true)
            {
                var db = new WebsiteDB();
                string query = "select * from pages join author on publish_author = author_id where page_id = " + pageid;
                List<Dictionary<string,string>> page = db.List_Query(query);

                if(page.Count > 0)
                {
                    foreach(Dictionary<String,String> pagedata in page)
                    {
                        Webpage webpage = new Webpage();
                        string pagetitle = pagedata["page_title"];
                        string pagebody = pagedata["page_body"];
                        string pageauthor = pagedata["author_name"];
                        string publishstate = pagedata["publish_state"];
                        string publishdate = pagedata["publish_date"];

                        title.InnerHtml = pagetitle;
                        webpage.set_W_title(pagetitle);
                        date.InnerHtml = publishdate;
                        body.InnerHtml = pagebody;
                        webpage.set_W_body(pagebody);
                        author.InnerHtml = pageauthor;
                        webpage.set_W_author(pageauthor);
                        state.InnerHtml = publishstate;
                        webpage.set_W_publish_state(publishstate);
                    }
                }
            }
        }
    }
}