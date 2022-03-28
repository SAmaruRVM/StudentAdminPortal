using System;
using System.Text.Json.Serialization;

namespace StudentAdminPortal.RestfulAPI.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; } = string.Empty;
        public string PostalAddress { get; set; } = string.Empty;
        public Guid StudentId { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
    }
}
