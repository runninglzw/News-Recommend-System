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
<script>
    function search() {
        var o = document.getElementById("search");
        
        var text = o.value;
        alert(text);
        window.location.href = "Search.aspx?type="+text;
    }



</script>
<body>
    <header id="header">
        <h1>新闻</h1>

        <nav id="nav">
            <ul>
                <li><a href="Main.aspx">首页</a></li>

                <li class="search">
                    <input id="search" type="text" style="width: 100px"><input  type="button" value="搜索"  onclick=search()></li>
                <a style="margin-left: 700px">修改密码</a>
            </ul>
        </nav>
    </header>
    <div id="content">
        <div id="content-1">
            <section id="sectionL">
                <header>最新报道</header>
                <ul>

                    <%foreach (var item in mynews) {%>

                    <li><%=item.Gettitle()%>
                        <span><%=item.Getpdate()%></span>&nbsp;&nbsp;
            <a href="<%=item.Geturl() %>"><%=item.Getsource() %> </a>
            <span style="display: none;"><%=item.Getchannelname() %></span>
                    </li>
                    <% } %>
                </ul>
                </article>
            </section>
            <aside id="asideR">
                <h5>最新推荐</h5>
                <div class="divline"></div>
                <ul>
                    <%foreach(var item in commendnews) {%>

                    <li><%=item.Gettitle()%>
                        <span><%=item.Getpdate()%></span>&nbsp;&nbsp;
            <a href="<%=item.Geturl() %>"><%=item.Getsource() %> onclick=""</a>
                    </li>
                    <% } %>
                </ul>

            </aside>
        </div>
        <div class="clearfix"></div>
    </div>
    </div>    
    <a id="nextpage" runat="server" href="Main.aspx?star=<%=(star+1) %>">下一页</a>
    <a id="beforpage" runat="server" href="Main.aspx?star=<%=(star-1) %>">上一页</a>
    <footer class="footer">
        <h4>Copyright © qin</h4>
    </footer>
</body>
</html>
