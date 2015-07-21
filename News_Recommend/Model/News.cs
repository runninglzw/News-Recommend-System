using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Recommend.Model
{
    public class News
    {
        string source;//新闻来源
        string content;//新闻摘要内容
        string title;//新闻的标题
        string url;//新闻的url
        string pdate;//新闻发布时间
        string channelid;//频道id
        string channelname;//频道名(也是新闻的类型)
        public News()
        {

        }
        public News
            (string source,
        string content,
        string title,
        string url,
        string pdate,
        string channelid,
        string channelname)
        {
            this.title = title;
            this.content = content;
            this.source = source;
            this.url = url;
            this.pdate = pdate;
            this.channelid = channelid;
            this.channelname = channelname;
        }
        public string Getcontent()
        {
            return content;
        }
        public string Gettitle()
        {
            return title;
        }
        public string Geturl()
        {
            return url;
        }
        public string Getsource()
        {
            return source;
        }
        public string Getpdate()
        {
            return pdate;
        }
        public string Getchannelid()
        {
            return channelid;
        }
        public string Getchannelname()
        {
            return channelname;
        }
    }
}