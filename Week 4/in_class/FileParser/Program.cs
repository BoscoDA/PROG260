namespace FileParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory() + @"\Files\Demo.txt";

            using(StreamReader sr = new StreamReader(path)) 
            {
                var line = sr.ReadLine();

                while(line != null)
                {
                    var stat = line.Split('|');

                    foreach(var item in stat)
                    {
                        Console.Write(item + " ");
                    }

                    line = sr.ReadLine();
                }
            }
        }
    }
}