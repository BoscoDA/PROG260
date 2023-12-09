using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataDesignWebAPIClient
{
    public class Response
    {
        [JsonPropertyName("success")]
        public bool success {get; set;}
        [JsonPropertyName("serverTime")]
        public DateTime serverTime { get; set;}
        [JsonPropertyName("fruit")]
        public List<string> fruit { get; set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Success: {success}\n\n");
            sb.Append($"Date: {serverTime}\n\n");

            if(fruit != null)
            {
                sb.Append("Fruit: ");
                foreach (string s in fruit)
                {
                    sb.Append($"{s}, ");
                }
            }

            return sb.ToString();
        }
    }
}
