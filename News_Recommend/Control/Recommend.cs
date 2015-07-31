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
        private string firsttype;//只有一个新闻喜欢类型
        private string secondtype;//可能为一到多个新闻喜欢类型
        private string keyword;//用户搜索次数最多的关键字
        public string getfirsttype()
        {
            return firsttype;
        }
        public string getsecondtype()
        {
            return secondtype;
        }
        public string getkeyword()
        {
            return keyword;
        }
        /// <summary>
        /// 从logdata中获得出现最多次数的类型
        /// </summary>
        /// <param name="userid"></param>用户的id
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
            //使用linq语句查询，相当于下面注释的一段代码：找到value最大的一项
            var maxtype = (from type in types orderby (type.Value) select new { type.Key, type.Value }).Last();
            if (maxtype.Value > 0)
                firsttype = maxtype.Key;
            //firsttype = types.Keys.First();//指定出现最多次数的类型为第一个
            //int max=types.Values.First();//指定第一个类型的次数为max
            //foreach (var dic in types)
            //{
            //    if (dic.Value > max)
            //    {
            //        firsttype = dic.Key;
            //        max = dic.Value;
            //    }
            //}

        }
        /// <summary>
        /// 获得用户注册时选择的新闻类型（在users表中存储）
        /// </summary>
        /// <param name="id"></param>用户id
        public void GetUserSecondtype(string id)
        {
            string sql = "select newstype from users where userid=@userid";
            SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@userid",id)
                };
            secondtype = (string)sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param);
        }
        /// <summary>
        /// 获得用户搜索次数最多的关键字
        /// </summary>
        /// <param name="id"></param>用户id
        public void GetKeyword(string id)
        {
            Dictionary<string, int> keywords = new Dictionary<string, int>();
            string sql = "select keyword from userkeyword where userid=@userid";
            DataSet ds = new DataSet();
            SqlParameter[] param =
            {
                new SqlParameter("@userid",id)
            };
            ds = sqlHelper.ExecuteDataSet(sqlHelper.connectionstring, CommandType.Text, sql, param);
            DataTable table=ds.Tables[0];//获取得到的数据，因为ds中只有一个表，所以它的第0个表就是keyword集合
            foreach (DataRow row in table.Rows)
            {
                //如果存在该关键字，则将其value++
                if (keywords.ContainsKey(row[0].ToString().Trim()))
                {
                    keywords[row[0].ToString().Trim()] += 1;
                }
                //否则将关键字加入集合中，其value设置为1
                else
                {
                    keywords.Add(row[0].ToString().Trim(),1);
                }
            }
            var min = (from d in keywords orderby d.Value select d.Key).Last();
            //将key映射为key，value的形式，然后根据value进行升序，最后一个为value最大的key
            var large=keywords.Keys.Select(key => new { key, value = keywords[key] }).OrderBy(key => key.value).Last();
            if(large.value>0)
                keyword = large.key.ToString().Trim();
        }

    }
}