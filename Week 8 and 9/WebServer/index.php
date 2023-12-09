<?php
    require "func.php";
    $helper = new Helper();
    date_default_timezone_set('Etc/UTC');
    $gmdate = date('Y-m-d\TH:i:s', time());
    $returnValue = array("success" => false, "serverTime" => stripslashes($gmdate));


    if(isset($_REQUEST['add-fruit']))
    {
        $fruit = $_REQUEST['add-fruit'];
        $result = $helper->AddFruit($fruit);
        $returnValue['success'] = $result;

        echo json_encode($returnValue);
    }

    else if(isset($_REQUEST['remove-fruit']))
    {
        $fruit = $_REQUEST['remove-fruit'];
        $helper->RemoveFruit($fruit);
        echo json_encode($returnValue);
    }

    else if(isset($_REQUEST['print-fruit']))
    {
        $fruit = $_REQUEST['print-fruit'];
        $helper->PrintFruit($fruit);
        echo json_encode($returnValue);
    }

    else if(isset($_REQUEST['process-fruit']))
    {
        $fruit = $_REQUEST['process-fruit'];
        $helper->ProcessFruit($fruit);
    }

    else if(isset($_REQUEST['get-daily']))
    {
        $fruit = $_REQUEST['get-daily'];
        $result = $helper->GetDaily($fruit);
        
        $returnValue['dailys'] = $result;
        $returnValue['success'] = TRUE;

        echo json_encode($returnValue);

    }

    else if($_SERVER["REQUEST_METHOD"] == "POST")
    {
        if(isset($_POST['add-fruit']))
        {
            $fruit = $_POST['add-fruit'];
            $result = $helper->AddFruit($fruit);
            $returnValue['success'] = $result;
            echo json_encode($returnValue);
        }

        if(isset($_POST['remove-fruit']))
        {
            $fruit = $_POST['remove-fruit'];
            $result = $helper->RemoveFruit($fruit);
            $returnValue['success'] = $result;
            echo json_encode($returnValue);
        }
    }

    else if($_SERVER["REQUEST_METHOD"] == "GET")
    {

        $result = $helper->GetFruit();

        if($result[0] == 'FAIL')
        {
            $returnValue['success'] = FALSE;
            $returnValue['fruit'] = NULL;
        }

        else
        {
            $returnValue['fruit'] = $result;
            $returnValue['success'] = true;
        }

        
        echo json_encode($returnValue);
    }

    else{
        $returnValue['success'] = FALSE;
        $returnValue['fruit'] = NULL;

        echo json_encode($returnValue);
    }

?>