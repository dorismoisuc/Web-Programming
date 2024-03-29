package model;

import java.util.Objects;

public class User {

    private String user_id;
    private String username;
    private String name;
    private String email;
    private String picture;
    private int age;
    private String hometown;

    public User() {

    }

    @Override
    public String toString() {
        return "User{" +
                "username='" + username + '\'' +
                ", name='" + name + '\'' +
                ", email='" + email + '\'' +
                ", picture='" + picture + '\'' +
                ", age=" + age +
                ", hometown='" + hometown + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        User profile = (User) o;
        return age == profile.age &&
                user_id.equals(profile.user_id) &&
                Objects.equals(name, profile.name) &&
                Objects.equals(email, profile.email) &&
                Objects.equals(picture, profile.picture) &&
                Objects.equals(hometown, profile.hometown);
    }

    @Override
    public int hashCode() {
        return Objects.hash(user_id, name, email, picture, age, hometown);
    }

    public String getUser_id() {
        return user_id;
    }

    public void setUser_id(String user_id) {
        this.user_id = user_id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPicture() {
        return picture;
    }

    public void setPicture(String picture) {
        this.picture = picture;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getHometown() {
        return hometown;
    }

    public void setHometown(String hometown) {
        this.hometown = hometown;
    }

    public User(String username, String name, String email, String picture, int age, String hometown) {
        this.username = username;
        this.name = name;
        this.email = email;
        this.picture = picture;
        this.age = age;
        this.hometown = hometown;
    }


    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
