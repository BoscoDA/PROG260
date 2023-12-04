using System.Net;
using System;
using CommandLine;
using Week8WebAPIInterface.Options;

namespace Week8WebAPIInterface
{
    internal class Program
    {
        static void Main()
        {
            string input = "help";

            string[] args = input.Split(' ');

            while(input.ToLower() != "exit")
            {
                int success = Parser.Default.ParseArguments<AddOptions, RemoveOptions, PrintOptions>(args)
                .MapResult(
                (AddOptions opts) => AddFruit(opts),
                (RemoveOptions opts) => RemoveFruit(opts),
                (PrintOptions opts) => PrintFruit(opts),
                errs => 0);

                if(input.ToLower() != "help")
                {
                    if (success == 1)
                    {
                        Console.WriteLine("\nSuccess!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nFailed!\n");
                    }
                }

                input = Console.ReadLine().Trim();

                args = input.Split(' ');
            }
            
            //Arguments: Print all elements in db, add new item to db, remove item from db, help, exit
            //CallUrl("http://ec2-3-17-29-162.us-east-2.compute.amazonaws.com/index.php?add-fruit=banana");
        }

        static string CallUrl(string url)
        {
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need  
            return urlText.ToString();
        }

        static int AddFruit(AddOptions opts)
        {
            string url = $"http://ec2-3-17-29-162.us-east-2.compute.amazonaws.com/index.php?add-fruit={opts.Fruit_Name}";
            string response = CallUrl(url);

            return response == "1" ? 1 : 0;
        }

        static int RemoveFruit(RemoveOptions opts)
        {
            string url = $"http://ec2-3-17-29-162.us-east-2.compute.amazonaws.com/index.php?remove-fruit={opts.Fruit_Name}";
            string response = CallUrl(url);

            return response == "1" ? 1 : 0;
        }

        static int PrintFruit(PrintOptions opts)
        {
            string url = $"http://ec2-3-17-29-162.us-east-2.compute.amazonaws.com/index.php?print-fruit";
            string response = CallUrl(url);

            if(response != "0")
            {
                Console.Write($"\n{response}");
            }

            return response == "0" ? 0 : 1;
        }
    }
}