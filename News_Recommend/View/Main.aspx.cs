using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using News_Recommend.Control;
using News_Recommend.Model;
using System.Web.Services; 

namespace News_Recommend.View
{
    public partial class Main : System.Web.UI.Page
    {
        public  List<News> mynews;
        public List<News> commendnews;
        public int star;//获取显示的页数
        protected void Page_Load(object sender, EventArgs e)
        {
            star = Convert.ToInt32(Request["star"]==null?"1":Request["star"]);
            if (star < 1)
            {
                star = 1;
            }
            if (star == 1)
            {
                beforpage.Visible = false;
            }
            mynews=Getall(star);
            commendnews = Getlike();
            //判断下一页是否可用
            List<News> nextnews = new List<News>();
            nextnews = Getall(star + 1);
            if (nextnews.Count < 1)
            {
                nextpage.Visible = false;//设置下一页不可用
            }

        }
        public List<News> Getall(int star)
        {
            string res = MyRequest.createurl_news(null, null, null, star.ToString());
            List<News> mynews = new List<News>();
            mynews = MyRequest.analysis_news(res);
            return mynews;
        }
        /// <summary>
        /// 记录用户的行为：将用户id，新闻类型，点击时间记录到数据库的logdata表
        /// </summary>
        /// <param name="type"></param>新闻得类型
        [WebMethod]
        public static void Record_log(string type)
        {
            try
            {
                string sql = "insert into logdata values(@userid,@newstype,@time)";
                string userid = "1";
                string time = DateTime.Now.ToString();
                SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@userid",userid),
                new SqlParameter("@newstype",type),
                new SqlParameter("@time",time)
                };
                sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param);
            }
            catch (Exception ex)
            {

            }

        }
        /// <summary>
        /// 以推荐类获得的用户喜欢的类型为参数，调用Myrequest获得该类型的新闻
        /// </summary>
        /// <returns></returns>
        public List<News> Getlike()
        {
            Recommend re=new Recommend();
            re.getusertype();
            string usertype = re.getfirsttype();//获得用户喜欢的新闻类型
            List<News> mylike = new List<News>();
            string result = MyRequest.createurl_news(null, usertype, null, null);
            mylike = MyRequest.analysis_news(result);
            return mylike;
        }
        protected void Search()
        {

            //Response.Redirect("Search.aspx");
        }

    }

}