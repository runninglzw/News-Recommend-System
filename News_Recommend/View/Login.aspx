<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="News_Recommend.View.Login" %>

<!DOCTYPE html>

<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <link rel="stylesheet" href="../css/main.css" type="text/css">
    <link rel="stylesheet" href="../css/head.css" type="text/css">
    <link rel="stylesheet" href="../css/content.css" type="text/css">
    <link rel="stylesheet" href="../css/foot.css" type="text/css">
    <style type="text/css">
    #login{
      margin-top: 100px;
    	border: 1px solid #ccc;
    }
    .input_login {
  border: #CCCCCC;
  border-radius: 5px;
  width: 80px;
  height: 35px;
  background-color: #2EAFBB;
  font-weight: bold;
  color: #fff;
  margin-left: 30px;
  margin-top: 15px;
}
.input_text {
  padding-left: 5px;
  border: none;
  display: inline-block;
  width: 180px;
  height: 40px;
  font-size: 14px;
  vertical-align: middle;
}
.logoPass {
  background-position: 0px 0px;
}
.logoPass, .logo {
  margin-left: 15px;
  width: 16px;
  height: 16px;
  display: inline-block;
  vertical-align: middle;
  background: url("../img/icon_input.png") no-repeat scroll -16px 0px transparent;
}
.user {
  margin: 20px auto;
  border: 1px solid #CCC;
  border-radius: 4px;
  width: 230px;
  height: 42px;
  margin-bottom: 36px;
}
    </style>
    <script type="text/javascript">
        function zhuce() {
            window.location.href = "./zhuce.aspx";
        }


        function checkId() {
            var oIdValue = document.getElementById("username").value;
            var oWarning = document.getElementById("warnning");
            var reg = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (oIdValue == "") {
                oWarning.innerHTML = "账号不能为空";
                oWarning.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";

            }
            else {
                oWarning.style.cssText = "display:none";
            }
        }
        function checkPass1() {
            var oPass1 = document.getElementById("pass");
            var pWarning1 = document.getElementById("pWarnning1");
            if (oPass1.value == "") {
                pWarning1.innerHTML = "密码不能为空";
                pWarning1.style.cssText = "display:inline-block;color:red;position:absolute;margin-left:10px;font-size:16px;line-height:40px";
            }
            else {
                pWarning1.style.cssText = "display:none";
            }
        }
    </script>
</head>
<body>

<header id="header"><h1>新闻</h1>		
    <nav id="nav">
        <ul>
            <li><a href="index.html">首页</a></li>
        </ul>
    </nav>
</header>
<div id="content">
	 <form id="login" action="?Action=Login" method="post">
            <h4 class="login">用户登录</h4>
            <ul class="user">
                <li class="logo"></li>
                <li>
                    <input id="username" name="username" required="required" class="input_text" placeholder="请输入邮箱"  value="" type="text" onblur=checkId()>
                </li>
                <span id="warnning" style="display:none;"></span>
            </ul>
            
            <ul class="user">
                <li class="logoPass"></li>
                <li>
                    <input id="pass" name="pass"  required="required" class="input_text" placeholder="请输入密码"  value="" type="password" onblur=checkPass1()>
                </li>
                <span id="pWarnning1" style="display:none;"></span>
            </ul>
           <input type="submit" class="input_login"  value="登录">
           <input type="button" class="input_login"  value="注册" onclick=zhuce()>
           </br></br>
           </form>
        </form>

   
</div>
</div>
<footer class="footer"><h4>Copyright © qin</h4></footer>
</body>
</html>
