<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Update info</title>
    <script src="main.js"></script>
    <link rel="stylesheet" href="styling.css" type="text/css">
</head>
<body>
<h2>Update info:</h2>
<form action="UpdateServlet" method="post" id="updateForm">
    <input type="text" name="name" placeholder="name" id="name"><br>
    <input type="text" name="email" placeholder="email" id="email"><br>
    <input type="text" name="picture" placeholder="pic" id="picture"><br>
    <input type="text" name="age" placeholder="age" id="age"><br>
    <input type="text" name="hometown" placeholder="hometown" id="hometown"><br>
    <button type="button" value="Update" onclick="validateUpdateInfo()">Update</button>
</form>
</body>
</html>
