<?php

function OpenConnection(): mysqli
{
    $dbhost="127.0.0.1";
    $dbusername="dorisuca";
    $dbpassword="12345";
    $dbname="exam";

    return mysqli_connect($dbhost,$dbusername,$dbpassword,$dbname);
}

function CloseConnection(mysqli $con){
    $con->close();
}