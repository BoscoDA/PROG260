namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
            List<string> files = Directory.GetFiles(dir).Where(x => !x.Contains("_out")).ToList();
            List<IDelimiterFile> toParse = new List<IDelimiterFile>();

            foreach (var file in files)
            {
                if (file.EndsWith(".txt"))
                {
                    MyFile tempFile = new MyFile(file, '|', ".txt");
                    toParse.Add(tempFile);
                }
                else if (file.EndsWith(".csv"))
                {
                    MyFile tempFile = new MyFile(file, ',', ".csv");
                    toParse.Add(tempFile);
                }
            }

            foreach (var file in toParse)
            {
                using (StreamReader sr = new StreamReader(file.Path))
                {
                    var line = sr.ReadLine();
                    var lineCount = 0;
                    while (line != null)
                    {
                        lineCount++;
                        Console.Write($"Line #{lineCount} :");
                        var fields = line.Split(file.Delimiter);
                        var fieldCount = 0;
                        foreach (var field in fields)
                        {
                            fieldCount++;
                            Console.Write($"Field #{fieldCount} = {field}");
                            var test = fields.Count();
                            if (fieldCount - 1 < fields.Count() - 1)
                            {

                                Console.Write(" ==> ");
                            }
                            else
                            {
                                Console.Write($"{Environment.NewLine}");
                            }
                        }

                        line = sr.ReadLine();
                    }
                }
            }
        }
    }
}