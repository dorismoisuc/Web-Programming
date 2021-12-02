package controller;

import db.Manager;
import model.User;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ProfilesController {

    public static User getUserWithUsername(String username) {
        String sql = "SELECT * FROM users WHERE username='" + username + "';";
        try {
            PreparedStatement stmt = Manager.getConnection().prepareStatement(sql);
            ResultSet result = stmt.executeQuery();
            if (result.next()){
                User user = new User();
                user.setUsername(result.getString("username"));
                user.setName(result.getString("name"));
                user.setEmail(result.getString("email"));
                user.setPicture(result.getString("picture"));
                user.setAge(result.getInt("age"));
                user.setHometown(result.getString("hometown"));
                return user;
            }
            return null;

        } catch (SQLException throwables) {
            throwables.printStackTrace();
            return null;
        }
    }

    public static List<User> search(String username,String name, String email, int age, String hometown){
        String sql = "SELECT * FROM users WHERE username<>'" + username + "'AND (name LIKE '%" + name + "%' OR email LIKE '%" + email + "%' OR AGE=" + age + " OR hometown LIKE '%" + hometown + "%')";
        try {
            PreparedStatement stmt = Manager.getConnection().prepareStatement(sql);
            ResultSet result = stmt.executeQuery();
            List<User> users = new ArrayList<>();

            while (result.next()){
                User user = new User();
                user.setUsername(result.getString("username"));
                user.setName(result.getString("name"));
                user.setEmail(result.getString("email"));
                user.setPicture(result.getString("picture"));
                user.setAge(result.getInt("age"));
                user.setHometown(result.getString("hometown"));
                users.add(user);
            }
            return users;

        } catch (SQLException throwables) {
            throwables.printStackTrace();
            return new ArrayList<>();
        }

    }

    public static void update(User user) {
        String sql = "UPDATE users SET email='" + user.getEmail() + "', name='" + user.getName() + "', picture='" +
                user.getPicture() + "', hometown='" + user.getHometown() + "', age=" + user.getAge() + " WHERE username='" +
                user.getUsername() + "';";
        try {
            PreparedStatement stmt = Manager.getConnection().prepareStatement(sql);
            stmt.execute();
            Manager.disconnect();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
}
