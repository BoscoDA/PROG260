﻿namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = @".\Files\";
            Parser parser = new Parser();

            parser.ParseFiles(dir);

            Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey();
        }
    }
}