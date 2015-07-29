using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using News_Recommend.Control;

namespace News_Recommend.View
{
    public partial class zhuce : System.Web.UI.Page
    {
        public List<string> types;
        protected void Page_Load(object sender, EventArgs e)
        {
            string res = MyRequest.createurl_keys();
            types = MyRequest.analysis_keys(res);
            if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
            {
                string userid=Request.Form["id"];
                string userpass1=Request.Form["pass1"];
                string userpass2=Request.Form["pass2"];
                string str = Request.Form.Get("like");//"id,value"的形式
                string[] typechar=str.Split(',');
                string type = typechar[1];
                //判断id是否存在
                if (!IsExist(userid))
                {
                    //判断两次密码输入是否一致
                    if (userpass1 == userpass2)
                    {
                        //判断是否注册成功
                        if (IsSuccess(userid, userpass1, type))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('注册成功！是否前往登陆？')</script>");
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('注册失败！')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('两次密码输入不一致，请重新输入')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('该账号已经被注册！')</script>");
                }
            }
        }
        /// <summary>
        /// 判断id是否已经注册过
        /// </summary>
        /// <param name="id"></param>注册时的id，邮箱
        /// <returns></returns>
        public bool IsExist(string id)
        {
            bool result = false;
            string sql = "select count(*) from users where userid=@userid";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@userid",id)};
            if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                result = true;
            else
                result = false;
            return result;
        }
        /// <summary>
        /// 判断是否注册成功
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsSuccess(string id, string pass, string type)
        {
            bool result = false;
            string sql = "insert into users(userid,userpass,newstype) values(@userid,@userpass,@newstype)";
            SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@userid",SqlDbType.VarChar),
                        new SqlParameter("@userpass",SqlDbType.VarChar),                    
                        new SqlParameter("@newstype",SqlDbType.VarChar)
                    };
            //为sql参数赋值
            param[0].Value = id;
            param[1].Value = pass;
            param[2].Value = type;
            if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                result = true;
            else
                result = false;
            return result;
        }
    }
}