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
        /// 对新闻检索接口进行请求返回json数据（字符串）
        /// </summary>
        /// <param name="url"></param>新闻检索接口的url
        /// <param name="channelid"></param>频道id
        /// <param name="channelname"></param>频道的名字
        /// <param name="title"></param>标题，可以模糊搜索
        /// <param name="page"></param>页数。默认为1，每页最多20条
        /// <returns></returns>
        public static string createurl_news(string channelid,string channelname,string title,string page)
        {
            string url = ConfigurationManager.ConnectionStrings["newsurl"].ConnectionString;//从Web.config中获得newsurl
            string appid = ConfigurationManager.ConnectionStrings["appid"].ConnectionString;
            string key = ConfigurationManager.ConnectionStrings["mykey"].ConnectionString;//从Web.config中获得key
            string time = GetTime();
            string myurl = url + "?showapi_appid=" + appid + "&showapi_sign=" + key + "&showapi_timestamp=" + time;
            if (channelid != null)
            {
                myurl = myurl + "&channelId=" + channelid;
            }
            if (channelname != null)
            {
                myurl = myurl + "&channelName=" + channelname;
            }
            if (title != null)
            {
                myurl = myurl + "&title=" + title;
            }
            if (page != null)
            {
                myurl = myurl + "&page=" + page;
            }
            WebRequest request = WebRequest.Create(myurl);
            IAsyncResult result = request.BeginGetResponse(null, request);
            WebResponse response = request.EndGetResponse(result);
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string res = reader.ReadToEnd();
            return res;
        }
        /// <summary>
        /// 对新闻类型接口进行请求返回json数据（字符串），返回的是包含新闻的频道id和名字等信息
        /// </summary>
        /// <param name="url"></param>新闻热点接口的url
        /// <returns></returns>
        public static string createurl_keys()
        {
            string appid = ConfigurationManager.ConnectionStrings["appid"].ConnectionString;
            string key = ConfigurationManager.ConnectionStrings["mykey"].ConnectionString;//从Web.config中获得key
            string time = GetTime();
            string url = ConfigurationManager.ConnectionStrings["keysurl"].ConnectionString;
            string myurl = url + "?showapi_appid=" + appid + "&showapi_sign=" + key + "&showapi_timestamp=" + time;
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
            JArray ja = (JArray)(jo["showapi_res_body"]["pagebean"]["contentlist"]);//索引到新闻集合
            foreach (JToken jt in ja)
            {
                string source = jt["source"].ToString();//获得新闻来源
                string content = jt["desc"].ToString();//获得新闻content
                string title = jt["title"].ToString();//获得标题                
                string url = jt["link"].ToString();//获得新闻url              
                string pdate = jt["pubDate"].ToString();//获得新闻发布时间
                string channelid = jt["channelId"].ToString();//获得新闻频道id
                string channelName = jt["channelName"].ToString();//获得新闻频道名
                News news = new News(source, content, title, url, pdate, channelid,channelName);
                newslist.Add(news);
            }
            return newslist;
        }
        public static List<string> analysis_keys(string data)
        {
            List<string> keyslist = new List<string>();
            JObject jo = (JObject)JsonConvert.DeserializeObject(data);//将字符串转化为JObject
            JArray ja = (JArray)jo["showapi_res_body"]["channelList"];
            foreach (JToken jt in ja)
            {
                string temp = jt["name"].ToString();//获得频道的名称
                keyslist.Add(temp);
            }
            return keyslist;
        }
        //按指定格式获得当前系统时间
        public static string GetTime()
        {

            DateTime dt = DateTime.Now;
            return dt.ToString("yyyyMMddHHmmss");
        }
    }
}