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

namespace News_Recommend.View
{
    public partial class Main : System.Web.UI.Page
    {
        private List<News> mynews;
        protected void Page_Load(object sender, EventArgs e)
        {
            mynews = Getall();
            Record_log("游戏");
            //string res = MyRequest.createurl_news(null, null, "北京", null);

            //List<News> mynews = new List<News>();
            //mynews = MyRequest.analysis_news(res);
            //ListBox1.DataSource = mynews;
            //ListBox1.DataBind();

            ////string res = MyRequest.createurl_keys();
            ////List<string> mynews = new List<string>();
            ////mynews = MyRequest.analysis_keys(res);
            ////ListBox1.DataSource = mynews;
            ////ListBox1.DataBind();
        }
        public List<News> Getall()
        {
            string res = MyRequest.createurl_news(null, null, null, null);
            List<News> mynews = new List<News>();
            mynews = MyRequest.analysis_news(res);
            return mynews;
        }
        /// <summary>
        /// 记录用户的行为：将用户id，新闻类型，点击时间记录到数据库的logdata表
        /// </summary>
        /// <param name="type"></param>新闻得类型
        public void Record_log(string type)
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
    }

}