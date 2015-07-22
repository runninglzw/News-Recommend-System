<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="News_Recommend.View.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <link rel="stylesheet" href="../css/main.css" type="text/css">
    <link rel="stylesheet" href="../css/head.css" type="text/css">
    <link rel="stylesheet" href="../css/content.css" type="text/css">
    <link rel="stylesheet" href="../css/foot.css" type="text/css">
    <link rel="stylesheet" href="../css/lunbo.css" type="text/css">
    <script type="text/javascript" src="../js/lunbo.js"></script>
    <style>
        .search{
            float: right;
        }
        #content-1 li{
            margin-bottom: 20px;
            display: block;
        }
    </style>
</head>
<body>
<header id="header"><h1>新闻</h1>
    <nav id="nav">
        <ul>
            <li><a href="index.html">首页</a></li>
            <li><a>个人中心</a>

            </li>
            <li class="search"><input type="text" style="width: 100px"><input type="button" value="搜索"></li>
            </li>
        </ul>
    </nav>
</header>
<div id="content">
    <div id="content-1">
        <section id="sectionL"><header>最新报道</header>
            <ul>
                <li>管理和追溯
                <div>2014-09-01</div>
            <a>来源</a>
                </li>
                <li>管理和追溯
                <div>2014-09-01</div>
                <a>来源</a>
                </li>
                <li>管理和追溯
                <div>2014-09-01</div>
                <a>来源</a>
                </li>
                <li>管理和追溯
                <div>2014-09-01</div>
                <a>来源</a>
                </li>
                <li>管理和追溯
                <div>2014-09-01</div>
                <a>来源</a>
                </li>

           </ul>
        </article>
        </section>
        <aside id="asideR"><h5 style="padding: 10px">最新推荐</h5>
            <ul>
                <li>管理和追溯
                    <div>2014-09-01</div>
                    <a>来源</a>
                </li>
                <li>管理和追溯
                    <div>2014-09-01</div>
                    <a>来源</a>
                </li>
                <li>管理和追溯
                    <div>2014-09-01</div>
                    <a>来源</a>
                </li>
                <li>管理和追溯
                    <div>2014-09-01</div>
                    <a>来源</a>
                </li>
                <li>管理和追溯
                    <div>2014-09-01</div>
                    <a>来源</a>
                </li>

            </ul>
        </aside>
    </div>
    <div class="clearfix"></div>

    </div>
</div>
<footer class="footer"><h4>Copyright © qin</h4></footer>
</body>
</html>
