using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
        /// 对新闻检索接口进行请求返回json数据（字符串）,主要根据新闻关键字进行查询
        /// </summary>
        /// <param name="url"></param>新闻检索接口的url
        /// q 为新闻的关键字
        /// <returns></returns>
        public static string createurl_news(string url,string q)
        {
            string key = ConfigurationManager.ConnectionStrings["mykey"].ConnectionString;//从Web.config中获得key
            string myurl = url + "?key=" + key+ "&q="+q;
            WebRequest request = WebRequest.Create(myurl);
            IAsyncResult result = request.BeginGetResponse(null, request);
            WebResponse response = request.EndGetResponse(result);
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string res = reader.ReadToEnd();
            return res;
        }
        /// <summary>
        /// 对新闻热点接口进行请求返回json数据（字符串），返回的是新闻的几个热点关键词
        /// </summary>
        /// <param name="url"></param>新闻热点接口的url
        /// <returns></returns>
        public static string createurl_keys(string url)
        {
            string key = ConfigurationManager.ConnectionStrings["mykey"].ConnectionString;//从Web.config中获得key
            string myurl = url + "?key=" + key;
            WebRequest request = WebRequest.Create(myurl);
            IAsyncResult result = request.BeginGetResponse(null, request);
            WebResponse response = request.EndGetResponse(result);
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string res = reader.ReadToEnd();
            return res;
        }
        /// <summary>
        /// 将新闻检索接口返回的json字符串进行解析，将解析得到的新闻数据填充到一个新闻的集合中
        /// </summary>
        /// <param name="data"></param>   json字符串
        /// <returns></returns>
        public static List<News> analysis_news(string data)
        {
            List<News> newslist=new List<News>();
            
            JObject jo = (JObject)JsonConvert.DeserializeObject(data);//将字符串转化为JObject
            JArray ja = (JArray)jo["result"];//索引到result
            foreach (JToken jt in ja)
            {
                string source = jt["src"].ToString();//获得新闻来源
                string content = jt["content"].ToString();//获得新闻content
                string title = jt["title"].ToString();//获得标题                
                string url = jt["url"].ToString();//获得新闻url              
                string pdate = jt["pdate"].ToString();//获得新闻发布时间
                string pdate_src = jt["pdate_src"].ToString();//获得新闻完整发布时间
                News news = new News(source, content, title, url, pdate, pdate_src);
                newslist.Add(news);
            }
            return newslist;
        }
        public static List<string> analysis_keys(string data)
        {
            List<string> keyslist = new List<string>();
            JObject jo = (JObject)JsonConvert.DeserializeObject(data);//将字符串转化为JObject
            JArray ja = (JArray)jo["result"];//索引到result
            foreach (JToken jt in ja)
            {
                string temp = jt.ToString();
                keyslist.Add(temp);
            }
            return keyslist;
        }
        /// <summary>
        /// 将Long类型转换为DateTime类型
        /// </summary>
        /// <param name="d">long</param>
        /// <returns></returns>
        //public static DateTime ConvertLongDateTime(Int64 d)
        //{           
        //    DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        //    //Int64 lTime = Int64.Parse(d);
        //    TimeSpan toNow = new TimeSpan(d);
        //    DateTime dtResult = dtStart.Add(toNow);
        //    return dtResult;
        //}
    }
}