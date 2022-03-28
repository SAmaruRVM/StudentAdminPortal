using System;
using System.Collections.Generic;

namespace StudentAdminPortal.RestfulAPI.Models
{
    public class Student
    {
        public Guid Id{ get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string AvatarURL { get; set; } = string.Empty;
        public Guid GenderId { get; set; }
        public Gender Gender { get; set; } = new();
        public ICollection<Address> Addresses { get; init; } = new List<Address>();
    }
}
