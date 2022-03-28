using AutoMapper;
using StudentAdminPortal.RestfulAPI.DTOs;
using StudentAdminPortal.RestfulAPI.Models;

namespace StudentAdminPortal.RestfulAPI.Profiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
