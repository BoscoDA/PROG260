using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Week9RestApiInterface
{
    public class DailyResponse
    {
        [JsonPropertyName("success")]
        public bool success { get; set; }
        [JsonPropertyName("serverTime")]
        public DateTime serverTime { get; set; }
        [JsonPropertyName("dailys")]
        public List<Daily> dailys { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Success: {success}{Environment.NewLine}");
            sb.Append($"Date: {serverTime}{Environment.NewLine}");

            if (dailys != null)
            {
                sb.Append("Dailys: ");
                foreach (Daily d in dailys)
                {
                    sb.Append($"Total: {d.Total}, TimeStamp: {d.Date}{Environment.NewLine}");
                }
            }

            sb.Append($"{Environment.NewLine}");
            return sb.ToString();
        }
    }
}
