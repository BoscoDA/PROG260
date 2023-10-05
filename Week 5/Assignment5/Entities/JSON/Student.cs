using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment5.Entities.JSON
{
    internal class Student
    {
        [JsonPropertyName("firstName")]
        public string FIrstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("isEnrolled")]
        public bool IsEnrolled { get; set; }
        [JsonPropertyName("YearsEnrolled")]
        public int YearsEnrolled { get; set; }
        [JsonPropertyName("address1")]
        public PhoneNumber Address1 { get; set; }
        [JsonPropertyName("address2")]
        public PhoneNumber Address2 { get; set; }
        [JsonPropertyName("phoneNumbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        public override string ToString()
        {
            return $"{FIrstName} {LastName}";
        }
    }
}
