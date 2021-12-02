package servlets;

import controller.ProfilesController;
import model.User;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/UpdateServlet")
public class UpdateServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        User currentUser = (User) req.getSession().getAttribute("user");
        if (currentUser==null) {
            resp.sendRedirect("/index.jsp");
            return;
        }

        ProfilesController.update(new User(currentUser.getUsername(),req.getParameter("name"), req.getParameter("email"), req.getParameter("picture"),
                Integer.parseInt(req.getParameter("age")), req.getParameter("hometown")));

        //set the current user again
        req.getSession().setAttribute("user", ProfilesController.getUserWithUsername(currentUser.getUsername()));
        resp.sendRedirect("/homepage.jsp");
    }
}
