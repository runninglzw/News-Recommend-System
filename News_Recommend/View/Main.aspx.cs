using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using News_Recommend.Control;
using News_Recommend.Model;

namespace News_Recommend.View
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string res = MyRequest.createurl_news(null, null, "北京", null);

            List<News> mynews = new List<News>();
            mynews = MyRequest.analysis_news(res);
            ListBox1.DataSource = mynews;
            ListBox1.DataBind();

            //string res = MyRequest.createurl_keys();
            //List<string> mynews = new List<string>();
            //mynews = MyRequest.analysis_keys(res);
            //ListBox1.DataSource = mynews;
            //ListBox1.DataBind();
        }

    }
}