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
        string pdate;//新闻发布时间例如：“1小时前”
        string pdate_src;//完整新闻发布时间 例如：“2015-03-17 10:24:00”
        public News()
        {

        }
        public News
            (string source,
        string content,
        string title,
        string url,
        string pdate,
        string pdate_src)
        {
            this.title = title;
            this.content = content;
            this.source = source;
            this.url = url;
            this.pdate = pdate;
            this.pdate_src = pdate_src;
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
        public string Getpdate_src()
        {
            return pdate_src;
        }
    }
}