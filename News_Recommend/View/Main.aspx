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
    <style>
        #content-1 li{
            margin-top: 10px;
            display: block;
        }
         #content-1 li div{
            display: inline-block;
        }
        #content-1 li .title{
        	width: 400px;
        	color:#333;
            display:inline-block;
        	
        }
         .titleR{
        	width: 290px;
        	color:#333;
            display:inline-block;
        	
        }
          .date{
        	width: 153px;
        	margin-left: 5px;
        	color: #2EAFCF;
        }
         #content-1 li .source{
        	width: 100px;
        	margin-left: 5px;
        	color:#C74343;
        }
           .fanye {
        	padding: 10px;
        	text-align: center;
        	color: #2EAFCF;
        }
        .fanye a{        	
        	color: #2EAFCF;
        }
         .fanyeR{
             width:300px;
        	padding: 10px;
        	text-align: center;
        	color: #2EAFCF;
        }
        .fanyeR a{        	
        	color: #2EAFCF;
        }
    </style>
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
                <a style="margin-left: 700px" href="changeps.aspx">修改密码</a>
            </ul>
        </nav>
    </header>
    <div id="content">
        <div id="content-1">
            <section id="sectionL">
                <header>最新报道</header>
                <ul id="new">
                    <%foreach (var item in mynews) {%>
                    <li id="">
                    <a href="" class="title"><%=item.Gettitle()%></a>
                        <div class="date"><%=item.Getpdate()%></div>
            <a class="source" href="<%=item.Geturl() %>"><%=item.Getsource() %> </a>
            <span style="display: none;"><%=item.Getchannelname() %></span>
            </li>
                    <% } %>
                    <br />
             <div class="fanye"><a id="nextpage"  href="Main.aspx?star=<%=(star+1) %>&count=<%=count %>">下一页</a>
   <a id="beforpage"  href="Main.aspx?star=<%=(star-1) %>&count=<%=count %>">上一页</a>
    </div>
    </ul> 
            </section>
            <aside id="asideR">
                <h5>最新推荐</h5>
                <div class="divline"></div>
                <ul>
                <%int i = count - 5; %>
                    <%for (; i < count;i++ ){%>
                    <li>
                    <a herf="" class="titleR"><%=commendnews[i].Gettitle()%></a>
                    <p>
                     <div class="date"><%=commendnews[i].Getpdate()%></div>
            <a class="source" ="<%=commendnews[i].Geturl()%>"><%=commendnews[i].Getsource()%></a>
                    </p>
                    </li>                   
                    <% } %>
                    <br />
                    <div class="fanyeR"><a  id="A1"  href="Main.aspx?star=<%=star %>&count=<%=(count+5) %>">下一页</a>
   <a id="A2"  href="Main.aspx?star=<%=star %>&count=<%=(count-5) %>">上一页</a>
    </div>
                </ul>

            </aside>
        </div>
        <div class="clearfix"></div>
    </div> 
    
    <footer class="footer">
        <h4>Copyright © qin</h4>
    </footer>
</body>
</html>
