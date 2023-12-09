using CommandLine;
using DataDesignWebAPIClient.Options;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading.Tasks.Sources;

namespace DataDesignWebAPIClient
{
    internal class Program
    {
        static async Task Main()
        {
            APITest test = new APITest("http://ec2-3-17-29-162.us-east-2.compute.amazonaws.com/index.php");

            await test.RunAddFruitTestAsync("Lemon");

            await test.RunRemoveFruitTestAsync("Granola");

            var result = await test.RunGetFruitTestAsync();
            var json = await result.Content.ReadAsStringAsync();
            Console.WriteLine(JsonSerializer.Deserialize<Response>(json));

            Console.WriteLine("Done!");

            Console.ReadKey();
        }
    }
}