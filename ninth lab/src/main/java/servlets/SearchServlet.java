package servlets;

import controller.ProfilesController;
import model.User;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/SearchServlet")
public class SearchServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getSession().setAttribute("users",
                ProfilesController.search(
                    ((User)req.getSession().getAttribute("user")).getUsername(),
                    req.getParameter("name"),
                    req.getParameter("email"),
                    Integer.parseInt(req.getParameter("age")),
                    req.getParameter("hometown"))
        );
        resp.sendRedirect("/browse.jsp");
    }
}
