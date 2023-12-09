<?php
date_default_timezone_set('Etc/UTC');
class DailyFruit
{
    public $date;
    public $total;

    function set_date($date)
    {
        $this->date = $date;
    }

    function get_date()
    {
        return $this->date;
    }

    function set_total($total)
    {
        $this->total = $total;
    }

    function get_total()
    {
        return $this->total;
    }
}

class Helper
{

    public function AddFruit($fruit)
    {
        require 'conn.php';

        $query = "INSERT INTO fruit(name) VALUES('".$fruit."') ";
        $result = mysqli_query($link,$query);

        $link->close();

        return $result;
    }

    public function RemoveFruit($fruit)
    {
        require 'conn.php';
        
        $query = "DELETE FROM fruit WHERE name = '".$fruit."' ";
        $result = mysqli_query($link,$query);

        $link->close();

        return $result;
    }

    public function PrintFruit()
    {
        require 'conn.php';
        
        $query = "SELECT * FROM fruit";
        $result = mysqli_query($link,$query);

        $link->close();

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
            return $result;
        }
    }

    public function GetFruit()
    {
        require 'conn.php';
        
        $fruitArr = Array();

        $query = "SELECT * FROM fruit";

        if($result = mysqli_query($link,$query))
        {
            if($result->num_rows>0)
            {
                while($row = $result->fetch_array(MYSQLI_ASSOC))
                {
                    array_push($fruitArr, $row['name']);
                }
            }
        }
        else
        {
            array_push($fruitArr, 'FAIL');
        }

        $link->close();

        return $fruitArr;
    }

    public function ProcessFruit()
    {
        //total pruchased fruit today
        require 'conn.php';
        
        $fruitArr = Array();

        $query = "SELECT * FROM fruit";

        if($result = mysqli_query($link,$query))
        {
            if($result->num_rows>0)
            {
                while($row = $result->fetch_array(MYSQLI_ASSOC))
                {
                    array_push($fruitArr, $row['name']);
                }
            }

            $count = sizeof($fruitArr);

            $query = "INSERT INTO fruit_daily_result(total) VALUES('".$count."') ";
            mysqli_query($link,$query);
        }

        $link->close();
    }

    public function GetDaily()
    {
        require 'conn.php';
        
        $fruitArr = Array();

        $query = "SELECT * FROM fruit_daily_result";

        if($result = mysqli_query($link,$query))
        {
            if($result->num_rows>0)
            {
                while($row = $result->fetch_array(MYSQLI_ASSOC))
                {
                    $temp = new DailyFruit();
                    $date = date('Y-m-d\TH:i:s', strtotime($row['date']));
                    $temp->set_date($date);
                    $temp->set_total($row['total']);
                    array_push($fruitArr, $temp);
                }
            }
        }
        else
        {
            array_push($fruitArr, 'FAIL');
        }

        $link->close();

        return $fruitArr;
    }
}



?>