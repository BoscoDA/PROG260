namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Consent is sealed class
            //Parser has a engine -> engine processes the files
            //file, delim, extension
            //engine
            //FilesToProcess
            //Errors
            //Start()
            //  loop through all and see if it ends with constant files extension and make file objects | add error if the file type is no supported
            //  loop thorugh filestoprocess and call the engine to parse the file
            string dir = @".\Files\";
            Parser parser = new Parser();
            parser.ParseFiles(dir);

            Console.ReadKey();
        }
    }
}