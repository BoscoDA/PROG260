using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment5.Entities.JSON
{
    internal class PhoneNumber
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("CanContact")]
        public bool CanContact { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}{Environment.NewLine}Number: {Number}{Environment.NewLine}Can Contact: {CanContact}";
        }
    }
}
