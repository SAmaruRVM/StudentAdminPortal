using System;

namespace StudentAdminPortal.RestfulAPI.DTOs
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; } = string.Empty;
        public string PostalAddress { get; set; } = string.Empty;
    }
}
