<?php
    $email = $_POST["email"];
    $password = $_POST["pwd"];
    $username = $_POST["user"];

    
    echo("{$email}, {$username}, {$password}");
    $encrypted_pwd = password_hash($password, PASSWORD_ARGON2ID, []);
    password_verify($password, $encrypted_pwd);
    $hash = hash("sha256");
    $uuid = bin2hex(random_bytes(16));
    
    // put user into db but not validated
    $mysql = mysqli_connect("localhost", "root", null, "php_registration", 3306, null);
    $query = "INSERT INTO users (uuid, email, password, username, validated) VALUES ($uuid, $email, $encrypted_pwd, $username, false)";
    echo $query;
    mysqli_query($mysql, $query);

    // send email and valdate user that
    // update user to validated
    mysqli_close($mysql);
?>