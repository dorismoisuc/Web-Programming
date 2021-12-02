<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Login</title>
    <link rel="stylesheet" href="stylingLogin.css" type="text/css">
</head>
<body>
<form action="LoginServlet" method="post">
    Enter username : <BR>
    <input type="text" name="username"> <BR> <BR>
    Enter password :
    <BR>
    <input type="password" name="password">
    <BR><BR>
    <input type="submit" value="Login"/>
</form>
</body>
</html>
