using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using News_Recommend.Model;
using News_Recommend.Control;
using System.Data;

namespace News_Recommend.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //判断是否点击了submit，登录
                if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
                {
                    string userid = Request.Form["username"];
                    string pass = Request.Form["pass"];

                    if (IsUser(userid, pass))
                    {
                        Session["userid"] = userid;
                        Response.Redirect("Main.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('账号或密码错误')</script>");

                    }

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), ex.Message, "<script language='javascript'>alert('账号或密码错误')</script>");
            }




        }
        /// <summary>
        /// 判断账号和密码是否匹配
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public bool IsUser(string id, string ps)
        {
            bool res=false;
            string sql = "select count(*) from users where userid=@userid and userpass=@userpass";
            SqlParameter[] param = 
            {
                new SqlParameter("@userid",id),
                new SqlParameter("@userpass",ps),
            };
            int result = Convert.ToInt32(sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param));

            if (result > 0)
            {
                Session["userid"] = id;
                //更新用户的最后登录时间
                sql = "update users set logintime=getdate() where userid=@userid";
                SqlParameter[] param2 = new SqlParameter[]
                {
                    new SqlParameter("@userid",id)
                };
                sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param2);
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }
    }

}