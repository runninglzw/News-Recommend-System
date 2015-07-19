using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using News_Recommend.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace News_Recommend.Control
{
    public class MyRequest
    {
        /// <summary>
        /// 对新闻接口进行请求返回json数据（字符串）
        /// </summary>
        /// <param name="url"></param>接口的url
        /// size 为获取新闻的个数
        /// <returns></returns>
        public static string createurl(string url,int size)
        {
            string myurl = url + "?size=" + size;
            WebRequest request = WebRequest.Create(myurl);
            IAsyncResult result = request.BeginGetResponse(null, request);
            WebResponse response = request.EndGetResponse(result);
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string res = reader.ReadToEnd();
            return res;
        }
        /// <summary>
        /// 将返回的json字符串进行解析，将解析得到的新闻数据填充到一个新闻的集合中
        /// </summary>
        /// <param name="data"></param>   json字符串
        /// <returns></returns>
        public static List<News> analysis(string data)
        {
            List<News> newslist=new List<News>();
            
            JObject jo = (JObject)JsonConvert.DeserializeObject(data);//将字符串转化为JObject
            JArray ja = (JArray)jo["detail"];//索引到detail
            foreach (JToken jt in ja)
            {
                string id = jt["group_id"].ToString();//获得id
                string title = jt["title"].ToString();//获得标题
                string source = jt["source"].ToString();//获得新闻来源
                string url = jt["article_url"].ToString();//获得新闻url
                Int64 time=Convert.ToInt64(jt["behot_time"].ToString());
                DateTime include_time = ConvertLongDateTime(time);//获得新闻收录时间,将获得的毫秒数转化为datetime
                int praise_count = Convert.ToInt32(jt["digg_count"].ToString());//获得新闻被赞次数
                int step_count = Convert.ToInt32(jt["bury_count"].ToString()); //新闻踩的次数
                int collect_count = Convert.ToInt32(jt["repin_count"].ToString());//新闻收藏的次数
                News news = new News(id,title,source,url,include_time,praise_count,step_count,collect_count);
                newslist.Add(news);
            }
            return newslist;
        }
        /// <summary>
        /// 将Long类型转换为DateTime类型
        /// </summary>
        /// <param name="d">long</param>
        /// <returns></returns>
        public static DateTime ConvertLongDateTime(Int64 d)
        {
           
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            //Int64 lTime = Int64.Parse(d);
            TimeSpan toNow = new TimeSpan(d);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }
    }
}