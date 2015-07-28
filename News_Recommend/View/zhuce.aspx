<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhuce.aspx.cs" Inherits="News_Recommend.View.zhuce" %>

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
        function checkId() {
            var oIdValue = document.getElementById("id").value;
            var oWarning = document.getElementById("warnning");
            var reg = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (oIdValue == "") {
                oWarning.innerHTML = "邮箱不能为空";
                oWarning.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";

            }
            else if (!reg.test(oIdValue) && oIdValue != "") {
                oWarning.innerHTML = "邮箱不正确";
                oWarning.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";
            }
            else {
                oWarning.style.cssText = "display:none";
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
            var oPass1 = document.getElementById("pass1");
            var oPass2 = document.getElementById("pass2");
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
    <style type="text/css">
    /*注册*/
#zhuce{
    width: 800px;
    margin: 20px auto;
    height: auto;
    background-color: #ffffff;
    padding-bottom: 30px;
 text-align: center;
}
.zhuce{
    padding-top:30px ;
    width: 500px;
    margin: 20px auto;
    text-align: center;
    font-size: 20px;
}
.zhuceList{
    width: 500px;
    margin: 20px auto;

}
.zhuceList-li{
    width: 100px;
}
.zhuceList-li-input{
    position: relative;
    padding-left: 12px;
    width:260px;
    border: 1px solid #758592;
    height: 40px;
}
.zhuceList-liMember{
    width: 100px;
    margin-left: -320px;
}
.zhuceList-memberName{
    border: 1px solid #758592;
    width: 400px;
    margin-left: 106px;
    border-collapse:collapse;
}
.zhuceList-memberName caption{
    font-size: 16px;
    font-weight: normal;
    text-align: left;
    margin-left:2px;
}
.zhuceList-memberName th ,td{
    padding: 10px;
    width: 200px;
    font-size: 16px;
    font-weight: normal;
    border: 1px solid #758592;
}
.zhuceList-memberName td input{
   width: 120px;
    height: 20px;
    border: none;
    text-align: left;
}
.input_zhuce{
    border: #CCCCCC;
    border-radius: 5px;
    width: 100px;
    height: 35px;
    background-color:#2EAFBB;
    font-weight: bold;
    color: #fff;
    margin-top: 15px;
}
    </style>
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
<div id="content">
    <div id="groupLogin">
        <form id="zhuce" action="?Action=Login" method="post">
            <h4 class="zhuce">用户注册</h4>
            <ul class="zhuceList">
                <li  class="zhuceList-li">账号：</li>
                <li>
                    <input id="id" name="id" class="zhuceList-li-input" type="text" value=""  placeholder="请输入邮箱" onblur=checkId()>
                </li>
                 <span id="warnning" style="display:none;"></span>

            </ul>
            <ul class="zhuceList">
                <li class="zhuceList-li">密码：</li>
                <li>
                    <input id="pass1" name="pass1"  class="zhuceList-li-input" type="password" value="" placeholder="请输入密码" onblur=checkPass1()>
                </li>
                <span id="pWarnning1" style="display:none;"></span>
            </ul>
            <ul class="zhuceList">
                <li class="zhuceList-li">密码：</li>
                <li>
                    <input id="pass2" name="pass2"  class="zhuceList-li-input" type="password" value="" placeholder="请再次输入密码" onblur=checkPass2()>
                </li>
                <span id="pWarnning2" style="display:none;"></span>
            </ul>
            <ul class="zhuceList">
            <select id="like" name="like"  >
           <option value="">----请选择您喜欢的新闻类型----</option>
           <%int i = 0; %>
           <%foreach(string str in types) {%>
            <option value=<%=i %>><%=str %></option>
           <%} %>
           </select>
            </ul>

            <input name="zhuce" class="input_zhuce" type="submit" value="注册" >
        </form>
    </div>
</div>
<footer class="footer"><h4>Copyright © 软件工程实践综合教学平台</h4></footer>
</body>
</html>
