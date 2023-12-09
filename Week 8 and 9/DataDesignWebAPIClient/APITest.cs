using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Net;

namespace DataDesignWebAPIClient
{
    public class APITest
    {
        private string url;
        static readonly HttpClient client = new HttpClient();

        public APITest(string url) 
        {
            this.url = url;
        }

        public async Task<HttpResponseMessage> RunAddFruitTestAsync(string fruit)
        {
            var values = new Dictionary<string, string>
            {
                {"add-fruit", fruit }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url, content);

            return response;

        }

        public async Task<HttpResponseMessage> RunRemoveFruitTestAsync(string fruit)
        {
            var values = new Dictionary<string, string>
            {
                {"remove-fruit", fruit }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url, content);

            return response;

        }

        public async Task<HttpResponseMessage> RunGetFruitTestAsync()
        {
            var response = await client.GetAsync(url);

            return response;
        }
    }
}
