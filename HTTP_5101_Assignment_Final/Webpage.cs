using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP_5101_Assignment_Final
{
    public class Webpage
    {
        // variables to store website information while viewing the page
        private string w_title;
        private string w_body;
        private string w_author;
        private string w_publish_state;
        private string w_publish_date;


        //getters
        public string get_W_title()
        {
            return w_title;
        }
        public string get_W_body()
        {
            return w_body;
        }
        public string get_W_author()
        {
            return w_author;
        }
        public string get_W_publish_state()
        {
            return w_publish_state;
        }
        public string get_W_publish_date()
        {
            return w_publish_date;
        }

        //setters
        public void set_W_title(string title)
        {
            w_title = title;
        }
        public void set_W_body(string body)
        {
            w_body = body;
        }
        public void set_W_author(string author)
        {
            w_author = author;

        }
        public void set_W_publish_state(string publish_state)
        {
            w_publish_state = publish_state;
        }
        public void set_W_publish_date(string publish_date)
        {
            w_publish_date = publish_date;
        }

    }
}