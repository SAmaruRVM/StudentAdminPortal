using System.Collections.Generic;
using System;

namespace StudentAdminPortal.RestfulAPI.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string AvatarURL { get; set; } = string.Empty;
        public GenderDTO Gender { get; set; } = new();
        public ICollection<AddressDTO> Addresses { get; init; } = new List<AddressDTO>();
    }
}
