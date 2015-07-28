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
    public partial class changeps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否点击了submit，确定按钮
            if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
            {
                string beforpass = Request.Form["pass"];
                string pass1 = Request.Form["pass1"];
                string pass2 = Request.Form["pass2"];
                //判断密码是否正确
                if (IsRight(beforpass))
                {
                    if (pass1 == pass2)
                    {
                        if (IsSuccess(Session["userid"].ToString(), pass1))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('密码修改成功')</script>");
                            Response.Redirect("Main.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('密码修改失败！')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('两次密码输入不一致')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('原密码错误')</script>");
                }
            }
        }
        /// <summary>
        /// 判断密码是否正确
        /// </summary>
        /// <param name="pass"></param>原密码
        /// <returns></returns>
        public bool IsRight(string pass)
        {
            bool result = false;
            string sql = "select count(*) from users where userid=@userid and userpass=@userpass";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@userid",Session["userid"]),
                new SqlParameter("@userpass",pass)
            };
            if ((int)sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param) <= 0)
                result = false;
            else
                result = true;
            return result;
        }
        /// <summary>
        /// 判断密码修改是否成功
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool IsSuccess(string id, string pass)
        {
            bool result = false;
            string sql = "update users set userpass=@userpass where userid=@userid";
            SqlParameter[] param2 = new SqlParameter[]
                {
                    new SqlParameter("@userpass",pass),
                    new SqlParameter("@userid",id)
                };
            if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param2) > 0)
                result = true;
            else
                result = false;
            return result;
        }
    }
}