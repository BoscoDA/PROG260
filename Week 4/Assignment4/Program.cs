namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = @".\File\";
            Parser parser = new Parser();
            
            parser.ParseFiles(dir);
            
            Console.ReadKey();
        }
    }
}