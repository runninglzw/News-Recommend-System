using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace News_Recommend.Control
{
    /// <summary>
    /// 从数据库的用户记录表中找出用户最喜欢的类型
    /// </summary>
    public class Recommend
    {
        private string firsttype;
        private string secondtype;
        public string getfirsttype()
        {
            return firsttype;
        }
        public string getsecondtype()
        {
            return secondtype;
        }
        /// <summary>
        /// 从logdata中获得出现最多次数的类型
        /// </summary>
        public void getusertype(string userid)
        {
            //一个类型的集合，包含用户点击的次数
            Dictionary<string, int> types = new Dictionary<string, int>();
            //获取类型集合
            string res = MyRequest.createurl_keys();
            List<string> mynews = new List<string>();
            mynews = MyRequest.analysis_keys(res);
            //将类型集合添加到types中，并且将出现次数初始化为0
            foreach (string type in mynews)
            {
                //从数据库中获得类型出现的次数
                string sql = "select count(*) from logdata where userid=@userid and newstype=@type";
                SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@userid",userid),
                new SqlParameter("@type",type)
                };
                int count = (int)sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param);
                if (!types.ContainsKey(type))
                {
                    types.Add(type, count);
                }
            }
            firsttype = types.Keys.First();//指定出现最多次数的类型为第一个
            int max=types.Values.First();//指定第一个类型的次数为max
            foreach (var dic in types)
            {
                if (dic.Value > max)
                {
                    firsttype = dic.Key;
                    max = dic.Value;
                }
            }

        }
        public void GetUserSecondtype()
        {
            //string sql = "select ";
        }

    }
}