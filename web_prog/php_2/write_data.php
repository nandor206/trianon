<?php
$country = $_POST["country"];
$place = $_POST["place"];

$db_id = mysqli_connect("localhost", "root", "helyek");

$sql_query = "Select orszag, fovaros where country like '' ";

?>