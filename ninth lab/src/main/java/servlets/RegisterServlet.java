package servlets;

import authentication.CredentialsManager;
import model.User;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/RegisterServlet")
public class RegisterServlet extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        CredentialsManager.register(new User(
                req.getParameter("username"),
                req.getParameter("name"),
                req.getParameter("email"),
                req.getParameter("picture"),
                Integer.parseInt(req.getParameter("age")),
                req.getParameter("hometown")),
                req.getParameter("password"));

        resp.sendRedirect("/login.jsp");
    }
}
