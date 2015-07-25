using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data;


namespace News_Recommend.Control
{
    public class sqlHelper
    {
        //获取数据库连接字符串，属于静态变量并且只读，项目中的文档可以直接使用，但不能修改
        public static readonly string connectionstring = ConfigurationManager.ConnectionStrings["NewsConnectionString"].ConnectionString;
        /// <summary>
        /// 执行一个不需要返回值的sqlcommand命令
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="cmdtype"></param>
        /// <param name="cmdtext"></param>
        /// <param name="cmdparams"></param>
        /// <returns></returns>
        public static int ExecuteNonQuary(string connectionstring, CommandType cmdtype, string cmdtext, params SqlParameter[] cmdparams)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //通过下面方法将参数逐个添加到SqlCommand的参数集合中
                PrePareCommand(cmd, con, null, cmdtype, cmdtext, cmdparams);
                int result = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                return result;
            }
        }
        /// <summary>
        /// 执行一条返回结果集的SQLCommand命令
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="cmdtype"></param>
        /// <param name="cmdtext"></param>
        /// <param name="cmdparams"></param>
        /// <returns></returns>
        public static SqlDataReader EcecuteReader(string connectionstring, CommandType cmdtype, string cmdtext, params SqlParameter[] cmdparams)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(connectionstring);
            try
            {
                //通过下面方法将参数逐个添加到SqlCommand的参数集合中
                PrePareCommand(cmd, con, null, cmdtype, cmdtext, cmdparams);
                SqlDataReader sdr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return sdr;
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }
        /// <summary>
        /// 执行一个返回一条结果集的命令
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="cmdtype"></param>
        /// <param name="cmdtext"></param>
        /// <param name="cmdparams"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionstring, CommandType cmdtype, string cmdtext, params SqlParameter[] cmdparams)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //通过下面方法将参数逐个添加到SqlCommand的参数集合中
                PrePareCommand(cmd, con, null, cmdtype, cmdtext, cmdparams);
                object result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return result;
            }
        }
        /// <summary>
        /// 执行一条返回DataSet的命令
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="cmdtype"></param>
        /// <param name="cmdtext"></param>
        /// <param name="cmdparams"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionstring, CommandType cmdtype, string cmdtext, params SqlParameter[] cmdparams)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                PrePareCommand(cmd, con, null, cmdtype, cmdtext, cmdparams);
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                return ds;
            }
            
        }
        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="con"></param>
        /// <param name="trans"></param>
        /// <param name="cmdtype"></param>
        /// <param name="cmdtext"></param>
        /// <param name="cmdparams"></param>
        public static void PrePareCommand(SqlCommand cmd, SqlConnection con, SqlTransaction trans
            , CommandType cmdtype, string cmdtext, params SqlParameter[] cmdparams)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                cmd.Connection = con;
                cmd.CommandText = cmdtext;
                if (trans != null)
                    cmd.Transaction = trans;
                cmd.CommandType = cmdtype;
                if (cmdparams != null)
                {
                    foreach (SqlParameter par in cmdparams)
                        cmd.Parameters.Add(par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}