<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="News_Recommend.View.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
        	width: 550px;
        	color:#333;
        	
        }
         #content-1 li .date{
        	width: 200px;
        	margin-left: 20px;
        	color: #2EAFCF;
        }
         #content-1 li .source{
        	width: 120px;
        	margin-left: 10px;
        	color:#C74343;
        }
        .back{
        	margin-left: 95%;
        	background-color:  #2EAFCF;
        	padding: 3px;
        	border-radius:2px; 
        	color: #fff;
        	text-align: center;
        	margin-bottom: 10px; 
        }
        .fanye {
        	padding: 10px;
        	text-align: center;
        	color: #2EAFCF;
        }
        .fanye a{        	
        	color: #2EAFCF;
        }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var oBack = document.getElementById("back");
            oBack.onclick = function () {
                window.location.href = "Main.aspx";
            }
        }

    </script>
</head>
<body>

<header id="header"><h1>新闻</h1>		
    <nav id="nav">
        <ul>
            <li><a href="index.html">首页</a><>
        </ul>
    </nav>
</header>
<div id="content">
    <div id="content-1">
    <ul id="new">
    <li id="">
                        <%foreach (var item in KeywordNews) {%>
                    <a class="title" href="<%=item.Geturl() %>"><%=item.Gettitle()%></a>
                        <div class="date"><%=item.Getpdate()%></div>
            <a class="source" href="<%=item.Geturl() %>"><%=item.Getsource() %> </a>
            <!--<span style="display: none;"><%=item.Getchannelname() %></span>-->
                    <% } %>
                    </li>
    </ul>
<div class="fanye"><a id="beforpage" runat="server" href="Main.aspx?star=<%=(star-1) %>">上一页</a>&nbsp;&nbsp;&nbsp;<a id="nextpage" runat="server" href="Main.aspx?star=<%=(star+1) %>">下一页</a></div>
<div id="back" class="back">返回</div>
</div>
</div>
<footer class="footer"><h4>Copyright  qin</h4></footer>
</body>

</html>
