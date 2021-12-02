package controller;

import db.Manager;
import model.Asset;
import model.User;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class AppController {
    public static User getUserWithUsername(String username) {
        String sql = "SELECT * FROM users WHERE username='" + username + "';";
        try {
            PreparedStatement stmt = Manager.getConnection().prepareStatement(sql);
            ResultSet result = stmt.executeQuery();
            if (result.next()){
                return new User(result.getInt("id"),result.getString("username"));
            }
            return null;

        } catch (SQLException throwables) {
            throwables.printStackTrace();
            return null;
        }
    }


    public static List<Asset> getAssetsOfUser(int userid) {
        String sql = "SELECT * FROM assets WHERE userid=" + userid;
        try {
            PreparedStatement stmt = Manager.getConnection().prepareStatement(sql);
            ResultSet result = stmt.executeQuery();
            List<Asset> assets = new ArrayList<>();

            while (result.next()){
                assets.add(new Asset(
                        result.getInt("id"),
                        result.getInt("userid"),
                        result.getString("name"),
                        result.getString("description"),
                        result.getInt("value")
                ));
            }
            return assets;

        } catch (SQLException throwables) {
            throwables.printStackTrace();
            return new ArrayList<>();
        }

    }

    public static void addAsset(int userId, String name, String desc, int value) {
        String sql = "INSERT INTO assets(userid, name, description, value) VALUES (" + userId + ",'" + name + "','" + desc + "'," + value + ")";
        PreparedStatement stmt;
        try {
            stmt = Manager.getConnection().prepareStatement(sql);
            stmt.execute();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }

    }
}
