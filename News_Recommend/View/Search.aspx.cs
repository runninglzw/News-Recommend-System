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
    public partial class Search : System.Web.UI.Page
    {
        public List<News> KeywordNews;
        public int star;//获取显示的页数
        public static string keyword;
        protected void Page_Load(object sender, EventArgs e)
        {
            star = Convert.ToInt32(Request["star"]==null?"1":Request["star"]);
            if (star < 1)
            {
                star = 1;
            }
            //页面为第一页则禁用上一页的功能
            if (star == 1)
            {
                beforpage.Visible = false;
            }
            keyword = Request["type"];
            KeywordNews = Getall(keyword, star);
            //判断下一页是否可用
            List<News> nextnews = new List<News>();
            nextnews = Getall(keyword, star+1);
            if (nextnews.Count < 1)
            {
                nextpage.Visible = false;//设置下一页不可用
            }
        }
        /// <summary>
        /// 按关键字和页数获得新闻
        /// </summary>
        /// <param name="keyword"></param>关键字
        /// <param name="star"></param>页数
        /// <returns></returns>
        public List<News> Getall(string keyword,int star)
        {
            string res = MyRequest.createurl_news(null, null, keyword, star.ToString());
            List<News> KeywordNews = new List<News>();
            KeywordNews = MyRequest.analysis_news(res);
            return KeywordNews;
        }
    }
}