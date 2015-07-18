using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Recommend.Model
{
    public class User
    {
        string id;
        string name;
        string password;
        DateTime logintime;
        string[] keyword;//关键词
        public string Getid()
        {
            return id;
        }
        public string Getname()
        {
            return name;
        }
        public string Getpassword()
        {
            return password;
        }
        public DateTime Getlogintime()
        {
            return logintime;
        }
        public User()
        {
 
        }
        public User(string id, string name, string password, DateTime logintime, string[] keyword)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.logintime = logintime;
            this.keyword = keyword;
        }
    }
}