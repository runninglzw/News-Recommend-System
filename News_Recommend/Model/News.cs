using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Recommend.Model
{
    public class News
    {
        string id;
        string source;//新闻来源
        string title;//新闻的标题
        string url;//新闻的url
        DateTime include_time;//新闻收录时间
        int praise_count;//新闻赞的次数
        int step_count;//新闻踩的次数
        int collect_count;//新闻收藏的次数
        public News()
        {
 
        }
        public News(string id,
        string title,
        string source,
        string url,
        DateTime include_time,
        int praise_count,
        int step_count,
        int collect_count)
        {
            this.id = id;
            this.title = title;
            this.source = source;
            this.url = url;
            this.include_time = include_time;
            this.praise_count = praise_count;
            this.step_count = step_count;
            this.collect_count = collect_count;
        }
        public string Getid()
        {
            return id;
        }
        public string Gettitle()
        {
            return title;
        }
        public string Geturl()
        {
            return url;
        }
        public DateTime Getinclude_time()
        {
            return include_time;
        }
        public int Getpraise_count()
        {
            return praise_count;
        }
        public int Getstep_count()
        {
            return step_count;
        }
        public int Getcollect_count()
        {
            return collect_count;
        }
    }
}