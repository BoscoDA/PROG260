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
        public Address? Address1 { get; set; }
        [JsonPropertyName("address2")]
        public Address? Address2 { get; set; }
        [JsonPropertyName("phoneNumbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FIrstName} {LastName} {Environment.NewLine}Is Enrolled: {IsEnrolled}{Environment.NewLine}Years Enrolled: {YearsEnrolled}");

            if (Address1 != null) 
            {
                sb.Append($"{Environment.NewLine}Address 1: {Address1.ToString()}");
            }
            if (Address2 != null) 
            {
                sb.Append($"{Environment.NewLine}Address 2: {Address2.ToString()}");
            }

            int phoneIndex = 1;
            foreach(var pn in PhoneNumbers)
            {
                sb.Append($"{Environment.NewLine}Phone #{phoneIndex}: {Environment.NewLine}{pn.ToString()}");
                phoneIndex++;
            }
            sb.Append($"{Environment.NewLine}");
            return sb.ToString();
        }
    }
}
