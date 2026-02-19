<?php
$name = $_POST["name"];
$title = $_POST["title"];

//$db_id = mysqli_connect("localhost", "root", "");


$info = (object) [
    'success' => true,
    'name' => $name,
    'title' => $title
  ];

header('Content-type: application/json');
echo json_encode($info);
