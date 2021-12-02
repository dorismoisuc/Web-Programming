package authentication;

import db.Manager;

import java.sql.*;

public class CredentialsManager {
    public static int authenticate(String username, String password) {
        ResultSet rs;
        int result = -1;
        Manager.connect();
        Connection con = Manager.getConnection();
        try {
            Statement stmt = con.createStatement();
            rs = stmt.executeQuery("select id from users where username='"+username+"' and password='"+ password +"'");
            if (rs.next()) {
                result = rs.getInt("id");
            }
            rs.close();
            Manager.disconnect();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return result;
    }

}
