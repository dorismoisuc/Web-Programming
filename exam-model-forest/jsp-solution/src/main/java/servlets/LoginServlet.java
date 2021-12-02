package servlets;

import authentication.CredentialsManager;
import org.json.simple.JSONObject;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet("/login")
public class LoginServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException{

        String action = request.getParameter("action");
        if((action != null) && action.equals("login")){
            String username = request.getParameter("user");
            String password = request.getParameter("password");
            JSONObject answer = new JSONObject();
            int userId = CredentialsManager.authenticate(username, password);
            if(userId != -1){
                answer.put("success", true);
                answer.put("userId", userId);
                request.getSession().setAttribute("userId", userId);
            } else{
                answer.put("success", false);
            }
            PrintWriter out = new PrintWriter(response.getOutputStream());
            out.println(answer);
            out.flush();
        }
    }
}
