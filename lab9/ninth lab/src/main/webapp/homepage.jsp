<%@ page import="model.User" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Homepage</title>
    <script src="main.js"></script>
    <link rel="stylesheet" type="text/css" href="styling.css"/>
</head>
<body>
<form action="LogoutServlet" method="post">
    <input type="submit" name="logout" value="Logout">
</form>
<h2>User info</h2>
<%
    User user = (User) session.getAttribute("user");
    if(user!=null){
        out.println("<div class=\"container-ph\">");
        out.println("<img src=\"/imgs/" + user.getPicture() + ".jpg\"><br>");
        out.println("<ul>");
        out.println("<li>Name: " + user.getName() + "</li>");
        out.println("<li>Email: " + user.getEmail() +"</li>");
        out.println("<li>Age: "  + user.getAge() + "</li>");
        out.println("<li>Hometown: " + user.getHometown()  + "</li>");
        out.println("</ul></div>");
    }

%>
<h2>Search:</h2>
<form action="SearchServlet" method="get" id="searchForm">
    <input type="text" name="name" placeholder="name" id="name"><br>
    <input type="text" name="email" placeholder="email" id="email"><br>
    <input type="text" name="age" placeholder="age" id="age"><br>
    <input type="text" name="hometown" placeholder="hometown" id="hometown"><br> <br>
    <button class="button" value="Search" onclick="validateSearch()"><span>Search</span></button>
</form>
<br>
<button class="button" onclick="location.href='update.jsp'"><span>Update Profile</span></button>
</body>
</html>
