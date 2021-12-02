<%@ page import="model.User" %>
<%@ page import="java.util.ArrayList" %>
<%@ page import="java.util.List" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Search</title>
    <script src="main.js"></script>
    <link rel="stylesheet" href="styling.css" type="text/css">
</head>
<body>
<form action="LogoutServlet" method="post">
    <input type="submit" name="logout" value="Logout">
</form>
<h2>Browse</h2>
<%
    List<User> users = (ArrayList<User>)session.getAttribute("users");
    out.println("<table>");
    out.println("<thead>");
    out.println("<th>name</th>");
    out.println("<th>email</th>");
    out.println("<th>age</th>");
    out.println("<th>hometown</th>");
    out.println("<th>picture</th>");
    out.println("</thead>");
    out.println("<tbody>");
    if (users!=null)
        for(User user:users){
            out.println("<tr>");
            out.println("<td>" + user.getName() +"</td>");
            out.println("<td>" + user.getEmail() +"</td>");
            out.println("<td>" + user.getAge() +"</td>");
            out.println("<td>" + user.getHometown() +"</td>");
            out.println("<td><img src=\"/imgs/" + user.getPicture() + ".jpg\"></td>");
            out.println("</tr>");
        }
    out.println("</tbody>");
    out.println("</table>");
%>
</body>
</html>
