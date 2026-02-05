<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
        // $server_name = "localhost";
        // $username = "root";
        // $password = "";
        // $dbname = "asd";
        // $conn = new mysqli($server_name, $username, $password, $dbname);

        $x = $_SERVER["QUERY_STRING"];

        print "asd: ".$x. "<br><br>";

        $arr = explode("&", $x);

        $szorzat = 1;
        for ($i=0; $i < count($arr); $i++) { 
           $szorzat *= (int)$arr[$i];
        }

        print "Szorzat: " .$szorzat;

        return;
    ?>
</body>
</html>