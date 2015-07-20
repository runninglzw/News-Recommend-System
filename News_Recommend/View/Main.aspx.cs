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
            string newsurl = ConfigurationManager.ConnectionStrings["newsurl"].ConnectionString;//从Web.config中获得newsurl
            //string res = MyRequest.createurl_news(newsurl, "子洲暴雨");
            //List<News> mynews = new List<News>();
            //mynews = MyRequest.analysis_news(res);
            //ListBox1.DataSource = mynews;
            //ListBox1.DataBind();

            string keysurl = ConfigurationManager.ConnectionStrings["keysurl"].ConnectionString;//从Web.config中获得keysurl
            string res = MyRequest.createurl_keys(keysurl);
            List<string> mynews = new List<string>();
            mynews = MyRequest.analysis_keys(res);
            ListBox1.DataSource = mynews;
            ListBox1.DataBind();
        }
    }
}