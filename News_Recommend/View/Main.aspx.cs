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
        public List<News> mynews;
        public List<News> commendnews;
        public int star;//获取显示的页数
        public int count;//获取推荐新闻的条数
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断Session是否为空，为空则跳转登陆界面
            if (Session["userid"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            star = Convert.ToInt32(Request.QueryString["star"] == null ? "1" : Request.QueryString["star"]);
            count = Convert.ToInt32(Request.QueryString["count"] == null ? "10" : Request.QueryString["count"]);
            if (star < 1)
            {
                star = 1;
            }
            if (Getall(star) == null)
            {
                --star;
            }
            if (count < 10)
            {
                count = 10;
            }
            //if (star == 1)
            //{
            //    //beforpage.Visible = false;
            //}
            mynews = Getall(star);
            commendnews = Getlike(Session["userid"].ToString());
            //如果count大于所有新闻的个数则count赋值为最大
            count = (count > commendnews.Count) ? commendnews.Count : count;



            ////判断下一页是否可用
            //List<News> nextnews = new List<News>();
            //nextnews = Getall(star + 1);
            //if (nextnews.Count < 1)
            //{
            //    //nextpage.Visible = false;//设置下一页不可用
            //}


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
        public List<News> Getlike(string id)
        {
            List<News> mylike = new List<News>();
            Recommend re = new Recommend();
            re.getusertype(id);//获得用户喜欢的新闻类型（从logdata表获得）
            re.GetUserSecondtype(id);//获得用户喜欢的类型（可能为多个，从users表获得）
            re.GetKeyword(id);//获得用户经常搜索的关键字（从userkeyword表中获得）
            string usertype = re.getfirsttype();
            //类型不为空才推荐
            if (!string.IsNullOrEmpty(usertype))
            {
                string res = MyRequest.createurl_news(null, usertype, null, null);
                mylike = MyRequest.analysis_news(res);
            }
            //判断类型是否大于1个，包含逗号就大于1个
            if (re.getsecondtype().Contains(","))
            {
                //将每一个类型的新闻都添加到mylike中
                string[] usertypes = re.getsecondtype().Split(',');
                //将获得的类型都添加到mylike中
                foreach (string type in usertypes)
                {
                    string res = MyRequest.createurl_news(null, type, null, null);
                    mylike.AddRange(MyRequest.analysis_news(res));
                }
            }
            else
            {
                string usertype2 = re.getsecondtype();
                //类型不为空才推荐
                if (!string.IsNullOrEmpty(usertype2))
                {
                    string res = MyRequest.createurl_news(null, usertype2, null, null);
                    mylike.AddRange(MyRequest.analysis_news(res));
                }
            }
            string userkeyword=re.getkeyword();
            //关键字不为空才推荐
            if (userkeyword != null)
            {
                string res = MyRequest.createurl_news(null, null,userkeyword, null);
                mylike.AddRange(MyRequest.analysis_news(res));
            }
            return mylike;
        }
    }

}