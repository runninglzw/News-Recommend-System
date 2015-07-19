using System;
using System.Collections.Generic;
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
            string res = MyRequest.createurl("http://api.1-blog.com/biz/bizserver/news/list.do", 10);
            List<News> mynews = new List<News>();
            mynews = MyRequest.analysis(res);
            ListBox1.DataSource = mynews;
            ListBox1.DataBind();
        }
    }
}