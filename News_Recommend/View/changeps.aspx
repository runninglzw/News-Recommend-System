<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changeps.aspx.cs" Inherits="News_Recommend.View.changeps" %>

<!DOCTYPE html>

<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <link rel="stylesheet" href="../css/main.css" type="text/css">
    <link rel="stylesheet" href="../css/head.css" type="text/css">
    <link rel="stylesheet" href="../css/content.css" type="text/css">
    <link rel="stylesheet" href="../css/foot.css" type="text/css">
    <script type="text/javascript">
        function checkPass() {
            var oPass1 = document.getElementById("pass1");
            var pWarning1 = document.getElementById("pWarnning");
            if (oPass1.value == "") {
                pWarning1.innerHTML = "密码不能为空";
                pWarning1.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";
            }
            else {
                pWarning1.style.cssText = "display:none";
            }
        }
        function checkPass1() {
            var oPass1 = document.getElementById("pass1");
            var pWarning1 = document.getElementById("pWarnning1");
            if (oPass1.value == "") {
                pWarning1.innerHTML = "密码不能为空";
                pWarning1.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";
            }
            else {
                pWarning1.style.cssText = "display:none";
            }
        }
        function checkPass2() {
            var oPass1 = document.getElementById("pass2");
            var oPass2 = document.getElementById("pass3");
            var pWarning = document.getElementById("pWarnning2");
            if (oPass2.value == "") {
                pWarning.innerHTML = "密码不能为空";
                pWarning.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";
            }
            else if (oPass1.value != oPass2.value && oPass2.value != "") {
                pWarning.innerHTML = "两次密码不一致";
                pWarning.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";
            }
            else {
                pWarning.style.cssText = "display:none";
            }
        }
      </script>
</head>
<body>
<span class="quick">
   <a href="index.html">
       返回登录
   </a>

    </span>
<header id="header">
    <h1>新闻</h1>
    <nav >
        <ul>
            <li><a href="student.html">首页</a></li>
        </ul>
    </nav>
</header>
<div id="content"><br/><br/><br/><br/><br/>
    <div id="groupLogin">
        <form id="zhuce" action="?Action=ok" method="post">
            <h4 class="zhuce">修改密码</h4>
            <ul class="zhuceList">
                <li class="zhuceList-li">原密码：</li>
                <li>
                    <input id="pass1" name="pass"  class="zhuceList-li-input" type="password" value="" placeholder="请输入原密码" onblur=checkPass()>
                </li>
                <span id="pWarnning" style="display:none;"></span>
            </ul>
            <ul class="zhuceList">
                <li class="zhuceList-li">新密码：</li>
                <li>
                    <input id="pass2" name="pass1"  class="zhuceList-li-input" type="password" value="" placeholder="请输入新密码" onblur=checkPass1()>
                </li>
                <span id="pWarnning1" style="display:none;"></span>
            </ul>
            <ul class="zhuceList">
                <li class="zhuceList-li">新密码：</li>
                <li>
                    <input id="pass3" name="pass2"  class="zhuceList-li-input" type="password" value="" placeholder="请再次输入新密码" onblur=checkPass2()>
                </li>
                <span id="pWarnning2" style="display:none;"></span>
            </ul>
            <input name="zhuce" class="input_zhuce" type="submit" value="确定" >
        </form>
    </div>
</div>
<footer class="footer"><h4>Copyright © 软件工程实践综合教学平台</h4></footer>
</body>
</html>
