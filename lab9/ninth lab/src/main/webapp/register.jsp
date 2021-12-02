<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Create an account</title>
    <script src="main.js"></script>
    <link rel="stylesheet" href="stylingRegister.css" type="text/css">
</head>
<body>
<h2>Create Account</h2>
<form action="RegisterServlet" method="post" id="registerForm">
    <input type="text" name="username" placeholder="username" id="username"> <BR>
    <input type="password" name="password" placeholder="password" id="password"> <BR>
    <input type="text" name="name" placeholder="name" id="name"> <BR>
    <input type="text" name="email" placeholder="email" id="email"> <BR>
    <input type="text" name="picture" placeholder="picture" id="picture"> <BR>
    <input type="text" name="age" placeholder="age" id="age"> <BR>
    <input type="text" name="hometown" placeholder="hometown" id="hometown"> <BR>
    <br><br>
    <input type="button" value="Register" onclick="validateRegister()"/>
</form>
</body>
</html>
