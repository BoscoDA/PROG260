<?php

    //mysql_connect(string server, string username, string password, string db_name, int port, int socket)
    $link = mysqli_connect("INSERT_SERVER_NAME","INSERT_USERNAME","INSERT_PASSWORD","INSERT_DB_NAME");

    if (mysqli_connect_errno()) 
    {
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
        exit();
    }
?>