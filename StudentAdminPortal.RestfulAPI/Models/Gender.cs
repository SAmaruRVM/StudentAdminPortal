using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentAdminPortal.RestfulAPI.Models
{
    public class Gender
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Student> Students { get; init; } = new List<Student>(); 
    }
}
