<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="News_Recommend.View.Main" %>

<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <link rel="stylesheet" href="../css/main.css" type="text/css">
    <link rel="stylesheet" href="../css/head.css" type="text/css">
    <link rel="stylesheet" href="../css/content.css" type="text/css">
    <link rel="stylesheet" href="../css/foot.css" type="text/css">
 
</head>
<body>
<header id="header"><h1>新闻</h1>

    <nav id="nav">
        <ul>
            <li><a href="index.html">首页</a></li>
            
            <li class="search"><input type="text" style="width: 100px"><input type="button" value="搜索" onclick=<%Response.Redirect("./Search.aspx"); %>></li>
            <a style="margin-left:700px">修改密码</a>
        </ul>
    </nav>
</header>
<div id="content">
    <div id="content-1">
        <section id="sectionL"><header>最新报道</header>
            <ul>
             
              <%foreach (var item in mynews) {%>
               
                    <li><%=item.Gettitle()%>
                <span><%=item.Getpdate()%></span>&nbsp;&nbsp;
            <a href="<%=item.Geturl() %>"><%=item.Getsource() %></a>
                </li>
               <% } %>

           </ul>
        </article>
        </section>
        <aside id="asideR"><h5>最新推荐</h5>
        <div class="divline"></div>
            <ul >
            <%foreach(var item in commendnews) {%>
              
                  <li><%=item.Gettitle()%>
                <span><%=item.Getpdate()%></span>&nbsp;&nbsp;
            <a href="<%=item.Geturl() %>"><%=item.Getsource() %></a>
                </li>
             <% } %>
                
            </ul>
           
        </aside>
    </div>
    <div class="clearfix"></div>
    </div>
</div>
<span style="display:none;"><%=star %></span>
<a href="Main.aspx?star=<%=(star+1) %>">下一页</a>
 <a href="Main.aspx?star=<%=(star-1) %>">上一页</a>
<footer class="footer"><h4>Copyright © qin</h4></footer>
</body>
</html>