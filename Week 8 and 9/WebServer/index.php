<?php

    require "func.php";
    $helper = new Helper();

    if(isset($_REQUEST['add-fruit']))
    {
        $fruit = $_REQUEST['add-fruit'];
        $helper->AddFruit($fruit);
    }

    if(isset($_REQUEST['remove-fruit']))
    {
        $fruit = $_REQUEST['remove-fruit'];
        $helper->RemoveFruit($fruit);
    }

    if(isset($_REQUEST['print-fruit']))
    {
        $fruit = $_REQUEST['print-fruit'];
        $helper->PrintFruit($fruit);
    }

?>