<?php

class Helper
{
    public function AddFruit($fruit)
    {
        require 'conn.php';

        $query = "INSERT INTO fruit(name) VALUES('".$fruit."') ";
        $result = mysqli_query($link,$query);
        echo $result;

        $link->close();
    }

    public function RemoveFruit($fruit)
    {
        require 'conn.php';
        
        $query = "DELETE FROM fruit WHERE name = '".$fruit."' ";
        $result = mysqli_query($link,$query);
        echo $result;

        $link->close();
    }

    public function PrintFruit()
    {
        require 'conn.php';
        
        $query = "SELECT * FROM fruit";
        $result = mysqli_query($link,$query);
        if($result == 1)
        {
            if($result->num_rows>0)
            {
                while($row = $result->fetch_array(MYSQLI_ASSOC))
                {
                    echo $row['name'];
                    echo "<br>";
                    echo "\n";
                }
            }
        }
        else
        {
            echo $result;
        }

        $link->close();
    }
}

?>