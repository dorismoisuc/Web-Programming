<?php

session_start();

if (isset($_POST['submit'])){
    include('connection.php');
    $username=$_POST['username'];

    $con=OpenConnection();

    $sql="SELECT id, name FROM person where name='$username' LIMIT 1";

    $query = $con->query($sql);

    if ($query){
        $row = mysqli_fetch_row($query);
        $userId = $row[0];
        $dbUserName = $row[1];
    }

    if ($username==$dbUserName){
        $_SESSION['username'] = $username;
        $_SESSION['id']=$userId;
        header('Location: mainpage.php');
    }

    else {
        echo "<b><i>Incorrect credentials</i>";
    }

    CloseConnection($con);

}

?>