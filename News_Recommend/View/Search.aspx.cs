using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            keyword = Request["type"];
            string first = Request["first"];
            star = Convert.ToInt32(Request["star"]==null?"1":Request["star"]);
            if (star < 1)
            {
                star = 1;
            }
            //如果本页没有数据则显示上一页
            if (Getall(keyword, star).Count <1)
            {
                --star;
            }
            
            KeywordNews = Getall(keyword, star);
            //如果关键字不为空并且第一次进入该页面而不是响应回发，将关键字记录到数据库中
            if (!string.IsNullOrEmpty(keyword)&& !string.IsNullOrEmpty(first))
            {          
                RecordKeyword(Session["userid"].ToString(), keyword);
                Session["first"] = null;
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
        /// <summary>
        /// 将关键字记录到数据库(userkeyword表)中
        /// </summary>
        /// <param name="id"></param>用户id
        /// <param name="keyword"></param>用户搜索的关键字
        public void RecordKeyword(string id,string keyword)
        {
            string sql = "insert into userkeyword values(@userid,@keyword)";
            SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@userid",id),
                new SqlParameter("@keyword",keyword)
                };
            sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param);
        }
    }
}